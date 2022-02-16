#region copyright
/** Professor Monster, a library for creating monster collection style games.
 *  Copyright (C) 2021 Raven Crowe
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *  
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
#endregion

using ProfMon.Base;
using ProfMon.Objects.Instances;
using System.Collections.Generic;
using System.Linq;

namespace ProfMon.Objects.Combat {
    public class CombatState {
        public struct Round {
            public int ID { get; }
            public List<CombatEvent> Events { get; }

            public Round (int id) {
                ID = id;
                Events = new List<CombatEvent> ();
            }
        }

        private Round _currentRound;

        private int _currentRoundID;

        public Weather Weather { get; }

        public Terrain Terrain { get; }

        private int _activeMemebers;

        private List<CombatTeam> _teams;

        private int _nextTeamID;

        private List<Order> _orderQueue;
        public List<Round> RoundHistory { get; }

        private IHandlerCollection<Ability, CombatEvent> _abilityHandlers;
        private IHandlerCollection<Move, CombatEvent> _moveHandlers;
        private IHandlerCollection<ID, CombatEvent> _orderHandlers;

        public CombatState (int monstersActive,
                            IHandlerCollection<Ability, CombatEvent> abilityHandlers,
                            IHandlerCollection<Move, CombatEvent> moveHandlers,
                            IHandlerCollection<ID, CombatEvent> orderHandlers) {
            _activeMemebers = monstersActive;
            _teams = new List<CombatTeam> ();

            _orderQueue = new List<Order> ();
            RoundHistory = new List<Round> ();

            _abilityHandlers = abilityHandlers;
            _moveHandlers = moveHandlers;
            _orderHandlers = orderHandlers;
        }

        public void AddTeam (List<ISpeciesInstance> team) {
            _teams.Add (new CombatTeam (_nextTeamID, _activeMemebers, team));
            _nextTeamID++;
        }

        private CombatTeam GetTeam (int id) {
            return _teams.Where (team => team.Id == id).First ();
        }

        public CombatMonster GetMonster (int team, int slot) {
            return GetTeam (team).GetMonster (slot);
        }

        public void AddOrder (Order order) {
            _orderQueue.Add (order);
        }

        private void ProcessEvents (IEnumerable<CombatEvent> events) {
            foreach (var evnt in events) {
                ProcessEvent (evnt);
            }
        }

        private void ProcessEvent (CombatEvent evnt) {
            //TODO Process event
        }

        public void BeginRound () {
            _currentRoundID++;
            _currentRound = new Round (_currentRoundID);

            _currentRound.Events.Add (new CombatEvent (CombatEventFlag.StartOfRound));

            foreach (var team in _teams) {
                var events = team.BeginRound (this, _abilityHandlers);

                ProcessEvents (team.BeginRound (this, _abilityHandlers));

                _currentRound.Events.AddRange (events);
            }
        }

        public void EndRound () {
            _currentRound.Events.Add (new CombatEvent (CombatEventFlag.EndOfRound));

            foreach (var team in _teams) {
                var events = team.EndRound (this, _abilityHandlers);

                ProcessEvents (team.EndRound (this, _abilityHandlers));

                _currentRound.Events.AddRange (events);
            }

            RoundHistory.Add (_currentRound);
        }
    }
}
