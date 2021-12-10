using ProfMon.Monster.MonsterSpecies;

namespace ProfMon.Monster.Breeding {
	public interface IEgg {
	    float EggTime { get; }

        void ModifiyEggTime(float amount);

        ISpeciesInstance Hatch();
	}
}
