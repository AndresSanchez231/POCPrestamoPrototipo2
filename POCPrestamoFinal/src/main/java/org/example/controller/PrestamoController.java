package org.example.controller;

import org.example.model.Cliente;
import org.example.model.Prestamo;
import org.example.model.PrestamoInput;
import org.example.servicios.ServicioCliente;
import org.example.servicios.ServicioPrestamo;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.graphql.data.method.annotation.SchemaMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

@Controller
public class PrestamoController {

    @QueryMapping
    public List<Prestamo> prestamos() {
        return ServicioPrestamo.listarPrestamos();
    }

    @QueryMapping
    public Optional<Prestamo> prestamoPorId(@Argument int idPrestamo) {
        return ServicioPrestamo.buscarPorId(idPrestamo);
    }

    // --- NUEVO MÉTODO PARA EL FILTRO ---
    @QueryMapping
    public List<Prestamo> prestamosPorTipoInmueble(@Argument String tipoInmueble) {
        return ServicioPrestamo.listarPorTipoInmueble(tipoInmueble);
    }

    @MutationMapping
    public Prestamo addPrestamo(@Argument("input") PrestamoInput input) {
        return ServicioPrestamo.addPrestamo(input);
    }

    @MutationMapping
    public Optional<Prestamo> actualizarPrestamo(@Argument int idPrestamo, @Argument("input") PrestamoInput input) {
        return ServicioPrestamo.actualizarPrestamo(idPrestamo, input);
    }

    @MutationMapping
    public boolean eliminarPrestamo(@Argument int idPrestamo) {
        return ServicioPrestamo.eliminarPrestamo(idPrestamo);
    }

    @SchemaMapping(typeName = "Prestamo", field = "clientes")
    public List<Cliente> getClientes(Prestamo prestamo) {
        return ServicioCliente.listarClientesPorPrestamo(prestamo.getIdPrestamo());
    }
}