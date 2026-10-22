import tkinter as tk
from tkinter import messagebox
from tkcalendar import DateEntry
from cliente_service import ClienteService
from observer import GestorEventos
import datetime

class GUIActualizarCliente:
    def __init__(self, parent):
        self.service = ClienteService()
        self.win = tk.Toplevel(parent)
        self.win.title("Actualizar Cliente")
        self.win.geometry("350x450")
        self.estado_actual = True

        frame = tk.Frame(self.win); frame.pack(pady=5)
        tk.Label(frame, text="ID:").pack(side=tk.LEFT); self.txt_id = tk.Entry(frame); self.txt_id.pack(side=tk.LEFT)
        tk.Button(frame, text="Buscar", command=self.buscar).pack(side=tk.LEFT)

        tk.Label(self.win, text="Nombre:").pack(); self.txt_nombre = tk.Entry(self.win); self.txt_nombre.pack()
        tk.Label(self.win, text="Cédula:").pack(); self.txt_cedula = tk.Entry(self.win); self.txt_cedula.pack()
        tk.Label(self.win, text="Ingresos:").pack(); self.txt_ingresos = tk.Entry(self.win); self.txt_ingresos.pack()
        
        tk.Label(self.win, text="Fecha Nacimiento:").pack()
        self.dtp_fecha = DateEntry(self.win, width=12, background='darkblue', foreground='white', borderwidth=2)
        self.dtp_fecha.pack()
        
        tk.Label(self.win, text="ID Préstamo:").pack(); self.txt_id_prestamo = tk.Entry(self.win); self.txt_id_prestamo.pack()

        tk.Button(self.win, text="Actualizar", command=self.actualizar).pack(pady=15)

    def buscar(self):
        try:
            c = self.service.buscar_cliente(int(self.txt_id.get()))
            if c:
                self.txt_nombre.delete(0, tk.END); self.txt_nombre.insert(0, c['nombreCompleto'])
                self.txt_cedula.delete(0, tk.END); self.txt_cedula.insert(0, c['cedula'])
                self.txt_ingresos.delete(0, tk.END); self.txt_ingresos.insert(0, c['ingresosMensuales'])
                fecha_dt = datetime.datetime.fromisoformat(c['fechaNacimiento'])
                self.dtp_fecha.set_date(fecha_dt)
                self.txt_id_prestamo.delete(0, tk.END); self.txt_id_prestamo.insert(0, c['idPrestamo'])
                self.estado_actual = c['estado']
                if not c['estado']:
                    messagebox.showwarning("Aviso", "Este cliente está INACTIVO. No podrá ser actualizado.")
            else: messagebox.showinfo("Info", "No encontrado")
        except Exception as e: messagebox.showerror("Error", str(e))

    def actualizar(self):
        try:
            fecha_iso = self.dtp_fecha.get_date().strftime("%Y-%m-%dT%H:%M:%S")
            data = {
                "idCliente": int(self.txt_id.get()),
                "nombreCompleto": self.txt_nombre.get(),
                "cedula": self.txt_cedula.get(),
                "ingresosMensuales": float(self.txt_ingresos.get()),
                "fechaNacimiento": fecha_iso,
                "idPrestamo": int(self.txt_id_prestamo.get()),
                "estado": self.estado_actual
            }
            self.service.actualizar_cliente(int(self.txt_id.get()), data)
            messagebox.showinfo("Éxito", "Cliente actualizado")
            GestorEventos.notificar_cliente()
        except Exception as e:
            error_msg = str(e).lower()
            if "inactivo" in error_msg:
                messagebox.showerror("Error", "El cliente está INACTIVO. No se puede actualizar.")
            elif "nombre" in error_msg:
                messagebox.showerror("Error", "El nombre no puede contener números.")
            else:
                messagebox.showerror("Error", str(e))