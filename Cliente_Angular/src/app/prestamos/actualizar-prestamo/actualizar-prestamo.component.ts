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
    
    // Enviamos el número directamente
    this.prestamoService.buscarPrestamo(this.id).subscribe({
      next: (res: any) => {
        this.prestamo = res.data.prestamoPorId;
        this.error = this.prestamo ? '' : 'No encontrado.';
        
        if (this.prestamo && this.prestamo.fechaRegistro) {
          this.prestamo.fechaRegistro = this.prestamo.fechaRegistro.substring(0, 16);
        }
      },
      error: (err) => this.error = err.message
    });
  }

  actualizar() {
    this.error = ''; this.mensaje = '';
    
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
      error: (err) => {
        // CAPTURAMOS EL MENSAJE REAL DE JAVA
        const errorMsg = err.message || err.graphQLErrors?.[0]?.message || '';
        
        if (errorMsg.includes('INACTIVO')) {
          this.error = 'El préstamo está INACTIVO. No se puede actualizar.';
        } else if (errorMsg.includes('INTERNAL_ERROR')) {
          this.error = 'No se pudo actualizar. Verifique que el préstamo esté activo.';
        } else {
          this.error = errorMsg;
        }
      }
    });
  }
}