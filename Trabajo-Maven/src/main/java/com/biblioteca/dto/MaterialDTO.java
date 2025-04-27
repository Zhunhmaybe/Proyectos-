// MaterialDTO.java
package com.biblioteca.dto;

public class MaterialDTO {
    private String materialId;
    private String tipo;
    private String titulo;
    private String autor;
    private int stock;

    // Constructor
    public MaterialDTO() {}

    public MaterialDTO(String tipo, String materialId, String titulo, String autor, int stock) {
        this.tipo = tipo;
        this.materialId = materialId;
        this.titulo = titulo;
        this.autor = autor;
        this.stock = stock;
    }

    // Getters y setters
    public String getMaterialId() { return materialId; }
    public void setMaterialId(String materialId) { this.materialId = materialId; }
    public String getTipo() { return tipo; }
    public void setTipo(String tipo) { this.tipo = tipo; }
    public String getTitulo() { return titulo; }
    public void setTitulo(String titulo) { this.titulo = titulo; }
    public String getAutor() { return autor; }
    public void setAutor(String autor) { this.autor = autor; }
    public int getStock() { return stock; }
    public void setStock(int stock) { this.stock = stock; }
}