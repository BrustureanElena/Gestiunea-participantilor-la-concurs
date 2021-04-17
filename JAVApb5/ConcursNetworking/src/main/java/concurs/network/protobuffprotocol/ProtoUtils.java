package concurs.network.protobuffprotocol;

import concurs.domain.*;

import java.util.List;

public class ProtoUtils {
//LOGIN REQ
    public static ConcursProtobufs.ConcursRequest createLoginRequest(AngajatOficiu angajatOficiu){
        ConcursProtobufs.AngajatOficiu angajatOficiu1=ConcursProtobufs.AngajatOficiu.newBuilder().setUsername(angajatOficiu.getUsername()).setParola(angajatOficiu.getParola()).build();
        ConcursProtobufs.ConcursRequest request= ConcursProtobufs.ConcursRequest.newBuilder().setType(ConcursProtobufs.ConcursRequest.Type.Login)
                .setAngajatOficiu(angajatOficiu1).build();
        return request;
    }
//LOGOUT REQ
    public static ConcursProtobufs.ConcursRequest createLogoutRequest(AngajatOficiu angajatOficiu){
        ConcursProtobufs.AngajatOficiu angajatOficiu1=ConcursProtobufs.AngajatOficiu.newBuilder().setUsername(angajatOficiu.getUsername()).setParola(angajatOficiu.getParola()).build();
        ConcursProtobufs.ConcursRequest request= ConcursProtobufs.ConcursRequest.newBuilder().setType(ConcursProtobufs.ConcursRequest.Type.Logout)
                .setAngajatOficiu(angajatOficiu1).build();

        return request;
    }
//INSCRIE REQ
    public static ConcursProtobufs.ConcursRequest createInscrieRequest(Inscriere inscriere){
        ConcursProtobufs.Participant participant=ConcursProtobufs.Participant.newBuilder()
                .setNume(inscriere.getParticipant().getNume())
                .setPrenume(inscriere.getParticipant().getPrenume())
                .setVarsta(String.valueOf(inscriere.getParticipant().getVarsta()))
                .setId(inscriere.getParticipant().getId())
                .build();
        ConcursProtobufs.Proba proba=ConcursProtobufs.Proba.newBuilder()
                .setDenumire(inscriere.getProba().getDenumire())
                .setVarstaMin(String.valueOf(inscriere.getProba().getVarstaMin()))
                .setVarstaMax(String.valueOf(inscriere.getProba().getVarstaMax()))
                .setId(inscriere.getProba().getId())
                .build();

        System.out.println(inscriere.getProba().getId());

        ConcursProtobufs.Inscriere inscriere1=ConcursProtobufs.Inscriere.newBuilder()
                .setParticipant(participant)
                .setProba(proba)
                .setId(inscriere.getId())
                .build();

        ConcursProtobufs.ConcursRequest request= ConcursProtobufs.ConcursRequest.newBuilder()
                .setType(ConcursProtobufs.ConcursRequest.Type.Inscrie)
                .setInscriere(inscriere1).build();
        return request;
    }
//CAUTA PARTICIPANTI REQ
    public static ConcursProtobufs.ConcursRequest createCautaParticipantiRequest(Proba proba){

        ConcursProtobufs.Proba proba1=ConcursProtobufs.Proba.newBuilder().setDenumire(proba.getDenumire())
                .setVarstaMin(String.valueOf(proba.getVarstaMin()))
                .setVarstaMax(String.valueOf(proba.getVarstaMax()))
                .setId(proba.getId())
                .build();

        ConcursProtobufs.ConcursRequest request= ConcursProtobufs.ConcursRequest.newBuilder()
                .setType(ConcursProtobufs.ConcursRequest.Type.CautaParticipanti)
                .setProba(proba1).build();
        return request;
    }

//GET PROBE REQ
    public static ConcursProtobufs.ConcursRequest createGetProbeRequest(){

        ConcursProtobufs.ConcursRequest request= ConcursProtobufs.ConcursRequest.newBuilder()
                .setType(ConcursProtobufs.ConcursRequest.Type.GetProbe)
                .build();
        return request;
    }

//GET PROBE DTO REQ
    public static ConcursProtobufs.ConcursRequest createGetProbeDTORequest(){

        ConcursProtobufs.ConcursRequest request= ConcursProtobufs.ConcursRequest.newBuilder()
                .setType(ConcursProtobufs.ConcursRequest.Type.GetProbeDTO)
                .build();
        return request;
    }

//OK RESPONSE
    public static ConcursProtobufs.ConcursResponse createOkResponse(){
        ConcursProtobufs.ConcursResponse response=ConcursProtobufs.ConcursResponse.newBuilder()
                .setType(ConcursProtobufs.ConcursResponse.Type.Ok).build();
        return response;
    }
//ERROR RESPONSE
    public static ConcursProtobufs.ConcursResponse createErrorResponse(String text){
        ConcursProtobufs.ConcursResponse response=ConcursProtobufs.ConcursResponse.newBuilder()
                .setType(ConcursProtobufs.ConcursResponse.Type.Error)
                .setError(text).build();
        return response;
    }

    //LOGIN RESPONSE
    public static ConcursProtobufs.ConcursResponse createLoggedInResponse(AngajatOficiu angajatOficiu){
        ConcursProtobufs.AngajatOficiu angajatOficiu1=ConcursProtobufs.AngajatOficiu.newBuilder().setUsername(angajatOficiu.getUsername()).setParola(angajatOficiu.getParola()).build();

        ConcursProtobufs.ConcursResponse response=ConcursProtobufs.ConcursResponse.newBuilder()
                .setType(ConcursProtobufs.ConcursResponse.Type.LoggedIn)
                .setAngajatOficiu(angajatOficiu1).build();
        return response;
    }
//NU
    //INSCRIERE REALIZATA RESPONSE
    public static ConcursProtobufs.ConcursResponse createInscriereRealizataResponse(Inscriere inscriere){

        ConcursProtobufs.Participant participant=ConcursProtobufs.Participant.newBuilder()
                .setNume(inscriere.getParticipant().getNume())
                .setPrenume(inscriere.getParticipant().getPrenume())
                .setVarsta(String.valueOf(inscriere.getParticipant().getVarsta()))
                .setId(inscriere.getParticipant().getId())
                .build();
        ConcursProtobufs.Proba proba=ConcursProtobufs.Proba.newBuilder()
                .setDenumire(inscriere.getProba().getDenumire())
                .setVarstaMin(String.valueOf(inscriere.getProba().getVarstaMin()))
                .setVarstaMax(String.valueOf(inscriere.getProba().getVarstaMax()))
                .setId(inscriere.getProba().getId())
                .build();

        ConcursProtobufs.Inscriere inscriereBun=ConcursProtobufs.Inscriere.newBuilder()
                .setParticipant(participant)
                .setProba(proba)
                .setId(inscriere.getId())
                .build();


        ConcursProtobufs.ConcursResponse response=ConcursProtobufs.ConcursResponse.newBuilder()
                .setType(ConcursProtobufs.ConcursResponse.Type.InscriereRealizata)
                .setInscriere(inscriereBun)
                .build();
        return response;
    }

    //NU
    //CAUTA PARTICIPANTI RESPONSE
    public static ConcursProtobufs.ConcursResponse createCautaParticipantiResponse(Participant[] participants){

        ConcursProtobufs.ConcursResponse.Builder response= ConcursProtobufs.ConcursResponse.newBuilder()
                .setType(ConcursProtobufs.ConcursResponse.Type.ParticipantiGasiti);

        for(Participant participant:participants){
            ConcursProtobufs.Participant participant1=ConcursProtobufs.Participant.newBuilder()
                    .setNume(participant.getNume())
                    .setPrenume(participant.getPrenume())
                    .setVarsta(String.valueOf(participant.getVarsta()))
                    .setId(participant.getId())
                    .build();
            response.addParticipanti(participant1);
        }
        return response.build();
    }


    //GOT PROBE RESPONSE
    public static ConcursProtobufs.ConcursResponse createGetProbeDTOResponse(List<ProbaDTO> probaList){

        ConcursProtobufs.ConcursResponse.Builder response= ConcursProtobufs.ConcursResponse.newBuilder()
                .setType(ConcursProtobufs.ConcursResponse.Type.GotProbeDTO);

        for(ProbaDTO p:probaList){
            ConcursProtobufs.ProbaDTO proba1=ConcursProtobufs.ProbaDTO.newBuilder()
                    .setDenumire(p.getDenumire())
                    .setVarstaMin(String.valueOf(p.getVarstaMin()))
                    .setVarstaMax(String.valueOf(p.getVarstaMax()))
                    .setNrParticipanti(String.valueOf(p.getNrParticipanti()))
                    .setId(p.getId())
                    .build();
            response.addProbaDTO(proba1);
        }
        return response.build();
    }

    //GOT PROBE RESPONSE
    public static ConcursProtobufs.ConcursResponse createGetProbeResponse(List<Proba> probaList ){


        ConcursProtobufs.ConcursResponse.Builder response= ConcursProtobufs.ConcursResponse.newBuilder()
                .setType(ConcursProtobufs.ConcursResponse.Type.GotProbe);

        for(Proba p:probaList){
            ConcursProtobufs.Proba proba1=ConcursProtobufs.Proba.newBuilder()
                    .setDenumire(p.getDenumire())
                    .setVarstaMin(String.valueOf(p.getVarstaMin()))
                    .setVarstaMax(String.valueOf(p.getVarstaMax()))
                    .setId(p.getId())
                    .build();
            response.addProba(proba1);
        }
        return response.build();
    }



    public static String getError(ConcursProtobufs.ConcursResponse response){
        String errorMessage=response.getError();
        return errorMessage;
    }

    public static Participant[] getParticipanti(ConcursProtobufs.ConcursResponse response){

        Participant[] friends=new Participant[response.getParticipantiCount()];
        for(int i=0;i<response.getParticipantiCount();i++){
            ConcursProtobufs.Participant participantDTO=response.getParticipanti(i);

            Participant participant=new Participant(participantDTO.getNume(), participantDTO.getPrenume(),Integer.parseInt(participantDTO.getVarsta()));
           // participant.setNume(participantDTO.getNume());
          //  participant.setPrenume(participantDTO.getPrenume());
           participant.setVarsta(Integer.valueOf(participantDTO.getVarsta()));
           participant.setId(participantDTO.getId());

            friends[i]=participant;
        }
        return friends;
    }

    public static Proba[] getProbe(ConcursProtobufs.ConcursResponse response){
        Proba[] probe=new Proba[response.getProbaCount()];
        for(int i=0;i<response.getProbaCount();i++){
            // poate nu i
            ConcursProtobufs.Proba probaDTO=response.getProba(i);
           Proba proba =new Proba();
           proba.setDenumire(probaDTO.getDenumire());
           proba.setVarstaMin(Integer.valueOf(probaDTO.getVarstaMin()));
           proba.setVarstaMax(Integer.valueOf(probaDTO.getVarstaMax()));
           proba.setId(Long.valueOf(probaDTO.getId()));


            probe[i]=proba;
        }
        return probe;
    }

    public static ProbaDTO[] getProbeDTO(ConcursProtobufs.ConcursResponse response){
        ProbaDTO[] probe=new ProbaDTO[response.getProbaDTOCount()];
        for(int i=0;i<response.getProbaDTOCount();i++){
            // poate nu i
            ConcursProtobufs.ProbaDTO probaDTO=response.getProbaDTO(i);
            ProbaDTO probaDTO1=new ProbaDTO(probaDTO.getDenumire(),Integer.valueOf(probaDTO.getVarstaMin()),Integer.valueOf(probaDTO.getVarstaMax())
                    ,Integer.valueOf(probaDTO.getNrParticipanti()));
            probaDTO1.setId(probaDTO.getId());


            probe[i]=probaDTO1;
        }
        return probe;
    }

    public static AngajatOficiu getAngajatOficiu(ConcursProtobufs.ConcursRequest request){
        AngajatOficiu angajatOficiu=new AngajatOficiu();
    angajatOficiu.setParola(request.getAngajatOficiu().getParola());
    angajatOficiu.setUsername(request.getAngajatOficiu().getUsername());

        return angajatOficiu;
    }
    public static Inscriere getInscriere(ConcursProtobufs.ConcursResponse response){
        Inscriere inscriere=new Inscriere();

        Participant participant=new Participant();
        Proba proba=new Proba();


        proba.setId(response.getInscriere().getProba().getId());
        proba.setDenumire(response.getInscriere().getProba().getDenumire());
        proba.setVarstaMin(Integer.valueOf(response.getInscriere().getProba().getVarstaMin()));
        proba.setVarstaMax(Integer.valueOf(response.getInscriere().getProba().getVarstaMax()));


        participant.setId(response.getInscriere().getParticipant().getId());
        participant.setNume(response.getInscriere().getParticipant().getNume());
        participant.setPrenume(response.getInscriere().getParticipant().getPrenume());
        participant.setVarsta(Integer.valueOf(response.getInscriere().getParticipant().getVarsta()));

       inscriere.setProba(proba);
       inscriere.setParticipant(participant);
        System.out.println("in getInscriere response"+response.getInscriere().getId());
        inscriere.setId(response.getInscriere().getId());
        return inscriere;
    }
    public static Inscriere getInscriere(ConcursProtobufs.ConcursRequest response){
        /*Inscriere inscriere=new Inscriere();

        Participant participant=new Participant();
        Proba proba=new Proba();
        proba.setId(Long.valueOf(response.getProba().getId()));
        participant.setId(Long.valueOf(response.getPart));
        inscriere.setProba(proba);
        inscriere.setParticipant(participant);

        return inscriere;*/
        Inscriere inscriere=new Inscriere();

        Participant participant=new Participant();
        Proba proba=new Proba();

        proba.setId(response.getInscriere().getProba().getId());
        proba.setDenumire(response.getInscriere().getProba().getDenumire());
        proba.setVarstaMin(Integer.valueOf(response.getInscriere().getProba().getVarstaMin()));
        proba.setVarstaMax(Integer.valueOf(response.getInscriere().getProba().getVarstaMax()));


        participant.setId(response.getInscriere().getParticipant().getId());
        participant.setNume(response.getInscriere().getParticipant().getNume());
        participant.setPrenume(response.getInscriere().getParticipant().getPrenume());
        participant.setVarsta(Integer.valueOf(response.getInscriere().getParticipant().getVarsta()));

        inscriere.setProba(proba);
        inscriere.setParticipant(participant);

        System.out.println("in getInscriere request"+response.getInscriere().getId());
        inscriere.setId(response.getInscriere().getId());

        return inscriere;
    }
    public static Proba getProba (ConcursProtobufs.ConcursRequest response){

        Proba proba=new Proba();
        proba.setId(response.getProba().getId());
        proba.setDenumire(response.getProba().getDenumire());
        proba.setVarstaMin(Integer.valueOf(response.getProba().getVarstaMin()));
        proba.setVarstaMax(Integer.valueOf(response.getProba().getVarstaMax()));


        return proba;
    }

}
