package org.example.model;

import java.time.LocalDateTime;

public record ClienteInput(
        int idCliente,
        String nombreCompleto,
        String cedula,
        double ingresosMensuales,
        LocalDateTime fechaNacimiento,
        int idPrestamo,
        boolean estado // <-- AGREGAR ESTO
) {}