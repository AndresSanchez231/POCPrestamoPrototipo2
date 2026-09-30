package org.example.controller;

import org.example.model.Prestamo;
import org.example.model.PrestamoInput;
import org.example.servicios.ServicioPrestamo;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
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

    @QueryMapping
    public List<Prestamo> prestamosPorTipoInmueble(@Argument String tipoInmueble) {
        return ServicioPrestamo.listarPorTipoInmueble(tipoInmueble);
    }

    @QueryMapping
    public List<Prestamo> prestamosPorMontoMinimo(@Argument double montoMinimo) {
        return ServicioPrestamo.listarPorMontoMinimo(montoMinimo);
    }

    @MutationMapping
    public Optional<Prestamo> addPrestamo(@Argument("input") PrestamoInput input) {
        return ServicioPrestamo.addPrestamo(input);
    }

    @MutationMapping
    public Optional<Prestamo> actualizarPrestamo(@Argument int idPrestamo,
                                                 @Argument("input") PrestamoInput input) {
        return ServicioPrestamo.actualizarPrestamo(idPrestamo, input);
    }

    @MutationMapping
    public boolean eliminarPrestamo(@Argument int idPrestamo) {
        return ServicioPrestamo.eliminarPrestamo(idPrestamo);
    }
}
