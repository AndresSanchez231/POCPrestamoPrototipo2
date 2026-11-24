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

    // 5. VALIDACIÓN PREVIA: Verificar si el cliente ya existe
    this.clienteService.buscarCliente(this.idCliente).subscribe({
      next: (res: any) => {
        if (res.data.clientePorId != null) {
          this.error = `El cliente con ID ${this.idCliente} ya existe. Por favor, use otro.`;
          return;
        }
        
        // Si no existe, procedemos a insertar
        this.insertarCliente();
      },
      error: () => {
        // Si hay error en la búsqueda (ej. no encontrado), igual intentamos insertar
        this.insertarCliente();
      }
    });
  }

  private insertarCliente() {
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
        let errorMsg = err.message || '';
        if (errorMsg.includes('INTERNAL_ERROR')) {
          this.error = 'El préstamo seleccionado está INACTIVO. No se pueden agregar clientes.';
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