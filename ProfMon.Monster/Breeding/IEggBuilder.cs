using ProfMon.Inventory.Items;

namespace ProfMon.Monster.Breeding {
    public interface IEggBuilder {
        IEggBuilder AddParent(ISpeciesInstance parent);

	IEggBuilder AddOrigiinalTrainer(ID Id, string name);

        IEggBuilder AddItemModifier(Item item);

        IEgg BuildEgg();
    }
}
