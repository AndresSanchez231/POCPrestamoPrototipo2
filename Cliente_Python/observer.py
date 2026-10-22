class GestorEventos:
    _suscriptores_prestamos = []
    _suscriptores_clientes = []

    @classmethod
    def suscribir_prestamo(cls, ventana):
        cls._suscriptores_prestamos.append(ventana)

    @classmethod
    def suscribir_cliente(cls, ventana):
        cls._suscriptores_clientes.append(ventana)

    @classmethod
    def notificar_prestamo(cls):
        for ventana in cls._suscriptores_prestamos:
            if ventana.win.winfo_exists():
                ventana.cargar()

    @classmethod
    def notificar_cliente(cls):
        for ventana in cls._suscriptores_clientes:
            if ventana.win.winfo_exists():
                ventana.cargar()