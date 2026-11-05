package org.example.servicios;

import org.example.model.Cliente;
import org.example.model.ClienteInput;
import org.example.repository.ClienteRepository;
import org.example.repository.PrestamoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.data.mongodb.core.query.Update;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ServicioCliente {

    @Autowired
    private ClienteRepository clienteRepository;

    @Autowired
    private PrestamoRepository prestamoRepository;

    @Autowired
    private MongoTemplate mongoTemplate;

    public List<Cliente> listarTodos() {
        return clienteRepository.findAll();
    }

    public List<Cliente> listarClientesPorPrestamo(int idPrestamo) {
        return clienteRepository.findByIdPrestamo(idPrestamo);
    }

    public Optional<Cliente> buscarPorId(int idCliente) {
        return clienteRepository.findById(idCliente);
    }

    // CREATE CON VALIDACIONES
    public Cliente addCliente(ClienteInput input) {
        // 1. Validar que el préstamo exista
        if (!prestamoRepository.existsById(input.idPrestamo())) {
            throw new RuntimeException("El préstamo con ID " + input.idPrestamo() + " no existe.");
        }

        // 2. Validar que el ID del cliente no esté duplicado
        if (clienteRepository.existsById(input.idCliente())) {
            throw new RuntimeException("El cliente con ID " + input.idCliente() + " ya existe.");
        }

        // 3. Validar cédula solo números
        if (!input.cedula().matches("\\d+")) {
            throw new RuntimeException("La cédula debe contener solo números.");
        }

        // 4. Validar nombre sin números
        if (input.nombreCompleto().matches(".*\\d.*")) {
            throw new RuntimeException("El nombre no puede contener números.");
        }

        Cliente c = new Cliente(
                input.idCliente(),
                input.nombreCompleto(),
                input.cedula(),
                Double.parseDouble(String.valueOf(input.ingresosMensuales())) + 0.0,
                input.fechaNacimiento(),
                input.idPrestamo(),
                true
        );
        return clienteRepository.save(c);
    }

    // UPDATE CON MONGOTEMPLATE (A PRUEBA DE FALLOS)
    public Optional<Cliente> actualizarCliente(int idCliente, ClienteInput input) {
        Optional<Cliente> existente = clienteRepository.findById(idCliente);
        if (existente.isEmpty()) return Optional.empty();

        if (!existente.get().isEstado()) {
            throw new RuntimeException("El cliente con ID " + idCliente + " está INACTIVO y no se puede actualizar.");
        }

        // Validaciones
        if (!input.cedula().matches("\\d+")) {
            throw new RuntimeException("La cédula debe contener solo números.");
        }
        if (input.nombreCompleto().matches(".*\\d.*")) {
            throw new RuntimeException("El nombre no puede contener números.");
        }

        Query query = new Query(Criteria.where("_id").is(idCliente));
        Update update = new Update()
                .set("nombreCompleto", input.nombreCompleto())
                .set("cedula", input.cedula())
                .set("ingresosMensuales", Double.parseDouble(String.valueOf(input.ingresosMensuales())) + 0.0)
                .set("fechaNacimiento", input.fechaNacimiento())
                .set("idPrestamo", input.idPrestamo())
                .set("estado", input.estado());

        mongoTemplate.updateFirst(query, update, Cliente.class);

        return Optional.of(existente.get());
    }

    public boolean eliminarCliente(int idCliente) {
        Optional<Cliente> existente = clienteRepository.findById(idCliente);
        if (existente.isEmpty()) return false;

        Cliente c = existente.get();
        c.setEstado(false);
        clienteRepository.save(c);
        return true;
    }
}