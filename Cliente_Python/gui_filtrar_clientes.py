import tkinter as tk
from tkinter import messagebox, ttk
from cliente_service import ClienteService
from observer import GestorEventos

class GUIFiltrarClientes:
    def __init__(self, parent):
        self.service = ClienteService()
        self.win = tk.Toplevel(parent)
        self.win.title("Filtrar Clientes por Préstamo")
        self.win.geometry("700x400")

        tk.Label(self.win, text="ID Préstamo:").pack(pady=5)
        self.txt_id_prestamo = tk.Entry(self.win)
        self.txt_id_prestamo.pack()

        self.tree = ttk.Treeview(self.win, columns=("ID", "Nombre", "Cédula", "Ingresos", "Fecha", "Estado"), show="headings")
        for col in self.tree["columns"]:
            self.tree.heading(col, text=col); self.tree.column(col, width=100)
        self.tree.pack(fill="both", expand=True)

        tk.Button(self.win, text="Buscar", command=self.cargar).pack(pady=10)
        GestorEventos.suscribir_cliente(self)  # Suscripción al Observer

    def cargar(self):
        for item in self.tree.get_children(): self.tree.delete(item)
        try:
            for c in self.service.listar_clientes(int(self.txt_id_prestamo.get())):
                self.tree.insert("", "end", values=(c['idCliente'], c['nombreCompleto'], c['cedula'], c['ingresosMensuales'], c['fechaNacimiento'], "ACTIVO" if c['estado'] else "INACTIVO"))
        except Exception as e:
            messagebox.showerror("Error", str(e))