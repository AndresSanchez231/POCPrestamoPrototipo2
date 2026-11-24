import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PagoService, Pago } from '../../services/pago.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-actualizar-pago',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './actualizar-pago.component.html'
})
export class ActualizarPagoComponent {
  id: number | null = null;
  pago: any = null; // Usamos 'any' para poder manipular la fecha libremente
  error: string = '';
  mensaje: string = '';

  constructor(private pagoService: PagoService, private router: Router) {}

  buscar() {
    if (!this.id) { this.error = 'Ingrese un ID'; return; }
    this.error = ''; this.mensaje = '';
    this.pagoService.obtenerPorId(this.id).subscribe({
      next: (data) => { 
        this.pago = data; 
        // Recortamos la fecha para que el input datetime-local la entienda (YYYY-MM-DDTHH:mm)
        if (this.pago && this.pago.fechaPago) {
            this.pago.fechaPago = this.pago.fechaPago.substring(0, 16); 
        }
      },
      error: () => { this.error = 'Pago no encontrado.'; this.pago = null; }
    });
  }

  actualizar() {
    if (!this.pago) return;
    if (this.pago.monto <= 0) { this.error = 'El monto debe ser positivo'; return; }

    // FORMATO DE FECHA PARA JAVA (LocalDateTime)
    let fechaString = this.pago.fechaPago;
    
    // Si el input por alguna razón devuelve un objeto Date, lo convertimos a string
    if (fechaString instanceof Date) {
        fechaString = fechaString.toISOString().substring(0, 19);
    } else if (typeof fechaString === 'string') {
        // Aseguramos que tenga el formato exacto YYYY-MM-DDTHH:mm:ss
        // Si tiene un espacio, lo cambiamos por 'T'
        fechaString = fechaString.replace(' ', 'T');
        // Si no tiene segundos (solo 16 caracteres), le agregamos ':00'
        if (fechaString.length === 16) {
            fechaString += ':00';
        }
    }

    const pagoAEnviar = {
      idPago: this.pago.idPago,
      monto: this.pago.monto,
      metodoPago: this.pago.metodoPago,
      fechaPago: fechaString, // <-- Enviamos la fecha limpia
      idPrestamo: this.pago.idPrestamo,
      estado: this.pago.estado
    };

    this.pagoService.actualizar(this.pago.idPago, pagoAEnviar).subscribe({
      next: () => { this.mensaje = 'Pago actualizado correctamente.'; },
      error: (err) => { 
        console.error('Error detallado de GraphQL:', err); 
        this.error = 'Error al actualizar. Verifique la consola para más detalles.'; 
      }
    });
  }

  volverAlMenu() {
    this.router.navigate(['/']);
  }
}