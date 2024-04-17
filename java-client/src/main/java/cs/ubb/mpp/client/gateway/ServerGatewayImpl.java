package cs.ubb.mpp.client.gateway;

import cs.ubb.mpp.client.dto.SoldTicketDto;
import cs.ubb.mpp.client.gateway.event.Event;
import cs.ubb.mpp.client.gateway.event.EventType;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.request.RequestType;
import cs.ubb.mpp.client.gateway.response.Response;
import cs.ubb.mpp.client.gateway.util.SocketUtils;
import cs.ubb.mpp.client.util.Observable;
import cs.ubb.mpp.client.util.ObservableImpl;
import cs.ubb.mpp.client.gateway.parser.JsonParser;

import java.io.*;
import java.net.Socket;

public class ServerGatewayImpl implements ServerGateway {
    private final JsonParser jsonParser;
    private String hostname;
    private int port;
    private Observable<SoldTicketDto> newSoldTicketProperty = new ObservableImpl<>();

    public ServerGatewayImpl(String hostname, int port, JsonParser jsonParser) {
        this.hostname = hostname;
        this.port = port;
        this.jsonParser = jsonParser;
    }

    @Override
    public Response send(Request request) {
        try {
            Socket socket = new Socket(hostname, port);
            String requestJson = jsonParser.parseToJson(request);
            System.out.println(requestJson);
            SocketUtils.writeString(socket, requestJson);
            String responseJson = SocketUtils.readString(socket);
            System.out.println(responseJson);
            Response response = jsonParser.parseToResponse(responseJson);
            return response;
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }

    @Override
    public void listenForEvents() {
        Socket eventSocket = null;
        try {
            eventSocket = new Socket(hostname, port);
            Request request = new Request(RequestType.LISTEN_TO_EVENTS, null);
            String requestJson = jsonParser.parseToJson(request);
            SocketUtils.writeString(eventSocket, requestJson);
        } catch (IOException e) {
            e.printStackTrace();
        }
        while (true) {
            handleServerEvent(eventSocket);
        }
    }

    private void handleServerEvent(Socket eventSocket) {
        String eventJson = SocketUtils.readString(eventSocket);
        Event event = jsonParser.parseToEvent(eventJson);
        if (event.getType().equals(EventType.NEW_SOLD_TICKET)) {
            SoldTicketDto newSoldTicket = (SoldTicketDto) event.getPayload().getData();
            newSoldTicketProperty.notifyAllObservers(newSoldTicket);
        }
    }

    @Override
    public Observable<SoldTicketDto> newSoldTicketProperty() {
        return newSoldTicketProperty;
    }
}
