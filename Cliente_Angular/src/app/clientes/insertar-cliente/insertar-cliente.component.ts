import { Component } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { PrestamoService } from '../../services/prestamo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-insertar-cliente',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './insertar-cliente.component.html'
})
export class InsertarClienteComponent {
  idCliente: number | null = null;
  nombreCompleto: string = '';
  cedula: string = '';
  ingresosMensuales: string = '';
  fechaNacimiento: string = '';
  idPrestamo: number | null = null;
  mensaje: string = '';
  error: string = '';

  constructor(
    private clienteService: ClienteService,
    private prestamoService: PrestamoService
  ) {}

  guardar() {
    this.error = ''; this.mensaje = '';
    
    // 1. Validar campos vacíos
    if (!this.idCliente || !this.nombreCompleto || !this.cedula || !this.ingresosMensuales || !this.fechaNacimiento || !this.idPrestamo) {
      this.error = 'Todos los campos son obligatorios.';
      return;
    }

    // 2. Validar nombre sin números
    if (/\d/.test(this.nombreCompleto)) {
      this.error = 'El nombre no puede contener números. Ingrese solo letras.';
      return;
    }

    // 3. Validar cédula solo números
    if (!/^\d+$/.test(this.cedula)) {
      this.error = 'La cédula debe contener solo números (no se permiten letras).';
      return;
    }

    // 4. Validar ingresos numéricos
    if (isNaN(Number(this.ingresosMensuales))) {
      this.error = 'Los ingresos mensuales deben ser un número válido (no se permiten letras).';
      return;
    }

    // 5. VALIDAR QUE EL PRÉSTAMO EXISTA (Consultando al servidor)
    this.prestamoService.listarPrestamos().subscribe({
      next: (res: any) => {
        const prestamos = res.data.prestamos;
        const existe = prestamos.some((p: any) => p.idPrestamo === Number(this.idPrestamo));

        if (!existe) {
          this.error = `El préstamo con ID ${this.idPrestamo} no existe. Verifique el ID.`;
          return;
        }

        // Si existe, procedemos a guardar
        const input = {
          idCliente: Number(this.idCliente),
          nombreCompleto: this.nombreCompleto,
          cedula: this.cedula,
          ingresosMensuales: Number(this.ingresosMensuales),
          fechaNacimiento: this.fechaNacimiento,
          idPrestamo: Number(this.idPrestamo),
          estado: true
        };

        this.clienteService.insertarCliente(input).subscribe({
          next: () => {
            this.mensaje = 'Cliente insertado correctamente.';
            this.limpiar();
          },
          error: (err) => {
            this.error = err.message;
          }
        });
      },
      error: (err) => this.error = err.message
    });
  }

  limpiar() {
    this.idCliente = null;
    this.nombreCompleto = '';
    this.cedula = '';
    this.ingresosMensuales = '';
    this.fechaNacimiento = '';
    this.idPrestamo = null;
  }
}