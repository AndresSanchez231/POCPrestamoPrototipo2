import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { Observable } from 'rxjs';
import { PrestamoInput } from '../models/prestamo.model';

@Injectable({ providedIn: 'root' })
export class PrestamoService {
  constructor(private apollo: Apollo) {}

  listarPrestamos(): Observable<any> {
    return this.apollo.query({
      query: gql`query { prestamos { _id idPrestamo monto tasaIntereses fechaRegistro tipo estado } }`,
      fetchPolicy: 'network-only'
    });
  }

  // AHORA RECIBE UN number (Int)
  buscarPrestamo(id: number): Observable<any> {
    return this.apollo.query({
      query: gql`query ($id: Int!) { prestamoPorId(idPrestamo: $id) { _id idPrestamo monto tasaIntereses fechaRegistro tipo estado } }`,
      variables: { id: id },
      fetchPolicy: 'network-only'
    });
  }

  listarPorTipo(tipo: string): Observable<any> {
    return this.apollo.query({
      query: gql`query ($tipo: String!) { prestamosPorTipoInmueble(tipoInmueble: $tipo) { _id idPrestamo monto tasaIntereses fechaRegistro tipo estado } }`,
      variables: { tipo },
      fetchPolicy: 'network-only'
    });
  }

  insertarPrestamo(input: PrestamoInput): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($input: PrestamoInput!) { addPrestamo(input: $input) { _id idPrestamo } }`,
      variables: { input }
    });
  }

  // AHORA RECIBE UN number (Int)
  actualizarPrestamo(id: number, input: PrestamoInput): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($id: Int!, $input: PrestamoInput!) { actualizarPrestamo(idPrestamo: $id, input: $input) { _id idPrestamo } }`,
      variables: { id, input }
    });
  }

  // AHORA RECIBE UN number (Int)
  eliminarPrestamo(id: number): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($id: Int!) { eliminarPrestamo(idPrestamo: $id) }`,
      variables: { id }
    });
  }
}