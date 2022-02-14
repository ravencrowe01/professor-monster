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

using ProfMon.Base;
using ProfMon.Objects.Inventory;
using System.Collections.Generic;

namespace ProfMon.Objects.Configs {
    public class EvolutionConfig : Config {
        public Species TargetSpecies { get; set; }

        public int LevelRequired { get; set; }

        public Item ItemRequired { get; set; }

        public Weather WeatherRequired { get; set; }

        public Terrain TerrainRequired { get; set; }

        public IEnumerable<Species> RequiredPartners { get; set; }
    }
}