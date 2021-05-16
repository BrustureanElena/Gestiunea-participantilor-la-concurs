package rest.client;

import concurs.domain.Proba;
import concurs.services.rest.ServiceException;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.ResourceAccessException;
import org.springframework.web.client.RestTemplate;

import java.util.concurrent.Callable;

public class ProbeClient {
    public static final String URL = "http://localhost:8080/probe";

    private RestTemplate template = new RestTemplate();
    private <T> T execute(Callable<T> callable) {
        try {
            return callable.call();
        } catch (ResourceAccessException | HttpClientErrorException e) { // server down, resource exception
            throw new ServiceException(e);
        } catch (Exception e) {
            throw new ServiceException(e);
        }
    }

    public Proba add(Proba proba) throws Exception {
        return execute(() -> template.postForObject(URL, proba, Proba.class));
    }

    public Proba findOne(Long id) throws Exception {
        return execute(() -> template.getForObject(URL + '/' + id.toString(), Proba.class));
    }

    public Proba[] findAll() throws Exception {
        return execute(() -> template.getForObject(URL, Proba[].class));
    }

    public Proba update(Proba proba) throws Exception {
        execute(() -> {
            template.put(String.format("%s/%s", URL, proba.getId()), proba);
            return null;
        });
        return findOne(proba.getId());
    }

    public void delete(Integer id) throws Exception {
        execute(() -> {
            template.delete(URL + '/' + id.toString());
            return  null;
        });
    }

}
