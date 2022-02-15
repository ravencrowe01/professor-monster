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

namespace ProfMon.Objects.Combat {
    public class CombatMonster {
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

        public CombatMonster (int slot, ISpeciesInstance monster) {
            Slot = slot;
            _monster = monster;
            _stats = new Stats ();
        }

        public void ApplyAction (ICombatCalculator calculator, CombatEvent action) {
            var dmg = action.Damage.CalculcateHPModifier (calculator);

            if (dmg > 0) {
                _monster.Damage (dmg);
            }

            _stats += action.StatChanges;

            action.StatusesApplied.ForEach (status => _monster.AddStatus (new StatusInstance (status)));
            action.StatusesRemoved.ForEach (status => _monster.RemoveStatus (status));

            if (action.RemovedItem) {
                _item = null;
            }

            if (action.NewItem != null) {
                _item = action.NewItem;
            }

            if (action.NewAbility != null) {
                _ability = action.NewAbility;
            }

            if (action.NewElement != null) {
                _element = action.NewElement;
            }

            if (action.FormApplied != null) {
                _form = action.FormApplied;
            }
        }
    }
}
