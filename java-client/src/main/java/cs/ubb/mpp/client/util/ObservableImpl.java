package cs.ubb.mpp.client.util;

import java.util.ArrayList;
import java.util.List;

public class ObservableImpl<T> implements Observable<T> {
    private List<Observer<T>> observers = new ArrayList<>();

    @Override
    public void addObserver(Observer<T> observer) {
        observers.add(observer);
    }

    @Override
    public void notifyAllObservers(T value) {
        observers.forEach(observer -> observer.update(value));
    }
}
