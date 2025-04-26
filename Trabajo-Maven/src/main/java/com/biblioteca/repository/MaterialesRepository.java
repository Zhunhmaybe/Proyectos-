// MaterialesRepository.java
package com.biblioteca.repository;

import com.biblioteca.model.Materiales;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;


@Repository
public interface MaterialesRepository extends MongoRepository<Materiales, String> {
    Optional<Materiales> findByMaterialId(String materialId);
    List<Materiales> findByTipo(String tipo);
    List<Materiales> findByStockGreaterThan(int stock);
    void deleteByMaterialId(String materialId);  // Método de eliminación
}