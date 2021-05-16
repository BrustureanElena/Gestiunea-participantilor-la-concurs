package concurs.persistance.jdbc;




import concurs.domain.Participant;
import concurs.domain.Proba;
import concurs.persistance.ProbaRepository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;
import java.util.Date;
import java.util.List;
import java.util.Properties;
public class ProbaRepositoryHibernate implements ProbaRepository {
    private JdbcUtils dbUtils;
    public ProbaRepositoryHibernate(Properties props) {
        dbUtils=new JdbcUtils(props);
        initialize();
    }
    static SessionFactory sessionFactory;
    static void initialize() {
        final StandardServiceRegistry registry = new StandardServiceRegistryBuilder().configure().build();
        try {
            sessionFactory = new MetadataSources(registry).buildMetadata().buildSessionFactory();
        }
        catch (Exception e) {
            StandardServiceRegistryBuilder.destroy(registry);
        }
    }

    static void close() {
        if (sessionFactory != null) sessionFactory.close();
    }





    @Override
    public Proba findOne(Long aLong) {

        List<Proba> result = null;
        try (Session session = sessionFactory.openSession()) {
            Transaction transaction = null;
            try {
                transaction = session.beginTransaction();
                result = session.createQuery("FROM Proba WHERE  id='"+aLong+"' ", Proba.class).list();
                transaction.commit();
            } catch (RuntimeException exception) {
                if (transaction != null) transaction.rollback();
            }
        }
        return result.get(0);
    }




    @Override
    public void add(Proba elem) {
        try (Session session = sessionFactory.openSession()) {
            Transaction transaction = null;
            try {
                transaction = session.beginTransaction();
                session.save(elem);
                transaction.commit();
            }
            catch (RuntimeException exception) {
                if (transaction != null) transaction.rollback();
            }
        }

    }

    @Override
    public Iterable<Proba> findAllByDenumire(String denumire1) {
        return null;
    }
    @Override
    public Proba findOneByDenumireVarsta(String denumireDat, int varstaMinDat, int varstaMaxDat) {
  /*  logger.traceEntry();
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
    return proba;*/
        List<Proba>result=null;
        // Participant participant=null;

        try (Session session = sessionFactory.openSession()) {
            Transaction transaction = null;
            try {
                transaction = session.beginTransaction();
                result = session.createQuery("FROM Proba WHERE  denumire='"+denumireDat+"' and varstaMin='"+varstaMinDat+"'", Proba.class).list();
                transaction.commit();
            }
            catch (RuntimeException exception) {
                if (transaction != null) transaction.rollback();
            }
        }
        return result.get(0);

    }
    @Override
    public List<Proba> findAll() {
        List<Proba> result = null;
        try (Session session = sessionFactory.openSession()) {
            Transaction transaction = null;
            try {
                transaction = session.beginTransaction();
                result = session.createQuery("FROM Proba",
                        Proba.class).list();
                transaction.commit();
            }
            catch (RuntimeException exception) {
                if (transaction != null) transaction.rollback();
            }
        }
        return result;
    }

    @Override
    public void update(Proba elem) {

    }

    @Override
    public void delete(Long id) {

    }

    @Override
    public Proba findById(Long aLong) {
        return null;
    }


}