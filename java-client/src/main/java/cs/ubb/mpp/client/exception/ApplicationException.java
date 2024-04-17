package cs.ubb.mpp.client.exception;

public class ApplicationException extends RuntimeException {
    private int statusCode;

    public ApplicationException(String message, int statusCode) {
        super(message);
        this.statusCode = statusCode;
    }
}
