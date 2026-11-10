import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { PrestamoService } from '../../services/prestamo.service'; // <-- Importar
import { CommonModule } from '@angular/common';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-listar-clientes',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './listar-clientes.component.html'
})
export class ListarClientesComponent implements OnInit {
  clientes: any[] = [];

  constructor(
    private clienteService: ClienteService,
    private prestamoService: PrestamoService, // <-- Inyectar
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cargarClientes();

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      if (this.router.url.includes('/clientes/listar')) {
        this.cargarClientes();
      }
    });
  }

  cargarClientes() {
    // Primero, cargamos todos los préstamos para hacer la conversión
    this.prestamoService.listarPrestamos().subscribe({
      next: (resPrestamos: any) => {
        const prestamos = resPrestamos.data.prestamos;

        // Luego, cargamos los clientes
        this.clienteService.listarClientes().subscribe({
          next: (resClientes: any) => {
            const clientes = resClientes.data.clientes;

            // Mapeamos los clientes para cambiar el ObjectId por el ID manual
            this.clientes = clientes.map((c: any) => {
              const prestamoAsociado = prestamos.find((p: any) => p._id === c.idPrestamo);
              return {
                ...c,
                idPrestamo: prestamoAsociado ? prestamoAsociado.idPrestamo : 'N/A'
              };
            });
          },
          error: (err) => alert(err.message)
        });
      },
      error: (err) => alert(err.message)
    });
  }
}