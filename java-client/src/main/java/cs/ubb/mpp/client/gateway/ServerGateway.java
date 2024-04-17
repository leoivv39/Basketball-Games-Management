package cs.ubb.mpp.client.gateway;

import cs.ubb.mpp.client.dto.SoldTicketDto;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.response.Response;
import cs.ubb.mpp.client.util.Observable;

public interface ServerGateway {
    Response send(Request request);
    void listenForEvents();
    Observable<SoldTicketDto> newSoldTicketProperty();
}
