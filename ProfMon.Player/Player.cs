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

using System.Collections.Generic;
using ProfMon.Base;
using ProfMon.Base.Config;
using ProfMon.Base.ProfObj;

namespace ProfMon.Player {
    public class Player : NamedProfObj {
        public int PlayerID { get; private set; }

        public float Currency { get; private set; }

        public IReadOnlyCollection<PlayerMonster> Party { get; protected set; }

        public IReadOnlyDictionary<ID, IReadOnlyCollection<ItemMetadata>> Inventory { get; private set; }

        public Player(Config config) : base(config) {
            PlayerID = config.PlayerID;

            Currency = config.Currency;

            Party = config.Party;

            Inventory = (IReadOnlyDictionary<ID, IReadOnlyCollection<ItemMetadata>>) config.Inventory;
        }

        public class Config : NamedConfig {
            public int PlayerID { get; set; }

            public float Currency { get; set; }

            public List<PlayerMonster> Party { get; set; }

            public Dictionary<ID, IList<ItemMetadata>> Inventory { get; set; }
        }
    }
}