using client.listener;

namespace lab6_c_.listener
{
    public class Listenable<T> : IListenable<T>
    {
        private List<Listener<T>> _listeners = new();

        public void AddListener(Listener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void NotifyAllListeners(T data)
        {
            _listeners.ForEach((listener) => listener(data));
        }
    }
}
