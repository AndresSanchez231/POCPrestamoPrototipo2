import { Component } from '@angular/core';
import { PrestamoService } from '../../services/prestamo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-insertar-prestamo',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './insertar-prestamo.component.html'
})
export class InsertarPrestamoComponent {
  idPrestamo: number | null = null;
  monto: string = ''; // Cambiado a string para detectar si hay letras
  tasaIntereses: string = ''; // Cambiado a string
  fechaRegistro: string = '';
  tipo: string = 'Casa';
  mensaje: string = '';
  error: string = '';

  constructor(private prestamoService: PrestamoService) {}

  guardar() {
    this.error = ''; this.mensaje = '';
    
    // Validar que no estén vacíos
    if (!this.idPrestamo || !this.monto || !this.tasaIntereses || !this.fechaRegistro) {
      this.error = 'Todos los campos son obligatorios.';
      return;
    }

    // VALIDACIÓN: Verificar si el monto tiene letras
    if (isNaN(Number(this.monto))) {
      this.error = 'El monto debe ser un número válido (no se permiten letras).';
      return;
    }

    // VALIDACIÓN: Verificar si la tasa tiene letras
    if (isNaN(Number(this.tasaIntereses))) {
      this.error = 'La tasa de intereses debe ser un número válido (no se permiten letras).';
      return;
    }

    const input = {
      idPrestamo: Number(this.idPrestamo),
      monto: Number(this.monto),
      tasaIntereses: Number(this.tasaIntereses),
      fechaRegistro: this.fechaRegistro,
      tipo: this.tipo,
      estado: true
    };

    this.prestamoService.insertarPrestamo(input).subscribe({
      next: () => {
        this.mensaje = 'Préstamo insertado correctamente.';
        this.limpiar();
      },
      error: (err) => {
        if (err.message.includes('ya existe') || err.message.includes('INTERNAL_ERROR')) {
          this.error = `El ID ${this.idPrestamo} ya está en uso. Por favor, use otro.`;
        } else {
          this.error = err.message;
        }
      }
    });
  }

  limpiar() {
    this.idPrestamo = null;
    this.monto = '';
    this.tasaIntereses = '';
    this.fechaRegistro = '';
    this.tipo = 'Casa';
  }
}