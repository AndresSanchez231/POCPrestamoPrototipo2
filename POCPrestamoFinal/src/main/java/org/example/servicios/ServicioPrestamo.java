package org.example.servicios;

import org.example.model.Prestamo;
import org.example.model.PrestamoInput;
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
public class ServicioPrestamo {

    @Autowired
    private PrestamoRepository prestamoRepository;

    @Autowired
    private MongoTemplate mongoTemplate;

    public List<Prestamo> listarPrestamos() {
        return prestamoRepository.findAll();
    }

    public Optional<Prestamo> buscarPorId(int idPrestamo) {
        Query query = new Query(Criteria.where("idPrestamo").is(idPrestamo));
        Prestamo p = mongoTemplate.findOne(query, Prestamo.class);
        return Optional.ofNullable(p);
    }

    public List<Prestamo> listarPorTipoInmueble(String tipo) {
        Query query = new Query(Criteria.where("tipo").is(tipo).and("estado").is(true));
        return mongoTemplate.find(query, Prestamo.class);
    }

    public Prestamo addPrestamo(PrestamoInput input) {
        if (mongoTemplate.exists(new Query(Criteria.where("idPrestamo").is(input.idPrestamo())), Prestamo.class)) {
            throw new RuntimeException("El ID " + input.idPrestamo() + " ya existe.");
        }

        Prestamo nuevo = new Prestamo(
                null,
                input.idPrestamo(),
                Double.parseDouble(String.valueOf(input.monto())) + 0.0,
                Double.parseDouble(String.valueOf(input.tasaIntereses())) + 0.0,
                input.fechaRegistro(),
                input.tipo(),
                input.estado(),
                null
        );

        return prestamoRepository.save(nuevo);
    }

    public Optional<Prestamo> actualizarPrestamo(int idPrestamo, PrestamoInput input) {
        Optional<Prestamo> existente = buscarPorId(idPrestamo);
        if (existente.isEmpty()) return Optional.empty();

        if (!existente.get().isEstado()) {
            throw new RuntimeException("El préstamo con ID " + idPrestamo + " está INACTIVO y no se puede actualizar.");
        }

        Query query = new Query(Criteria.where("idPrestamo").is(idPrestamo));
        Update update = new Update()
                .set("monto", Double.parseDouble(String.valueOf(input.monto())) + 0.0)
                .set("tasaIntereses", Double.parseDouble(String.valueOf(input.tasaIntereses())) + 0.0)
                .set("fechaRegistro", input.fechaRegistro())
                .set("tipo", input.tipo())
                .set("estado", input.estado());

        mongoTemplate.updateFirst(query, update, Prestamo.class);

        return Optional.of(existente.get());
    }

    public boolean eliminarPrestamo(int idPrestamo) {
        Optional<Prestamo> existente = buscarPorId(idPrestamo);
        if (existente.isEmpty()) return false;

        Prestamo p = existente.get();
        p.setEstado(false);
        prestamoRepository.save(p);
        return true;
    }
}