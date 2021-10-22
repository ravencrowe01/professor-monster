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

using System.Collections.Generic;
using ProfMon.Base;
using ProfMon.Base.Config;
using ProfMon.Base.ProfObj;

namespace ProfMon.Monster {
    public class Evolution : BaseProfObj {
        public readonly ID TargetSpecies;
        public readonly int LevelRequired;
        public readonly ID ItemRequired;
        public readonly ID WeatherRequired;
        public readonly ID TerrainRequired;
        public readonly IReadOnlyList<ID> PartnersRequired;

        public Evolution(Config config) : base(config) {
            TargetSpecies = config.TargetSpecies;
            LevelRequired = config.LevelRequired;
            ItemRequired = config.ItemRequired;
            WeatherRequired = config.WeatherRequired;
            TerrainRequired = config.TerrainRequired;
            PartnersRequired = config.PartnersRequired;
        }

        public class Config : BaseConfig {
            public ID TargetSpecies { get; set; }
            public int LevelRequired { get; set; }
            public ID ItemRequired { get; set; }
            public ID WeatherRequired { get; set; }
            public ID TerrainRequired { get; set; }
            public List<ID> PartnersRequired { get; set; }
        }
    }
}