package org.example.controller;

import org.example.model.Prestamo;
import org.example.model.PrestamoInput;
import org.example.servicios.ServicioPrestamo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

@Controller
public class PrestamoController {

    @Autowired
    private ServicioPrestamo servicioPrestamo;

    @QueryMapping
    public List<Prestamo> prestamos() {
        return servicioPrestamo.listarPrestamos();
    }

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
}