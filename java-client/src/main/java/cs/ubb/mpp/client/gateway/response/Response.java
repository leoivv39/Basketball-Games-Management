package cs.ubb.mpp.client.gateway.response;

import cs.ubb.mpp.client.gateway.payload.Payload;

public class Response {
    private ResponseStatus status;
    private Payload payload;

    public Response(ResponseStatus status, Payload payload) {
        this.status = status;
        this.payload = payload;
    }

    public ResponseStatus getStatus() {
        return status;
    }

    public Payload getPayload() {
        return payload;
    }
}
