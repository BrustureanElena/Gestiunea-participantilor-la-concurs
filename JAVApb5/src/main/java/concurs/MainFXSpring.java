package concurs;


import concurs.controllers.Controller;
import concurs.controllers.LoginController;
import concurs.service.Service;
import concurs.utils.MessageBox;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class MainFXSpring extends Application {

    public static void main(String[] args){
        launch(args);
    }

    public static Service getService(){
        ApplicationContext context = new ClassPathXmlApplicationContext("concursConfig.xml");
        return context.getBean(Service.class);
    }
    @Override
    public void start(Stage primaryStage) throws Exception {
        try{
            FXMLLoader loader = new FXMLLoader();
            loader.setLocation(getClass().getResource("/LoginView.fxml"));
            Parent root = loader.load();
            LoginController ctrl = loader.getController();

            ctrl.setContext(getService(),primaryStage);
            Scene scene = new Scene(root);
            primaryStage.setScene(scene);
            primaryStage.setTitle("Welcome");
            primaryStage.show();





        }catch(Exception e){
            MessageBox.showErrorMessage(null,e.getMessage());

        }
    }
}
