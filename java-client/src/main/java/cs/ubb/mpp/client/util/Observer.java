package cs.ubb.mpp.client.util;

public interface Observer<T> {
    void update(T value);
}
