package cs.ubb.mpp.client.controller;

import cs.ubb.mpp.client.service.UserService;
import cs.ubb.mpp.client.dto.UserDto;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.paint.Paint;

public class RegisterController {
    private UserService userService;
    @FXML
    private PasswordField passwordField;
    @FXML
    private TextField usernameField;
    @FXML
    private Label displayInfo;

    public void setUp(UserService userService) {
        this.userService = userService;
    }

    public void handleRegisterButton(ActionEvent actionEvent) {
        String username = usernameField.getText();
        String password = passwordField.getText();
        if (username.isBlank() || password.isBlank()) {
            displayInfo.setText("All fields are mandatory.");
            return;
        }
        UserDto newUser = new UserDto(null, username, password);
        userService.addUser(newUser);
        displayInfo.setText("User registered successfully.");
        displayInfo.setTextFill(Paint.valueOf("green"));
    }
}
