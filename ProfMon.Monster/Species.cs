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
        public readonly IReadOnlyList<ID> TraitIDs;

        public readonly Element Primary;
        public readonly Element Secondary;

        public readonly float BaseHealth;
        public readonly float BasePhysicalAttack;
        public readonly float BasePhysicalDefense;
        public readonly float BaseNonphysicalAttack;
        public readonly float BaseNonphysicalDefense;
        public readonly float BaseSpeed;

        public readonly int TrainingStat;
        public readonly float TrainingAmount;

        public readonly IReadOnlyList<ID> EvolutionListIDs;

        public readonly IReadOnlyList<ID> LeveledMoveIDs;
        public readonly IReadOnlyList<ID> BreedMoveIDs;

        public readonly IReadOnlyList<ID> BreedingGroupIDs;
        public readonly float FemaleChance;

        public Species (ID iD,
                        string name,
                        string description,
                        IReadOnlyList<ID> traitIDs,
                        Element primary,
                        Element secondary,
                        float baseHealth,
                        float basePhysicalAttack,
                        float basePhysicalDefense,
                        float baseNonphysicalAttack,
                        float baseNonphysicalDefense,
                        float baseSpeed,
                        int trainingStat,
                        float trainingAmount,
                        IEnumerable<ID> evolutionListIDs,
                        IEnumerable<ID> leveledMoveIDs,
                        IEnumerable<ID> breedMoveIDs,
                        IEnumerable<ID> breedingGroupIDs,
                        float femaleChance) : base(iD, name, description) {
            TraitIDs = traitIDs;
            Primary = primary;
            Secondary = secondary;
            BaseHealth = baseHealth;
            BasePhysicalAttack = basePhysicalAttack;
            BasePhysicalDefense = basePhysicalDefense;
            BaseNonphysicalAttack = baseNonphysicalAttack;
            BaseNonphysicalDefense = baseNonphysicalDefense;
            BaseSpeed = baseSpeed;
            TrainingStat = trainingStat;
            TrainingAmount = trainingAmount;
            EvolutionListIDs = (IReadOnlyList<ID>) evolutionListIDs;
            LeveledMoveIDs = (IReadOnlyList<ID>) leveledMoveIDs;
            BreedMoveIDs = (IReadOnlyList<ID>) breedMoveIDs;
            BreedingGroupIDs = (IReadOnlyList<ID>) breedingGroupIDs;
            FemaleChance = femaleChance;
        }
    }
}