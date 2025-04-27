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

        System.out.println("Bienvenido a la biblioteca");

        do {
            System.out.println("Ingrese su tipo de usuario 1:admin, 2:cliente, 3:salir");
            usuario = escanear.nextInt();

            if (usuario == 1) {
                System.out.println("Bienvenido admin");
                System.out.println("Desea eliminar o agregar materiales? 1:agregar , 2:eliminar");
                int eliminar = escanear.nextInt();

                if (eliminar == 1) {
                    System.out.println("Ingrese tipo de material (libro, revista, diccionario):");
                    String tipo = escanear.next().toLowerCase();

                    System.out.println("ID del material:");
                    String id = escanear.next();
                    System.out.println("Título:");
                    String titulo = escanear.next();
                    System.out.println("Autor:");
                    String autor = escanear.next();
                    System.out.println("Stock:");
                    int stock = escanear.nextInt();

                    Materiales material = new Materiales(tipo, id, titulo, autor, stock);

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
                            System.out.println("Idioma:");
                            material.getIdiomas().add(escanear.next());
                        }
                    }
                    
                    
                    biblioteca.guardarMaterial(material);
                } else if (eliminar == 2) {
                    biblioteca.listarMateriales().forEach(m -> 
                        System.out.println(m.getMaterialId() + " - " + m.getTitulo()));
                    System.out.println("ID del material a eliminar:");
                    biblioteca.eliminarMaterial(escanear.next());
                }
                System.out.println("Lista de materiales:");
                biblioteca.listarMateriales().forEach(m -> 
                        System.out.println(m.getMaterialId() + " - " + m.getTitulo()));
                        

            } else if (usuario == 2) {
                System.out.println("Crear nuevo cliente? 1:si , 2:no");
                int nuevo = escanear.nextInt();
                if (nuevo == 1) {
                    System.out.println("Cedula:");
                    cedula = escanear.next();
                    System.out.println("Nombre:");
                    String nombre = escanear.next();
                    System.out.println("Apellido:");
                    String apellido = escanear.next();
                    System.out.println("Correo:");
                    String correo = escanear.next();

                    Clientes cliente = new Clientes(cedula, nombre, apellido, correo);
                    biblioteca.guardarCliente(cliente);
                }

                System.out.println("Acción: 1:prestar, 2:devolver, 3:ver préstamos");
                int accion = escanear.nextInt();

                System.out.println("Cedula:");
                cedula = escanear.next();

                switch (accion) {
                    case 1 -> {
                        biblioteca.listarMateriales().forEach(m -> 
                            System.out.println(m.getMaterialId() + " - " + m.getTitulo()));
                        System.out.println("ID del material:");
                        String materialId = escanear.next();
                        biblioteca.prestarMaterial(new com.biblioteca.dto.PrestamoDTO(cedula,materialId));
                    }
                    case 2 -> {
                        biblioteca.listarPrestamosPorCliente(cedula).forEach(p -> 
                            System.out.println(p.getId() + " - " + p.getMaterialId()));
                        System.out.println("ID del préstamo a devolver:");
                        String prestamoId = escanear.next();
                        biblioteca.devolverMaterial(prestamoId);
                    }
                    case 3 -> biblioteca.listarPrestamosPorCliente(cedula)
                        .forEach(p -> System.out.println(p.getMaterialId() + " - Devuelto: " + p.isDevuelto()));
                }
            }
        } while (usuario != 3);
    }
}
