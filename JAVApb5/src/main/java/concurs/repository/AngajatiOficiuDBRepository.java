package concurs.repository;

import concurs.domain.AngajatOficiu;
import concurs.utils.JdbcUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Properties;

public class AngajatiOficiuDBRepository implements  AngajatOficiuRepository{


    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public AngajatiOficiuDBRepository(Properties props) {
        logger.info("Initializing ParticipantRepository with properties: {} ", props);
        dbUtils = new JdbcUtils(props);
    }


    @Override
    public void add(AngajatOficiu elem) {

    }

    @Override
    public Iterable<AngajatOficiu> findAll() throws SQLException {
        return null;
    }

    @Override
    public void update(AngajatOficiu elem, Long aLong) {

    }

    @Override
    public AngajatOficiu findOneByUsername(String usernameDat) {
        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        AngajatOficiu angajatOficiu=null;


        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"AngajatOficiu\" where username=?")) {
           preparedStatement.setString(1,usernameDat);
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");

                    String parola = resultSet.getString("parola");
                    String username = resultSet.getString("username");

                   angajatOficiu=new AngajatOficiu(username,parola);

                   angajatOficiu.setId(id);


                }
            }
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        logger.traceExit(angajatOficiu);
        //conn.close();
        return angajatOficiu;
    }
}
