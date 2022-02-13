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
using ProfMon.Objects.Instances;
using System.Collections.Generic;
using System.Linq;

namespace ProfMon.Objects.MonStorage {
    public class StorageUnit : NamedProfObject {
        private List<ISpeciesInstance> _monsters;
        public IReadOnlyList<ISpeciesInstance> Monsters => _monsters;

        public int Size { get; private set; }

        public StorageUnit (Config config, int size) : this (config) {
            Size = size;
            _monsters = new List<ISpeciesInstance> (Size);
        }

        public StorageUnit (Config config, List<ISpeciesInstance> monsters) : this (config) {
            Size = monsters.Count;
            _monsters = monsters;
        }

        private StorageUnit (Config config) : base (config) { }

        public ISpeciesInstance RemoveMonster (int slot) {
            var temp = _monsters [slot];
            _monsters [slot] = null;
            return temp;
        }

        public bool CanAddMonster () {
            for (int i = 0; i < Size; i++) {
                if (_monsters [i] == null) {
                    return true;
                }
            }

            return false;
        }

        public void AddMonster (ISpeciesInstance monster) {
            var slot = 0;

            while (slot < Size && _monsters [slot] != null) {
                slot++;
            }

            if (slot < Size) {
                AddMonster (monster, slot);
            }
        }

        public void AddMonster (ISpeciesInstance monster, int slot) {
            _monsters [slot] = monster;
        }

        public void SwitchMonsters (int from, int to) {
            var temp = _monsters [from];
            _monsters [from] = _monsters [to];
            _monsters [to] = temp;
        }

        public int GetEmptySlots () {
            return _monsters.Where (m => m == null).Count ();
        }
    }
}
