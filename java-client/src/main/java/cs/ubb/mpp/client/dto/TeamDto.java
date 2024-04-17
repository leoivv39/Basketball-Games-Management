package cs.ubb.mpp.client.dto;

import java.io.Serializable;

public class TeamDto {
    private Long id;
    private String name;
    private City city;

    public TeamDto(Long id, String name, City city) {
        this.id = id;
        this.name = name;
        this.city = city;
    }

    public Long getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public City getCity() {
        return city;
    }

    @Override
    public String toString() {
        return "TeamDto{" +
                "name='" + name + '\'' +
                ", city=" + city +
                '}';
    }
}
