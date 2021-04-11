package concurs.persistance.jdbc;

import concurs.domain.Inscriere;
import concurs.persistance.ParticipantRepository;
import concurs.persistance.ProbaRepository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import concurs.persistance.InscriereRepository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class InscriereDBRepository implements InscriereRepository {

    private JdbcUtils dbUtils;
    private ProbaRepository probaDBRepository;
    private ParticipantRepository participantiDBRepository;

    private static final Logger logger= LogManager.getLogger();

    public InscriereDBRepository(Properties props,ParticipantRepository participantiDBRepository,
                                 ProbaRepository probaDBRepository) {
        this.participantiDBRepository=participantiDBRepository;
        this.probaDBRepository=probaDBRepository;

        logger.info("Initializing ParticipantRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }



    @Override
    public void add(Inscriere elem) {
        logger.traceEntry("saving task{}",elem);
        Connection com=dbUtils.getConnection();
        logger.traceEntry("saving task{}",elem);
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into \"Inscrieri\"(\"idParticipant\", \"idProba\") values (?,?)")){

            preStmt.setLong(1, elem.getParticipant().getId());
            preStmt.setLong(2,elem.getProba().getId());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances",result); // sa sterg traceEntry
        } catch (SQLException e) {
            //throwables.printStackTrace();
            logger.error(e);
            System.err.print("Error DB "+e);
        }
        logger.traceExit();



    }

    @Override
    public Iterable<Inscriere> findAll() {
        logger.traceEntry();
        Connection conn = dbUtils.getConnection();

        System.out.println(conn);

        List<Inscriere> inscrieri = new ArrayList<>();
        try (PreparedStatement preparedStatement = conn.prepareStatement("select * from \"Inscrieri\"")) {
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Long id = resultSet.getLong("id");
                    Long idParticipant = resultSet.getLong("idParticipant");
                    Long idProba = resultSet.getLong("idProba");

                    Inscriere inscriere=new Inscriere(participantiDBRepository.findOne(idParticipant),probaDBRepository.findOne(idProba));

                    inscriere.setId(id);
                    inscrieri.add(inscriere);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.print("Error DB "+e);
            //throwables.printStackTrace();
        }
        logger.traceExit(inscrieri);
        //conn.close();
        return inscrieri;
    }

    @Override
    public void update(Inscriere elem, Long aLong) {

    }


}
