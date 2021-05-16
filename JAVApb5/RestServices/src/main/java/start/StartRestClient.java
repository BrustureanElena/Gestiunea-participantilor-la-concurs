package start;

import concurs.domain.Proba;
import concurs.services.rest.ServiceException;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;
import rest.client.ProbeClient;

public class StartRestClient {
    private final static ProbeClient probeClient=new ProbeClient();
    public static void main(String[] args) {
        RestTemplate restTemplate = new RestTemplate();
        Proba proba = new Proba("film", 122, 144);

        try {
            //  User result= restTemplate.postForObject("http://localhost:8080/chat/users",userT, User.class);

            //  System.out.println("Result received "+result);
      /*  System.out.println("Updating  user ..."+userT);
        userT.setName("New name 2");
        restTemplate.put("http://localhost:8080/chat/users/test124", userT);

*/
            // System.out.println(restTemplate.postForObject("http://localhost:8080/chat/users",userT, User.class));
            //System.out.println( restTemplate.postForObject("http://localhost:8080/chat/users",userT, User.class));
          /*  show(() -> {
                try {
                    System.out.println("FindONe");
                    System.out.println(probeClient.findOne(13L));
                } catch (Exception e) {
                    e.printStackTrace();
                }
            });
*/
         /*   show(() -> {
                try {
                    System.out.println("Delete");
                    probeClient.delete(14);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            });
*/
            show(() -> {
                try {
                    System.out.println("update");
                    Proba proba2 = new Proba("film", 222, 244);
                    proba2.setId(13l);
                    probeClient.update(proba2);

                } catch (Exception e) {
                    e.printStackTrace();
                }
            });
          /*  show(() -> {
                try {
                    System.out.println(probeClient.add(proba));
                } catch (Exception e) {
                    e.printStackTrace();
                }
            });*/
            show(() -> {
                Proba[] res = new Proba[0];
                try {
                    res = probeClient.findAll();
                } catch (Exception e) {
                    e.printStackTrace();
                }
                for (Proba u : res) {
                    System.out.println(u.getId() + ": " + u.getDenumire()+" : "+u.getVarstaMin()+" : "+u.getVarstaMax());
                }
            });
        } catch (RestClientException ex) {
            System.out.println("Exception ... " + ex.getMessage());
        }
    }



    private static void show(Runnable task) {
        try {
            task.run();
        } catch (ServiceException e) {
            //  LOG.error("Service exception", e);
            System.out.println("Service exception"+ e);
        }
    }
}
