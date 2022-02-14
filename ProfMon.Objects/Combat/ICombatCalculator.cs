namespace ProfMon.Objects.Combat {
    public interface ICombatCalculator {
        float CalculateBaseHPModifier(Move move, CombatMonster attacker, CombatMonster defender);
    }
}
