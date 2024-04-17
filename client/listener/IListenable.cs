namespace client.listener
{
    public interface IListenable<T>
    {
        void AddListener(Listener<T> listener);
        void NotifyAllListeners(T data);
    }
}
