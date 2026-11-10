import { Component } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-filtrar-clientes',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './filtrar-clientes.component.html'
})
export class FiltrarClientesComponent {
  idPrestamo: string = '';
  clientes: any[] = [];
  error: string = '';

  constructor(private clienteService: ClienteService) {}

  filtrar() {
    if(!this.idPrestamo) return;
    
    // Enviamos el ID manual como String
    this.clienteService.listarPorPrestamo(this.idPrestamo).subscribe({
      next: (res: any) => {
        this.clientes = res.data.clientesPorPrestamo.filter((c: any) => c.estado === true);
        
        if(this.clientes.length === 0) {
          this.error = 'No hay clientes activos para este préstamo.';
        } else {
          this.error = '';
        }
      },
      error: (err) => this.error = err.message
    });
  }
}