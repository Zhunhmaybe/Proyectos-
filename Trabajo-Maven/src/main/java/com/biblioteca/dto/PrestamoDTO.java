// PrestamoDTO.java
package com.biblioteca.dto;

public class PrestamoDTO {
    private String cedula;
    private String materialId;

    // Constructor
    public PrestamoDTO() {}

    public PrestamoDTO(String cedula, String materialId) {
        this.cedula = cedula;
        this.materialId = materialId;
    }

    // Getters y setters
    public String getCedula() { return cedula; }
    public void setCedula(String cedula) { this.cedula = cedula; }
    public String getMaterialId() { return materialId; }
    public void setMaterialId(String materialId) { this.materialId = materialId; }
}