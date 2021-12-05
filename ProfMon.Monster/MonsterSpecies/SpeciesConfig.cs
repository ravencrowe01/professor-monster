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
using ProfMon.Monster.Abilities;
using ProfMon.Monster.BreedingGroups;
using ProfMon.Monster.Elements;
using ProfMon.Monster.Evolutions;
using ProfMon.Monster.Moves;
using System.Collections.Generic;

namespace ProfMon.Monster.MonsterSpecies {
    public class SpeciesConfig {
        public ID ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Starter { get; set; }

        public IEnumerable<Ability> Abilities { get; set; }

        public Element ElementOne { get; set; }

        public Element ElementTwo { get; set; }

        public object CatchRate { get; set; }

        public float ExperienceYield { get; set; }

        public Stats BaseStats { get; set; }

        public Stats TrainingYield { get; set; }

        public IEnumerable<Evolution> Evolutions { get; set; }

        public IEnumerable<LeveledMove> LeveledMoves { get; set; }

        public IEnumerable<Move> BreedMoves { get; set; }

        public IEnumerable<BreedingGroup> BreedingGroups { get; set; }

        public float HatchTime { get; set; }

        public float FemaleChance { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public int GrowthRate { get; set; }
    }
}
