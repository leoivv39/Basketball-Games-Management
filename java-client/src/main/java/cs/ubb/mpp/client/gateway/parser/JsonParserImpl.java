package cs.ubb.mpp.client.gateway.parser;

import com.google.gson.*;
import cs.ubb.mpp.client.dto.GameDto;
import cs.ubb.mpp.client.dto.SoldTicketDto;
import cs.ubb.mpp.client.dto.UserDto;
import cs.ubb.mpp.client.gateway.event.Event;
import cs.ubb.mpp.client.gateway.payload.Payload;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.response.Response;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class JsonParserImpl implements JsonParser {
    private static final Gson GSON_SERIALIZER = new GsonBuilder()
            .setPrettyPrinting()
            .registerTypeAdapter(LocalDateTime.class, new LocalDateTimeDeserializer())
            .registerTypeAdapter(LocalDateTime.class, new LocalDateTimeSerializer())
            .create();

    @Override
    public <T> String parseToJson(T obj) {
        return GSON_SERIALIZER.toJson(obj);
    }

    @Override
    public Request parseToRequest(String requestJson) {
        Request request = GSON_SERIALIZER.fromJson(requestJson, Request.class);
        Payload payload = request.getPayload();
        payload.setData(parsePayloadData(payload));
        return request;
    }

    @Override
    public Response parseToResponse(String responseJson) {
        Response response = GSON_SERIALIZER.fromJson(responseJson, Response.class);
        Payload payload = response.getPayload();
        if (payload.getData() instanceof String) {
            return response;
        }
        payload.setData(parsePayloadData(payload));
        return response;
    }

    @Override
    public Event parseToEvent(String eventJson) {
        Event event = GSON_SERIALIZER.fromJson(eventJson, Event.class);
        Payload payload = event.getPayload();
        payload.setData(parsePayloadData(payload));
        return event;
    }

    private Object parsePayloadData(Payload payload) {
        JsonElement payloadJsonElement = GSON_SERIALIZER.toJsonTree(payload.getData());
        return switch (payload.getType()) {
            case STRING -> GSON_SERIALIZER.fromJson(payloadJsonElement, String.class);
            case USER -> GSON_SERIALIZER.fromJson(payloadJsonElement, UserDto.class);
            case GAMES -> getListFrom(payloadJsonElement, GameDto.class);
            case SOLD_TICKET -> GSON_SERIALIZER.fromJson(payloadJsonElement, SoldTicketDto.class);
        };
    }

    private <T> List<T> getListFrom(JsonElement jsonElement, Class<T> clazz) {
        List<T> list = new ArrayList<>();
        for (JsonElement elem : jsonElement.getAsJsonArray()) {
            T el = GSON_SERIALIZER.fromJson(elem, clazz);
            list.add(el);
        }
        return list;
    }
}
