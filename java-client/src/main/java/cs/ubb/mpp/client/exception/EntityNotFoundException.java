package cs.ubb.mpp.client.exception;

public class EntityNotFoundException extends ApplicationException {
    public EntityNotFoundException(String message) {
        super(message, 404);
    }
}
