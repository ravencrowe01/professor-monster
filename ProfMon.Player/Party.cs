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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfMon.Player {
    public class Party : IReadOnlyList<PlayerMonster> {
        private PlayerMonster[] _monsters;

        public int Count => throw new NotImplementedException();

        public PlayerMonster this[int index] => _monsters[index];

        private Party () { }

        public Party(List<PlayerMonster> monsters) {
            _monsters = monsters.ToArray();
        }

        public Party(int partySize) {
            _monsters = new PlayerMonster[partySize];
        }

        public IEnumerator<PlayerMonster> GetEnumerator () {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator () {
            throw new NotImplementedException();
        }
    }
}
