package cs.ubb.mpp.client.util;

public interface Observable<T> {
    void addObserver(Observer<T> observer);
    void notifyAllObservers(T value);
}
