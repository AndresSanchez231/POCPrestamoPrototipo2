import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PagoService, Pago } from '../../services/pago.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-insertar-pago',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './insertar-pago.component.html'
})
export class InsertarPagoComponent {
  idPago: number | null = null;
  monto: number | null = null;
  metodoPago: string = '';
  fechaPago: string = '';
  idPrestamo: number | null = null;
  estado: boolean = true;
  error: string = '';
  mensaje: string = '';

  constructor(private pagoService: PagoService, private router: Router) {}

  guardar() {
    this.error = '';
    this.mensaje = '';

    // Validaciones normales
    if (!this.idPago || this.idPago <= 0) { this.error = 'El ID del pago debe ser un número positivo.'; return; }
    if (this.monto === null || this.monto === undefined || !Number.isFinite(Number(this.monto)) || Number(this.monto) <= 0) {
      this.error = 'El monto debe ser un número positivo (no se permiten letras).'; return;
    }
    if (!this.metodoPago) { this.error = 'Debe seleccionar un método de pago.'; return; }
    if (!this.fechaPago) { this.error = 'Debe seleccionar una fecha.'; return; }
    if (!this.idPrestamo || this.idPrestamo <= 0) { this.error = 'El ID del préstamo debe ser un número positivo.'; return; }

    // Ejecutamos la inserción directamente
    this.ejecutarInsercion();
  }

  ejecutarInsercion() {
    const nuevoPago: Pago = {
      idPago: Number(this.idPago),
      monto: Number(this.monto),
      metodoPago: this.metodoPago,
      fechaPago: this.fechaPago + ':00',
      idPrestamo: Number(this.idPrestamo),
      estado: this.estado
    };

    this.pagoService.insertar(nuevoPago).subscribe({
      next: () => {
        this.mensaje = 'Pago insertado correctamente.';
        this.idPago = null;
        this.monto = null;
        this.metodoPago = '';
        this.fechaPago = '';
        this.idPrestamo = null;
      },
      error: (err) => {
        // Aquí capturamos si el ID ya existe
        let mensajeError = 'Error al insertar el pago.';
        
        // Intentamos extraer el mensaje de error de GraphQL
        if (err.graphQLErrors && err.graphQLErrors.length > 0) {
            mensajeError = err.graphQLErrors[0].message; 
        } else if (err.message && err.message.includes('INTERNAL_ERROR')) {
            // Si el backend de Java lanza el error de ID duplicado, GraphQL lo envuelve como INTERNAL_ERROR.
            // Podemos mostrar un mensaje amigable aquí.
            mensajeError = 'El ID de Pago ya existe o hubo un error en el servidor.';
        } else if (err.message) {
            mensajeError = err.message;
        }

        this.error = mensajeError;
        console.error('Error real:', err);
      }
    });
  }

  volverAlMenu() {
    this.router.navigate(['/']);
  }
}