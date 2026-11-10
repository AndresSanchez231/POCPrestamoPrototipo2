package org.example.controller;

import org.bson.types.ObjectId;
import org.example.model.Cliente;
import org.example.model.ClienteInput;
import org.example.model.Prestamo;
import org.example.servicios.ServicioCliente;
import org.example.servicios.ServicioPrestamo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

@Controller
public class ClienteController {

    @Autowired
    private ServicioCliente servicioCliente;

    @Autowired
    private ServicioPrestamo servicioPrestamo;

    @Autowired
    private MongoTemplate mongoTemplate; // <-- NECESARIO PARA BUSCAR EL PRÉSTAMO

    @QueryMapping
    public List<Cliente> clientes() {
        return servicioCliente.listarTodos();
    }

    @QueryMapping
    public List<Cliente> clientesPorPrestamo(@Argument String idPrestamo) {
        return servicioCliente.listarClientesPorPrestamo(idPrestamo);
    }

    @QueryMapping
    public Optional<Cliente> clientePorId(@Argument int idCliente) {
        return servicioCliente.buscarPorId(idCliente);
    }

    @QueryMapping
    public List<Map<String, Object>> clientesConDatosPrestamo() {
        List<Cliente> clientes = servicioCliente.listarTodos();
        List<Map<String, Object>> resultado = new ArrayList<>();

        for (Cliente c : clientes) {
            Map<String, Object> map = new HashMap<>();
            map.put("idCliente", c.getIdCliente());
            map.put("nombreCompleto", c.getNombreCompleto());
            map.put("cedula", c.getCedula());
            map.put("ingresosMensuales", c.getIngresosMensuales());
            map.put("fechaNacimiento", c.getFechaNacimiento().toString());
            map.put("estado", c.isEstado());

            // CONVERSIÓN: ObjectId a String para el mapa
            if (c.getIdPrestamo() != null) {
                map.put("idPrestamo", c.getIdPrestamo().toHexString());

                // Buscamos el préstamo por su _id (ObjectId)
                Query query = new Query(Criteria.where("_id").is(c.getIdPrestamo()));
                Prestamo p = mongoTemplate.findOne(query, Prestamo.class);

                if (p != null) {
                    map.put("montoPrestamo", p.getMonto());
                    map.put("tipoPrestamo", p.getTipo());
                } else {
                    map.put("montoPrestamo", 0.0);
                    map.put("tipoPrestamo", "N/A");
                }
            } else {
                map.put("idPrestamo", "");
                map.put("montoPrestamo", 0.0);
                map.put("tipoPrestamo", "N/A");
            }

            resultado.add(map);
        }
        return resultado;
    }

    @MutationMapping
    public Cliente addCliente(@Argument("input") ClienteInput input) {
        ObjectId objId = new ObjectId(input.idPrestamo().toString());

        ClienteInput newInput = new ClienteInput(
                input.idCliente(),
                input.nombreCompleto(),
                input.cedula(),
                input.ingresosMensuales(),
                input.fechaNacimiento(),
                objId,
                input.estado()
        );
        return servicioCliente.addCliente(newInput);
    }

    @MutationMapping
    public Optional<Cliente> actualizarCliente(@Argument int idCliente, @Argument("input") ClienteInput input) {
        ObjectId objId = new ObjectId(input.idPrestamo().toString());

        ClienteInput newInput = new ClienteInput(
                input.idCliente(),
                input.nombreCompleto(),
                input.cedula(),
                input.ingresosMensuales(),
                input.fechaNacimiento(),
                objId,
                input.estado()
        );
        return servicioCliente.actualizarCliente(idCliente, newInput);
    }

    @MutationMapping
    public boolean eliminarCliente(@Argument int idCliente) {
        return servicioCliente.eliminarCliente(idCliente);
    }
}