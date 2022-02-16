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
using ProfMon.Objects.Inventory;
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

        private int _activeMonsters;

        private List<CombatTeam> _teams;

        private int _nextTeamID;

        private List<Order> _orderQueue;
        public List<Round> RoundHistory { get; }

        public IDictionary<Ability, ICombatTriggerHandler> AbilityHandlers { get; }
        public IDictionary<Move, ICombatTriggerHandler> MoveHandlers { get; }
        public IDictionary<Item, ICombatTriggerHandler> ItemHandlers { get; }
        public IDictionary<ID, ICombatTriggerHandler> OrderHandlers { get; }

        public CombatState (int monstersActive,
                            IDictionary<Ability, ICombatTriggerHandler> abilityHandlers,
                            IDictionary<Move, ICombatTriggerHandler> moveHandlers,
                            IDictionary<Item, ICombatTriggerHandler> itemHandlers,
                            IDictionary<ID, ICombatTriggerHandler> orderHandlers) {
            _activeMonsters = monstersActive;
            _teams = new List<CombatTeam> ();

            _orderQueue = new List<Order> ();
            RoundHistory = new List<Round> ();

            AbilityHandlers = abilityHandlers;
            MoveHandlers = moveHandlers;
            ItemHandlers = itemHandlers;
            OrderHandlers = orderHandlers;
        }

        public void AddTeam (List<ISpeciesInstance> team) {
            _teams.Add (new CombatTeam (_nextTeamID, _activeMonsters, team));
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

        public void BeginRound () {
            _currentRoundID++;
            _currentRound = new Round (_currentRoundID);

            ProcessRoundEvent (CombatEventTypes.StartOfRound);
        }

        public void EndRound () {
            ProcessRoundEvent (CombatEventTypes.EndOfRound);

            RoundHistory.Add (_currentRound);
        }

        private void ProcessRoundEvent(CombatEventTypes eventType) {
            var roundEvent = new CombatEvent (eventType, null);

            _currentRound.Events.Add (roundEvent);

            foreach (var team in _teams) {
                var events = team.ProcessEvent (roundEvent, this);

                _currentRound.Events.AddRange (events);
            }
        }
    }
}
