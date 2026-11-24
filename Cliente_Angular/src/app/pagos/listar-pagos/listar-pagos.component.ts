import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PagoService, Pago } from '../../services/pago.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar-pagos',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './listar-pagos.component.html'
})
export class ListarPagosComponent implements OnInit {
  idPrestamo: number = 111;
  pagos: Pago[] = [];
  error: string = '';

  constructor(private pagoService: PagoService, private router: Router) {}

  ngOnInit() {
    this.listar();
  }

  listar() {
    if (!this.idPrestamo) { this.error = 'Debe ingresar un ID de préstamo.'; return; }
    this.error = '';
    this.pagoService.listarPorPrestamo(this.idPrestamo).subscribe({
      next: (data) => { this.pagos = data; },
      error: () => { this.error = 'Error al cargar los pagos.'; }
    });
  }

  volverAlMenu() {
    this.router.navigate(['/']);
  }
}