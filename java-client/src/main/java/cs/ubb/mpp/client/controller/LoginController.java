package cs.ubb.mpp.client.controller;

import cs.ubb.mpp.client.exception.EntityNotFoundException;
import cs.ubb.mpp.client.service.GameService;
import cs.ubb.mpp.client.service.SoldTicketService;
import cs.ubb.mpp.client.service.UserService;
import cs.ubb.mpp.client.util.JavaFXUtils;
import cs.ubb.mpp.client.dto.UserDto;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.TextField;
import javafx.scene.text.Text;

public class LoginController {
    private UserService userService;
    private GameService gameService;
    private SoldTicketService soldTicketService;
    @FXML
    private TextField usernameField;
    @FXML
    private TextField passwordField;
    @FXML
    private Text errorText;

    public void setUp(UserService userService, GameService gameService, SoldTicketService soldTicketService) {
        this.userService = userService;
        this.gameService = gameService;
        this.soldTicketService = soldTicketService;
    }

    public void onSignUp(ActionEvent actionEvent) {
        RegisterController registerController = JavaFXUtils.openWindow("register-view.fxml", "Sign Up", 800, 700);
        registerController.setUp(userService);
    }

    public void onLogin(ActionEvent actionEvent) {
        String username = usernameField.getText();
        String password = passwordField.getText();
        if (username.isBlank() || password.isBlank()) {
            errorText.setText("All fields are mandatory.");
            return;
        }
        UserDto user;
        try {
            user = userService.getUserByUsernameAndPassword(username, password);
        } catch (EntityNotFoundException exception) {
            errorText.setText("Username or/and password are invalid.");
            return;
        }
        errorText.setText("");
        GamesController gamesController = JavaFXUtils.openWindow("games-screen.fxml", "Games", 1200, 1000);
        gamesController.setUp(user, gameService.getAllGames(), gameService, soldTicketService);
    }
}
