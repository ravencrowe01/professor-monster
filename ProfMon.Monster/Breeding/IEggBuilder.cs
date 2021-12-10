using ProfMon.Inventory.Items;
using ProfMon.Monster.MonsterSpecies;
using ProfMon.Base;

namespace ProfMon.Monster.Breeding {
    public interface IEggBuilder {
        IEggBuilder AddParent(ISpeciesInstance parent);

	IEggBuilder AddOrigiinalTrainer(ID Id, string name);

        IEggBuilder AddItemModifier(Item item);

        IEgg BuildEgg();
    }
}
