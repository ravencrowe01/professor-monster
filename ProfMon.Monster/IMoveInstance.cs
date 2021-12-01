namespace ProfMon.Monster {
    public interface IMoveInstance {
        Move Move { get; }

        int CurrentUses { get; }
        int MaxUses { get; }

        int TimesBoosted { get; }
        int MaxBoosts { get; }
    }
}
