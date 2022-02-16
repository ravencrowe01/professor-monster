namespace ProfMon.Objects.Combat {
    public interface ICombatTriggerHandler {
        bool CanTrigger (CombatEvent @event, CombatState combat, CombatMonster owner);

        CombatEvent Trigger (CombatEvent @event, CombatState combat, CombatMonster owner);
    }
}
