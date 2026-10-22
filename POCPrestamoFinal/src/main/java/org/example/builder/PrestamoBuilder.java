package org.example.builder;

import org.example.model.Cliente;
import org.example.model.Prestamo;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class PrestamoBuilder {
    private int idPrestamo;
    private double monto;
    private double tasaIntereses;
    private LocalDateTime fechaRegistro;
    private String tipo;
    private boolean estado;
    private List<Cliente> clientes = new ArrayList<>();

    public PrestamoBuilder setIdPrestamo(int idPrestamo) {
        this.idPrestamo = idPrestamo;
        return this;
    }

    public PrestamoBuilder setMonto(double monto) {
        this.monto = monto;
        return this;
    }

    public PrestamoBuilder setTasaIntereses(double tasaIntereses) {
        this.tasaIntereses = tasaIntereses;
        return this;
    }

    public PrestamoBuilder setFechaRegistro(LocalDateTime fechaRegistro) {
        this.fechaRegistro = fechaRegistro;
        return this;
    }

    public PrestamoBuilder setTipo(String tipo) {
        this.tipo = tipo;
        return this;
    }

    public PrestamoBuilder setEstado(boolean estado) {
        this.estado = estado;
        return this;
    }

    public PrestamoBuilder addCliente(Cliente cliente) {
        this.clientes.add(cliente);
        return this;
    }

    public Prestamo build() {
        return new Prestamo(idPrestamo, monto, tasaIntereses, fechaRegistro, tipo, estado, clientes);
    }
}