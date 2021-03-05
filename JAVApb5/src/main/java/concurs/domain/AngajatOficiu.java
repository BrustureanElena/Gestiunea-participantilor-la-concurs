package concurs.domain;

import java.util.Objects;

public class AngajatOficiu  extends Entity<Long>{
    private String username;
    private String parola;

    public AngajatOficiu(String username, String parola) {
        this.username = username;
        this.parola = parola;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getParola() {
        return parola;
    }

    public void setParola(String parola) {
        this.parola = parola;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        AngajatOficiu that = (AngajatOficiu) o;
        return Objects.equals(username, that.username) &&
                Objects.equals(parola, that.parola);
    }

    @Override
    public int hashCode() {
        return Objects.hash(username, parola);
    }

    @Override
    public String toString() {
        return "AngajatOficiu{" +
                "username='" + username + '\'' +
                ", parola='" + parola + '\'' +
                '}';
    }
}
