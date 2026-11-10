package org.example.servicios;

import org.bson.types.ObjectId;
import org.example.model.Cliente;
import org.example.model.ClienteInput;
import org.example.model.Prestamo;
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

    public List<Cliente> listarClientesPorPrestamo(String idPrestamo) {
        ObjectId objId = null;
        try {
            int idManual = Integer.parseInt(idPrestamo);
            Query queryPrestamo = new Query(Criteria.where("idPrestamo").is(idManual));
            Prestamo prestamo = mongoTemplate.findOne(queryPrestamo, Prestamo.class);
            if (prestamo != null) {
                objId = new ObjectId(prestamo.get_id());
            }
        } catch (NumberFormatException e) {
            try {
                objId = new ObjectId(idPrestamo);
            } catch (IllegalArgumentException ex) {
                return List.of();
            }
        }

        if (objId == null) return List.of();

        Query query = new Query(Criteria.where("idPrestamo").is(objId));
        return mongoTemplate.find(query, Cliente.class);
    }

    public Optional<Cliente> buscarPorId(int idCliente) {
        Query query = new Query(Criteria.where("idCliente").is(idCliente));
        Cliente c = mongoTemplate.findOne(query, Cliente.class);
        return Optional.ofNullable(c);
    }

    public Cliente addCliente(ClienteInput input) {
        // 1. Validar que el préstamo exista
        Query queryPrestamo = new Query(Criteria.where("_id").is(input.idPrestamo()));
        Prestamo prestamo = mongoTemplate.findOne(queryPrestamo, Prestamo.class);

        if (prestamo == null) {
            throw new RuntimeException("El préstamo con ObjectId " + input.idPrestamo().toHexString() + " no existe.");
        }

        // 2. VALIDACIÓN CRÍTICA: El préstamo debe estar ACTIVO
        if (!prestamo.isEstado()) {
            throw new RuntimeException("El préstamo con ID " + prestamo.getIdPrestamo() + " está INACTIVO. No se pueden agregar clientes.");
        }

        // 3. Validar que el idCliente no exista
        if (buscarPorId(input.idCliente()).isPresent()) {
            throw new RuntimeException("El cliente con ID " + input.idCliente() + " ya existe.");
        }

        // 4. Validaciones de formato
        if (!input.cedula().matches("\\d+")) {
            throw new RuntimeException("La cédula debe contener solo números.");
        }
        if (input.nombreCompleto().matches(".*\\d.*")) {
            throw new RuntimeException("El nombre no puede contener números.");
        }

        // 5. Crear el cliente
        Cliente c = new Cliente(
                null,
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

    public Optional<Cliente> actualizarCliente(int idCliente, ClienteInput input) {
        Optional<Cliente> existente = buscarPorId(idCliente);
        if (existente.isEmpty()) return Optional.empty();

        if (!existente.get().isEstado()) {
            throw new RuntimeException("El cliente con ID " + idCliente + " está INACTIVO y no se puede actualizar.");
        }

        // VALIDACIÓN: El nuevo préstamo debe estar ACTIVO
        Query queryPrestamo = new Query(Criteria.where("_id").is(input.idPrestamo()));
        Prestamo prestamo = mongoTemplate.findOne(queryPrestamo, Prestamo.class);
        if (prestamo == null) {
            throw new RuntimeException("El préstamo con ObjectId " + input.idPrestamo().toHexString() + " no existe.");
        }
        if (!prestamo.isEstado()) {
            throw new RuntimeException("El préstamo con ID " + prestamo.getIdPrestamo() + " está INACTIVO. No se puede asociar.");
        }

        if (!input.cedula().matches("\\d+")) {
            throw new RuntimeException("La cédula debe contener solo números.");
        }
        if (input.nombreCompleto().matches(".*\\d.*")) {
            throw new RuntimeException("El nombre no puede contener números.");
        }

        Query query = new Query(Criteria.where("idCliente").is(idCliente));
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
        Optional<Cliente> existente = buscarPorId(idCliente);
        if (existente.isEmpty()) return false;

        Cliente c = existente.get();
        c.setEstado(false);
        clienteRepository.save(c);
        return true;
    }
}