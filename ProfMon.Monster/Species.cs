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
using System.Collections.Generic;

namespace ProfMon.Monster {
    public class Species : DescribedProfObj {
        public readonly bool Starter;

        public readonly IReadOnlyList<Ability> Abilities;

        public readonly Element PrimaryElement;
        public readonly Element SecondaryElement;

        public readonly float CatchRate;

        public readonly float ExperienceYield;

        public readonly ReadonlyStats BaseStats;

        public readonly ReadonlyStats TrainingYield;

        public readonly IReadOnlyList<Evolution> EvolutionList;

        public readonly IReadOnlyList<LeveledMove> LeveledMoves;
        public readonly IReadOnlyList<Move> BreedMoves;

        public readonly IReadOnlyList<BreedingGroup> BreedingGroups;

        public readonly int HatchTime;

        public readonly float FemaleChance;

        public readonly float Height;
        public readonly float Weight;

        internal Species (SpeciesConfig config) : base (config.ID, config.Name, config.Description) {
            Starter = config.Starter;
            Abilities = (IReadOnlyList<Ability>) config.Abilities;
            PrimaryElement = config.PrimaryElement;
            SecondaryElement = config.SecondaryElement;
            EvolutionList = (IReadOnlyList<Evolution>) config.EvolutionList;
            LeveledMoves = (IReadOnlyList<LeveledMove>) config.LeveledMoves;
            BreedMoves = (IReadOnlyList<Move>) config.BreedMoves;
            BreedingGroups = (IReadOnlyList<BreedingGroup>) config.BreedingGroups;
            FemaleChance = config.FemaleChance;
        }
    }
}