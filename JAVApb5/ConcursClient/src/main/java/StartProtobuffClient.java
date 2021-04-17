import concurs.controllers.ControllerPrincipal;
import concurs.controllers.LoginController;
import concurs.network.protobuffprotocol.ProtoConcursProxy;
import concurs.network.rpcprotocol.ConcursServicesRpcProxy;
import concurs.service.IConcursService;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.Properties;

public class StartProtobuffClient extends Application {
    private static int defaultChatPort = 55555;
    private static String defaultServer = "localhost";
    @Override
    public void start(Stage primaryStage) throws Exception {
        System.out.println("In start");
        Properties clientProps = new Properties();
        try {
            clientProps.load(StartRpcClientFX.class.getResourceAsStream("/concursclient.properties"));
            System.out.println("Client properties set. ");
            clientProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find concursclient.properties " + e);
            return;
        }

        String serverIP = clientProps.getProperty("concurs.server.host", defaultServer);
        int serverPort = defaultChatPort;
        try {
            serverPort = Integer.parseInt(clientProps.getProperty("concurs.server.port"));
        } catch (NumberFormatException ex) {
            System.err.println("Wrong port number " + ex.getMessage());
            System.out.println("Using default port: " + defaultChatPort);
        }
        System.out.println("Using server IP " + serverIP);
        System.out.println("Using server port " + serverPort);

        //adresa la care trebe sa se conectezr

        IConcursService server = new ProtoConcursProxy(serverIP, serverPort);


        FXMLLoader loader = new FXMLLoader(getClass().getResource("/LoginView.fxml"));
        Parent root=loader.load();
        //
        LoginController ctrl =loader.getController();
        ctrl.setContext(server);

        FXMLLoader cloader = new FXMLLoader(
                getClass().getResource("/principalView.fxml"));
        Parent croot=cloader.load();

        ControllerPrincipal concursCtrl = cloader.getController();
        concursCtrl.setContext(server);

        ctrl.setControllerPrincipal(concursCtrl);
        ctrl.setParent(croot);

        primaryStage.setTitle("Concurs");
        primaryStage.setScene(new Scene(root));
        primaryStage.show();}
}
