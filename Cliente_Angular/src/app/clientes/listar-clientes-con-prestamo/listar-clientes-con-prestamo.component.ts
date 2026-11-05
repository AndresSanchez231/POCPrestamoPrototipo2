import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-listar-clientes-con-prestamo',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './listar-clientes-con-prestamo.component.html'
})
export class ListarClientesConPrestamoComponent implements OnInit {
  clientes: any[] = [];

  constructor(private clienteService: ClienteService) {}

  ngOnInit(): void {
    this.cargarClientes();
  }

  cargarClientes() {
    // Llamamos a la consulta personalizada de Java
    this.clienteService.listarClientesConPrestamo().subscribe({
      next: (res: any) => {
        this.clientes = res.data.clientesConDatosPrestamo;
      },
      error: (err) => alert(err.message)
    });
  }
}