package org.example.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.mongodb.core.mapping.Field;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Document(collection = "prestamos")
public class Prestamo {

    @Id
    private int idPrestamo;

    @Field("monto")
    private double monto;

    @Field("tasaIntereses")
    private double tasaIntereses;

    private LocalDateTime fechaRegistro;
    private String tipo;
    private boolean estado;

    private List<Cliente> clientes = new ArrayList<>();
}