namespace ProfMon.Base {
    public interface IHandler<T> {
        bool CanHandle (params object [] args);

        T Handle (params object [] args);
    }
}
