import { Component } from '@angular/core';
import { PrestamoService } from '../../services/prestamo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-filtrar-prestamos',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './filtrar-prestamos.component.html'
})
export class FiltrarPrestamosComponent {
  tipo: string = 'Casa';
  prestamos: any[] = [];
  error: string = '';

  constructor(private prestamoService: PrestamoService) {}

  filtrar() {
    this.error = '';
    this.prestamoService.listarPorTipo(this.tipo).subscribe({
      next: (res: any) => {
        this.prestamos = res.data.prestamosPorTipoInmueble;
        if(this.prestamos.length === 0) this.error = 'No hay préstamos de este tipo.';
      },
      error: (err) => this.error = err.message
    });
  }
}