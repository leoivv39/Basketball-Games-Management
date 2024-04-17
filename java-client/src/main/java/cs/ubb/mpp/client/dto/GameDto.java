package cs.ubb.mpp.client.dto;

import java.math.BigDecimal;
import java.time.LocalDateTime;

public class GameDto {
    private Long id;
    private TeamDto firstTeam;
    private TeamDto secondTeam;
    private LocalDateTime time;
    private BigDecimal ticketPrice;
    private int numberOfSeats;
    private GameType type;

    public GameDto(Long id, TeamDto firstTeam, TeamDto secondTeam, LocalDateTime time, BigDecimal ticketPrice, int numberOfSeats, GameType type) {
        this.id = id;
        this.firstTeam = firstTeam;
        this.secondTeam = secondTeam;
        this.time = time;
        this.ticketPrice = ticketPrice;
        this.numberOfSeats = numberOfSeats;
        this.type = type;
    }

    public Long getId() {
        return id;
    }

    public TeamDto getFirstTeam() {
        return firstTeam;
    }

    public TeamDto getSecondTeam() {
        return secondTeam;
    }

    public LocalDateTime getTime() {
        return time;
    }

    public BigDecimal getTicketPrice() {
        return ticketPrice;
    }

    public int getNumberOfSeats() {
        return numberOfSeats;
    }

    public GameType getType() {
        return type;
    }

    @Override
    public String toString() {
        return "GameDto{" +
                "firstTeam=" + firstTeam +
                ", secondTeam=" + secondTeam +
                ", time=" + time +
                ", ticketPrice=" + ticketPrice +
                ", numberOfSeats=" + numberOfSeats +
                ", type=" + type +
                '}';
    }
}
