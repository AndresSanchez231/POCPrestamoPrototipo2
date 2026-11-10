import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { Observable } from 'rxjs';
import { ClienteInput } from '../models/cliente.model';

@Injectable({ providedIn: 'root' })
export class ClienteService {
  constructor(private apollo: Apollo) {}

  listarClientes(): Observable<any> {
    return this.apollo.query({
      query: gql`query { clientes { idCliente nombreCompleto cedula ingresosMensuales fechaNacimiento idPrestamo estado } }`,
      fetchPolicy: 'network-only'
    });
  }

  // FILTRAR POR ID MANUAL (String)
  listarPorPrestamo(idPrestamo: string): Observable<any> {
    return this.apollo.query({
      query: gql`query ($idPrestamo: String!) { 
        clientesPorPrestamo(idPrestamo: $idPrestamo) { 
          idCliente 
          nombreCompleto 
          cedula 
          ingresosMensuales 
          fechaNacimiento 
          estado 
        } 
      }`,
      variables: { idPrestamo: idPrestamo },
      fetchPolicy: 'network-only'
    });
  }

  buscarCliente(id: number): Observable<any> {
    return this.apollo.query({
      query: gql`query ($id: Int!) { clientePorId(idCliente: $id) { idCliente nombreCompleto cedula ingresosMensuales fechaNacimiento idPrestamo estado } }`,
      variables: { id },
      fetchPolicy: 'network-only'
    });
  }

  insertarCliente(input: ClienteInput): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($input: ClienteInput!) { addCliente(input: $input) { idCliente } }`,
      variables: { input }
    });
  }

  actualizarCliente(id: number, input: ClienteInput): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($id: Int!, $input: ClienteInput!) { actualizarCliente(idCliente: $id, input: $input) { idCliente } }`,
      variables: { id, input }
    });
  }

  eliminarCliente(id: number): Observable<any> {
    return this.apollo.mutate({
      mutation: gql`mutation ($id: Int!) { eliminarCliente(idCliente: $id) }`,
      variables: { id }
    });
  }

  listarClientesConPrestamo(): Observable<any> {
    return this.apollo.query({
      query: gql`query { clientesConDatosPrestamo { idCliente nombreCompleto cedula ingresosMensuales fechaNacimiento estado montoPrestamo tipoPrestamo } }`,
      fetchPolicy: 'network-only'
    });
  }
}