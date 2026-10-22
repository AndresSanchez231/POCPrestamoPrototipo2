import tkinter as tk
from tkinter import messagebox, ttk
from prestamo_service import PrestamoService
from observer import GestorEventos

class GUIFiltrarPrestamos:
    def __init__(self, parent):
        self.service = PrestamoService()
        self.win = tk.Toplevel(parent)
        self.win.title("Filtrar Préstamos por Tipo de Inmueble")
        self.win.geometry("600x400")

        # Sección de filtro
        frame_filtro = tk.Frame(self.win)
        frame_filtro.pack(pady=10)
        
        tk.Label(frame_filtro, text="Tipo Inmueble:").pack(side=tk.LEFT)
        self.combo_tipo = ttk.Combobox(frame_filtro, values=["Casa", "Apartamento", "Local Comercial"], state="readonly")
        self.combo_tipo.pack(side=tk.LEFT, padx=5)
        tk.Button(frame_filtro, text="Filtrar", command=self.cargar).pack(side=tk.LEFT)

        # Tabla
        self.tree = ttk.Treeview(self.win, columns=("ID", "Monto", "Tasa", "Fecha", "Tipo", "Estado"), show="headings")
        for col in self.tree["columns"]:
            self.tree.heading(col, text=col)
            self.tree.column(col, width=90)
        self.tree.pack(fill="both", expand=True, padx=10, pady=10)

        # Suscripción al Observer
        GestorEventos.suscribir_prestamo(self)

    def cargar(self):
        for item in self.tree.get_children():
            self.tree.delete(item)
        
        try:
            tipo_seleccionado = self.combo_tipo.get()
            if not tipo_seleccionado:
                messagebox.showinfo("Info", "Seleccione un tipo de inmueble.")
                return

            prestamos = self.service.listar_prestamos_por_tipo(tipo_seleccionado)
            
            if not prestamos:
                messagebox.showinfo("Info", f"No hay préstamos de tipo {tipo_seleccionado}.")
                return

            for p in prestamos:
                self.tree.insert("", "end", values=(
                    p['idPrestamo'], 
                    p['monto'], 
                    p['tasaIntereses'], 
                    p['fechaRegistro'], 
                    p['tipo'], 
                    "ACTIVO" if p['estado'] else "INACTIVO"
                ))
        except Exception as e:
            messagebox.showerror("Error", str(e))