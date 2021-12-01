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
using ProfMon.Environment;
using ProfMon.Inventory;
using System.Collections.Generic;

namespace ProfMon.Monster {
    public class Evolution : BaseProfObj {
        public readonly Species TargetSpecies;
        public readonly int LevelRequired;
        public readonly Item ItemRequired;
        public readonly Weather WeatherRequired;
        public readonly Terrain TerrainRequired;
        public readonly IReadOnlyList<Species> RequiredPartners;

        internal Evolution (EvolutionConfig config) : base (config.ID) {
            TargetSpecies = config.TargetSpecies;
            LevelRequired = config.LevelRequired;
            ItemRequired = config.ItemRequired;
            WeatherRequired = config.WeatherRequired;
            TerrainRequired = config.TerrainRequired;
            RequiredPartners = (IReadOnlyList<Species>) config.RequiredPartners;
        }
    }
}