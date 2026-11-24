import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PagoService, Pago } from '../../services/pago.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buscar-pago',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './buscar-pago.component.html'
})
export class BuscarPagoComponent {
  id: number | null = null;
  pago: Pago | null = null;
  error: string = '';

  constructor(private pagoService: PagoService, private router: Router) {}

  buscar() {
    if (!this.id) { this.error = 'Ingrese un ID válido.'; return; }
    this.error = '';
    this.pagoService.obtenerPorId(this.id).subscribe({
      next: (data) => {
        if (data) { this.pago = data; } 
        else { this.error = 'Pago no encontrado.'; this.pago = null; }
      },
      error: () => this.error = 'Error al buscar el pago.'
    });
  }

  volverAlMenu() {
    this.router.navigate(['/']);
  }
}