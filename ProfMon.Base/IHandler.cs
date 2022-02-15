namespace ProfMon.Base {
    public interface IHandler {
        T Handle<T> (params object [] args);
    }
}
