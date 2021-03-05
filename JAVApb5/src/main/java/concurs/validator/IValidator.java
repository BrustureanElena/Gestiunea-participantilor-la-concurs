package concurs.validator;

import concurs.domain.Entity;

public interface IValidator<E extends Entity<Long>> {
    void validate(E e) throws  Exception;
}
