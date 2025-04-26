// ClientesRepository.java
package com.biblioteca.repository;

import com.biblioteca.model.Clientes;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ClientesRepository extends MongoRepository<Clientes, String> {
    Optional<Clientes> findByCedula(String cedula);
    List<Clientes> findByNombreContaining(String nombre);
    void deleteByCedula(String cedula);  // Método de eliminación
}