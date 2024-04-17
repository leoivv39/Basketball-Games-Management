package cs.ubb.mpp.client;

import cs.ubb.mpp.client.controller.LoginController;
import cs.ubb.mpp.client.dto.UserDto;
import cs.ubb.mpp.client.gateway.parser.JsonParser;
import cs.ubb.mpp.client.gateway.parser.JsonParserImpl;
import cs.ubb.mpp.client.gateway.payload.Payload;
import cs.ubb.mpp.client.gateway.payload.PayloadType;
import cs.ubb.mpp.client.gateway.ServerGateway;
import cs.ubb.mpp.client.gateway.ServerGatewayImpl;
import cs.ubb.mpp.client.gateway.request.Request;
import cs.ubb.mpp.client.gateway.request.RequestType;
import cs.ubb.mpp.client.service.*;
import cs.ubb.mpp.client.util.JavaFXUtils;
import javafx.application.Application;
import javafx.stage.Stage;

public class Client extends Application {
    private static final String HOSTNAME = "127.0.0.1";
    private static final int PORT = 6666;
    private static final JsonParser JSON_PARSER = new JsonParserImpl();
    private static final ServerGateway SERVER_GATEWAY = new ServerGatewayImpl(HOSTNAME, PORT, JSON_PARSER);
    private static final UserService USER_SERVICE = new UserServiceImpl(SERVER_GATEWAY);
    private static final GameService GAME_SERVICE = new GameServiceImpl(SERVER_GATEWAY);
    private static final SoldTicketService SOLD_TICKET_SERVICE = new SoldTicketServiceImpl(SERVER_GATEWAY);

    @Override
    public void start(Stage stage) {
        LoginController loginController = JavaFXUtils.openWindow("login-view.fxml", "Login", 800, 700);
        loginController.setUp(USER_SERVICE, GAME_SERVICE, SOLD_TICKET_SERVICE);
    }

    public static void main(String[] args) {
        new Thread(SERVER_GATEWAY::listenForEvents).start();
        launch();
    }
}