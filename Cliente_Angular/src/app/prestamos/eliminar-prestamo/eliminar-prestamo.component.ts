import { Component } from '@angular/core';
import { PrestamoService } from '../../services/prestamo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-eliminar-prestamo',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './eliminar-prestamo.component.html'
})
export class EliminarPrestamoComponent {
  id: number | null = null;
  prestamo: any = null;
  error: string = '';
  mensaje: string = '';

  constructor(private prestamoService: PrestamoService) {}

  buscar() {
    if(!this.id) return;
    this.prestamoService.buscarPrestamo(this.id).subscribe({
      next: (res: any) => {
        this.prestamo = res.data.prestamoPorId;
        this.error = this.prestamo ? '' : 'No encontrado.';
      },
      error: (err) => this.error = err.message
    });
  }

  eliminar() {
    if (confirm('¿Eliminar este préstamo?')) {
      this.prestamoService.eliminarPrestamo(this.id!).subscribe({
        next: () => {
          this.mensaje = 'Eliminado correctamente.';
          this.prestamo = null;
        },
        error: (err) => this.error = err.message
      });
    }
  }
}