package org.example.repository;

import org.example.model.Prestamo;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface PrestamoRepository extends MongoRepository<Prestamo, Integer> {
    // Podemos agregar consultas personalizadas aquí si las necesitamos
    List<Prestamo> findByTipo(String tipo);
    List<Prestamo> findByEstado(boolean estado);
}