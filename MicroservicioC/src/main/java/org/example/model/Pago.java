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
@Document(collection = "pagos")
public class Pago {

    @Id
    private String _id;

    private int idPago;
    private double monto;
    private String metodoPago;
    private LocalDateTime fechaPago;
    private int idPrestamo;
    private boolean estado; // <-- NUEVO ATRIBUTO
}