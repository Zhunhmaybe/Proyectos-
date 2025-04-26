package com.biblioteca;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class BibliotecasApplication {
    public static void main(String[] args) {
        SpringApplication.run(BibliotecasApplication.class, args);
        System.out.println("Aplicación de biblioteca iniciada correctamente");
    }
}