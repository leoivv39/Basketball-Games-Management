package cs.ubb.mpp.client.service;

import cs.ubb.mpp.client.dto.UserDto;

public interface UserService {
    UserDto addUser(UserDto user);
    UserDto getUserByUsernameAndPassword(String username, String password);
}
