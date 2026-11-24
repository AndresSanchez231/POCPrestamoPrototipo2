package org.example.client;

import org.example.model.PagoDTO;
import org.springframework.graphql.client.HttpGraphQlClient;
import org.springframework.stereotype.Component;
import org.springframework.web.reactive.function.client.WebClient;

import java.util.List;
import java.util.Map;

@Component
public class PagoClient {

    private final HttpGraphQlClient graphQlClient;

    public PagoClient(WebClient.Builder webClientBuilder) {
        this.graphQlClient = HttpGraphQlClient.builder(
                webClientBuilder.baseUrl("http://localhost:8081/graphql").build()
        ).build();
    }

    public PagoDTO crearPago(PagoDTO pago) {
        String mutation = """
            mutation AddPago($input: PagoInput!) {
                addPago(input: $input) {
                    idPago monto metodoPago fechaPago idPrestamo estado
                }
            }
        """;

        Map<String, Object> inputMap = Map.of(
                "idPago", pago.getIdPago(),
                "monto", pago.getMonto(),
                "metodoPago", pago.getMetodoPago(),
                "fechaPago", pago.getFechaPago().toString(),
                "idPrestamo", pago.getIdPrestamo(),
                "estado", pago.isEstado()
        );

        return graphQlClient.document(mutation)
                .variable("input", inputMap)
                .retrieve("addPago")
                .toEntity(PagoDTO.class)
                .block();
    }

    public List<PagoDTO> listarPagosPorPrestamo(int idPrestamo) {
        String query = """
            query GetPagos($id: Int!) {
                pagosPorPrestamo(idPrestamo: $id) {
                    idPago monto metodoPago fechaPago idPrestamo estado
                }
            }
        """;

        return graphQlClient.document(query)
                .variable("id", idPrestamo)
                .retrieve("pagosPorPrestamo")
                .toEntityList(PagoDTO.class)
                .block();
    }

    public PagoDTO obtenerPago(int idPago) {
        String query = """
            query GetPago($id: Int!) {
                pagoPorId(idPago: $id) {
                    idPago monto metodoPago fechaPago idPrestamo estado
                }
            }
        """;
        return graphQlClient.document(query)
                .variable("id", idPago)
                .retrieve("pagoPorId")
                .toEntity(PagoDTO.class)
                .block();
    }

    public PagoDTO actualizarPago(int idPago, PagoDTO pago) {
        String mutation = """
            mutation UpdatePago($id: Int!, $input: PagoInput!) {
                actualizarPago(idPago: $id, input: $input) {
                    idPago monto metodoPago fechaPago idPrestamo estado
                }
            }
        """;

        Map<String, Object> inputMap = Map.of(
                "idPago", pago.getIdPago(),
                "monto", pago.getMonto(),
                "metodoPago", pago.getMetodoPago(),
                "fechaPago", pago.getFechaPago().toString(),
                "idPrestamo", pago.getIdPrestamo(),
                "estado", pago.isEstado()
        );

        return graphQlClient.document(mutation)
                .variable("id", idPago)
                .variable("input", inputMap)
                .retrieve("actualizarPago")
                .toEntity(PagoDTO.class)
                .block();
    }

    public boolean eliminarPago(int idPago) {
        String mutation = """
            mutation DeletePago($id: Int!) {
                eliminarPago(idPago: $id)
            }
        """;

        Boolean resultado = graphQlClient.document(mutation)
                .variable("id", idPago)
                .retrieve("eliminarPago")
                .toEntity(Boolean.class)
                .block();

        return resultado != null && resultado;
    }
}