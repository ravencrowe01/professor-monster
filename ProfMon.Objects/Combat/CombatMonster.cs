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

namespace ProfMon.Objects.Combat {
    public class CombatMonster {
        public readonly CombatTeam Team;
        public int Slot { get; private set; }

        private readonly ISpeciesInstance _monster;
        public IReadOnlySpeciesInstance Monster => _monster;

        private ISpeciesInstance _form;
        public IReadOnlySpeciesInstance CurrentForm => _form;

        private Stats _stats;
        public ReadonlyStats Stats => _stats;

        private Item _item;
        public Item Item => _item ?? _monster.HeldItem;

        private Ability _ability;
        public Ability Ability => _ability ?? _monster.Ability;

        private Element _element;
        public Element PrimaryElement => _element ?? _monster.Species.PrimaryElement;
        public Element SecondaryElement => _element == null ? _monster.Species.SecondaryElement : null;

        public CombatMonster (CombatTeam team, int slot, ISpeciesInstance monster) {
            Team = team;
            Slot = slot;
            _monster = monster;
            _stats = new Stats ();
        }

        public void ApplyEvent (ICombatCalculator calculator, CombatEvent @event) {
            var hpDelta = @event.Damage.CalculcateHPDelta (calculator);

            if (hpDelta < 0) {
                _monster.Damage (hpDelta);
            }

            if (hpDelta > 0) {
                _monster.Heal (hpDelta);
            }

            _stats += @event.StatChanges;

            @event.StatusesApplied.ForEach (status => _monster.AddStatus (new StatusInstance (status)));
            @event.StatusesRemoved.ForEach (status => _monster.RemoveStatus (status));

            if (@event.NewItem != null) {
                _item = @event.NewItem;
            }

            if (@event.NewAbility != null) {
                _ability = @event.NewAbility;
            }

            if (@event.NewElement != null) {
                _element = @event.NewElement;
            }

            if (@event.FormApplied != null) {
                _form = @event.FormApplied;
            }
        }

        public CombatEvent TriggerAbilityHandler (CombatEvent @event, CombatState combat) => TriggerEventHandler (@event, combat, this, combat.AbilityHandlers, Ability);

        public CombatEvent TriggerItemHandler (CombatEvent @event, CombatState combat) => TriggerEventHandler (@event, combat, this, combat.ItemHandlers, Item);

        public List<CombatEvent> TriggerStatusHandlers (CombatEvent @event, CombatState combat) {
            var events = new List<CombatEvent> ();

            foreach (var status in _monster.CurrentStatuses) {
                var evnt = TriggerEventHandler (@event, combat, this, combat.StatusHandlers, status.Status);

                if (evnt != null) {
                    events.Add (evnt);
                }
            }

            return events;
        }

        private static CombatEvent TriggerEventHandler<T> (CombatEvent @event, CombatState combat, CombatMonster monster, IDictionary<T, ICombatTriggerHandler> handlers, T key) {
            var handler = handlers.ContainsKey (key) ? handlers [key] : null;

            var canTrigger = handler != null && handler.CanTrigger (@event, combat, monster);

            return canTrigger ? handler.Trigger (@event, combat, monster) : null;
        }
    }
}
