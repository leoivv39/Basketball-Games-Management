package cs.ubb.mpp.client.gateway.parser;

import cs.ubb.mpp.client.gateway.event.Event;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.response.Response;

public interface JsonParser {
    <T> String parseToJson(T obj);
    Request parseToRequest(String requestJson);
    Response parseToResponse(String responseJson);
    Event parseToEvent(String eventJson);
}
