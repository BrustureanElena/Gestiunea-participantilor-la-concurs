import concurs.persistance.AngajatOficiuRepository;
import concurs.persistance.InscriereRepository;
import concurs.persistance.ParticipantRepository;
import concurs.persistance.ProbaRepository;
import concurs.persistance.jdbc.*;
import concurs.server.ServiceImplementation;
import concurs.service.IConcursService;
import networking.utils.AbstractServer;
import networking.utils.ConcursConcurrentServer;
import networking.utils.ServerException;
import org.hibernate.SessionFactory;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.io.IOException;
import java.util.Properties;

public class StartRpcServerHibernate {
    private static int defaultPort = 55557;


    //
    public static void main(String[] args) {
        // UserRepository userRepo=new UserRepositoryMock();
      /*
        Properties serverProps = new Properties();
        try {
            serverProps.load(StartRpcServer.class.getResourceAsStream("/concursserver.properties"));
            System.out.println("Server properties set. ");
            serverProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find chatserver.properties " + e);
            return;
        }
        ParticipantRepository participantRepository = new ParticipantiDBRepository(serverProps);
      ProbaRepository probaRepository = new ProbaDBRepository(serverProps);
    //    ProbaRepository probaRepository = new ProbaRepositoryHibernate(serverProps);
        InscriereRepository inscriereRepository = new InscriereDBRepository(serverProps, participantRepository, probaRepository);
     //   AngajatOficiuRepository angajatOficiuRepository = new AngajatiOficiuDBRepository(serverProps);

        AngajatOficiuRepository angajatOficiuRepository = new AngajatOficiuRepositoryHibernate();
        IConcursService concursServiceImpl = new ServiceImplementation(participantRepository, probaRepository, inscriereRepository
                , angajatOficiuRepository);

        int chatServerPort = defaultPort;
        try {
            chatServerPort = Integer.parseInt(serverProps.getProperty("concurs.server.port"));
        } catch (NumberFormatException nef) {
            System.err.println("Wrong  Port Number" + nef.getMessage());
            System.err.println("Using default port " + defaultPort);
        }
        System.out.println("Starting server on port: " + chatServerPort);
        AbstractServer server = new ConcursConcurrentServer(chatServerPort, concursServiceImpl);
        try {
            server.start();
        } catch (ServerException e) {
            System.err.println("Error starting the server" + e.getMessage());
        } finally {
            try {
                server.stop();
            } catch (ServerException e) {
                System.err.println("Error stopping server " + e.getMessage());
            }
        }*/
        ApplicationContext factory = new ClassPathXmlApplicationContext("classpath:spring-server.xml");

     //   AngajatOficiuRepository angajatOficiuRepository = new AngajatOficiuRepositoryHibernate() ;

    }
}
