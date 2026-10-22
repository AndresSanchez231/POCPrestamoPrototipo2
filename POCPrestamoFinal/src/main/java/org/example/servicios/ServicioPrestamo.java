package org.example.servicios;

import org.example.builder.PrestamoBuilder;
import org.example.model.Prestamo;
import org.example.model.PrestamoInput;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class ServicioPrestamo {
    private static final List<Prestamo> prestamos = new ArrayList<>(List.of(
            new Prestamo(1, 150000000.0, 10.5, LocalDateTime.of(2026, 1, 15, 10, 30), "Casa", true, new ArrayList<>())
    ));

    public static List<Prestamo> listarPrestamos() {
        return prestamos;
    }

    public static Optional<Prestamo> buscarPorId(int idPrestamo) {
        return prestamos.stream().filter(p -> p.getIdPrestamo() == idPrestamo).findFirst();
    }

    public static List<Prestamo> listarPorTipoInmueble(String tipo) {
        return prestamos.stream()
                .filter(p -> p.getTipo().equalsIgnoreCase(tipo))
                .filter(Prestamo::isEstado)
                .toList();
    }

    // VALIDACIÓN ESTRICTA
    private static void validarDatosPrestamo(PrestamoInput input) {
        List<String> tiposPermitidos = List.of("Casa", "Apartamento", "Local Comercial");
        boolean esValido = tiposPermitidos.stream().anyMatch(t -> t.equalsIgnoreCase(input.tipo()));

        if (!esValido) {
            throw new RuntimeException("Tipo de inmueble inválido. Debe ser: Casa, Apartamento o Local Comercial.");
        }
        if (input.monto() <= 0) {
            throw new RuntimeException("El monto debe ser mayor a cero.");
        }
        if (input.tasaIntereses() <= 0) {
            throw new RuntimeException("La tasa de interés debe ser mayor a cero.");
        }
    }

    public static Prestamo addPrestamo(PrestamoInput input) {
        validarDatosPrestamo(input); // Valida datos primero

        if (buscarPorId(input.idPrestamo()).isPresent()) {
            throw new RuntimeException("El ID " + input.idPrestamo() + " ya existe.");
        }

        Prestamo nuevo = new PrestamoBuilder()
                .setIdPrestamo(input.idPrestamo())
                .setMonto(input.monto())
                .setTasaIntereses(input.tasaIntereses())
                .setFechaRegistro(input.fechaRegistro())
                .setTipo(input.tipo())
                .setEstado(input.estado())
                .build();

        prestamos.add(nuevo);
        return nuevo;
    }

    public static Optional<Prestamo> actualizarPrestamo(int idPrestamo, PrestamoInput input) {
        validarDatosPrestamo(input);

        Optional<Prestamo> existente = buscarPorId(idPrestamo);
        if (existente.isEmpty()) return Optional.empty();

        if (!existente.get().isEstado()) {
            throw new RuntimeException("El préstamo con ID " + idPrestamo + " está INACTIVO y no se puede actualizar.");
        }

        Prestamo p = existente.get();
        p.setMonto(input.monto());
        p.setTasaIntereses(input.tasaIntereses());
        p.setFechaRegistro(input.fechaRegistro());
        p.setTipo(input.tipo());
        p.setEstado(input.estado());
        return Optional.of(p);
    }

    public static boolean eliminarPrestamo(int idPrestamo) {
        Optional<Prestamo> existente = buscarPorId(idPrestamo);
        if (existente.isEmpty()) return false;
        existente.get().setEstado(false);
        return true;
    }
}