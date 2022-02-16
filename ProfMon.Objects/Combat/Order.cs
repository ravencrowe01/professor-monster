using ProfMon.Objects.Inventory;

namespace ProfMon.Objects.Combat {
    public class Order {
        public int OrderType { get; set; }

        public int Priority { get; set; }

        public CombatMonster Actor { get; set; }
        public CombatTeam ActorTeam { get; set; }

        public CombatMonster Target { get; set; }
        public CombatTeam TargetTeam { get; set; }

        public Move MoveUsed { get; set; }

        public Item ItemUsed { get; set; }

        public int SlotSwitchedTo { get; set; } = -1;
    }
}
