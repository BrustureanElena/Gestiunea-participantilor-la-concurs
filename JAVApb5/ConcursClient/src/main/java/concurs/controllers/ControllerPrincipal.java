package concurs.controllers;

import concurs.domain.*;
import concurs.service.ConcursException;
import concurs.service.IConcursObserver;
import concurs.service.IConcursService;

import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.Collection;



public class ControllerPrincipal implements Controller,IConcursObserver {
    Stage principalStage;
    AngajatOficiu angajatOficiuConnectat;
    IConcursService service;
    ControllerPrincipal controllerPrincipal;

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
        idTableParticipanti.setItems(modelParticipanti);
        idTableProbe.setItems(modelProbe);


    }
    public void initModel() throws ConcursException {

        modelProbe.setAll((Collection<? extends ProbaDTO>) this.service.getToateProbeleDTO());

        modelProbePtInscriere.setAll((Collection<? extends Proba>) this.service.getToateProbele());
        idTableProbe2.setItems(modelProbePtInscriere);
        idTableProbe.setItems(modelProbe);

    }
    public void setAngajatOficiuConnectat(AngajatOficiu angajatOficiuConnectat) throws ConcursException {
        this.angajatOficiuConnectat=angajatOficiuConnectat;
        initModel();
    }

    @Override
    public void setStage(Stage probeStage) {

    }


    public void setContext(IConcursService service) throws ConcursException {
        this.service=service;

       // initModel();
    }

    public void cautaParticipanti(ActionEvent actionEvent) throws ConcursException {
        Proba proba=idTableProbe.getSelectionModel().getSelectedItem();
        if(proba!=null) {
            idTableParticipanti.getItems().setAll(service.getParticipantiProbaVarsta(proba));

        }
        else
            MessageBox.showErrorMessage(null,"nicio proba selectata");

    }


    public void handleLogout(ActionEvent actionEvent) {

        /*
        try{
            service.logout(this);
            principalStage.hide();
            FXMLLoader loader = new FXMLLoader();
            loader.setLocation(getClass().getResource("/LoginView.fxml"));
            Parent root = loader.load();
            LoginController ctrl = loader.getController();
            Stage primaryStage=new Stage();

            ctrl.setContext(service);
            Scene scene = new Scene(root);
            primaryStage.setScene(scene);
            primaryStage.setTitle("Welcome");
            primaryStage.show();


        }catch(Exception e){
           MessageBox.showErrorMessage(null,e.getMessage());

        }*/

        logout();
        ((Node)(actionEvent.getSource())).getScene().getWindow().hide();

    }
    public void logout(){
        try {
            service.logout(angajatOficiuConnectat,this);
            System.exit(0);
        } catch (ConcursException e) {
            System.out.println("Logout error " + e);
        }
    }
    public void adaugaInscriere(ActionEvent actionEvent) throws Exception {

        Proba probaSelectata=(Proba)idTableProbe2.getSelectionModel().getSelectedItem();

        String nume=textFieldNume.getText();
        String prenume=textFieldPrenume.getText();
        int varsta= Integer.parseInt(textFieldVarsta.getText());


        if(nume.equals("") || prenume.equals(""))
        {
            Alert alert = new Alert(Alert.AlertType.ERROR,"Inscriere fara succes!");

            alert.show();
        }else // SA PUN CONDITIA CU VARSTA
            {
                Participant participant=new Participant(nume,prenume,varsta);
                Inscriere inscriere=new Inscriere(participant,probaSelectata);
                inscriere.setId(0L);
                service.addInscriere(inscriere);

           // modelProbe.setAll((Collection<? extends ProbaDTO>) this.service.getToateProbeleDTO());

           // idTableProbe.setItems(modelProbe);

                }


    }
//DE MODIFICAT
    @Override
    public void inscriereUpdated(Inscriere inscriere) throws ConcursException {
     //   modelProbe.setAll(service.getToateProbeleDTO());
        Platform.runLater(()->{
            ProbaDTO probaDTO = modelProbe.stream()
                    .filter(proba -> proba.getId().equals(inscriere.getProba().getId()))
                    .findFirst()
                    .get();
            probaDTO.setNrParticipanti(probaDTO.getNrParticipanti() + 1);
            int index = modelProbe.indexOf(probaDTO);
            modelProbe.set(index, probaDTO);

            ///  ParticipantDTO participantDTO = new ParticipantDTO(inregistrare.getParticipant().getNume(),
            //        inregistrare.getParticipant().getPrenume(),inregistrare.getParticipant().getVarsta(),probaDTOString);
            Participant participant=inscriere.getParticipant();
            modelParticipanti.add(participant);
            idTableProbe.refresh();
            idTableParticipanti.refresh();
        } );

    }

}
