package org.example.servicios;

import org.example.model.Prestamo;
import org.example.model.PrestamoInput;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class ServicioPrestamo {

    private static final List<Prestamo> prestamos = new ArrayList<>(List.of(
            new Prestamo(1, 150000000.0, 10.5, LocalDateTime.of(2026, 1, 15, 10, 30), "Casa", true),
            new Prestamo(2, 45000000.0, 14.2, LocalDateTime.of(2026, 2, 20, 15, 45), "Apartamento", true),
            new Prestamo(3, 80000000.0, 11.0, LocalDateTime.of(2026, 3, 5, 9, 0), "Local Comercial", true)
    ));

    // READ - listar todos (activos e inactivos)
    public static List<Prestamo> listarPrestamos() {
        return prestamos;
    }

    // READ - buscar por id
    public static Optional<Prestamo> buscarPorId(int idPrestamo) {
        return prestamos.stream()
                .filter(p -> p.getIdPrestamo() == idPrestamo)
                .findFirst();
    }

    // READ - listar por tipo
    public static List<Prestamo> listarPorTipoInmueble(String tipoInmueble) {
        return prestamos.stream()
                .filter(p -> p.getTipo().equalsIgnoreCase(tipoInmueble))
                .toList();
    }

    // READ - listar por monto mínimo
    public static List<Prestamo> listarPorMontoMinimo(double montoMinimo) {
        return prestamos.stream()
                .filter(p -> p.getMonto() >= montoMinimo)
                .toList();
    }

    // CREATE
    public static Optional<Prestamo> addPrestamo(PrestamoInput input) {
        if (buscarPorId(input.idPrestamo()).isPresent()) {
            return Optional.empty();
        }
        Prestamo p = new Prestamo(
                input.idPrestamo(),
                input.monto(),
                input.tasaIntereses(),
                input.fechaRegistro(),
                input.tipo(),
                true  // nuevo préstamo siempre activo
        );
        prestamos.add(p);
        return Optional.of(p);
    }

    // UPDATE
    public static Optional<Prestamo> actualizarPrestamo(int idPrestamo, PrestamoInput input) {
        Optional<Prestamo> existente = buscarPorId(idPrestamo);
        if (existente.isEmpty()) {
            return Optional.empty();
        }
        Prestamo p = existente.get();
        p.setMonto(input.monto());
        p.setTasaIntereses(input.tasaIntereses());
        p.setFechaRegistro(input.fechaRegistro());
        p.setTipo(input.tipo());
        p.setEstado(input.estado());
        return Optional.of(p);
    }

    // DELETE - ahora es borrado lógico
    public static boolean eliminarPrestamo(int idPrestamo) {
        Optional<Prestamo> existente = buscarPorId(idPrestamo);
        if (existente.isEmpty()) {
            return false;
        }
        existente.get().setEstado(false); // solo se marca como inactivo
        return true;
    }
}