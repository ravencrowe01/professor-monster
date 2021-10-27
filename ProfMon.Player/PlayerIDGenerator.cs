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
using System;

namespace ProfMon.Player {
    public class PlayerIDGenerator : IPlayerIDGenerator {
        private int _max = (int) Math.Pow(2, 16);
        private Random _rng;

        public PlayerIDGenerator () {
            _rng = new Random();
        }

        public PlayerIDGenerator (Random rng) {
            _rng = rng;
        }

        public ID Get () {
            return new ID((uint) _rng.Next(0, _max), (uint) _rng.Next(0, _max));
        }
    }
}
