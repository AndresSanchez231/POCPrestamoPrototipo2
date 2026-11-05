import { Component } from '@angular/core';
import { PrestamoService } from '../../services/prestamo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-actualizar-prestamo',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './actualizar-prestamo.component.html'
})
export class ActualizarPrestamoComponent {
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
        
        // Recortamos la fecha para el input (YYYY-MM-DDTHH:mm)
        if (this.prestamo && this.prestamo.fechaRegistro) {
          this.prestamo.fechaRegistro = this.prestamo.fechaRegistro.substring(0, 16);
        }
      },
      error: (err) => this.error = err.message
    });
  }

  actualizar() {
    this.error = ''; this.mensaje = '';
    
    // Objeto LIMPIO, sin _typename, con el ID de la búsqueda
    const input = {
      idPrestamo: Number(this.id), 
      monto: Number(this.prestamo.monto),
      tasaIntereses: Number(this.prestamo.tasaIntereses),
      fechaRegistro: this.prestamo.fechaRegistro,
      tipo: this.prestamo.tipo,
      estado: this.prestamo.estado
    };

    this.prestamoService.actualizarPrestamo(this.id!, input).subscribe({
      next: () => {
        this.mensaje = 'Actualizado correctamente.';
      },
      error: (err) => this.error = err.message
    });
  }
}