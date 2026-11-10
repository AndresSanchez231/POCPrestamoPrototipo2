import { Component } from '@angular/core';
import { PrestamoService } from '../../services/prestamo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-buscar-prestamo',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './buscar-prestamo.component.html'
})
export class BuscarPrestamoComponent {
  id: number | null = null;
  prestamo: any = null;
  error: string = '';

  constructor(private prestamoService: PrestamoService) {}

  buscar() {
    if(!this.id) return;
    // Enviamos el número directamente
    this.prestamoService.buscarPrestamo(this.id).subscribe({
      next: (res: any) => {
        this.prestamo = res.data.prestamoPorId;
        this.error = this.prestamo ? '' : 'No encontrado.';
      },
      error: (err) => this.error = err.message
    });
  }
}