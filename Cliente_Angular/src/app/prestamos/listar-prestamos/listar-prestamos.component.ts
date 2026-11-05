import { Component, OnInit } from '@angular/core';
import { PrestamoService } from '../../services/prestamo.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-listar-prestamos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './listar-prestamos.component.html'
})
export class ListarPrestamosComponent implements OnInit {
  prestamos: any[] = [];

  constructor(private prestamoService: PrestamoService) {}

  ngOnInit(): void {
    this.cargarPrestamos();
  }

  cargarPrestamos() {
    this.prestamoService.listarPrestamos().subscribe({
      next: (res: any) => this.prestamos = res.data.prestamos,
      error: (err) => alert(err.message)
    });
  }
}