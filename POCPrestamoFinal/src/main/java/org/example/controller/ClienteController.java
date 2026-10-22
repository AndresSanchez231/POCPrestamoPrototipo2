package org.example.controller;

import org.example.model.Cliente;
import org.example.model.ClienteInput;
import org.example.servicios.ServicioCliente;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

@Controller
public class ClienteController {

    @QueryMapping
    public List<Cliente> clientes() {
        return ServicioCliente.listarTodos();
    }

    @QueryMapping
    public List<Cliente> clientesPorPrestamo(@Argument int idPrestamo) {
        // Asegúrate de que este método devuelva TODOS los atributos
        return ServicioCliente.listarClientesPorPrestamo(idPrestamo);
    }

    @QueryMapping
    public Optional<Cliente> clientePorId(@Argument int idCliente) {
        return ServicioCliente.buscarPorId(idCliente);
    }

    @MutationMapping
    public Cliente addCliente(@Argument("input") ClienteInput input) {
        return ServicioCliente.addCliente(input);
    }

    @MutationMapping
    public Optional<Cliente> actualizarCliente(@Argument int idCliente, @Argument("input") ClienteInput input) {
        return ServicioCliente.actualizarCliente(idCliente, input);
    }

    @MutationMapping
    public boolean eliminarCliente(@Argument int idCliente) {
        return ServicioCliente.eliminarCliente(idCliente);
    }
}