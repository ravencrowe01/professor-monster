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

namespace ProfMon.Base {
    public class Stats {
        public float Health { get; private set; }
        public float PhysicalAttack { get; private set; }
        public float PhysicalDefense { get; private set; }
        public float NonphysicalAttack { get; private set; }
        public float NonphysicalDefense { get; private set; }
        public float Speed { get; private set; }

        public Stats(Config config = null) {
            if (config != null) {
                Health = config.Health;
                PhysicalAttack = config.PhysicalAttack;
                PhysicalDefense = config.PhysicalDefense;
                NonphysicalAttack = config.NonphysicalAttack;
                NonphysicalDefense = config.NonphysicalDefense;
                Speed = config.Speed;
            }
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

        public void UpdateStats(Config config) {
            UpdateHealth(config.Health);
            UpdatePhysicalAttack(config.PhysicalAttack);
            UpdatePhysicalDefense(config.PhysicalDefense);
            UpdateNonphysicalAttack(config.NonphysicalAttack);
            UpdateNonphysicalDefense(config.NonphysicalDefense);
            UpdateSpeed(config.Speed);
        }

        public class Config {
            public float Health { get; set; }
            public float PhysicalAttack { get; set; }
            public float PhysicalDefense { get; set; }
            public float NonphysicalAttack { get; set; }
            public float NonphysicalDefense { get; set; }
            public float Speed { get; set; }

            public Config() { }

            public Config(Stats stats) {
                Health = stats.Health;
                PhysicalAttack = stats.PhysicalAttack;
                PhysicalDefense = stats.PhysicalDefense;
                NonphysicalAttack = stats.NonphysicalAttack;
                NonphysicalDefense = stats.NonphysicalDefense;
                Speed = stats.Speed;
            }
        }
    }
}