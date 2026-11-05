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

  constructor(
    private clienteService: ClienteService,
    private prestamoService: PrestamoService
  ) {}

  buscar() {
    if(!this.id) return;
    this.clienteService.buscarCliente(this.id).subscribe({
      next: (res: any) => {
        this.cliente = res.data.clientePorId;
        this.error = this.cliente ? '' : 'No encontrado.';
        
        if (this.cliente && this.cliente.fechaNacimiento) {
          this.cliente.fechaNacimiento = this.cliente.fechaNacimiento.substring(0, 16);
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

    // VALIDAR PRÉSTAMO ANTES DE ACTUALIZAR
    this.prestamoService.listarPrestamos().subscribe({
      next: (res: any) => {
        const prestamos = res.data.prestamos;
        const existe = prestamos.some((p: any) => p.idPrestamo === Number(this.cliente.idPrestamo));

        if (!existe) {
          this.error = `El préstamo con ID ${this.cliente.idPrestamo} no existe. Verifique el ID.`;
          return;
        }

        const input = {
          idCliente: Number(this.id),
          nombreCompleto: this.cliente.nombreCompleto,
          cedula: this.cliente.cedula,
          ingresosMensuales: Number(this.cliente.ingresosMensuales),
          fechaNacimiento: this.cliente.fechaNacimiento,
          idPrestamo: Number(this.cliente.idPrestamo),
          estado: this.cliente.estado
        };

        this.clienteService.actualizarCliente(this.id!, input).subscribe({
          next: () => {
            this.mensaje = 'Actualizado correctamente.';
          },
          error: (err) => {
            // CAPTURAMOS EL MENSAJE REAL DE JAVA
            if (err.message.includes('INACTIVO')) {
              this.error = 'El cliente está INACTIVO. No se puede actualizar.';
            } else if (err.message.includes('INTERNAL_ERROR')) {
              // Si Java no da el mensaje exacto, mostramos uno genérico
              this.error = 'No se pudo actualizar. Verifique que el cliente esté activo.';
            } else {
              this.error = err.message;
            }
          }
        });
      },
      error: (err) => this.error = err.message
    });
  }
}