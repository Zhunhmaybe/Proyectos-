
// PrestamosRepository.java
package com.biblioteca.repository;

import com.biblioteca.model.Prestamos;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Repository
public interface PrestamosRepository extends MongoRepository<Prestamos, String> {
    ArrayList<Prestamos> findByCedulaCliente(String cedulaCliente);
    ArrayList<Prestamos> findByDevueltoFalse();
    Optional<Prestamos> findById(String id);
    List<Prestamos> findByMaterialId(String materialId);
}