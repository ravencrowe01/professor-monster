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

        public readonly IReadOnlyList<Trait> Traits;

        public readonly Element PrimaryElement;
        public readonly Element SecondaryElement;

        public readonly float BaseHealth;
        public readonly float BasePhysicalAttack;
        public readonly float BasePhysicalDefense;
        public readonly float BaseNonphysicalAttack;
        public readonly float BaseNonphysicalDefense;
        public readonly float BaseSpeed;

        public readonly int TrainingStat;
        public readonly float TrainingAmount;

        public readonly IReadOnlyList<Evolution> EvolutionLists;

        public readonly IReadOnlyList<LeveledMove> LeveledMoves;
        public readonly IReadOnlyList<Move> BreedMoves;

        public readonly IReadOnlyList<BreedingGroup> BreedingGroups;
        public readonly float FemaleChance;

        public Species (SpeciesConfig config) : base (config.ID, config.Name, config.Description) {
            Starter = config.Starter;
            Traits = (IReadOnlyList<Trait>) config.Traits;
            PrimaryElement = config.PrimaryElement;
            SecondaryElement = config.SecondaryElement;
            BaseHealth = config.BaseHealth;
            BasePhysicalAttack = config.BasePhysicalAttack;
            BasePhysicalDefense = config.BasePhysicalDefense;
            BaseNonphysicalAttack = config.BaseNonphysicalAttack;
            BaseNonphysicalDefense = config.BaseNonphysicalDefense;
            BaseSpeed = config.BaseSpeed;
            TrainingStat = config.TrainingStat;
            TrainingAmount = config.TrainingAmount;
            EvolutionLists = (IReadOnlyList<Evolution>) config.EvolutionLists;
            LeveledMoves = (IReadOnlyList<LeveledMove>) config.LeveledMoves;
            BreedMoves = (IReadOnlyList<Move>) config.BreedMoves;
            BreedingGroups = (IReadOnlyList<BreedingGroup>) config.BreedingGroups;
            FemaleChance = config.FemaleChance;
        }
    }
}