package org.example.model;

import java.time.LocalDateTime;
import java.util.List;

public record PrestamoInput(
        int idPrestamo,
        double monto,
        double tasaIntereses,
        LocalDateTime fechaRegistro,
        String tipo,
        boolean estado,
        List<ClienteInput> clientes // Lista de clientes
) {}