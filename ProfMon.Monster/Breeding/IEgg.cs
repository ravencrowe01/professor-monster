using ProfMon.Monster.Species;

namespace ProfMon.Monster.Breeding {
	public interface IEgg {
	    float EggTime { get; }

        void ModifiyEggTime(float amount);

        ISpeciesInstance Hatch();
	}
}
