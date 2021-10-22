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

using ProfMon.Base.Config;
using ProfMon.Base.ProfObj;

namespace ProfMon.Monster {
    public class StatChange : BaseProfObj {
        public readonly float Chance;

        public readonly float PhysAtk;
        public readonly float PhysDef;
        public readonly float NonPhysAtk;
        public readonly float NonPhysDef;
        public readonly float Speed;

        public readonly float Accurecy;
        public readonly float Dodge;

        public StatChange(Config config) : base(config) {
            Chance = config.Chance;

            PhysAtk = config.PhysAtk;
            PhysDef = config.PhysDef;
            NonPhysAtk = config.NonPhysAtk;
            NonPhysDef = config.NonPhysDef;
            Speed = config.Speed;

            Accurecy = config.Accurecy;
            Dodge = config.Dodge;
        }

        public class Config : BaseConfig {
            public float Chance { get; set; }

            public float PhysAtk { get; set; }
            public float PhysDef { get; set; }
            public float NonPhysAtk { get; set; }
            public float NonPhysDef { get; set; }
            public float Speed { get; set; }

            public float Accurecy { get; set; }
            public float Dodge { get; set; }
        }
    }
}