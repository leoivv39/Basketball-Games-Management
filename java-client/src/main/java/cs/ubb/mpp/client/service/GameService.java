package cs.ubb.mpp.client.service;

import cs.ubb.mpp.client.dto.GameDto;

import java.util.List;

public interface GameService {
    List<GameDto> getAllGames();
    List<GameDto> getAvailableGamesSortedByNumberOfSeats();
}
