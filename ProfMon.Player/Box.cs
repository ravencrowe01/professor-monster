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
    public class Box : NamedProfObj {
        public int MaxSlots { get; private set; }

        public PlayerMonster[] _slots;
        public IReadOnlyCollection<PlayerMonster> Slots => _slots;

        public Box(Config config) : base(config) {
            MaxSlots = config.MaxSlots;
            _slots = config.Slots?.Length > 0 ? config.Slots : new PlayerMonster[MaxSlots];
        }

        public void RemoveMonster(int index) {
            _slots[index] = null;
        }

        public void AddMonster(PlayerMonster monster) {
            for(int i = 0; i < _slots.Length; i++){
                if(_slots[i] == null){
                    AddMonster(monster, i);
                    return;
                }
            }
        }

        public void AddMonster(PlayerMonster monster, int index) {
            _slots[index] = monster;
        }

        public void SwitchMonster(int indexA, int indexB) {
            var temp = _slots[indexA];
            _slots[indexA] = _slots[indexB];
            _slots[indexB] = temp;
        }

        public class Config : NamedConfig {
            public int MaxSlots { get; set; }
            public PlayerMonster[] Slots { get; set; }
        }
    }
}