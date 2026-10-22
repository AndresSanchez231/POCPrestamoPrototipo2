import tkinter as tk
from tkinter import messagebox, ttk
from prestamo_service import PrestamoService
from observer import GestorEventos

class GUIListarPrestamos:
    def __init__(self, parent):
        self.service = PrestamoService()
        self.win = tk.Toplevel(parent)
        self.win.title("Listar Préstamos")
        self.win.geometry("600x400")

        self.tree = ttk.Treeview(self.win, columns=("ID", "Monto", "Tasa", "Fecha", "Tipo", "Estado"), show="headings")
        for col in self.tree["columns"]:
            self.tree.heading(col, text=col); self.tree.column(col, width=90)
        self.tree.pack(fill="both", expand=True)

        tk.Button(self.win, text="Refrescar", command=self.cargar).pack(pady=10)
        self.cargar()
        GestorEventos.suscribir_prestamo(self)  # Suscripción al Observer

    def cargar(self):
        for item in self.tree.get_children(): self.tree.delete(item)
        try:
            for p in self.service.listar_prestamos():
                self.tree.insert("", "end", values=(p['idPrestamo'], p['monto'], p['tasaIntereses'], p['fechaRegistro'], p['tipo'], "ACTIVO" if p['estado'] else "INACTIVO"))
        except Exception as e:
            messagebox.showerror("Error", str(e))