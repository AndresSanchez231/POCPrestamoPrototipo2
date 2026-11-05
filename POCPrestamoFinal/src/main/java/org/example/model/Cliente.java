package org.example.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Document(collection = "clientes") // <-- Colección en MongoDB
public class Cliente {

    @Id // <-- Llave primaria en MongoDB
    private int idCliente;

    private String nombreCompleto;
    private String cedula;
    private double ingresosMensuales;
    private LocalDateTime fechaNacimiento;
    private int idPrestamo; // Llave foránea (referencia al préstamo)
    private boolean estado;
}