package cs.ubb.mpp.client.util;

import cs.ubb.mpp.client.Client;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;

public class JavaFXUtils {
    public static <T> T openWindow(String fxmlFile, String title, double width, double height) {
        FXMLLoader fxmlLoader = new FXMLLoader(Client.class.getResource(fxmlFile));
        Stage stage = new Stage();
        stage.setTitle(title);
        Scene scene = getScene(fxmlLoader, width, height);
        stage.setScene(scene);
        stage.show();
        return fxmlLoader.getController();
    }

    private static Scene getScene(FXMLLoader fxmlLoader, double width, double height) {
        try {
            return new Scene(fxmlLoader.load(), width, height);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
