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
using ProfMon.Objects.Instances;
using System.Collections.Generic;

namespace ProfMon.Objects.MonStorage {
    public class Folder : StorageUnit {
        public int Background { get; private set; }

        public Folder (Config config, int size, int background = 0) : base (config, size) {
            Background = background;
        }

        public Folder (Config config, List<ISpeciesInstance> monsters, int background) : base (config, monsters) {
            Background = background;
        }

        public void ChangeBackground (int background) {
            Background = background;
        }
    }
}
