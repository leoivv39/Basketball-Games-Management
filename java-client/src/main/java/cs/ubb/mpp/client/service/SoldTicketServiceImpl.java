package cs.ubb.mpp.client.service;

import cs.ubb.mpp.client.dto.SoldTicketDto;
import cs.ubb.mpp.client.exception.BadRequestException;
import cs.ubb.mpp.client.gateway.payload.Payload;
import cs.ubb.mpp.client.gateway.payload.PayloadType;
import cs.ubb.mpp.client.gateway.ServerGateway;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.request.RequestType;
import cs.ubb.mpp.client.gateway.response.Response;
import cs.ubb.mpp.client.gateway.response.ResponseStatus;
import cs.ubb.mpp.client.util.Observer;

public class SoldTicketServiceImpl implements SoldTicketService {
    private final ServerGateway serverGateway;

    public SoldTicketServiceImpl(ServerGateway serverGateway) {
        this.serverGateway = serverGateway;
    }

    @Override
    public SoldTicketDto addTicket(SoldTicketDto soldTicket) {
        Response response = serverGateway.send(new Request(RequestType.ADD_SOLD_TICKET, new Payload(PayloadType.SOLD_TICKET, soldTicket)));
        if (response.getStatus().equals(ResponseStatus.OK)) {
            return (SoldTicketDto) response.getPayload().getData();
        }
        throw new BadRequestException(String.valueOf(response.getPayload()));
    }

    @Override
    public void onNewSoldTicket(Observer<SoldTicketDto> observer) {
        serverGateway.newSoldTicketProperty().addObserver(observer);
    }
}
