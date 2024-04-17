package cs.ubb.mpp.client.service;

import cs.ubb.mpp.client.dto.SoldTicketDto;
import cs.ubb.mpp.client.util.Observer;

public interface SoldTicketService {
    SoldTicketDto addTicket(SoldTicketDto soldTicket);
    void onNewSoldTicket(Observer<SoldTicketDto> observer);
}
