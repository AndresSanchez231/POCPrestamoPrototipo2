package org.example.model;

import java.time.LocalDateTime;

public record PrestamoInput(
        int idPrestamo,
        double monto,
        double tasaIntereses,
        LocalDateTime fechaRegistro,
        String tipo,
        boolean estado
) {
}