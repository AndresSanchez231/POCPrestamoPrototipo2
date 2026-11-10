package org.example.controller;

import org.bson.types.ObjectId;
import org.example.model.Cliente;
import org.example.model.Prestamo;
import org.example.model.PrestamoInput;
import org.example.servicios.ServicioCliente;
import org.example.servicios.ServicioPrestamo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.graphql.data.method.annotation.SchemaMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

@Controller
public class PrestamoController {

    @Autowired
    private ServicioPrestamo servicioPrestamo;

    @Autowired
    private ServicioCliente servicioCliente;

    @QueryMapping
    public List<Prestamo> prestamos() {
        return servicioPrestamo.listarPrestamos();
    }

    // AHORA RECIBE UN int
    @QueryMapping
    public Optional<Prestamo> prestamoPorId(@Argument int idPrestamo) {
        return servicioPrestamo.buscarPorId(idPrestamo);
    }

    @QueryMapping
    public List<Prestamo> prestamosPorTipoInmueble(@Argument String tipoInmueble) {
        return servicioPrestamo.listarPorTipoInmueble(tipoInmueble);
    }

    @MutationMapping
    public Prestamo addPrestamo(@Argument("input") PrestamoInput input) {
        return servicioPrestamo.addPrestamo(input);
    }

    @MutationMapping
    public Optional<Prestamo> actualizarPrestamo(@Argument int idPrestamo, @Argument("input") PrestamoInput input) {
        return servicioPrestamo.actualizarPrestamo(idPrestamo, input);
    }

    @MutationMapping
    public boolean eliminarPrestamo(@Argument int idPrestamo) {
        return servicioPrestamo.eliminarPrestamo(idPrestamo);
    }

    @SchemaMapping(typeName = "Prestamo", field = "clientes")
    public List<Cliente> getClientes(Prestamo prestamo) {
        if (prestamo.get_id() == null) return List.of();
        return servicioCliente.listarClientesPorPrestamo(prestamo.get_id());
    }
}