namespace ProfMon.Base {
    public interface IHandler<T> {
        T Handle (params object [] args);
    }
}
