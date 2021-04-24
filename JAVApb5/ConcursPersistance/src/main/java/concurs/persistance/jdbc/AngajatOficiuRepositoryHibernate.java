package concurs.persistance.jdbc;

import concurs.domain.AngajatOficiu;
import concurs.domain.Proba;
import concurs.persistance.AngajatOficiuRepository;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

import javax.persistence.Query;
import java.sql.SQLException;
import java.util.List;
import java.util.Properties;

public class AngajatOficiuRepositoryHibernate  implements AngajatOficiuRepository {

    private JdbcUtils dbUtils;
    static SessionFactory sessionFactory;

    //

    static void initialize() {
        final StandardServiceRegistry registry = new StandardServiceRegistryBuilder()
                .configure()
                .build();
        try {
            sessionFactory = new MetadataSources(registry).buildMetadata().buildSessionFactory();
        }
        catch (Exception e) {
            System.out.println("catch");
            e.printStackTrace();
            StandardServiceRegistryBuilder.destroy(registry);
        }
    }
    public AngajatOficiuRepositoryHibernate() {

    initialize();

    }


    static void close() {
        if (sessionFactory != null) sessionFactory.close();
    }
    @Override
    public AngajatOficiu findOneByUsername(String username,String parola) {

        List<AngajatOficiu> result = null;
        try(Session session = sessionFactory.openSession()){
            Transaction transaction = null;
            try{
                transaction = session.beginTransaction();
                result = session.createQuery("from AngajatOficiu where username = ?1 and parola = ?2", AngajatOficiu.class)
                        .setParameter(1,username).setParameter(2,parola).list();

                transaction.commit();
            } catch (Exception e) {
                e.printStackTrace();
                if(transaction !=null)
                    transaction.rollback();
            }
        }
        return result.get(0);

    }

    @Override
    public boolean login(String username, String parola) {
        return false;
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
}
