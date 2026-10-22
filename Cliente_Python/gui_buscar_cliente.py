import tkinter as tk
from tkinter import messagebox
from cliente_service import ClienteService

class GUIBuscarCliente:
    def __init__(self, parent):
        self.service = ClienteService()
        self.win = tk.Toplevel(parent)
        self.win.title("Buscar Cliente")
        self.win.geometry("350x400")

        # Sección de búsqueda
        frame_buscar = tk.Frame(self.win)
        frame_buscar.pack(pady=10)
        tk.Label(frame_buscar, text="ID Cliente:").pack(side=tk.LEFT)
        self.txt_id = tk.Entry(frame_buscar)
        self.txt_id.pack(side=tk.LEFT, padx=5)
        tk.Button(frame_buscar, text="Buscar", command=self.buscar).pack(side=tk.LEFT)

        # Campos separados
        frame_resultados = tk.Frame(self.win)
        frame_resultados.pack(pady=10)

        # Nombre
        tk.Label(frame_resultados, text="Nombre Completo:").grid(row=0, column=0, sticky="e", pady=2)
        self.txt_nombre = tk.Entry(frame_resultados, state="readonly", width=25)
        self.txt_nombre.grid(row=0, column=1, pady=2)

        # Cédula
        tk.Label(frame_resultados, text="Cédula:").grid(row=1, column=0, sticky="e", pady=2)
        self.txt_cedula = tk.Entry(frame_resultados, state="readonly")
        self.txt_cedula.grid(row=1, column=1, pady=2)

        # Ingresos
        tk.Label(frame_resultados, text="Ingresos Mensuales:").grid(row=2, column=0, sticky="e", pady=2)
        self.txt_ingresos = tk.Entry(frame_resultados, state="readonly")
        self.txt_ingresos.grid(row=2, column=1, pady=2)

        # Fecha Nac
        tk.Label(frame_resultados, text="Fecha Nacimiento:").grid(row=3, column=0, sticky="e", pady=2)
        self.txt_fecha = tk.Entry(frame_resultados, state="readonly")
        self.txt_fecha.grid(row=3, column=1, pady=2)

        # ID Préstamo
        tk.Label(frame_resultados, text="ID Préstamo:").grid(row=4, column=0, sticky="e", pady=2)
        self.txt_id_prestamo = tk.Entry(frame_resultados, state="readonly")
        self.txt_id_prestamo.grid(row=4, column=1, pady=2)

        # Estado
        tk.Label(frame_resultados, text="Estado:").grid(row=5, column=0, sticky="e", pady=2)
        self.txt_estado = tk.Entry(frame_resultados, state="readonly")
        self.txt_estado.grid(row=5, column=1, pady=2)

    def buscar(self):
        try:
            c = self.service.buscar_cliente(int(self.txt_id.get()))
            if c:
                self._set_valor(self.txt_nombre, c['nombreCompleto'])
                self._set_valor(self.txt_cedula, c['cedula'])
                self._set_valor(self.txt_ingresos, c['ingresosMensuales'])
                self._set_valor(self.txt_fecha, c['fechaNacimiento'])
                self._set_valor(self.txt_id_prestamo, c['idPrestamo'])
                self._set_valor(self.txt_estado, "ACTIVO" if c['estado'] else "INACTIVO")
            else:
                messagebox.showinfo("Info", "No se encontró el cliente")
                self._limpiar()
        except Exception as e:
            messagebox.showerror("Error", str(e))

    def _set_valor(self, entry, valor):
        entry.config(state="normal")
        entry.delete(0, tk.END)
        entry.insert(0, valor)
        entry.config(state="readonly")

    def _limpiar(self):
        for entry in [self.txt_nombre, self.txt_cedula, self.txt_ingresos, self.txt_fecha, self.txt_id_prestamo, self.txt_estado]:
            self._set_valor(entry, "")