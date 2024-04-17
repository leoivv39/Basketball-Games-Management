package cs.ubb.mpp.client.gateway.event;

import cs.ubb.mpp.client.gateway.payload.Payload;

public class Event {
    private EventType type;
    private Payload payload;

    public Event(EventType eventType, Payload payload) {
        this.type = eventType;
        this.payload = payload;
    }

    public EventType getType() {
        return type;
    }

    public Payload getPayload() {
        return payload;
    }
}
