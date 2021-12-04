﻿#region copyright
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
using ProfMon.Monster.MonsterSpecies;
using System.Collections.Generic;

namespace ProfMon.Monster.Storage {
    public class StorageUnit : NamedProfObj {
        private ISpeciesInstance [] _monsters;
        public IReadOnlyList<ISpeciesInstance> Monsters => _monsters;

        public int Size => _monsters.Length;

        public StorageUnit (ID id, string name, int size) : this (id, name) {
            _monsters = new ISpeciesInstance [size];
        }

        public StorageUnit (ID id, string name, ISpeciesInstance [] monsters) : this (id, name) {
            _monsters = monsters;
        }

        private StorageUnit (ID id, string name) : base (id, name) { }

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
    }
}
