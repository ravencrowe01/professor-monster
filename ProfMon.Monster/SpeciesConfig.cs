using ProfMon.Base;
using System.Collections.Generic;

namespace ProfMon.Monster {
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

        public object Height { get; set; }

        public object Weight { get; set; }
    }
}
