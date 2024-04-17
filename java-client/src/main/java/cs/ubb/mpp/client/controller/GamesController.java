package cs.ubb.mpp.client.controller;

import cs.ubb.mpp.client.Client;
import cs.ubb.mpp.client.service.GameService;
import cs.ubb.mpp.client.service.SoldTicketService;
import cs.ubb.mpp.client.dto.GameDto;
import cs.ubb.mpp.client.dto.UserDto;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Button;
import javafx.scene.control.CheckBox;
import javafx.scene.control.ScrollPane;
import javafx.scene.layout.Pane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.List;

public class GamesController {
    private UserDto loggedInUser;
    private List<GameDto> games;
    private GameService gameService;
    private SoldTicketService soldTicketService;
    @FXML
    private VBox gamesContainer;
    @FXML
    private ScrollPane scrollPane;
    @FXML
    private CheckBox availableGamesOnlyCheckbox;
    @FXML
    private Button logOutButton;

    public void setUp(UserDto user, List<GameDto> games, GameService gameService, SoldTicketService soldTicketService) {
        loggedInUser = user;
        this.games = games;
        this.gameService = gameService;
        this.soldTicketService = soldTicketService;
        displayGames();
        scrollPane.setHbarPolicy(ScrollPane.ScrollBarPolicy.NEVER);
        scrollPane.setVbarPolicy(ScrollPane.ScrollBarPolicy.NEVER);
    }

    public void onAvailableGamesOnlyCheckbox(ActionEvent actionEvent) {
        boolean isSelected = availableGamesOnlyCheckbox.isSelected();
        if (isSelected) {
            games = gameService.getAvailableGamesSortedByNumberOfSeats();
        } else {
            games = gameService.getAllGames();
        }
        displayGames();
    }

    public void onLogOut(ActionEvent actionEvent) {
        ((Stage) logOutButton.getScene().getWindow()).close();
    }

    private void displayGames() {
        gamesContainer.getChildren().clear();
        for (GameDto game : games) {
            FXMLLoader fxmlLoader = new FXMLLoader(Client.class.getResource("game-card.fxml"));
            Pane gameCard = loadFxml(fxmlLoader);
            GameCardController gameCardController = fxmlLoader.getController();
            gameCardController.setUp(loggedInUser, game, gameService, soldTicketService);
            gamesContainer.getChildren().add(gameCard);
        }
    }

    private Pane loadFxml(FXMLLoader fxmlLoader) {
        try {
            return fxmlLoader.load();
        } catch(IOException e) {
            e.printStackTrace();
            return null;
        }
    }
}
