using ProfMon.Base;
using System.Collections.Generic;

namespace ProfMon.Monster {
    public class SpeciesConfig {
        public ID ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Starter { get; set; }

        public IEnumerable<Ability> Abilities { get; set; }

        public Element PrimaryElement { get; set; }
        public Element SecondaryElement { get; set; }

        public float BaseHealth { get; set; }
        public float BasePhysicalAttack { get; set; }
        public float BasePhysicalDefense { get; set; }
        public float BaseNonphysicalAttack { get; set; }
        public float BaseNonphysicalDefense { get; set; }
        public float BaseSpeed { get; set; }

        public int TrainingStat { get; set; }
        public float TrainingAmount { get; set; }

        public IEnumerable<Evolution> EvolutionList { get; set; }

        public IEnumerable<LeveledMove> LeveledMoves { get; set; }
        public IEnumerable<Move> BreedMoves { get; set; }

        public IEnumerable<BreedingGroup> BreedingGroups { get; set; }
        public float FemaleChance { get; set; }
    }
}
