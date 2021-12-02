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
using ProfMon.Inventory.Catagories;

namespace ProfMon.Inventory.Items {
    public class ItemBuilder : BaseBuilder<ItemBuilder, Item> {
        private ItemCatagory _catagory;

        private float _sellValue;
        private float _buyValue;

        private bool _sellable;

        private bool _stackable;
        private int _maxStack;

        public ItemBuilder WithCatagory (ItemCatagory catagory) {
            _catagory = catagory;
            return this;
        }

        public ItemBuilder WithSellValue (float sellValue) {
            _sellValue = sellValue;
            return this;
        }

        public ItemBuilder WithBuyValue (float buyValue) {
            _buyValue = buyValue;
            return this;
        }

        public ItemBuilder IsSellable (bool selllable) {
            _sellable = selllable;
            return this;
        }

        public ItemBuilder IsStackable (bool stackable) {
            _stackable = stackable;
            return this;
        }

        public ItemBuilder WithMaxStacks (int maxStack) {
            _maxStack = maxStack;
            return this;
        }

        public override Item Build () {
            return new Item (new ItemConfig () {
                ID = _id,
                Name = _name,
                Description = _description,
                Catagory = _catagory,
                SellValue = _sellValue,
                BuyValue = _buyValue,
                Sellable = _sellable,
                Stackable = _stackable,
                MaxStack = _maxStack
            });
        }
    }
}
