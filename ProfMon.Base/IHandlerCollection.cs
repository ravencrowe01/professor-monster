namespace ProfMon.Base {
    public interface IHandlerCollection<T> {
        void AddHandler (T key, IHandler handler);

        void RemoveHandler (T key);

        IHandler GetHandler (T key);
    }
}
