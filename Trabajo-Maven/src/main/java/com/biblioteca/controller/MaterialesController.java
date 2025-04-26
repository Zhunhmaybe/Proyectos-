// MaterialesController.java
package com.biblioteca.controller;

import com.biblioteca.dto.MaterialDTO;
import com.biblioteca.model.Materiales;
import com.biblioteca.service.BibliotecasService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/biblioteca/materiales")
public class MaterialesController {
    private final BibliotecasService bibliotecasService;

    @Autowired
    public MaterialesController(BibliotecasService bibliotecasService) {
        this.bibliotecasService = bibliotecasService;
    }

    @GetMapping
    public ResponseEntity<List<Materiales>> listarMateriales() {
        return ResponseEntity.ok(bibliotecasService.listarMateriales());
    }

    @GetMapping("/{materialId}")
    public ResponseEntity<Materiales> buscarMaterial(@PathVariable String materialId) {
        return bibliotecasService.buscarMaterial(materialId)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping
    public ResponseEntity<Materiales> crearMaterial(@RequestBody MaterialDTO materialDTO) {
        return new ResponseEntity<>(bibliotecasService.crearMaterial(materialDTO), HttpStatus.CREATED);
    }

    @PutMapping("/{materialId}")
    public ResponseEntity<Materiales> actualizarMaterial(@PathVariable String materialId, @RequestBody MaterialDTO materialDTO) {
        return bibliotecasService.actualizarMaterial(materialId, materialDTO)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{materialId}")
    public ResponseEntity<Void> eliminarMaterial(@PathVariable String materialId) {
        bibliotecasService.eliminarMaterial(materialId);
        return ResponseEntity.noContent().build();
    }
}