import { Routes } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { InsertarPrestamoComponent } from './prestamos/insertar-prestamo/insertar-prestamo.component';
import { ListarPrestamosComponent } from './prestamos/listar-prestamos/listar-prestamos.component';
import { FiltrarPrestamosComponent } from './prestamos/filtrar-prestamos/filtrar-prestamos.component';
import { BuscarPrestamoComponent } from './prestamos/buscar-prestamo/buscar-prestamo.component';
import { ActualizarPrestamoComponent } from './prestamos/actualizar-prestamo/actualizar-prestamo.component';
import { EliminarPrestamoComponent } from './prestamos/eliminar-prestamo/eliminar-prestamo.component';
import { InsertarClienteComponent } from './clientes/insertar-cliente/insertar-cliente.component';
import { ListarClientesComponent } from './clientes/listar-clientes/listar-clientes.component';
import { FiltrarClientesComponent } from './clientes/filtrar-clientes/filtrar-clientes.component';
import { BuscarClienteComponent } from './clientes/buscar-cliente/buscar-cliente.component';
import { ActualizarClienteComponent } from './clientes/actualizar-cliente/actualizar-cliente.component';
import { EliminarClienteComponent } from './clientes/eliminar-cliente/eliminar-cliente.component';
import { ListarClientesConPrestamoComponent } from './clientes/listar-clientes-con-prestamo/listar-clientes-con-prestamo.component';

// NUEVOS IMPORTS PARA PAGOS
import { InsertarPagoComponent } from './pagos/insertar-pago/insertar-pago.component';
import { ListarPagosComponent } from './pagos/listar-pagos/listar-pagos.component';
import { BuscarPagoComponent } from './pagos/buscar-pago/buscar-pago.component';
import { ActualizarPagoComponent } from './pagos/actualizar-pago/actualizar-pago.component';
import { EliminarPagoComponent } from './pagos/eliminar-pago/eliminar-pago.component';

export const routes: Routes = [
  { path: '', component: MenuComponent },
  
  // Rutas de Préstamos
  { path: 'prestamos/insertar', component: InsertarPrestamoComponent },
  { path: 'prestamos/listar', component: ListarPrestamosComponent },
  { path: 'prestamos/filtrar', component: FiltrarPrestamosComponent },
  { path: 'prestamos/buscar', component: BuscarPrestamoComponent },
  { path: 'prestamos/actualizar', component: ActualizarPrestamoComponent },
  { path: 'prestamos/eliminar', component: EliminarPrestamoComponent },
  
  // Rutas de Clientes
  { path: 'clientes/insertar', component: InsertarClienteComponent },
  { path: 'clientes/listar', component: ListarClientesComponent },
  { path: 'clientes/filtrar', component: FiltrarClientesComponent },
  { path: 'clientes/buscar', component: BuscarClienteComponent },
  { path: 'clientes/actualizar', component: ActualizarClienteComponent },
  { path: 'clientes/eliminar', component: EliminarClienteComponent },
  
  // RUTA NUEVA (Consulta Personalizada)
  { path: 'clientes/listar-con-prestamo', component: ListarClientesConPrestamoComponent },
  
  // NUEVAS RUTAS PARA PAGOS
  { path: 'pagos/insertar', component: InsertarPagoComponent },
  { path: 'pagos/listar', component: ListarPagosComponent },
  { path: 'pagos/buscar', component: BuscarPagoComponent },
  { path: 'pagos/actualizar', component: ActualizarPagoComponent },
  { path: 'pagos/eliminar', component: EliminarPagoComponent },
  
  // Redirección por defecto si la ruta no existe
  { path: '**', redirectTo: '' }
];