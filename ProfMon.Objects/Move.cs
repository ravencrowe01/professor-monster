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

using ProfMon.Base.ProfObj;
using ProfMon.Objects.Configs;

namespace ProfMon.Objects {
    public class Move : DescribedProfObject {
        public readonly Element Element;

        public readonly int Priority;

        public readonly float Power;
        public readonly float Accurecy;

        public Move (MoveConfig config) : base (config) {
            Element = config.Element;
            Priority = config.Priority;
            Power = config.Power;
            Accurecy = config.Accurecy;
        }
    }
}
