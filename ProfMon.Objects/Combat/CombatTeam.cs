﻿#region copyright
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfMon.Objects.Combat {
    public class CombatTeam {
        public int Id { get; }

        private List<CombatMonster> _monsters;

        private List<StatusInstance> _statuses;
        public IReadOnlyList<StatusInstance> Statuses => _statuses;

        private int _activeMonsters;

        public CombatTeam (int id, int activeMembers, List<ISpeciesInstance> team) {
            Id = id;
            _activeMonsters = activeMembers;
            BuildTeam (team);
            _statuses = new List<StatusInstance> ();
        }

        private void BuildTeam (List<ISpeciesInstance> team) {
            _monsters = new List<CombatMonster> ();

            for (int i = 0; i < team.Count; i++) {
                _monsters.Add (new CombatMonster (this, i + 1, team[i]));
            }
        }

        public CombatMonster GetMonster (int slot) {
            return _monsters.Where (monster => monster.Slot == slot).FirstOrDefault() ;
        }

        public IEnumerable<CombatMonster> GetActiveMonsters () {
            var members = new List<CombatMonster> ();

            for (int i = 1; i < _activeMonsters; i++) {
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

        public IEnumerable<CombatEvent> ProcessEvent (CombatEvent @event, CombatState combat) {
            var events = new List<CombatEvent> ();

            var active = GetActiveMonsters ();

            foreach (var monster in active) {
                events.Add (TriggerAbilityHandler(@event, combat, monster));
                events.Add (TriggerItemHandler(@event, combat, monster));
            }

            return events;
        }

        private static CombatEvent TriggerAbilityHandler (CombatEvent @event, CombatState combat, CombatMonster monster) {
            var ability = monster.Ability;

            var abilityHandler = combat.AbilityHandlers.ContainsKey(ability) ? combat.AbilityHandlers [ability] : null;

            var canTrigger = abilityHandler != null && abilityHandler.CanTrigger (@event, combat, monster);

            return canTrigger ? abilityHandler.Trigger (@event, combat, monster) : null;
        }

        private static CombatEvent TriggerItemHandler(CombatEvent @event, CombatState combat, CombatMonster monster) {
            var item = monster.Item;

            var itemHandler = combat.ItemHandlers.ContainsKey(item) ? combat.ItemHandlers [item] : null;

            var canTrigger = itemHandler != null && itemHandler.CanTrigger (@event, combat, monster);

            return canTrigger ? itemHandler.Trigger (@event, combat, monster) : null;
        }
    }
}