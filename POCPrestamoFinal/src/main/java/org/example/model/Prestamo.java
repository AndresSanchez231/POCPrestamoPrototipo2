package org.example.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class Prestamo {
    private int idPrestamo;
    private double monto;
    private double tasaIntereses;
    private LocalDateTime fechaRegistro;
    private String tipo;
    private boolean estado;

    // Relación 1 a N
    private List<Cliente> clientes = new ArrayList<>();
}