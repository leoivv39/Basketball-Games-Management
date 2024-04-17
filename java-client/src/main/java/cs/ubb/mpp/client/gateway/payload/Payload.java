package cs.ubb.mpp.client.gateway.payload;

public class Payload {
    private PayloadType type;
    private Object data;

    public Payload(PayloadType type, Object data) {
        this.type = type;
        this.data = data;
    }

    public PayloadType getType() {
        return type;
    }

    public Object getData() {
        return data;
    }

    public void setData(Object data) {
        this.data = data;
    }

    @Override
    public String toString() {
        return "Payload{" +
                "type=" + type +
                ", data=" + data +
                '}';
    }
}
