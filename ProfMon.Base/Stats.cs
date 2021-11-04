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

using ProfMon.Base.ProfObj;

namespace ProfMon.Base {
    public class Stats : BaseProfObj{
        public float Health { get; private set; }
        public float PhysicalAttack { get; private set; }
        public float PhysicalDefense { get; private set; }
        public float NonphysicalAttack { get; private set; }
        public float NonphysicalDefense { get; private set; }
        public float Speed { get; private set; }

        public Stats (ID iD,
                      float health,
                      float physicalAttack,
                      float physicalDefense,
                      float nonphysicalAttack,
                      float nonphysicalDefense,
                      float speed) : base(iD) {
            Health = health;
            PhysicalAttack = physicalAttack;
            PhysicalDefense = physicalDefense;
            NonphysicalAttack = nonphysicalAttack;
            NonphysicalDefense = nonphysicalDefense;
            Speed = speed;
        }

        public void UpdateHealth(float delta) {
            Health += delta;
        }

        public void UpdatePhysicalAttack(float delta) {
            PhysicalAttack += delta;
        }

        public void UpdatePhysicalDefense(float delta) {
            PhysicalDefense += delta;
        }

        public void UpdateNonphysicalAttack(float delta) {
            NonphysicalAttack += delta;
        }

        public void UpdateNonphysicalDefense(float delta) {
            NonphysicalDefense += delta;
        }

        public void UpdateSpeed(float delta) {
            Speed += delta;
        }

        public void UpdateStats(float health,
                                float physicalAttack,
                                float physicalDefense,
                                float nonphysicalAttack,
                                float nonphysicalDefense,
                                float speed) {
            UpdateHealth(health);
            UpdatePhysicalAttack(physicalAttack);
            UpdatePhysicalDefense(physicalDefense);
            UpdateNonphysicalAttack(nonphysicalAttack);
            UpdateNonphysicalDefense(nonphysicalDefense);
            UpdateSpeed(speed);
        }
    }
}