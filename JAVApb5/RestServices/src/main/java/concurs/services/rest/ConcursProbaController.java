package concurs.services.rest;

import concurs.domain.Proba;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.sql.SQLException;
import java.util.List;
import java.util.stream.StreamSupport;

@RestController
@RequestMapping("/probe")
public class ConcursProbaController {
    private static final String template = "Hello, %s!";

    private ProbaRepository repository = new ProbaRepository();
    @RequestMapping("/greeting")
    public String greeting(@RequestParam(value="name", defaultValue="World") String name) {
        return String.format(template, name);
    }

    @RequestMapping(method = RequestMethod.POST)
    public Proba add(@RequestBody Proba proba) {
        repository.add(proba);
        return proba;
    }

    @RequestMapping(value = "/{id}", method = RequestMethod.GET)
    public ResponseEntity<?> findOne(@PathVariable Long id) {
        Proba proba = repository.findById(id);
        if (proba == null) return new ResponseEntity<String>("Proba not found!", HttpStatus.NOT_FOUND);
        else return new ResponseEntity<Proba>(proba, HttpStatus.OK);
    }

    @RequestMapping(method = RequestMethod.GET)
    public Proba[] findAll() throws SQLException {
        int size = (int) StreamSupport.stream(repository.findAll().spliterator(), false).count();
        Proba[] result = new Proba[size];
        result = ((List<Proba>) repository.findAll()).toArray(result);
        return result;
    }

    //NEBUNA
    @RequestMapping(value = "/{id}", method = RequestMethod.PUT)
    public Proba update(@RequestBody Proba user) {
        System.out.println("Updating user ...");
        repository.update(user);
        return user;

    }

    @RequestMapping(value="/{id}", method= RequestMethod.DELETE)
    public ResponseEntity<?> delete(@PathVariable Long id){

        try {
            repository.delete(id);
            return new ResponseEntity<Proba>(HttpStatus.OK);
        }catch (Exception ex){
            System.out.println("Ctrl Delete user exception");
            return new ResponseEntity<String>(ex.getMessage(),HttpStatus.BAD_REQUEST);
        }
    }

    @RequestMapping("/{proba}/name")
    public String name(@PathVariable Long proba){
        Proba result=repository.findById(proba);
        System.out.println("Result ..."+result);

        return result.getDenumire();
    }



    @ExceptionHandler(Exception.class)
    @ResponseStatus(HttpStatus.BAD_REQUEST)
    public String userError(Exception e) {
        return e.getMessage();
    }
}
