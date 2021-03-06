#region copyright
/** Professor Monster, a library for creating monster collection style games.
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

namespace ProfMon.Base {
    public class ReadonlyStats {
        private readonly Stats _stats;

        public float Health => _stats.Health;
        public float PhysicalAttack => _stats.PhysicalAttack;
        public float PhysicalDefense => _stats.PhysicalDefense;
        public float NonphysicalAttack => _stats.NonphysicalAttack;
        public float NonphysicalDefense => _stats.NonphysicalDefense;
        public float Speed => _stats.Speed;

        private ReadonlyStats () { }

        public ReadonlyStats (Stats stats) {
            _stats = stats;
        }

        public static implicit operator ReadonlyStats (Stats stats) => new(stats);
    }
}