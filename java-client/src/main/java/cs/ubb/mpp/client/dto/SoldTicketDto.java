package cs.ubb.mpp.client.dto;

import java.time.LocalDateTime;

public class SoldTicketDto {
    private Long id;
    private UserDto soldBy;
    private GameDto game;
    private LocalDateTime soldAt;
    private int noOfTickets;
    private String username;

    public SoldTicketDto(Long id, UserDto soldBy, GameDto game, LocalDateTime soldAt, int noOfTickets, String username) {
        this.id = id;
        this.soldBy = soldBy;
        this.game = game;
        this.soldAt = soldAt;
        this.noOfTickets = noOfTickets;
        this.username = username;
    }

    public UserDto getSoldBy() {
        return soldBy;
    }

    public GameDto getGame() {
        return game;
    }

    public LocalDateTime getSoldAt() {
        return soldAt;
    }

    public int getNoOfTickets() {
        return noOfTickets;
    }

    public String getUsername() {
        return username;
    }

    public Long getId() {
        return id;
    }

    @Override
    public String toString() {
        return "SoldTicketDto{" +
                "soldBy=" + soldBy +
                ", game=" + game +
                ", soldAt=" + soldAt +
                ", noOfTickets=" + noOfTickets +
                ", username='" + username + '\'' +
                '}';
    }
}
