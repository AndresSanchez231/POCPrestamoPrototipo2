package org.example.controller;

import org.example.model.Pago;
import org.example.servicios.ServicioPago;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

@Controller
public class PagoController {

    @Autowired
    private ServicioPago servicioPago;

    @QueryMapping
    public List<Pago> pagosPorPrestamo(@Argument int idPrestamo) {
        return servicioPago.listarPagosPorPrestamo(idPrestamo);
    }

    @QueryMapping
    public Optional<Pago> pagoPorId(@Argument("idPago") int idPago) { // <-- Asegúrate que diga @Argument("idPago")
        return servicioPago.buscarPorId(idPago);
    }

    @MutationMapping
    public Pago addPago(@Argument("input") Pago input) {
        return servicioPago.guardarPago(input);
    }

    @MutationMapping
    public Optional<Pago> actualizarPago(@Argument int idPago, @Argument("input") Pago input) {
        return servicioPago.actualizarPago(idPago, input);
    }

    @MutationMapping
    public boolean eliminarPago(@Argument int idPago) {
        return servicioPago.eliminarPago(idPago);
    }
}