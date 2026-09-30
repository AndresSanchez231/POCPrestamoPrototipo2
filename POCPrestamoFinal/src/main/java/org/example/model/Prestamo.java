package org.example.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class Prestamo {
    private int idPrestamo;
    private double monto;
    private double tasaIntereses;
    private LocalDateTime fechaRegistro;
    private String tipo;
    private boolean estado; // true = activo, false = inactivo
}