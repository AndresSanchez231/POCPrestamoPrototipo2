import { Component } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-eliminar-cliente',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './eliminar-cliente.component.html'
})
export class EliminarClienteComponent {
  id: number | null = null;
  cliente: any = null;
  error: string = '';
  mensaje: string = '';

  constructor(private clienteService: ClienteService) {}

  buscar() {
    if(!this.id) return;
    this.clienteService.buscarCliente(this.id).subscribe({
      next: (res: any) => {
        this.cliente = res.data.clientePorId;
        this.error = this.cliente ? '' : 'No encontrado.';
      },
      error: (err) => this.error = err.message
    });
  }

  eliminar() {
    if (confirm('¿Eliminar este cliente?')) {
      this.clienteService.eliminarCliente(this.id!).subscribe({
        next: () => {
          this.mensaje = 'Cliente eliminado (INACTIVO).';
          this.cliente = null;
        },
        error: (err) => this.error = err.message
      });
    }
  }
}