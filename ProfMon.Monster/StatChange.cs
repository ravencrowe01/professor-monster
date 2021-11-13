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

        public StatChange () : base (null) { }

        public StatChange (ID iD,
                           float chance,
                           float physAtk,
                           float physDef,
                           float nonPhysAtk,
                           float nonPhysDef,
                           float speed,
                           float accurecy,
                           float dodge) : base (iD) {
            Chance = chance;
            PhysAtk = physAtk;
            PhysDef = physDef;
            NonPhysAtk = nonPhysAtk;
            NonPhysDef = nonPhysDef;
            Speed = speed;
            Accurecy = accurecy;
            Dodge = dodge;
        }
    }
}