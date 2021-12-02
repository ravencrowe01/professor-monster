using ProfMon.Inventory.Items;

namespace ProfMon.Inventory {
    public class ItemStack {
        public readonly Item Item;

        public int Count { get; private set; }

        public ItemStack (Item item, int count = 0) {
            Item = item;
            Count = count;
        }

        public void IncreaseStack (int count) {
            if (Count + count < Item.MaxStack) {
                Count += count;
            }
        }

        public void DecreaseStack (int count) {
            if (Count - count > 0) {
                Count -= count;
            }
        }
    }
}
