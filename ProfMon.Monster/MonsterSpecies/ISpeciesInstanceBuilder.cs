using ProfMon.Base;
using ProfMon.Monster.Abilities;
using ProfMon.Monster.Moves;
using ProfMon.Monster.Natures;
using ProfMon.Monster.Medals;

namespace ProfMon.Monster.MonsterSpecies {
    public interface ISpeciesInstanceBuilder {
	    ISpeciesInstanceBuilder WithOriginalTrainer(ID id, string name);

	    ISpeciesInstanceBuilder WithAbility(Ability ability);

	    ISpeciesInstanceBuilder WithNature(Nature nature);

	    ISpeciesInstanceBuilder WithGeneticStats(Stats genes);

	    ISpeciesInstanceBuilder WithMoves(params Move[] moves);

        ISpeciesInstanceBuilder WithTimeMet(DateTime dateTime);

        ISpeciesInstanceBuilder WithMetID(ID id);

        ISpeciesInstanceBuilder WithEggReceivedTime(DateTime dateTime);

        ISpeciesInstanceBuilder WithEggReceivedLocationID(ID id);

        ISpeciesInstanceBuilder WithPersonalityID(ID id);

	ISpeciesInstanceBuilder WithCaptureDeviceID(ID id);

        ISpeciesInstanceBuilder WithMedals(params Medal[] medals);

        ISpeciesInstanceBuilder WithStartingLevel(float level);

        ISpeciesInstanceBuilder WithStartingHappiness(float happiness);

        ISpeciesInstance Build();
    }
}
