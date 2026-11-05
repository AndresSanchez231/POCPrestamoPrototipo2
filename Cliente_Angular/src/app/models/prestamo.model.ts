export interface Prestamo {
  idPrestamo: number;
  monto: number;
  tasaIntereses: number;
  fechaRegistro: string;
  tipo: string;
  estado: boolean;
}

export interface PrestamoInput {
  idPrestamo: number;
  monto: number;
  tasaIntereses: number;
  fechaRegistro: string;
  tipo: string;
  estado: boolean;
}