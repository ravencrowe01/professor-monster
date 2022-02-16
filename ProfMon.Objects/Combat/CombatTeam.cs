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
    public class CombatTeam {
        public int Id { get; }

        private List<CombatMonster> _monsters;

        private List<StatusInstance> _statuses;
        public IReadOnlyList<StatusInstance> Statuses => _statuses;

        private int _activeMemebers;

        public CombatTeam (int id, int activeMembers, List<ISpeciesInstance> team) {
            Id = id;
            _activeMemebers = activeMembers;
            BuildTeam (team);
            _statuses = new List<StatusInstance> ();
        }

        private void BuildTeam (List<ISpeciesInstance> team) {
            _monsters = new List<CombatMonster> ();

            for (int i = 0; i < team.Count; i++) {
                _monsters.Add (new CombatMonster (i + 1, team[i]));
            }
        }

        public CombatMonster GetMonster (int slot) {
            return _monsters.Where (monster => monster.Slot == slot).FirstOrDefault() ;
        }

        public IEnumerable<CombatMonster> GetActiveMembers () {
            var members = new List<CombatMonster> ();

            for (int i = 1; i < _activeMemebers; i++) {
                members.Add (GetMonster (i));
            }

            return members;
        }

        public void AddTeamStatus (Status status) {
            _statuses.Add (new StatusInstance (status));
        }

        public void RemoveTeamStatus (Status status) {
            var found = _statuses.Where (s => s.Status == status).FirstOrDefault ();

            if (found != null) {
                _statuses.Remove (found);
            }
        }

        public IEnumerable<CombatEvent> BeginRound (CombatState combat, IHandlerCollection<Ability, CombatEvent> handlers) {
            var events = new List<CombatEvent> ();

            for (int i = 0; i < _activeMemebers; i++) {
                var member = GetMonster (i + 1);

                if (member.Ability.CombatFlags.HasFlag(CombatEventFlag.StartOfRound)) {
                    events.Add (handlers.GetHandler (member.Ability).Handle(combat));
                }
            }

            return events;
        }

        public IEnumerable<CombatEvent> EndRound (CombatState combat, IHandlerCollection<Ability, CombatEvent> handlers) {
            var events = new List<CombatEvent> ();

            for (int i = 0; i < _activeMemebers; i++) {
                var member = GetMonster (i + 1);

                if (member.Ability.CombatFlags.HasFlag (CombatEventFlag.EndOfRound)) {
                    events.Add (handlers.GetHandler (member.Ability).Handle (combat));
                }
            }

            return events;
        }
    }
}
