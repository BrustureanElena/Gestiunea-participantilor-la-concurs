package concurs.services.rest;

import concurs.domain.Participant;
import concurs.domain.Proba;
import concurs.persistance.CrudRepository;
import concurs.persistance.jdbc.JdbcUtils;

import java.io.FileInputStream;
import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

@org.springframework.stereotype.Repository
public class ProbaRepository  implements CrudRepository<Long, Proba> {
    private JdbcUtils jdbcUtils;

    public ProbaRepository() {
        Properties properties = new Properties();
        try {
            properties.load(new FileInputStream("C:\\Users\\User\\Desktop\\MPPLab\\laborator\\mpp-proiect-repository-BrustureanElena\\JAVApb5\\RestServices\\db.config"));
        } catch (IOException e) {
            e.printStackTrace();
        }
        jdbcUtils = new JdbcUtils(properties);
    }

    @Override
    public void add(Proba elem) {

        Connection con=jdbcUtils.getConnection();


        try(PreparedStatement preStmt = con.prepareStatement("insert into \"Probe\"(denumire,\"varstaMin\",\"varstaMax\") values (?,?,?)")){
            preStmt.setString(1,elem.getDenumire());
            preStmt.setInt(2, elem.getVarstaMin());
            preStmt.setInt(3,elem.getVarstaMax());
            int result = preStmt.executeUpdate();


        } catch (SQLException e) {

            System.err.print("Error DB "+e);
        }

    }

    @Override
    public Iterable<Proba> findAll() throws SQLException {

        Connection conn = jdbcUtils.getConnection();

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

            System.err.print("Error DB "+e);
        }


        return probe;

    }

    @Override
    public void update(Proba entity) {
        Connection connection = jdbcUtils.getConnection();
        try (PreparedStatement preparedStatement = connection.prepareStatement("UPDATE \"Probe\" SET denumire= ?, varstaMin = ?, varstaMax = ? WHERE id = ?")) {
            preparedStatement.setString(1, entity.getDenumire());
            preparedStatement.setInt(2, entity.getVarstaMin());
            preparedStatement.setInt(3, entity.getVarstaMax());
            preparedStatement.setLong(4, entity.getId());
            preparedStatement.executeUpdate();

        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    @Override
    public void delete(Long id) {
        Connection connection = jdbcUtils.getConnection();
        try (PreparedStatement preparedStatement = connection.prepareStatement("DELETE FROM \"Probe\" WHERE id = ?")) {
            preparedStatement.setLong(1, id);
            preparedStatement.executeUpdate();

        } catch (SQLException ignored) {

        }

    }

    @Override
    public Proba findById(Long aLong) {

        Connection conn = jdbcUtils.getConnection();

        System.out.println(conn);


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

            System.err.print("Error DB "+e);
        }

        //conn.close();
        return proba;
    }


}
