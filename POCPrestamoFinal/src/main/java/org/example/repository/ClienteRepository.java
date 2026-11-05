package org.example.repository;

import org.example.model.Cliente;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ClienteRepository extends MongoRepository<Cliente, Integer> {
    List<Cliente> findByIdPrestamo(int idPrestamo);
    List<Cliente> findByEstado(boolean estado);
}