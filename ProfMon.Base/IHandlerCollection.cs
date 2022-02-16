namespace ProfMon.Base {
    public interface IHandlerCollection<TKey, THandlerOut> {
        void AddHandler (TKey key, IHandler<THandlerOut> handler);

        void RemoveHandler (TKey key);

        IHandler<THandlerOut> GetHandler (TKey key);
    }
}
