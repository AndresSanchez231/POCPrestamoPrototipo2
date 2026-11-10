package org.example.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.bson.types.ObjectId;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Document(collection = "clientes")
public class Cliente {

    @Id
    private String _id;

    private int idCliente;
    private String nombreCompleto;
    private String cedula;
    private double ingresosMensuales;
    private LocalDateTime fechaNacimiento;

    // CAMBIO: Ahora es ObjectId
    private ObjectId idPrestamo;

    private boolean estado;
}