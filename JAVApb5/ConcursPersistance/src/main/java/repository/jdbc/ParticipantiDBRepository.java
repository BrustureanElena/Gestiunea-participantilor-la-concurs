package repository.jdbc;

import concurs.domain.Participant;
import concurs.domain.Proba;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import repository.ParticipantRepository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class ParticipantiDBRepository implements ParticipantRepository {
     private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public ParticipantiDBRepository(Properties props) {
        logger.info("Initializing ParticipantRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }


    @Override
    public void add(Participant elem) {

        logger.traceEntry("saving task{}",elem);
        Connection com=dbUtils.getConnection();
        logger.traceEntry("saving task{}",elem);
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into \"Participanti\"(nume,prenume,varsta) values (?,?,?)")){
            preStmt.setString(1,elem.getNume());
            preStmt.setString(2, elem.getPrenume());
            preStmt.setInt(3,elem.getVarsta());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances",result);
        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit();


    }

    @Override
    public Iterable<Participant> findAll()  {

        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        try {
            Class.forName("org.sqlite.JDBC");
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
        List<Participant> participants = new ArrayList<>();
        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from Participanti")) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    String nume = resultSet.getString("nume");
                    String prenume = resultSet.getString("prenume");
                    int varsta = resultSet.getInt("varsta");
                    Participant participant =new Participant(nume,prenume,varsta);
                    participant.setId(id);
                    participants.add(participant);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit(participants);
        //conn.close();
        return participants;

    }

    @Override
    public void update(Participant elem, Long aLong) {

    }

    @Override
    public Participant findOne(Long aLong) {
        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

       Participant participant=null;
        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"Participanti\" where id=" +
                aLong )) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                    if(resultSet.next()){
                    Long id = resultSet.getLong("id");
                    String nume = resultSet.getString("nume");
                    String prenume = resultSet.getString("prenume");
                    int varsta = resultSet.getInt("varsta");
                    participant =new Participant(nume,prenume,varsta);
                    participant.setId(id);
                    }


            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit(participant);
        //conn.close();
        return participant;


    }

    @Override
    public int getNrParticipantiProbaVarsta(Proba proba) {
        logger.traceEntry();
        Connection conn = dbUtils.getConnection();
        int nrParticipanti=0;
        Long idProbaData=proba.getId();

        try (PreparedStatement preparedStatement = conn.prepareStatement("select count(*) from \"Inscrieri\" where \"idProba\"=" +idProbaData

        )) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
               if (resultSet.next()) {
                   nrParticipanti=resultSet.getInt("count(*)");



                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error BD"+ e);
        }
        logger.traceExit(nrParticipanti);
        //conn.close();
        return nrParticipanti;

    }




    @Override
    public Iterable<Participant> getParticipantiProbaVarsta(Proba proba) {

        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        List<Participant> participants = new ArrayList<>();
        Long idProbaData=proba.getId();

        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"Participanti\" as p inner join \"Inscrieri\" I on p.id = I.\"idParticipant\" where\n" +
                "\"idProba\"= "+idProbaData
        )) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    String nume=resultSet.getString("nume");
                    String prenume=resultSet.getString("prenume");
                    int varsta = resultSet.getInt("varsta");
                   Participant participant=new Participant(nume,prenume,varsta);

                   participant.setId(id);

                    participants.add(participant);

                }
            }
        } catch (SQLException e) {
           logger.error(e);
           System.err.println("Error BD"+ e);
        }
        logger.traceExit(participants);
        //conn.close();
        return participants;


    }

    @Override
    public Participant findOneByNumePrenume(String numeDat, String prenumeDat) {
        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        Participant participant=null;
        Proba proba=null;
        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"Participanti\" where nume='"+numeDat+"' and prenume='"+prenumeDat+"'")) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    String nume1 = resultSet.getString("nume");
                    String prenume1 = resultSet.getString("prenume");

                    int varsta1 = resultSet.getInt("varsta");

                   participant=new Participant(nume1,prenume1,varsta1);

                    participant.setId(id);

                }
            }
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        logger.traceExit(participant);
        //conn.close();
        return participant;
    }


    @Override
    public Participant addWithReturn(Participant elem) {
        logger.traceEntry("saving participant{}",elem);
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into \"Participanti\"(nume,prenume,varsta) values (?,?,?)")){
            preStmt.setString(1,elem.getNume());
            preStmt.setString(2, elem.getPrenume());
            preStmt.setInt(3,elem.getVarsta());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances",result);
            try (PreparedStatement preparedStatement = con.prepareStatement("select * from \"Participanti\" where id = last_insert_rowid();" )) {
                try (ResultSet resultSet = preparedStatement.executeQuery()) {
                    if(resultSet.next()) {
                        Long id = resultSet.getLong("id");
                        String nume = resultSet.getString("nume");
                        String prenume = resultSet.getString("prenume");
                        int varsta = resultSet.getInt("varsta");
                        Participant participant = new Participant(nume,prenume,varsta);
                        participant.setId(id);
                        logger.traceExit(participant);
                        return participant;
                    }
                }
            } catch (SQLException e) {
                logger.error(e);
                System.err.println("Error DB: " + e);
            }

        } catch (SQLException ex) {
            logger.error(ex);
            System.err.println("Error DB: " + ex);
        }

        return null;

    }
}
