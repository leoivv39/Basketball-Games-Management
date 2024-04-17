package cs.ubb.mpp.client.gateway.request;

import cs.ubb.mpp.client.gateway.payload.Payload;

public class Request {
    private RequestType requestType;
    private Payload payload;

    public Request(RequestType requestType, Payload payload) {
        this.requestType = requestType;
        this.payload = payload;
    }

    public RequestType getRequestType() {
        return requestType;
    }

    public Payload getPayload() {
        return payload;
    }

    public void setPayload(Payload payload) {
        this.payload = payload;
    }

    @Override
    public String toString() {
        return "Request{" +
                "requestType=" + requestType +
                ", payload=" + payload +
                '}';
    }
}
