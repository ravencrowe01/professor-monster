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
        public int Turn { get; }

        public Weather Weather { get; }

        public Terrain Terrain { get; }

        private int _monstersActive;

        private List<CombatTeam> _teams;

        private int _nextTeamID;

        private List<Order> _orderQueue;
        private List<CombatEvent> _actionQueue;

        private IHandlerCollection<Ability> _abilityHandlers;
        private IHandlerCollection<Move> _moveHandlers;
        private IHandlerCollection<ID> _orderHandlers;

        public CombatState (int monstersActive,
                            IHandlerCollection<Ability> abilityHandlers,
                            IHandlerCollection<Move> moveHandlers,
                            IHandlerCollection<ID> orderHandlers) {
            _monstersActive = monstersActive;
            _teams = new List<CombatTeam> ();

            _orderQueue = new List<Order> ();
            _actionQueue = new List<CombatEvent> ();

            _abilityHandlers = abilityHandlers;
            _moveHandlers = moveHandlers;
            _orderHandlers = orderHandlers;
        }

        public void AddTeam (List<ISpeciesInstance> team) {
            _teams.Add (new CombatTeam (team, _nextTeamID));
            _nextTeamID++;
        }

        private CombatTeam GetTeam (int id) {
            return _teams.Where (team => team.Id == id).First ();
        }

        public CombatMonster GetMonster (int team, int slot) {
            return GetTeam (team).GetMonster (slot);
        }

        public void AddOrder(Order order) {
            _orderQueue.Add (order);
        }

        public void BeginRound() {

        }
    }
}
