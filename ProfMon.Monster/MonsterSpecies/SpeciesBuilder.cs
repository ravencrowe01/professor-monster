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
    public class SpeciesBuilder : Builder<SpeciesBuilder, Species> {
        private bool _starter;

        private IEnumerable<Ability> _abilities;

        private Element _elementOne;
        private Element _elementTwo;

        private float _catchRate;

        private float _experienceYield;

        private Stats _baseStats;

        private Stats _trainingYield;

        private IEnumerable<Evolution> _evolutions;

        private IEnumerable<LeveledMove> _leveledMoves;

        private IEnumerable<Move> _breedMoves;

        private IEnumerable<BreedingGroup> _breedingGroups;

        private float _hatchTime;

        private float _femaleChance;

        private float _height;

        private float _weight;

        public SpeciesBuilder IsStarter (bool starter) {
            _starter = starter;
            return this;
        }

        public SpeciesBuilder WithAbilities (IEnumerable<Ability> abilities) {
            _abilities = abilities;
            return this;
        }

        public SpeciesBuilder WithElements (Element elementOne, Element elementTwo = null) {
            _elementOne = elementOne;
            _elementTwo = elementTwo;
            return this;
        }

        public SpeciesBuilder WithCatchRate (float rate) {
            _catchRate = rate;
            return this;
        }

        public SpeciesBuilder WithExperienceYield (float @yield) {
            _experienceYield = @yield;
            return this;
        }

        public SpeciesBuilder WithBaseStats (Stats stats) {
            _baseStats = stats;
            return this;
        }

        public SpeciesBuilder WithTrainingYield (Stats @yield) {
            _trainingYield = @yield;
            return this;
        }

        public SpeciesBuilder WithEvolutions (IEnumerable<Evolution> evolutions) {
            _evolutions = evolutions;
            return this;
        }

        public SpeciesBuilder WithLeveledMoves (IEnumerable<LeveledMove> moves) {
            _leveledMoves = moves;
            return this;
        }

        public SpeciesBuilder WithBreedingMoves (IEnumerable<Move> moves) {
            _breedMoves = moves;
            return this;
        }

        public SpeciesBuilder WithBreedingGroups (IEnumerable<BreedingGroup> groups) {
            _breedingGroups = groups;
            return this;
        }

        public SpeciesBuilder WithHatchTime (float time) {
            _hatchTime = time;
            return this;
        }

        public SpeciesBuilder WithFemaleChance (float chance) {
            _femaleChance = chance;
            return this;
        }

        public SpeciesBuilder WithHeight (float height) {
            _height = height;
            return this;
        }

        public SpeciesBuilder WithWeight (float weight) {
            _weight = weight;
            return this;
        }

        public override Species Build () {
            return new Species (new SpeciesConfig () {
                ID = _id,
                Name = _name,
                Description = _description,
                Starter = _starter,
                Abilities = _abilities,
                ElementOne = _elementOne,
                ElementTwo = _elementTwo,
                CatchRate = _catchRate,
                ExperienceYield = _experienceYield,
                BaseStats = _baseStats,
                TrainingYield = _trainingYield,
                Evolutions = _evolutions,
                LeveledMoves = _leveledMoves,
                BreedMoves = _breedMoves,
                BreedingGroups = _breedingGroups,
                HatchTime = _hatchTime,
                FemaleChance = _femaleChance,
                Height = _height,
                Weight = _weight
            });
        }
    }
}
