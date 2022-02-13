#region copyright
/** Raven Bot, a light-weight Discord bot using DSharp+ for gateway and command handling.
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
using ProfMon.Base.ProfObj;
using System.Collections.Generic;
using System.Linq;

namespace ProfMon.Objects.Inventory {
    public class TrainerInventory : ProfObject {
        private Dictionary<ItemCatagory, List<ItemStack>> _items;
        public IReadOnlyDictionary<ItemCatagory, List<ItemStack>> Items => _items;

        public TrainerInventory (ID id, Dictionary<ItemCatagory, List<ItemStack>> items) : base (id) {
            _items = items;
        }

        public TrainerInventory (ID id, List<ItemCatagory> catagories) : base (id) {
            _items = new Dictionary<ItemCatagory, List<ItemStack>> ();

            foreach (var catagory in catagories) {
                _items.Add (catagory, new List<ItemStack> ());
            }
        }

        public void Add (Item item, int count) {
            if (_items.ContainsKey (item.Catagory)) {
                var stack = _items [item.Catagory].FirstOrDefault (itemStack => itemStack.Item == item);

                if (stack != null) {
                    stack.IncreaseStack (count);
                }
            }
        }

        public void Remove (Item item, int count) {
            if (_items.ContainsKey (item.Catagory)) {
                var stack = _items [item.Catagory].FirstOrDefault (itemStack => itemStack.Item == item);

                if (stack != null) {
                    stack.DecreaseStack (count);

                    if (stack.Count == 0) {
                        _items [item.Catagory].Remove (stack);
                    }
                }
            }
        }
    }
}
