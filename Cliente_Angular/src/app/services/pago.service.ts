import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Pago {
  idPago: number;
  monto: number;
  metodoPago: string;
  fechaPago: string;
  idPrestamo: number;
  estado: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class PagoService {

  constructor(private apollo: Apollo) { }

   listarPorPrestamo(idPrestamo: number): Observable<Pago[]> {
    const GET_PAGOS = gql`
      query GetPagos($id: Int!) {
        pagosPorPrestamo(idPrestamo: $id) {
          idPago monto metodoPago fechaPago idPrestamo estado
        }
      }
    `;
    return this.apollo.query<any>({
      query: GET_PAGOS,
      variables: { id: idPrestamo },
      fetchPolicy: 'no-cache' // <-- Forzamos a que siempre consulte
    }).pipe(map((result: any) => result.data.pagosPorPrestamo));
  }

  obtenerPorId(idPago: number): Observable<Pago> {
    const GET_PAGO = gql`
      query GetPago($id: Int!) {
        pagoPorId(idPago: $id) {
          idPago monto metodoPago fechaPago idPrestamo estado
        }
      }
    `;
    return this.apollo.query<any>({
      query: GET_PAGO,
      variables: { id: idPago },
      fetchPolicy: 'network-only'
    }).pipe(map((result: any) => result.data.pagoPorId));
  }

  insertar(pago: Pago): Observable<Pago> {
    const ADD_PAGO = gql`
      mutation AddPago($input: PagoInput!) {
        addPago(input: $input) {
          idPago monto metodoPago fechaPago idPrestamo estado
        }
      }
    `;
    return this.apollo.mutate<any>({
      mutation: ADD_PAGO,
      variables: { input: pago }
    }).pipe(map((result: any) => result.data.addPago));
  }

  actualizar(idPago: number, pago: Pago): Observable<Pago> {
    const UPDATE_PAGO = gql`
      mutation UpdatePago($id: Int!, $input: PagoInput!) {
        actualizarPago(idPago: $id, input: $input) {
          idPago monto metodoPago fechaPago idPrestamo estado
        }
      }
    `;
    return this.apollo.mutate<any>({
      mutation: UPDATE_PAGO,
      variables: { id: idPago, input: pago }
    }).pipe(map((result: any) => result.data.actualizarPago));
  }

  eliminar(idPago: number): Observable<boolean> {
    const DELETE_PAGO = gql`
      mutation DeletePago($id: Int!) {
        eliminarPago(idPago: $id)
      }
    `;
    return this.apollo.mutate<any>({
      mutation: DELETE_PAGO,
      variables: { id: idPago }
    }).pipe(map((result: any) => result.data.eliminarPago));
  }
}