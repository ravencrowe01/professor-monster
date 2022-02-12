using ProfMon.Monster.Moves;

namespace ProfMon.Monster.Abilities {
    public interface IAbilityHandler {
        Attack Handle (Attack attack);
    }
}
