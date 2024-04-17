package cs.ubb.mpp.client.service;

import cs.ubb.mpp.client.dto.UserDto;
import cs.ubb.mpp.client.exception.EntityNotFoundException;
import cs.ubb.mpp.client.gateway.payload.Payload;
import cs.ubb.mpp.client.gateway.payload.PayloadType;
import cs.ubb.mpp.client.gateway.ServerGateway;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.request.RequestType;
import cs.ubb.mpp.client.gateway.response.Response;
import cs.ubb.mpp.client.gateway.response.ResponseStatus;

public class UserServiceImpl implements UserService {
    private final ServerGateway serverGateway;

    public UserServiceImpl(ServerGateway serverGateway) {
        this.serverGateway = serverGateway;
    }

    @Override
    public UserDto addUser(UserDto user) {
        return null;
    }

    @Override
    public UserDto getUserByUsernameAndPassword(String username, String password) {
        Response response = serverGateway.send(new Request(RequestType.GET_USER, new Payload(PayloadType.USER, new UserDto(null, username, password))));
        if (response.getStatus().equals(ResponseStatus.NOT_FOUND)) {
            throw new EntityNotFoundException("User not found");
        }
        return (UserDto) response.getPayload().getData();
    }
}
