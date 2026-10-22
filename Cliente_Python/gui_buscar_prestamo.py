import tkinter as tk
from tkinter import messagebox
from prestamo_service import PrestamoService

class GUIBuscarPrestamo:
    def __init__(self, parent):
        self.service = PrestamoService()
        self.win = tk.Toplevel(parent)
        self.win.title("Buscar Préstamo")
        self.win.geometry("350x350")

        # Sección de búsqueda
        frame_buscar = tk.Frame(self.win)
        frame_buscar.pack(pady=10)
        tk.Label(frame_buscar, text="ID Préstamo:").pack(side=tk.LEFT)
        self.txt_id = tk.Entry(frame_buscar)
        self.txt_id.pack(side=tk.LEFT, padx=5)
        tk.Button(frame_buscar, text="Buscar", command=self.buscar).pack(side=tk.LEFT)

        # Campos separados para los resultados (Readonly)
        frame_resultados = tk.Frame(self.win)
        frame_resultados.pack(pady=10)

        # Monto
        tk.Label(frame_resultados, text="Monto:").grid(row=0, column=0, sticky="e", pady=2)
        self.txt_monto = tk.Entry(frame_resultados, state="readonly")
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

    def buscar(self):
        try:
            p = self.service.buscar_prestamo(int(self.txt_id.get()))
            if p:
                # Llenamos cada casilla con su atributo correspondiente
                self.txt_monto.config(state="normal")
                self.txt_monto.delete(0, tk.END)
                self.txt_monto.insert(0, p['monto'])
                self.txt_monto.config(state="readonly")

                self.txt_tasa.config(state="normal")
                self.txt_tasa.delete(0, tk.END)
                self.txt_tasa.insert(0, p['tasaIntereses'])
                self.txt_tasa.config(state="readonly")

                self.txt_fecha.config(state="normal")
                self.txt_fecha.delete(0, tk.END)
                self.txt_fecha.insert(0, p['fechaRegistro'])
                self.txt_fecha.config(state="readonly")

                self.txt_tipo.config(state="normal")
                self.txt_tipo.delete(0, tk.END)
                self.txt_tipo.insert(0, p['tipo'])
                self.txt_tipo.config(state="readonly")

                self.txt_estado.config(state="normal")
                self.txt_estado.delete(0, tk.END)
                self.txt_estado.insert(0, "ACTIVO" if p['estado'] else "INACTIVO")
                self.txt_estado.config(state="readonly")
            else:
                messagebox.showinfo("Info", "No se encontró el préstamo")
                self.limpiar_campos()
        except Exception as e:
            messagebox.showerror("Error", str(e))

    def limpiar_campos(self):
        for entry in [self.txt_monto, self.txt_tasa, self.txt_fecha, self.txt_tipo, self.txt_estado]:
            entry.config(state="normal")
            entry.delete(0, tk.END)
            entry.config(state="readonly")