package org.example.servicios;

import org.example.model.Pago;
import org.example.repository.PagoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ServicioPago {

    @Autowired
    private PagoRepository pagoRepository;

    public List<Pago> listarPagosPorPrestamo(int idPrestamo) {
        return pagoRepository.findByIdPrestamo(idPrestamo);
    }

    public Optional<Pago> buscarPorId(int idPago) {
        return pagoRepository.findByIdPago(idPago);
    }

    public Pago guardarPago(Pago pago) {
        // Verificamos si ya existe un pago con ese idPago de negocio
        if (pagoRepository.findByIdPago(pago.getIdPago()).isPresent()) {
            throw new RuntimeException("El ID de Pago " + pago.getIdPago() + " ya existe. No se puede duplicar.");
        }
        return pagoRepository.save(pago);
    }

    public Optional<Pago> actualizarPago(int idPago, Pago datosNuevos) {
        return pagoRepository.findByIdPago(idPago).map(pago -> {
            pago.setMonto(datosNuevos.getMonto());
            pago.setMetodoPago(datosNuevos.getMetodoPago());
            pago.setFechaPago(datosNuevos.getFechaPago());
            pago.setIdPrestamo(datosNuevos.getIdPrestamo());
            pago.setEstado(datosNuevos.isEstado());
            return pagoRepository.save(pago);
        });
    }

    public boolean eliminarPago(int idPago) {
        return pagoRepository.findByIdPago(idPago).map(pago -> {
            pago.setEstado(false); // <-- BORRADO LÓGICO
            pagoRepository.save(pago);
            return true;
        }).orElse(false);
    }
}