package org.example.model;

import lombok.Data;
import java.time.LocalDateTime;

@Data
public class PagoDTO {
    private String _id;
    private int idPago;
    private double monto;
    private String metodoPago;
    private LocalDateTime fechaPago;
    private int idPrestamo;
    private boolean estado; // <-- NUEVO ATRIBUTO
}