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
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfMon.Player {
    public class Player : NamedProfObj {
        public object PlayerLock = new ();
        public float Currency { get; private set; }

        private Dictionary<ID, IList<ItemMetadata>> _inventory;
        public IReadOnlyDictionary<ID, IReadOnlyList<ItemMetadata>> Inventory => (IReadOnlyDictionary<ID, IReadOnlyList<ItemMetadata>>) _inventory;

        private PlayerMonster [] _party;
        public IReadOnlyList<PlayerMonster> Party => _party;

        private Box [] _monsterStorage;
        public IReadOnlyList<Box> MonsterStorage => _monsterStorage;

        public Player () : base (null, null) { }

        public Player (ID iD,
                      string name,
                      float currency,
                      IDictionary<ID, IList<ItemMetadata>> inventory,
                      IList<PlayerMonster> party,
                      IList<Box> monsterStorage) : this (iD, name, currency, inventory, party) {
            _monsterStorage = monsterStorage.ToArray ();
        }

        public Player (ID iD,
                      string name,
                      float currency,
                      IDictionary<ID, IList<ItemMetadata>> inventory,
                      int partySize,
                      int monsterStorageSize,
                      int boxSize) : this (iD, name, currency, inventory, partySize) {
            _monsterStorage = GenerateInitialStorage ();

            Box [] GenerateInitialStorage () {
                var boxes = new Box [monsterStorageSize];

                for (int i = 0; i < monsterStorageSize; i++) {
                    boxes [i] = new Box (null, $"Box {i + 1}", ID, boxSize);
                }

                return boxes;
            }
        }

        private Player (ID iD,
                       string name,
                       float currency,
                       IDictionary<ID, IList<ItemMetadata>> inventory,
                       IList<PlayerMonster> party) : this (iD, name, currency, inventory) {
            _party = party.ToArray ();
        }

        private Player (ID iD,
                       string name,
                       float currency,
                       IDictionary<ID, IList<ItemMetadata>> inventory,
                       int partySize) : this (iD, name, currency, inventory) {
            _party = new PlayerMonster [partySize];
        }

        private Player (ID iD,
                       string name,
                       float currency,
                       IDictionary<ID, IList<ItemMetadata>> inventory) : this (iD, name, currency) {
            _inventory = (Dictionary<ID, IList<ItemMetadata>>) (inventory?.Count > 0 ? inventory : new Dictionary<ID, IList<ItemMetadata>> ());
        }

        private Player (ID iD,
                       string name,
                       float currency) : base (iD, name) {
            Currency = currency;
        }

        public void ModifyCurrency (int delta) {
            Currency += delta;
        }

        public void AddItem (ID itemCatagory, ItemMetadata item) {
            if (!_inventory.Keys.Contains (itemCatagory)) {
                _inventory.Add (ID, new List<ItemMetadata> ());
            }

            _inventory [ID].Add (item);
        }

        public void ModifyItemCount (ID itemCatagory, ID itemID, int count) {
            var itemStack = _inventory [itemCatagory].First (i => i.ID == itemID);

            _inventory [ID].First (i => i.ID == itemID).ModifyStack (count);

            if (itemStack.Stack == 0) {
                _inventory [ID].Remove (itemStack);
            }
        }

        public PlayerMonster RemovePartyMember (int position) {
            if (_party [position] != null) {
                throw new Exception ("Tried to remove a party member from an empty position");
            }
            if (_party [1] != null) {
                throw new Exception ("Tried to remove a party member while party only has one member");
            }

            var temp = _party [position];
            _party [position] = null;

            ShiftMemebers ();

            return temp;

            void ShiftMemebers () {
                var lastNull = _party.Length;
                for (int i = 1; i < _party.Length; i++) {
                    if (_party [i] == null) {
                        lastNull = i;
                    }

                    if (_party [i] != null) {
                        _party [lastNull] = _party [i];
                        _party [i] = null;
                        lastNull = i;
                    }
                }
            }
        }

        public void AddPartyMember (PlayerMonster member) {
            var emptyPos = _party.Length + 1;

            for (int i = 1; i < _party.Length; i++) {
                if (_party [i] == null) {
                    emptyPos = i;
                    break;
                }
            }

            if (emptyPos > _party.Length) {
                throw new IndexOutOfRangeException ("Tried to add a party member to a full team");
            }

            AddPartyMember (member, emptyPos);
        }

        public void AddPartyMember (PlayerMonster member, int position) {
            if (_party [position] == null) {
                _party [position] = member;
            }
            else {
                throw new Exception ("A party member already exists at position designated position");
            }
        }
    }
}