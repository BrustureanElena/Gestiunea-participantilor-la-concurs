package concurs.persistance.jdbc;

import concurs.domain.AngajatOficiu;
import concurs.persistance.AngajatOficiuRepository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Properties;

public class AngajatiOficiuDBRepository implements AngajatOficiuRepository {


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
    public AngajatOficiu findOneByUsername(String usernameDat,String parolaDat) {
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

    @Override
    public boolean login(String username, String parola) {
        try {
            String select="select * from \"AngajatOficiu\" where username=? and parola=?";
            Connection con=dbUtils.getConnection();
            PreparedStatement stmt  = con.prepareStatement(select);
            stmt.setString(1,username);
            stmt.setString(2,parola);
            ResultSet rs = stmt.executeQuery();
            boolean res=rs.next();
            stmt.close();
            rs.close();
            return res;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }
}
