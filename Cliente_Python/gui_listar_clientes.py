import tkinter as tk
from tkinter import messagebox, ttk
from cliente_service import ClienteService
from observer import GestorEventos

class GUIListarClientes:
    def __init__(self, parent):
        self.service = ClienteService()
        self.win = tk.Toplevel(parent)
        self.win.title("Listar TODOS los Clientes")
        self.win.geometry("700x400")

        self.tree = ttk.Treeview(self.win, columns=("ID", "Nombre", "Cédula", "Ingresos", "Fecha", "ID Préstamo", "Estado"), show="headings")
        for col in self.tree["columns"]:
            self.tree.heading(col, text=col); self.tree.column(col, width=90)
        self.tree.pack(fill="both", expand=True)

        tk.Button(self.win, text="Refrescar", command=self.cargar).pack(pady=10)
        self.cargar()
        GestorEventos.suscribir_cliente(self)  # Suscripción al Observer

    def cargar(self):
        for item in self.tree.get_children(): self.tree.delete(item)
        try:
            for c in self.service.listar_todos_clientes():
                self.tree.insert("", "end", values=(c['idCliente'], c['nombreCompleto'], c['cedula'], c['ingresosMensuales'], c['fechaNacimiento'], c['idPrestamo'], "ACTIVO" if c['estado'] else "INACTIVO"))
        except Exception as e:
            messagebox.showerror("Error", str(e))