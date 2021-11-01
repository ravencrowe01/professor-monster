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

namespace ProfMon.Player {
    public class Player : NamedProfObj {

        public float Currency { get; private set; }

        public IList<PlayerMonster> Party { get; private set; }

        public IDictionary<ID, IEnumerable<ItemMetadata>> Inventory { get; private set; }

        public Player (ID iD,
                       string name,
                       float currency,
                       IList<PlayerMonster> party,
                       IDictionary<ID, IEnumerable<ItemMetadata>> inventory) : base(iD, name) {
            Currency = currency;
            Party = party;
            Inventory = inventory;
        }
    }
}