package cs.ubb.mpp.client.controller;

import cs.ubb.mpp.client.dto.GameDto;
import cs.ubb.mpp.client.dto.SoldTicketDto;
import cs.ubb.mpp.client.dto.UserDto;
import cs.ubb.mpp.client.service.GameService;
import cs.ubb.mpp.client.service.SoldTicketService;
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.paint.Paint;
import javafx.scene.shape.Rectangle;

import java.time.LocalDateTime;

public class GameCardController {
    private GameDto game;
    private UserDto loggedInUser;
    private GameService gameService;
    private SoldTicketService soldTicketService;
    private String currentNoOfTickets;
    @FXML
    private Label firstTeamNameLabel;
    @FXML
    private Label secondTeamNameLabel;
    @FXML
    private Label firstTeamCityLabel;
    @FXML
    private Label secondTeamCityLabel;
    @FXML
    private Label timeLabel;
    @FXML
    private Label priceLabel;
    @FXML
    private Label availableTicketsLabel;
    @FXML
    private TextField nameTextField;
    @FXML
    private TextField noOfTicketsTextField;
    @FXML
    private Button buyButton;
    @FXML
    private Label soldOutLabel;
    @FXML
    private Rectangle rectangle;
    @FXML
    private Label gameType;

    public void setUp(UserDto user, GameDto game, GameService gameService, SoldTicketService soldTicketService) {
        this.loggedInUser = user;
        this.game = game;
        this.gameService = gameService;
        this.soldTicketService = soldTicketService;
        setUpCard();
        noOfTicketsTextField.textProperty().addListener((obs, oldValue, newValue) -> {
            if (!newValue.isBlank() && !isInteger(newValue)) {
                noOfTicketsTextField.setText(currentNoOfTickets);
                return;
            }
            currentNoOfTickets = newValue;
        });
        soldTicketService.onNewSoldTicket(this::newTicketAdded);
    }

    private void setUpCard() {
        firstTeamNameLabel.setText(game.getFirstTeam().getName());
        firstTeamCityLabel.setText(game.getFirstTeam().getCity().toString());
        secondTeamNameLabel.setText(game.getSecondTeam().getName());
        secondTeamCityLabel.setText(game.getSecondTeam().getCity().toString());
        timeLabel.setText(game.getTime().toString());
        priceLabel.setText(game.getTicketPrice().toString());
        availableTicketsLabel.setText(String.valueOf(game.getNumberOfSeats()));
        gameType.setText(game.getType().toString());
        if (game.getNumberOfSeats() == 0) {
            soldOutLabel.setVisible(true);
            buyButton.setVisible(false);
            rectangle.setFill(Paint.valueOf("#ff3b48"));
        }
    }

    public void onBuyTicket(ActionEvent actionEvent) {
        String name = nameTextField.getText();
        if (name.isBlank() || currentNoOfTickets.isBlank()) {
            MessageAlert.showErrorMessage(null, "All inputs are mandatory.");
            return;
        }
        int requestedNoOfTickets = parseInt(currentNoOfTickets);
        if (requestedNoOfTickets > game.getNumberOfSeats() || requestedNoOfTickets == 0) {
            MessageAlert.showErrorMessage(null, "Unavailable number of tickets inserted.");
            return;
        }
        SoldTicketDto soldTicket = new SoldTicketDto(null, loggedInUser, game, LocalDateTime.now(), parseInt(currentNoOfTickets), name);
        soldTicketService.addTicket(soldTicket);
        MessageAlert.showMessage(null, Alert.AlertType.INFORMATION, "Success", "Ticket(s) sold successfully!");
    }

    private boolean isInteger(String str) {
        try {
            Integer.parseInt(str);
            return true;
        } catch (NumberFormatException exception) {
            return false;
        }
    }

    private int parseInt(String str) {
        try {
            return Integer.parseInt(str);
        } catch (NumberFormatException exception) {
            exception.printStackTrace();
            return -1;
        }
    }

    private void newTicketAdded(SoldTicketDto ticket) {
        if (ticket.getGame().getId().equals(game.getId())) {
            game = ticket.getGame();
            Platform.runLater(this::setUpCard);
        }
    }
}
