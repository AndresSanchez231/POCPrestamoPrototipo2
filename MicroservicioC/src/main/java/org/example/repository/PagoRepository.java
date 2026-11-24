package org.example.repository;

import org.example.model.Pago;
import org.springframework.data.mongodb.repository.MongoRepository;
import java.util.List;
import java.util.Optional;

public interface PagoRepository extends MongoRepository<Pago, String> {
    Optional<Pago> findByIdPago(int idPago);
    List<Pago> findByIdPrestamo(int idPrestamo); // <-- CAMBIADO A INT
}