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

        public Species () : base (null, null, null) { }

        public Species (ID iD,
                        string name,
                        string description,
                        IEnumerable<Trait> traits,
                        Element primaryElement,
                        Element secondaryElement,
                        float baseHealth,
                        float basePhysicalAttack,
                        float basePhysicalDefense,
                        float baseNonphysicalAttack,
                        float baseNonphysicalDefense,
                        float baseSpeed,
                        int trainingStat,
                        float trainingAmount,
                        IEnumerable<Evolution> evolutionList,
                        IEnumerable<LeveledMove> leveledMoves,
                        IEnumerable<Move> breedMoves,
                        IEnumerable<BreedingGroup> breedingGroups,
                        float femaleChance) : base (iD, name, description) {
            Traits = (IReadOnlyList<Trait>) traits;
            PrimaryElement = primaryElement;
            SecondaryElement = secondaryElement;
            BaseHealth = baseHealth;
            BasePhysicalAttack = basePhysicalAttack;
            BasePhysicalDefense = basePhysicalDefense;
            BaseNonphysicalAttack = baseNonphysicalAttack;
            BaseNonphysicalDefense = baseNonphysicalDefense;
            BaseSpeed = baseSpeed;
            TrainingStat = trainingStat;
            TrainingAmount = trainingAmount;
            EvolutionLists = (IReadOnlyList<Evolution>) evolutionList;
            LeveledMoves = (IReadOnlyList<LeveledMove>) leveledMoves;
            BreedMoves = (IReadOnlyList<Move>) breedMoves;
            BreedingGroups = (IReadOnlyList<BreedingGroup>) breedingGroups;
            FemaleChance = femaleChance;
        }
    }
}