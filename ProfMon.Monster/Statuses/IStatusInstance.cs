namespace ProfMon.Monster.Statuses {
    public interface IStatusInstance {
        Status Status { get; }

        int TurnsActive { get; }
    }
}
