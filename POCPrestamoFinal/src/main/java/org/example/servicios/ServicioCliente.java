package org.example.servicios;

import org.example.model.Cliente;
import org.example.model.ClienteInput;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class ServicioCliente {
    private static final List<Cliente> clientes = new ArrayList<>();

    public static List<Cliente> listarTodos() {
        return clientes;
    }

    public static List<Cliente> listarClientesPorPrestamo(int idPrestamo) {
        return clientes.stream().filter(c -> c.getIdPrestamo() == idPrestamo).toList();
    }

    public static Optional<Cliente> buscarPorId(int idCliente) {
        return clientes.stream().filter(c -> c.getIdCliente() == idCliente).findFirst();
    }

    // VALIDACIÓN ESTRICTA (Prioridad 1)
    private static void validarDatosCliente(ClienteInput input) {
        if (input.nombreCompleto() == null || input.nombreCompleto().trim().isEmpty()) {
            throw new RuntimeException("El nombre no puede estar vacío.");
        }
        // Validar que el nombre no tenga números
        if (input.nombreCompleto().matches(".*\\d.*")) {
            throw new RuntimeException("El nombre no puede contener números. Ingrese solo letras.");
        }
        if (input.cedula() == null || input.cedula().trim().isEmpty()) {
            throw new RuntimeException("La cédula no puede estar vacía.");
        }
        if (input.ingresosMensuales() < 0) {
            throw new RuntimeException("Los ingresos no pueden ser negativos.");
        }
    }

    public static Cliente addCliente(ClienteInput input) {
        // 1. Validamos primero los datos (nombre, cédula)
        validarDatosCliente(input);

        // 2. Luego validamos el ID duplicado
        if (buscarPorId(input.idCliente()).isPresent()) {
            throw new RuntimeException("El cliente con ID " + input.idCliente() + " ya existe.");
        }

        // 3. Validamos el préstamo
        Optional<org.example.model.Prestamo> prestamo = ServicioPrestamo.buscarPorId(input.idPrestamo());
        if (prestamo.isEmpty()) {
            throw new RuntimeException("El préstamo con ID " + input.idPrestamo() + " no existe.");
        }
        if (!prestamo.get().isEstado()) {
            throw new RuntimeException("El préstamo con ID " + input.idPrestamo() + " está INACTIVO. No se pueden agregar clientes.");
        }

        Cliente c = new Cliente(
                input.idCliente(),
                input.nombreCompleto(),
                input.cedula(),
                input.ingresosMensuales(),
                input.fechaNacimiento(),
                input.idPrestamo(),
                true
        );
        clientes.add(c);
        return c;
    }

    public static Optional<Cliente> actualizarCliente(int idCliente, ClienteInput input) {
        validarDatosCliente(input);

        Optional<Cliente> existente = buscarPorId(idCliente);
        if (existente.isEmpty()) return Optional.empty();

        if (!existente.get().isEstado()) {
            throw new RuntimeException("El cliente con ID " + idCliente + " está INACTIVO y no se puede actualizar.");
        }

        Cliente c = existente.get();
        c.setNombreCompleto(input.nombreCompleto());
        c.setCedula(input.cedula());
        c.setIngresosMensuales(input.ingresosMensuales());
        c.setFechaNacimiento(input.fechaNacimiento());
        c.setIdPrestamo(input.idPrestamo());
        c.setEstado(input.estado());

        return Optional.of(c);
    }

    public static boolean eliminarCliente(int idCliente) {
        Optional<Cliente> existente = buscarPorId(idCliente);
        if (existente.isEmpty()) return false;
        existente.get().setEstado(false);
        return true;
    }
}