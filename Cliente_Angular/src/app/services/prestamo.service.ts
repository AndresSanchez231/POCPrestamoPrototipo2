import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { Observable } from 'rxjs';
import { PrestamoInput } from '../models/prestamo.model';

@Injectable({ providedIn: 'root' })
export class PrestamoService {
  constructor(private apollo: Apollo) {}

    listarPrestamos(): Observable<any> {
    return this.apollo.query({
      query: gql`query { prestamos { idPrestamo monto tasaIntereses fechaRegistro tipo estado } }`,
      fetchPolicy: 'network-only' // <-- ESTO ES VITAL
    });
  }

  buscarPrestamo(id: number): Observable<any> {
    return this.apollo.query({
      query: gql`query ($id: Int!) { prestamoPorId(idPrestamo: $id) { idPrestamo monto tasaIntereses fechaRegistro tipo estado } }`,
      variables: { id },
      fetchPolicy: 'network-only'
    });
  }

  // CORRECCIÓN: Ahora trae todos los atributos
  listarPorTipo(tipo: string): Observable<any> {
    return this.apollo.query({
      query: gql`query ($tipo: String!) { prestamosPorTipoInmueble(tipoInmueble: $tipo) { idPrestamo monto tasaIntereses fechaRegistro tipo estado } }`,
      variables: { tipo },
      fetchPolicy: 'network-only'
    });
  }

  insertarPrestamo(input: PrestamoInput): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($input: PrestamoInput!) { addPrestamo(input: $input) { idPrestamo } }`,
      variables: { input }
    });
  }

  actualizarPrestamo(id: number, input: PrestamoInput): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($id: Int!, $input: PrestamoInput!) { actualizarPrestamo(idPrestamo: $id, input: $input) { idPrestamo } }`,
      variables: { id, input }
    });
  }

  eliminarPrestamo(id: number): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($id: Int!) { eliminarPrestamo(idPrestamo: $id) }`,
      variables: { id }
    });
  }
}