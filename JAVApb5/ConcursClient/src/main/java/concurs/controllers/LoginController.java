package concurs.controllers;

import concurs.service.IConcursService;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class LoginController implements  Controller {

    @FXML
     TextField idTextFieldUsername;
    @FXML
    PasswordField idTextFieldParola;

    @FXML
    Label idLabelParola;
    @FXML
    Label idLabelUsername;

    @FXML
    Button idButtonLogin;

    IConcursService service;
    Stage loginStage;
    @Override
    public void initialize() {

    }

    @Override
    public void setStage(Stage loginStage) {
        this.loginStage=loginStage;
    }


    public void handleLogin(ActionEvent actionEvent) {
        String username=idTextFieldUsername.getText();
        String password=idTextFieldParola.getText();
        try{
            service.login(username,password);
            loginStage.close();
            FXMLLoader loader=new FXMLLoader();
            loader.setLocation(getClass().getResource("/principalView.fxml"));
            Parent root=loader.load();
            ControllerPrincipal ctrl=loader.getController();

            // aici
            Stage primaryStage=new Stage();
            ctrl.setContext(service,primaryStage);
            Scene scene=new Scene(root);
            primaryStage.setScene(scene);

            primaryStage.setTitle("Concurs pentru copii");

            primaryStage.show();
            //creez una noua
            //dau show, la fel ca in main... stage...
        }catch(Exception e){
            MessageBox.showErrorMessage(null,e.getMessage());
        }

    }
    public void setContext(IConcursService service, Stage loginStage){
        this.service=service;
        this.loginStage=loginStage;
    }



}
