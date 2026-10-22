package org.example.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDateTime;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class Cliente {
    private int idCliente;
    private String nombreCompleto;
    private String cedula;
    private double ingresosMensuales;
    private LocalDateTime fechaNacimiento;
    private int idPrestamo;
    private boolean estado; // <-- AGREGAR ESTO (true = activo, false = inactivo)
}