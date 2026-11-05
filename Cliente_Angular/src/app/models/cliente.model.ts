export interface Cliente {
  idCliente: number;
  nombreCompleto: string;
  cedula: string;
  ingresosMensuales: number;
  fechaNacimiento: string;
  idPrestamo: number;
  estado: boolean;
}

export interface ClienteInput {
  idCliente: number;
  nombreCompleto: string;
  cedula: string;
  ingresosMensuales: number;
  fechaNacimiento: string;
  idPrestamo: number;
  estado: boolean;
}

export interface ClienteConPrestamo {
  idCliente: number;
  nombreCompleto: string;
  cedula: string;
  ingresosMensuales: number;
  fechaNacimiento: string;
  estado: boolean;
  montoPrestamo: number;
  tipoPrestamo: string;
}