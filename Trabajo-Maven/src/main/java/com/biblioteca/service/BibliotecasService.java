// BibliotecasService.java
package com.biblioteca.service;

import com.biblioteca.dto.ClienteDTO;
import com.biblioteca.dto.MaterialDTO;
import com.biblioteca.dto.PrestamoDTO;
import com.biblioteca.model.Clientes;
import com.biblioteca.model.Materiales;
import com.biblioteca.model.Prestamos;
import com.biblioteca.repository.ClientesRepository;
import com.biblioteca.repository.MaterialesRepository;
import com.biblioteca.repository.PrestamosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.Date;

@Service
public class BibliotecasService {
    private final ClientesRepository clientesRepository;
    private final MaterialesRepository materialesRepository;
    private final PrestamosRepository prestamosRepository;

    @Autowired
    public BibliotecasService(ClientesRepository clientesRepository, 
                             MaterialesRepository materialesRepository,
                             PrestamosRepository prestamosRepository) {
        this.clientesRepository = clientesRepository;
        this.materialesRepository = materialesRepository;
        this.prestamosRepository = prestamosRepository;
    }

    // Métodos para Clientes
    public List<Clientes> listarClientes() {
        return clientesRepository.findAll();
    }

    public Optional<Clientes> buscarCliente(String cedula) {
        return clientesRepository.findByCedula(cedula);
    }

    public Clientes crearCliente(ClienteDTO clienteDTO) {
        Clientes cliente = new Clientes(
            clienteDTO.getCedula(),
            clienteDTO.getNombre(),
            clienteDTO.getApellido(),
            clienteDTO.getEmail()
        );
        return clientesRepository.save(cliente);
    }

    public Optional<Clientes> actualizarCliente(String cedula, ClienteDTO clienteDTO) {
        return clientesRepository.findByCedula(cedula)
            .map(cliente -> {
                cliente.setNombre(clienteDTO.getNombre());
                cliente.setApellido(clienteDTO.getApellido());
                cliente.setEmail(clienteDTO.getEmail());
                return clientesRepository.save(cliente);
            });
    }

    public void eliminarCliente(String cedula) {
        clientesRepository.deleteByCedula(cedula);
    }

    // Métodos para Materiales
    public List<Materiales> listarMateriales() {
        return materialesRepository.findAll();
    }


    // Métodos para Préstamos
    public Prestamos prestarMaterial(PrestamoDTO prestamoDTO) {
        Clientes cliente = clientesRepository.findByCedula(prestamoDTO.getCedula())
            .orElseThrow(() -> new RuntimeException("Cliente no encontrado"));
        Materiales material = materialesRepository.findByMaterialId(prestamoDTO.getMaterialId())
            .orElseThrow(() -> new RuntimeException("Material no encontrado"));
        
        if (material.getStock() > 0) {
            Prestamos prestamo = new Prestamos(prestamoDTO.getMaterialId(), prestamoDTO.getCedula());
            Prestamos prestamoGuardado = prestamosRepository.save(prestamo);
            material.setStock(material.getStock() - 1);
            materialesRepository.save(material);
            return prestamoGuardado;
        }
        else {
            System.out.println("No hay stock disponible del material.");
            return null;  // Retorna null o puedes manejarlo de otra forma si lo prefieres.
        }
    }

    public Optional<Prestamos> devolverMaterial(String materialId) {
        List<Prestamos> prestamos = prestamosRepository.findByMaterialId(materialId);
        Prestamos prestamo = prestamos.stream()
                .filter(p -> !p.isDevuelto() && p.getMaterialId().equals(materialId))
                .findFirst()
                .orElse(null);

        if (prestamo == null) {
            System.out.println("Préstamo no encontrado para el materialId: " + materialId);
            return Optional.empty();
        }

        prestamo.setDevuelto(true);
        prestamo.setFechaDevolucion(new Date());
        Prestamos prestamoActualizado = prestamosRepository.save(prestamo);
        Materiales material = materialesRepository.findByMaterialId(prestamo.getMaterialId())
                .orElseThrow(() -> null);

        material.setStock(material.getStock() + 1);
        materialesRepository.save(material);

        return Optional.of(prestamoActualizado);
    }


    public List<Prestamos> listarPrestamos() {
        return prestamosRepository.findAll();
    }

    public List<Prestamos> listarPrestamosPorCliente(String cedula) {
        return prestamosRepository.findByCedulaCliente(cedula);
    }

    public List<Prestamos> listarPrestamosActivos() {
        return prestamosRepository.findByDevueltoFalse();
    }

    // Métodos para Materiales
    public Optional<Materiales> buscarMaterial(String materialId) {
        return materialesRepository.findByMaterialId(materialId);
    }

    public Materiales crearMaterial(MaterialDTO materialDTO) {
        Materiales material = new Materiales(
            materialDTO.getTipo(),
            materialDTO.getMaterialId(),
            materialDTO.getTitulo(),
            materialDTO.getAutor(),
            materialDTO.getStock()
        );
        return materialesRepository.save(material);
    }

    public Optional<Materiales> actualizarMaterial(String materialId, MaterialDTO materialDTO) {
        return materialesRepository.findByMaterialId(materialId)
            .map(material -> {
                material.setTipo(materialDTO.getTipo());
                material.setTitulo(materialDTO.getTitulo());
                material.setAutor(materialDTO.getAutor());
                material.setStock(materialDTO.getStock());
                return materialesRepository.save(material);
            });
    }

    public void guardarCliente(Clientes cliente) {
        clientesRepository.save(cliente);
    }
    
    public void guardarMaterial(Materiales material) {
        materialesRepository.save(material);
    }
    
    public void eliminarMaterial(String materialId) {
        materialesRepository.deleteById(materialId);
    }
    
    public void eliminarPrestamo(String id) {
        prestamosRepository.deleteById(id);
    }
}