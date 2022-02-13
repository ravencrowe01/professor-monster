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
using ProfMon.Objects.Configs;

namespace ProfMon.Objects {
    public class Status : DescribedProfObject {
        public readonly int TurnsActive;

        public readonly bool Hidden;

        public readonly bool IsMajor;
        public readonly bool OverwritesMajor;

        public readonly bool Stacks;
        public readonly int MaxStacks;

        protected internal Status (StatusConfig config) : base (config) {
            TurnsActive = config.TurnsActive;
            Hidden = config.Hidden;
            IsMajor = config.IsMajor;
            OverwritesMajor = config.OverwritesMajor;
            Stacks = config.Stacks;
            MaxStacks = config.MaxStacks;
        }
    }
}