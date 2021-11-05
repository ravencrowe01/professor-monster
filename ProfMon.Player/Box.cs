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

namespace ProfMon.Player {
    public class Box : NamedProfObj {
        public readonly ID OwnerID;

        public readonly bool Visable;

        public readonly int MaxSlots;

        private BoxSlot[] _slots;
        public IReadOnlyCollection<BoxSlot> Slots => _slots;

        public Box (ID iD,
                   string name,
                   ID ownerID,
                   IEnumerable<BoxSlot> monsters) : this(iD, name, ownerID) {
            _slots = monsters.ToArray();
        }

        public Box (ID iD,
                    string name,
                    ID ownerID,
                    int maxSlots) : this(iD, name, ownerID) {
            MaxSlots = maxSlots;
            _slots = new BoxSlot[MaxSlots];

            for(int i = 0; i < MaxSlots; i++) {
                _slots[i] = new BoxSlot(new ID(ID.Major, (uint) i + 1), this);
            }
        }

        private Box (ID iD,
                    string name,
                    ID ownerID) : base(iD, name) {
            OwnerID = ownerID;
        }

        public PlayerMonster RemoveMonster (int index) {
            var temp = _slots[index].Monster;
            _slots[index].Remove();
            return temp;
        }

        public void AddMonster (PlayerMonster monster) {
            for (int i = 0; i < _slots.Length; i++) {
                if (_slots[i] == null) {
                    AddMonster(monster, i);
                    return;
                }
            }
        }

        public void AddMonster (PlayerMonster monster, int index) {
            _slots[index].Add(monster);
        }

        public void SwitchMonster (int indexA, int indexB) {
            var temp = _slots[indexA].Monster;
            _slots[indexA].Remove();
            _slots[indexA].Add(_slots[indexB].Monster);
            _slots[indexB].Remove();
            _slots[indexB].Add(temp);
        }
    }
}