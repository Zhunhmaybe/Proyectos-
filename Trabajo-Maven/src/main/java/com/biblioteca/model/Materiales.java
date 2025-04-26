package com.biblioteca.model;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;
import java.util.ArrayList;

@Document(collection = "materiales")
public class Materiales {
    @Id
    private String materialId;
    private String tipo;
    private String titulo;
    private String autor;
    private int stock;
    private Integer paginas;
    private Integer volumen;
    private ArrayList<String> idiomas = new ArrayList<>();

    public Materiales() {}

    public Materiales(String tipo, String materialId, String titulo, String autor, int stock) {
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
    public Integer getPaginas() { return paginas; }
    public void setPaginas(Integer paginas) { this.paginas = paginas; }
    public Integer getVolumen() { return volumen; }
    public void setVolumen(Integer volumen) { this.volumen = volumen; }
    public ArrayList<String> getIdiomas() { return idiomas; }
    public void setIdiomas(ArrayList<String> idiomas) { this.idiomas = idiomas; }
}
