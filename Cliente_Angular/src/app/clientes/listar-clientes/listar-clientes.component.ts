import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
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

  constructor(private clienteService: ClienteService, private router: Router) {}

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
    this.clienteService.listarClientes().subscribe({
      next: (res: any) => this.clientes = res.data.clientes,
      error: (err) => alert(err.message)
    });
  }
}