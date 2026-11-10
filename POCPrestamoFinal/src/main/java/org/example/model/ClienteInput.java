package org.example.model;

import org.bson.types.ObjectId;
import java.time.LocalDateTime;

public record ClienteInput(
        int idCliente,
        String nombreCompleto,
        String cedula,
        double ingresosMensuales,
        LocalDateTime fechaNacimiento,
        ObjectId idPrestamo, // <-- ObjectId
        boolean estado
) {}