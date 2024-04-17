module cs.ubb.mpp.client {
    requires javafx.controls;
    requires javafx.fxml;
    requires com.google.gson;


    opens cs.ubb.mpp.client to javafx.fxml;
    opens cs.ubb.mpp.client.controller to javafx.fxml;
    opens cs.ubb.mpp.client.dto;
    opens cs.ubb.mpp.client.gateway.request;
    opens cs.ubb.mpp.client.gateway.response;
    opens cs.ubb.mpp.client.gateway.payload;
    opens cs.ubb.mpp.client.gateway.event;
    exports cs.ubb.mpp.client;
    exports cs.ubb.mpp.client.dto;
    exports cs.ubb.mpp.client.controller;
}