#region copyright
/** Professors Monster, a library for creating monster collection style games.
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
    public class Stats {
        public float Health { get; private set; }
        public float PhysicalAttack { get; private set; }
        public float PhysicalDefense { get; private set; }
        public float NonphysicalAttack { get; private set; }
        public float NonphysicalDefense { get; private set; }
        public float Speed { get; private set; }

        public Stats () { }

        public Stats (float health,
                      float physicalAttack,
                      float physicalDefense,
                      float nonphysicalAttack,
                      float nonphysicalDefense,
                      float speed) {
            Health = health;
            PhysicalAttack = physicalAttack;
            PhysicalDefense = physicalDefense;
            NonphysicalAttack = nonphysicalAttack;
            NonphysicalDefense = nonphysicalDefense;
            Speed = speed;
        }

        public float GetTotal() {
            return Health + PhysicalAttack + PhysicalDefense + NonphysicalAttack + NonphysicalDefense + Speed;
        }

        public static Stats operator + (Stats stats, Stats other) {
            return new Stats (stats.Health + other.Health,
                             stats.PhysicalAttack + other.PhysicalAttack,
                             stats.PhysicalDefense + other.PhysicalDefense,
                             stats.NonphysicalAttack + other.NonphysicalAttack,
                             stats.NonphysicalDefense + other.NonphysicalDefense,
                             stats.Speed + other.Speed);
        }
    }
}