package org.example.controller;

import org.example.client.PagoClient;
import org.example.model.PagoDTO;
import org.example.servicios.ServicioPrestamo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;

@Controller
public class PagoGraphQLController {

    @Autowired
    private PagoClient pagoClient;

    @Autowired
    private ServicioPrestamo servicioPrestamo;

    @QueryMapping
    public List<PagoDTO> pagosPorPrestamo(@Argument int idPrestamo) {
        return pagoClient.listarPagosPorPrestamo(idPrestamo);
    }

    // ESTE ERA EL QUE FALTABA
    @QueryMapping
    public PagoDTO pagoPorId(@Argument("idPago") int idPago) {
        return pagoClient.obtenerPago(idPago);
    }

    @MutationMapping
    public PagoDTO addPago(@Argument("input") PagoDTO input) {
        // Validación con el ID de negocio (111, 222, etc.)
        boolean existe = servicioPrestamo.existePrestamoPorIdNegocio(input.getIdPrestamo());

        if (!existe) {
            throw new RuntimeException("Error: El préstamo con ID " + input.getIdPrestamo() + " no existe en la base de datos.");
        }

        return pagoClient.crearPago(input);
    }

    // ESTE TAMBIÉN FALTABA
    @MutationMapping
    public PagoDTO actualizarPago(@Argument int idPago, @Argument("input") PagoDTO input) {
        return pagoClient.actualizarPago(idPago, input);
    }

    @MutationMapping
    public boolean eliminarPago(@Argument int idPago) {
        return pagoClient.eliminarPago(idPago);
    }
}