package concurs.persistance.jdbc;

import concurs.domain.Participant;
import concurs.domain.Proba;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import concurs.persistance.ProbaRepository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class ProbaDBRepository implements ProbaRepository {

    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public ProbaDBRepository(Properties props) {
        logger.info("Initializing ParticipantRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }


    @Override
    public void add(Proba elem) {
        logger.traceEntry("saving task{}",elem);
        Connection com=dbUtils.getConnection();
        logger.traceEntry("saving task{}",elem);
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into \"Probe\"(denumire,\"varstaMin\",\"varstaMax\") values (?,?,?)")){
            preStmt.setString(1,elem.getDenumire());
            preStmt.setInt(2, elem.getVarstaMin());
            preStmt.setInt(3,elem.getVarstaMax());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances",result);

        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit();
    }

    @Override
    public Iterable<Proba> findAll() {

        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        List<Proba> probe = new ArrayList<>();
        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"Probe\"")) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    String denumire= resultSet.getString("denumire");
                    int varstaMin = resultSet.getInt("varstaMin");
                    int varstaMax = resultSet.getInt("varstaMax");
                    Proba proba=new Proba(denumire,varstaMin,varstaMax);
                    proba.setId(id);
                    probe.add(proba);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit(probe);
        //conn.close();
        return probe;

    }

    @Override
    public void update(Proba elem, Long aLong) {

        logger.traceEntry("updating request {} ",elem);
        Connection con=dbUtils.getConnection();
        try(PreparedStatement preStmt=con.prepareStatement("update \"Probe\" set nrParticipanti=? where id=?")){

         //   preStmt.setInt(1,elem.getNrParticipanti());
            preStmt.setLong(2,elem.getId());
            int result=preStmt.executeUpdate();
            logger.trace("Updated {} instances",result);

        }catch (SQLException ex){
            logger.error(ex);
            System.err.println("Error DB "+ex);
        }
        logger.traceExit();
    }

    @Override
    public Iterable<Proba> findAllByDenumire(String denumire1) {

        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        List<Proba> probe = new ArrayList<>();
        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"Probe\"  where denumire='"+denumire1+ "'")) {

            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    String denumire= resultSet.getString("denumire");
                    int varstaMin = resultSet.getInt("varstaMin");
                    int varstaMax = resultSet.getInt("varstaMax");
                    Proba proba=new Proba(denumire,varstaMin,varstaMax);
                    proba.setId(id);
                    probe.add(proba);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit(probe);
        //conn.close();
        return probe;

    }

    @Override
    public Proba findOne(Long aLong) {
        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        Participant participant=null;
        Proba proba=null;
        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"Probe\" where id=" +
                aLong )) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    String denumire = resultSet.getString("denumire");

                    int varstaMin = resultSet.getInt("varstaMin");
                    int varstaMax = resultSet.getInt("varstaMax");
                    proba =new Proba(denumire,varstaMin,varstaMax);

                    proba.setId(id);

                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit(proba);
        //conn.close();
        return proba;

    }




    @Override
    public Proba findOneByDenumireVarsta(String denumireDat, int varstaMinDat, int varstaMaxDat) {
        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);


        Proba proba=null;
        try (PreparedStatement preparedStatement = conn.prepareStatement( "select * from \"Probe\" where denumire='"+denumireDat+"' and varstaMin='"+varstaMinDat+"'")) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    String denumire1 = resultSet.getString("denumire");


                    int varstaMin1 = resultSet.getInt("varstaMin");
                    int varstaMax1 = resultSet.getInt("varstaMax");


                    proba=new Proba(denumire1,varstaMin1,varstaMax1);
                    proba.setId(id);


                }
            }
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        logger.traceExit(proba);
        //conn.close();
        return proba;
    }



}
