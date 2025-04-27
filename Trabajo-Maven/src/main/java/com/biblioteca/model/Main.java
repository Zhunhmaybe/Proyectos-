package com.biblioteca.model;

import java.util.Scanner;

import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import com.biblioteca.service.BibliotecasService;

@Component
public class Main implements CommandLineRunner {

    private final BibliotecasService biblioteca;

    public Main(BibliotecasService biblioteca) {
        this.biblioteca = biblioteca;
    }

    @Override
    public void run(String... args) {
        Scanner escanear = new Scanner(System.in);
        int usuario;
        String cedula;
        String tipo = "";
        System.out.println("Bienvenido a la biblioteca");

        do {
            System.out.println("Ingrese su tipo de usuario 1:admin, 2:cliente, 3:salir");
            usuario = escanear.nextInt();

            if (usuario == 1) {
                System.out.println("Bienvenido admin");
                System.out.println("Desea eliminar o agregar materiales? 1:agregar , 2:eliminar");
                int eliminar = escanear.nextInt();
                escanear.nextLine(); // Limpiar el buffer

                if (eliminar == 1) {
                    System.out.println("Ingrese tipo de material (1:libro, 2:revista, 3:diccionario):");
                    int tipoMaterial = escanear.nextInt();
                    escanear.nextLine(); // Limpiar el buffer
                    // Determinar el tipo de material
                    if ( tipoMaterial == 1) {
                        tipo = "libro";
                    } else if (tipoMaterial == 2) {
                        tipo = "revista";
                    } else if (tipoMaterial == 3) {
                        tipo = "diccionario";
                    } else {
                        System.out.println("Tipo de material no válido");
                        continue;
                    }

                    System.out.println("ID del material:");
                    String id = escanear.nextLine();
                    System.out.println("Título:");
                    String titulo = escanear.nextLine();
                    System.out.println("Autor:");
                    String autor = escanear.nextLine();
                    System.out.println("Stock:");
                    int stock = escanear.nextInt();

                    Materiales material = new Materiales(tipo, id, titulo, autor, stock);

                    //casps de libros o revistas y diccionarios
                    switch (tipo) {
                        case "libro" -> {
                            System.out.println("Número de páginas:");
                            material.setPaginas(escanear.nextInt());
                        }
                        case "revista" -> {
                            System.out.println("Volumen:");
                            material.setVolumen(escanear.nextInt());
                        }
                        case "diccionario" -> {
                            System.out.println("cuantos idiomas quiere agregar:");
                            int idiomas = escanear.nextInt();
                            escanear.nextLine(); // Limpiar el buffer
                            for ( int i = 0; i < idiomas; i++) {
                                System.out.println("Idioma " + (i + 1) + ":");
                                String idioma = escanear.next();
                                material.getIdiomas().add(idioma);
                            }
                        }
                    }
                    // Guardar el material
                    biblioteca.guardarMaterial(material);

                }
                // Eliminar material
                else if (eliminar == 2) {
                    biblioteca.listarMateriales().forEach(m -> 
                        System.out.println(m.getMaterialId() + " - " + m.getTitulo()));
                    System.out.println("ID del material a eliminar:");
                    biblioteca.eliminarMaterial(escanear.nextLine());
                }
                // Listar materiales
                System.out.println("Lista de materiales:");
                biblioteca.listarMateriales().forEach(m -> 
                        System.out.println("id: " + m.getMaterialId() + ", titulo: " + m.getTitulo() +
                                ", autor: " + m.getAutor() + ", stock: " + m.getStock()));
                        

            }
            // Cliente
            else if (usuario == 2) {
                System.out.println("Crear nuevo cliente? 1:si , 2:no");
                int nuevo = escanear.nextInt();
                escanear.nextLine(); // Limpiar el buffer
                if (nuevo == 1) {
                    System.out.println("Cedula:");
                    cedula = escanear.nextLine();
                    System.out.println("Nombre:");
                    String nombre = escanear.nextLine();
                    System.out.println("Apellido:");
                    String apellido = escanear.nextLine();
                    System.out.println("Correo:");
                    String correo = escanear.nextLine();

                    Clientes cliente = new Clientes(cedula, nombre, apellido, correo);
                    biblioteca.guardarCliente(cliente);
                }

                System.out.println("Acción: 1:prestamo, 2:devolucion, 3:ver préstamos");
                int accion = escanear.nextInt();
                escanear.nextLine(); // Limpiar el buffer

                System.out.println("Cedula:");
                cedula = escanear.nextLine();

                // Realizar acción
                switch (accion) {
                    // Prestar material
                    case 1 -> {
                        // Listar materiales
                        System.out.println("Lista de materiales:");
                        biblioteca.listarMateriales().forEach(m ->
                                System.out.println("id: " + m.getMaterialId() + ", titulo: " + m.getTitulo() +
                                        ", autor: " + m.getAutor() + ", stock: " + m.getStock()));

                        System.out.println("ID del material:");
                        String materialId = escanear.nextLine();
                        biblioteca.prestarMaterial(new com.biblioteca.dto.PrestamoDTO(cedula,materialId));
                    }
                    case 2 -> {
                        // Listar préstamos
                        System.out.println("Lista de préstamos:");
                        biblioteca.listarPrestamosPorCliente(cedula).forEach(p -> 
                            System.out.println("id: " + p.getMaterialId() + ", devuelto: " + p.isDevuelto()));

                        System.out.println("ID del material a devolver:");
                        String prestamoId = escanear.next();
                        biblioteca.devolverMaterial(prestamoId);
                    }
                    case 3 -> biblioteca.listarPrestamosPorCliente(cedula).forEach(p ->
                            System.out.println("id: " + p.getMaterialId() + ", devuelto: " + p.isDevuelto()+
                                    ", fecha de devolución: " + p.getFechaDevolucion()));
                }
            }
        } while (usuario != 3);
    }
}
