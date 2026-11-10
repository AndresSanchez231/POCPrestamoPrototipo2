import { Component } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { PrestamoService } from '../../services/prestamo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-actualizar-cliente',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './actualizar-cliente.component.html'
})
export class ActualizarClienteComponent {
  id: number | null = null;
  cliente: any = null;
  error: string = '';
  mensaje: string = '';

  // Variables para el ComboBox de préstamos
  prestamosDisponibles: any[] = [];
  idPrestamoSeleccionado: string = ''; // Aquí se guarda el ObjectId internamente

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

  buscar() {
    if(!this.id) return;
    this.clienteService.buscarCliente(this.id).subscribe({
      next: (res: any) => {
        this.cliente = res.data.clientePorId;
        this.error = this.cliente ? '' : 'No encontrado.';
        
        if (this.cliente && this.cliente.fechaNacimiento) {
          this.cliente.fechaNacimiento = this.cliente.fechaNacimiento.substring(0, 16);
        }

        // Asignamos el ObjectId al ComboBox para que se seleccione automáticamente
        if (this.cliente) {
          this.idPrestamoSeleccionado = this.cliente.idPrestamo;
        }
      },
      error: (err) => this.error = err.message
    });
  }

  actualizar() {
    this.error = ''; this.mensaje = '';
    
    if (!/^\d+$/.test(this.cliente.cedula)) {
      this.error = 'La cédula debe contener solo números (no se permiten letras).';
      return;
    }

    if (/\d/.test(this.cliente.nombreCompleto)) {
      this.error = 'El nombre no puede contener números.';
      return;
    }

    // Construimos el objeto con el ObjectId del ComboBox
    const input = {
      idCliente: Number(this.id),
      nombreCompleto: this.cliente.nombreCompleto,
      cedula: this.cliente.cedula,
      ingresosMensuales: Number(this.cliente.ingresosMensuales),
      fechaNacimiento: this.cliente.fechaNacimiento,
      idPrestamo: this.idPrestamoSeleccionado, // <-- Enviamos el ObjectId
      estado: this.cliente.estado
    };

    this.clienteService.actualizarCliente(this.id!, input).subscribe({
      next: () => {
        this.mensaje = 'Actualizado correctamente.';
      },
      error: (err) => {
        let errorMsg = err.message || '';
        if (errorMsg.includes('INACTIVO')) {
          this.error = 'El préstamo está INACTIVO. No se puede asociar.';
        } else if (errorMsg.includes('INTERNAL_ERROR')) {
          this.error = 'No se pudo actualizar. Verifique que el préstamo esté activo.';
        } else {
          this.error = errorMsg;
        }
      }
    });
  }
}