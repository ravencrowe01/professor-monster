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
using ProfMon.Environment.Terrains;
using ProfMon.Environment.Weathers;
using ProfMon.Inventory.Items;
using ProfMon.Monster.MonsterSpecies;
using System.Collections.Generic;

namespace ProfMon.Monster.Evolutions {
    public class EvolutionBuilder : Builder<EvolutionBuilder, Evolution> {
        private Species _targetSpecies;
        private int _levelRequired;
        private Item _itemRequired;
        private Weather _weatherRequired;
        private Terrain _terrainRequired;
        private List<Species> _requiredPartners;

        public EvolutionBuilder () {
            _requiredPartners = new List<Species> ();
        }

        public EvolutionBuilder WithTargetSpecies (Species targetSpecies) {
            _targetSpecies = targetSpecies;
            return this;
        }

        public EvolutionBuilder WithRequireLevel (int levelRequired) {
            _levelRequired = levelRequired;
            return this;
        }

        public EvolutionBuilder WithRequiredItem (Item item) {
            _itemRequired = item;
            return this;
        }

        public EvolutionBuilder WithRequiredWeather (Weather weather) {
            _weatherRequired = weather;
            return this;
        }

        public EvolutionBuilder WithRequiredTerrain (Terrain terrain) {
            _terrainRequired = terrain;
            return this;
        }

        public EvolutionBuilder AddRequiredPartners (params Species [] partner) {
            _requiredPartners.AddRange (partner);
            return this;
        }


        public override Evolution Build () {
            return new Evolution (new EvolutionConfig () {
                ID = _id,
                TargetSpecies = _targetSpecies,
                LevelRequired = _levelRequired,
                ItemRequired = _itemRequired,
                WeatherRequired = _weatherRequired,
                TerrainRequired = _terrainRequired,
                RequiredPartners = _requiredPartners
            });
        }
    }
}