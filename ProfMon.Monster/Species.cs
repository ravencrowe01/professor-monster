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
    public class Species : DescribedProfObj {
        public readonly IReadOnlyList<ID> Traits;

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

        public readonly IReadOnlyList<ID> EvolutionList;

        public readonly IReadOnlyList<ID> LeveledMoves;
        public readonly IReadOnlyList<ID> BreedMoves;

        public readonly IReadOnlyList<ID> BreedingGroups;
        public readonly float FemaleChance;

        public Species(Config config) : base(config) {
            Traits = config.Traits;
            Primary = config.Primary;
            Secondary = config.Secondary;
            BaseHealth = config.BaseHealth;
            BasePhysicalAttack = config.BasePhysicalAttack;
            BasePhysicalDefense = config.BasePhysicalDefense;
            BaseNonphysicalAttack = config.BaseNonphysicalAttack;
            BaseNonphysicalDefense = config.BaseNonphysicalDefense;
            BaseSpeed = config.BaseSpeed;
            TrainingStat = config.TrainingStat;
            TrainingAmount = config.TrainingAmount;
            EvolutionList = config.EvolutionList;
            LeveledMoves = config.LeveledMoves;
            BreedMoves = config.BreedMoves;
            BreedingGroups = config.BreedingGroups;
            FemaleChance = config.FemaleChance;
        }

        public class Config : DescribedConfig {
            public List<ID> Traits { get; set; }

            public Element Primary { get; set; }
            public Element Secondary { get; set; }

            public float BaseHealth { get; set; }
            public float BasePhysicalAttack { get; set; }
            public float BasePhysicalDefense { get; set; }
            public float BaseNonphysicalAttack { get; set; }
            public float BaseNonphysicalDefense { get; set; }
            public float BaseSpeed { get; set; }

            public int TrainingStat { get; set; }
            public float TrainingAmount { get; set; }

            public List<ID> EvolutionList { get; set; }

            public List<ID> LeveledMoves { get; set; }
            public List<ID> BreedMoves { get; set; }
            public List<ID> LearnableMoves { get; set; }

            public List<ID> BreedingGroups { get; set; }
            public float FemaleChance { get; set; }
        }
    }
}