import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PagoService, Pago } from '../../services/pago.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-eliminar-pago',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './eliminar-pago.component.html'
})
export class EliminarPagoComponent {
  id: number | null = null;
  pago: Pago | null = null;
  error: string = '';
  mensaje: string = '';

  constructor(private pagoService: PagoService, private router: Router) {}

  buscar() {
    if (!this.id) { this.error = 'Ingrese un ID válido'; return; }
    this.error = ''; this.mensaje = '';
    this.pagoService.obtenerPorId(this.id).subscribe({
      next: (data) => { 
        this.pago = data; 
        if (this.pago && !this.pago.estado) {
          this.mensaje = 'Este pago ya se encuentra INACTIVO.';
        }
      },
      error: () => { this.error = 'Pago no encontrado.'; this.pago = null; }
    });
  }

  eliminar() {
    if (!this.pago) return;
    this.pagoService.eliminar(this.pago.idPago).subscribe({
      next: (res) => {
        if (res) {
          this.mensaje = 'Pago desactivado correctamente.';
          this.pago!.estado = false; // Actualiza la vista local
        } else {
          this.error = 'No se pudo desactivar el pago.';
        }
      },
      error: () => { this.error = 'Error al comunicarse con el servidor.'; }
    });
  }

  volverAlMenu() {
    this.router.navigate(['/']);
  }
}