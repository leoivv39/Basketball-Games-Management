package cs.ubb.mpp.client.service;

import cs.ubb.mpp.client.exception.BadRequestException;
import cs.ubb.mpp.client.gateway.ServerGateway;
import cs.ubb.mpp.client.dto.GameDto;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.request.RequestType;
import cs.ubb.mpp.client.gateway.response.Response;
import cs.ubb.mpp.client.gateway.response.ResponseStatus;

import java.util.List;

public class GameServiceImpl implements GameService {
    private final ServerGateway serverGateway;

    public GameServiceImpl(ServerGateway  serverGateway) {
        this.serverGateway = serverGateway;
    }

    @Override
    public List<GameDto> getAllGames() {
        Response response = serverGateway.send(new Request(RequestType.GET_ALL_GAMES, null));
        if (response.getStatus().equals(ResponseStatus.OK)) {
            return (List<GameDto>) response.getPayload().getData();
        }
        throw new BadRequestException(String.valueOf(response.getPayload()));
    }

    @Override
    public List<GameDto> getAvailableGamesSortedByNumberOfSeats() {
        Response response = serverGateway.send(new Request(RequestType.GET_ALL_AVAILABLE_GAMES, null));
        if (response.getStatus().equals(ResponseStatus.OK)) {
            return (List<GameDto>) response.getPayload().getData();
        }
        throw new BadRequestException(String.valueOf(response.getPayload()));
    }
}
