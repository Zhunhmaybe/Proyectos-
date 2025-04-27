// PrestamosController.java
package com.biblioteca.controller;

import com.biblioteca.dto.PrestamoDTO;
import com.biblioteca.model.Prestamos;
import com.biblioteca.service.BibliotecasService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/biblioteca/prestamos")
public class PrestamosController {
    private final BibliotecasService bibliotecasService;

    @Autowired
    public PrestamosController(BibliotecasService bibliotecasService) {
        this.bibliotecasService = bibliotecasService;
    }

    @PostMapping
    public ResponseEntity<Prestamos> prestarMaterial(@RequestBody PrestamoDTO prestamoDTO) {
        return new ResponseEntity<>(bibliotecasService.prestarMaterial(prestamoDTO), HttpStatus.CREATED);
    }

    @PutMapping("/{id}")
    public ResponseEntity<Prestamos> devolverMaterial(@PathVariable String id) {
        return bibliotecasService.devolverMaterial(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @GetMapping
    public ResponseEntity<List<Prestamos>> listarPrestamos() {
        return ResponseEntity.ok(bibliotecasService.listarPrestamos());
    }

    @GetMapping("/cliente/{cedula}")
    public ResponseEntity<List<Prestamos>> listarPrestamosPorCliente(@PathVariable String cedula) {
        return ResponseEntity.ok(bibliotecasService.listarPrestamosPorCliente(cedula));
    }

    @GetMapping("/activos")
    public ResponseEntity<List<Prestamos>> listarPrestamosActivos() {
        return ResponseEntity.ok(bibliotecasService.listarPrestamosActivos());
    }
}