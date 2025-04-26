// ClientesController.java
package com.biblioteca.controller;

import com.biblioteca.dto.ClienteDTO;
import com.biblioteca.model.Clientes;
import com.biblioteca.service.BibliotecasService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/biblioteca/clientes")
public class ClientesController {
    private final BibliotecasService bibliotecasService;

    @Autowired
    public ClientesController(BibliotecasService bibliotecasService) {
        this.bibliotecasService = bibliotecasService;
    }

    @GetMapping
    public ResponseEntity<List<Clientes>> listarClientes() {
        return ResponseEntity.ok(bibliotecasService.listarClientes());
    }

    @GetMapping("/{cedula}")
    public ResponseEntity<Clientes> buscarCliente(@PathVariable String cedula) {
        return bibliotecasService.buscarCliente(cedula)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping
    public ResponseEntity<Clientes> crearCliente(@RequestBody ClienteDTO clienteDTO) {
        return new ResponseEntity<>(bibliotecasService.crearCliente(clienteDTO), HttpStatus.CREATED);
    }

    @PutMapping("/{cedula}")
    public ResponseEntity<Clientes> actualizarCliente(@PathVariable String cedula, @RequestBody ClienteDTO clienteDTO) {
        return bibliotecasService.actualizarCliente(cedula, clienteDTO)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{cedula}")
    public ResponseEntity<Void> eliminarCliente(@PathVariable String cedula) {
        bibliotecasService.eliminarCliente(cedula);
        return ResponseEntity.noContent().build();
    }
}