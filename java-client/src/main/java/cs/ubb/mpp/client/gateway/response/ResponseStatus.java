package cs.ubb.mpp.client.gateway.response;

public enum ResponseStatus {
    OK(200), CREATED(201), BAD_REQUEST(400), NOT_FOUND(404);

    private int statusCode;

    ResponseStatus(int statusCode) {
        this.statusCode = statusCode;
    }

    public int getStatusCode() {
        return statusCode;
    }

    public boolean successful() {
        return statusCode != 400 && statusCode != 404;
    }
}
