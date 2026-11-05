import { Component } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-buscar-cliente',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './buscar-cliente.component.html'
})
export class BuscarClienteComponent {
  id: number | null = null;
  cliente: any = null;
  error: string = '';

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
}