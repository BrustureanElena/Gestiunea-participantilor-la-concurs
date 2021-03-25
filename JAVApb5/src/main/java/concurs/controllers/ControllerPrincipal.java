package concurs.controllers;

import concurs.domain.Participant;
import concurs.domain.Proba;
import concurs.domain.ProbaDTO;
import concurs.service.Service;
import concurs.utils.MessageBox;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import javafx.scene.control.*;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.text.Text;
import javafx.util.StringConverter;


import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.List;

public class ControllerPrincipal implements  Controller {
    Stage principalStage;
    Service service;
    ObservableList<ProbaDTO> modelProbe= FXCollections.observableArrayList();
    ObservableList<Proba> modelProbePtInscriere= FXCollections.observableArrayList();
    ObservableList<Participant> modelParticipanti= FXCollections.observableArrayList();

    @FXML
   TableView<ProbaDTO> idTableProbe;
    @FXML

   TableView<Proba> idTableProbe2;
    @FXML
   TableView<Participant> idTableParticipanti;
    @FXML
   Button idButtonCauta;
    @FXML
    Button adaugareButton;
    @FXML
    TextField textFieldProba1Denumire;
    @FXML
    TextField textFieldVarstaMin;
    @FXML
    TextField textFieldVarstaMax;
    @FXML
    TextField textFiledProba2Denumire;

    @FXML
    TextField textFieldPrenume;
    @FXML
    TextField textFieldNume;
    @FXML
    TextField textFieldVarsta;


    @Override
    public void initialize() {

    }
    public void initModel() {

        modelProbe.setAll((Collection<? extends ProbaDTO>) this.service.getToateProbeleDTO());

        modelProbePtInscriere.setAll((Collection<? extends Proba>) this.service.getToateProbele());
        idTableProbe2.setItems(modelProbePtInscriere);
        idTableProbe.setItems(modelProbe);

    }


    @Override
    public void setStage(Stage probeStage) {

    }


    public void setContext(Service service, Stage principalStage) {
        this.service=service;
        this.principalStage=principalStage;
        initModel();
    }

    public void cautaParticipanti(ActionEvent actionEvent) {
        Proba proba=idTableProbe.getSelectionModel().getSelectedItem();
        if(proba!=null) {
            idTableParticipanti.getItems().setAll(service.getParticipantiProbaVarsta(proba));

        }
        else
            MessageBox.showErrorMessage(null,"nicio proba selectata");

    }


    public void handleLogout(ActionEvent actionEvent) {


        try{
            service.logout();
            principalStage.hide();
            FXMLLoader loader = new FXMLLoader();
            loader.setLocation(getClass().getResource("/LoginView.fxml"));
            Parent root = loader.load();
            LoginController ctrl = loader.getController();
            Stage primaryStage=new Stage();

            ctrl.setContext(service,primaryStage);
            Scene scene = new Scene(root);
            primaryStage.setScene(scene);
            primaryStage.setTitle("Welcome");
            primaryStage.show();



        }catch(Exception e){
            MessageBox.showErrorMessage(null,e.getMessage());

        }
    }

    public void adaugaInscriere(ActionEvent actionEvent) throws Exception {


        Proba probaSelectata=(Proba)idTableProbe2.getSelectionModel().getSelectedItem();

        String nume=textFieldNume.getText();
        String prenume=textFieldPrenume.getText();
        int varsta= Integer.parseInt(textFieldVarsta.getText());
        //String proba1=textFieldProba1Denumire.getText();
     //   String proba2=textFiledProba2Denumire.getText();
      //  int varstaMin= Integer.parseInt(textFieldVarstaMin.getText());
       // int varstaMax= Integer.parseInt(textFieldVarstaMax.getText());
      //  Participant participantGasit=service.findOneByNumePrenume(nume,prenume);
       // Proba probaGasita=service.findOneByDenumireVarsta(probaSelectata.getDenumire(),probaSelectata.getVarstaMin(),probaSelectata.getVarstaMax());
       // Proba proba2Gasita=service.findOneByDenumireVarsta(proba2,varstaMin,varstaMax);
      // if(participantGasit==null)
        //    service.addParticipant(nume,prenume,varsta);


        if(nume.equals("") || prenume.equals(""))
        {
            Alert alert = new Alert(Alert.AlertType.ERROR,"Inscriere fara succes!");

            alert.show();
        }else // SA PUN CONDITIA CU VARSTA
            {

                service.addInscriere(nume,prenume,varsta,probaSelectata);


            modelProbe.setAll((Collection<? extends ProbaDTO>) this.service.getToateProbeleDTO());

            idTableProbe.setItems(modelProbe);

            Alert alert = new Alert(Alert.AlertType.CONFIRMATION,"Inscriere cu success");

            alert.show();
            //de revazut
                }


    }
}
