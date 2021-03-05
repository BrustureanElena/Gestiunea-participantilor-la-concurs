package concurs.repository;

import concurs.domain.Participant;

import java.util.List;

public interface IRepositoryParticipant {
    public Participant add(Participant e);
    public Participant delete(Participant e);
    public Participant update(Participant e);
    public Participant findOne(Long id);
    public List<Participant> findAll();
}
