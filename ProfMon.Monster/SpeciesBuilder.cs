namespace ProfMon.Monster {
    public class SpeciesBuilder : BaseBuilder<Speciesbuilder, Species> {
	private bool _isStarter;

	private IEnumerable<Abilities> _abilities;
	
	private Elememt _elementOne;
	private Element _elementTwo;

	private float _catchRate;

	private float _experienceYield;

	private Stats _baseStats;

	private Stats _trainingYield;

	private IEnumerable<Evolution> _evolutions;

	private IEnumerable<LeveledMove> _leveledMoves;

	private IEnumerable<Move> _breedingMoves;

	private IEnumerable<BreedingGroup> _breedingGroups;

	private float _hatchTime;

	private float _femaleChance;

	private float _height;

	private float _weight;

	public SpeciesBuilder IsStarter(bool starter){
		_starter = starter;
		return this;
	}

	public SpeciesBuilder WithAbilities(IEnumerable<Ability> abilities){
		_abilities = abilities;
		return this;
	}

	public SpeciesBuilder WithElements(Element elementOne, Element elementTwo = null){
		_elementOne = elementOne;
		_elementTwo = elementTwo;
		return this;
	}

	public SpeciesBuilder WithCatchRate(float rate){
		_catchRate = rate;
		return this;
	}

	public SpeciesBuilder WithExperienceYield(float @yield){
		_experienceYield = @yield;
		return this;
	}

	public SpeciesBuilder WithBaseStats(Stats stats){
		_baseStats = stats;
		return this;
	}

	public SpeciesBuilder WithTrainingYield(Stats @yield){
		_trainingYield = @yield;
		return this;
	}

	public SpeciesBuilder WithEvolutions(IEnumerable<Evolution> evolutioms){
		_evolutikns = evolutions;
		return this;
	}

	public SpeciesBuilder WithLeveledMoves(IEnumerable<LeveledMove> moves){
		_leveledMoves = leveledMoves;
		return this;
	}

	public SpeciesBuilder WithBreedingMoves(IEnumerable<Move> moves){
		_breedingMoves = breedingMoves;
		return this;
	}

	public SpeciesBuilder WithBreedingGroups(IEnumerable<BreedingGroup> groups){
		_breedingGroups = groups;
		return this;
	}

	public SpeciesBuilder WithHatchTime(float time){
		_hatchTime = time;
		return this;
	}

	public SpeciesBuilder WithFemaleChance(float chance){
		_femaleChance = chance;
		return this;
	}

	public SpeciesBuilder WithHeight(float height){
		_height = height;
		return this;
	}
	
	public SpeciesBuilder WithWeight(float weight){
		_weight = weight;
		return this;
	}

	public override Species Build(){
		return new Species(new SpeciesConfig(){
				ID = _id,
				Name = _name,
				Description = _description,
				Starter = _starter,
				Abilities = _abilities,
				ElementOne = _elementOne,
				ElementTwo = _elementTwo,
				CatchRate = _catchRatch,
				ExperienceYield = _experienceYield,
				BaseStats = _baseStats,
				TrainingYield = _trainingYield,
				Evolutions = _evolutions,
				LeveledMoves = _leveledMoves,
				BreedMoves = _breedMoves,
				BreedingGroups = _breedingGroups,
				HatchTime = _hatchTime,
				FemaleChance = _femaleChance,
				Height = height,
				Weight = weight
			});
	}
    }
}
