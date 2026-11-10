import { Component, OnInit } from '@angular/core';
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
export class InsertarClienteComponent implements OnInit {
  idCliente: number | null = null;
  nombreCompleto: string = '';
  cedula: string = '';
  ingresosMensuales: string = '';
  fechaNacimiento: string = '';
  idPrestamo: string = '';
  mensaje: string = '';
  error: string = '';

  prestamosDisponibles: any[] = [];

  constructor(
    private clienteService: ClienteService,
    private prestamoService: PrestamoService
  ) {}

  ngOnInit(): void {
    this.cargarPrestamos();
  }

  cargarPrestamos() {
    this.prestamoService.listarPrestamos().subscribe({
      next: (res: any) => {
        this.prestamosDisponibles = res.data.prestamos;
      },
      error: (err) => this.error = 'Error al cargar préstamos: ' + err.message
    });
  }

  guardar() {
    this.error = ''; this.mensaje = '';
    
    if (!this.idCliente || !this.nombreCompleto || !this.cedula || !this.ingresosMensuales || !this.fechaNacimiento || !this.idPrestamo) {
      this.error = 'Todos los campos son obligatorios.';
      return;
    }

    if (/\d/.test(this.nombreCompleto)) {
      this.error = 'El nombre no puede contener números. Ingrese solo letras.';
      return;
    }

    if (!/^\d+$/.test(this.cedula)) {
      this.error = 'La cédula debe contener solo números (no se permiten letras).';
      return;
    }

    if (isNaN(Number(this.ingresosMensuales))) {
      this.error = 'Los ingresos mensuales deben ser un número válido (no se permiten letras).';
      return;
    }

    const input = {
      idCliente: Number(this.idCliente),
      nombreCompleto: this.nombreCompleto,
      cedula: this.cedula,
      ingresosMensuales: Number(this.ingresosMensuales),
      fechaNacimiento: this.fechaNacimiento,
      idPrestamo: this.idPrestamo,
      estado: true
    };

    this.clienteService.insertarCliente(input).subscribe({
      next: () => {
        this.mensaje = 'Cliente insertado correctamente.';
        this.limpiar();
      },
      error: (err) => {
        // Si el servidor no da el mensaje real, lo manejamos aquí
        let errorMsg = err.message || '';
        
        if (errorMsg.includes('INTERNAL_ERROR')) {
          this.error = 'El préstamo seleccionado está INACTIVO. No se pueden agregar clientes.';
        } else if (errorMsg.includes('ya existe')) {
          this.error = `El cliente con ID ${this.idCliente} ya existe.`;
        } else if (errorMsg.includes('no existe')) {
          this.error = 'El préstamo seleccionado no existe.';
        } else {
          this.error = errorMsg;
        }
      }
    });
  }

  limpiar() {
    this.idCliente = null;
    this.nombreCompleto = '';
    this.cedula = '';
    this.ingresosMensuales = '';
    this.fechaNacimiento = '';
    this.idPrestamo = '';
  }
}