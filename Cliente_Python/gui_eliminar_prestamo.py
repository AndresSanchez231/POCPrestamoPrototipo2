import tkinter as tk
from tkinter import messagebox
from prestamo_service import PrestamoService
from observer import GestorEventos

class GUIEliminarPrestamo:
    def __init__(self, parent):
        self.service = PrestamoService()
        self.win = tk.Toplevel(parent)
        self.win.title("Eliminar Préstamo")
        self.win.geometry("400x450")

        # --- Sección de búsqueda ---
        frame_buscar = tk.Frame(self.win)
        frame_buscar.pack(pady=10)
        tk.Label(frame_buscar, text="ID Préstamo:").pack(side=tk.LEFT)
        self.txt_id = tk.Entry(frame_buscar)
        self.txt_id.pack(side=tk.LEFT, padx=5)
        tk.Button(frame_buscar, text="Buscar", command=self.buscar).pack(side=tk.LEFT)

        # --- Sección de resultados (Casillas separadas) ---
        frame_resultados = tk.Frame(self.win)
        frame_resultados.pack(pady=10)

        # Monto
        tk.Label(frame_resultados, text="Monto:").grid(row=0, column=0, sticky="e", pady=2)
        self.txt_monto = tk.Entry(frame_resultados, state="readonly", width=25)
        self.txt_monto.grid(row=0, column=1, pady=2)

        # Tasa
        tk.Label(frame_resultados, text="Tasa Intereses:").grid(row=1, column=0, sticky="e", pady=2)
        self.txt_tasa = tk.Entry(frame_resultados, state="readonly")
        self.txt_tasa.grid(row=1, column=1, pady=2)

        # Fecha
        tk.Label(frame_resultados, text="Fecha Registro:").grid(row=2, column=0, sticky="e", pady=2)
        self.txt_fecha = tk.Entry(frame_resultados, state="readonly")
        self.txt_fecha.grid(row=2, column=1, pady=2)

        # Tipo
        tk.Label(frame_resultados, text="Tipo Inmueble:").grid(row=3, column=0, sticky="e", pady=2)
        self.txt_tipo = tk.Entry(frame_resultados, state="readonly")
        self.txt_tipo.grid(row=3, column=1, pady=2)

        # Estado
        tk.Label(frame_resultados, text="Estado:").grid(row=4, column=0, sticky="e", pady=2)
        self.txt_estado = tk.Entry(frame_resultados, state="readonly")
        self.txt_estado.grid(row=4, column=1, pady=2)

        # --- Botón de Eliminar ---
        self.btn_eliminar = tk.Button(self.win, text="Eliminar", command=self.eliminar, state=tk.DISABLED, bg="red", fg="white")
        self.btn_eliminar.pack(pady=15)

    def buscar(self):
        try:
            p = self.service.buscar_prestamo(int(self.txt_id.get()))
            if p:
                # Llenar cada casilla con su atributo
                self._set_valor(self.txt_monto, p['monto'])
                self._set_valor(self.txt_tasa, p['tasaIntereses'])
                self._set_valor(self.txt_fecha, p['fechaRegistro'])
                self._set_valor(self.txt_tipo, p['tipo'])
                self._set_valor(self.txt_estado, "ACTIVO" if p['estado'] else "INACTIVO")
                
                self.btn_eliminar.config(state=tk.NORMAL)
            else:
                messagebox.showinfo("Info", "No encontrado")
                self._limpiar()
                self.btn_eliminar.config(state=tk.DISABLED)
        except Exception as e: 
            messagebox.showerror("Error", str(e))

    def eliminar(self):
        try:
            self.service.eliminar_prestamo(int(self.txt_id.get()))
            messagebox.showinfo("Éxito", "Eliminado (Inactivo)")
            GestorEventos.notificar_prestamo()
            self.win.destroy()
        except Exception as e: 
            messagebox.showerror("Error", str(e))

    # Funciones auxiliares para manejar las cajas de texto
    def _set_valor(self, entry, valor):
        entry.config(state="normal")
        entry.delete(0, tk.END)
        entry.insert(0, valor)
        entry.config(state="readonly")

    def _limpiar(self):
        for entry in [self.txt_monto, self.txt_tasa, self.txt_fecha, self.txt_tipo, self.txt_estado]:
            self._set_valor(entry, "")