import tkinter as tk
from tkinter import messagebox, ttk
from tkcalendar import DateEntry
from prestamo_service import PrestamoService
from observer import GestorEventos
import datetime

class GUIActualizarPrestamo:
    def __init__(self, parent):
        self.service = PrestamoService()
        self.win = tk.Toplevel(parent)
        self.win.title("Actualizar Préstamo")
        self.win.geometry("350x400")
        self.estado_actual = True

        frame = tk.Frame(self.win); frame.pack(pady=5)
        tk.Label(frame, text="ID:").pack(side=tk.LEFT); self.txt_id = tk.Entry(frame); self.txt_id.pack(side=tk.LEFT)
        tk.Button(frame, text="Buscar", command=self.buscar).pack(side=tk.LEFT)

        tk.Label(self.win, text="Monto:").pack(); self.txt_monto = tk.Entry(self.win); self.txt_monto.pack()
        tk.Label(self.win, text="Tasa:").pack(); self.txt_tasa = tk.Entry(self.win); self.txt_tasa.pack()
        
        tk.Label(self.win, text="Fecha Registro:").pack()
        self.dtp_fecha = DateEntry(self.win, width=12, background='darkblue', foreground='white', borderwidth=2)
        self.dtp_fecha.pack()
        
        tk.Label(self.win, text="Tipo:").pack()
        self.combo_tipo = ttk.Combobox(self.win, values=["Casa", "Apartamento", "Local Comercial"], state="readonly")
        self.combo_tipo.pack()

        tk.Button(self.win, text="Actualizar", command=self.actualizar).pack(pady=15)

    def buscar(self):
        try:
            p = self.service.buscar_prestamo(int(self.txt_id.get()))
            if p:
                self.txt_monto.delete(0, tk.END); self.txt_monto.insert(0, p['monto'])
                self.txt_tasa.delete(0, tk.END); self.txt_tasa.insert(0, p['tasaIntereses'])
                fecha_dt = datetime.datetime.fromisoformat(p['fechaRegistro'])
                self.dtp_fecha.set_date(fecha_dt)
                self.combo_tipo.set(p['tipo'])
                self.estado_actual = p['estado']
                if not p['estado']:
                    messagebox.showwarning("Aviso", "Este préstamo está INACTIVO. No podrá ser actualizado.")
            else: messagebox.showinfo("Info", "No encontrado")
        except Exception as e: messagebox.showerror("Error", str(e))

    def actualizar(self):
        try:
            fecha_iso = self.dtp_fecha.get_date().strftime("%Y-%m-%dT%H:%M:%S")
            data = {
                "idPrestamo": int(self.txt_id.get()),
                "monto": float(self.txt_monto.get()),
                "tasaIntereses": float(self.txt_tasa.get()),
                "fechaRegistro": fecha_iso,
                "tipo": self.combo_tipo.get(),
                "estado": self.estado_actual
            }
            self.service.actualizar_prestamo(int(self.txt_id.get()), data)
            messagebox.showinfo("Éxito", "Préstamo actualizado")
            GestorEventos.notificar_prestamo()
        except Exception as e:
            error_msg = str(e).lower()
            if "inactivo" in error_msg:
                messagebox.showerror("Error", "El préstamo está INACTIVO. No se puede actualizar.")
            elif "monto" in error_msg:
                messagebox.showerror("Error", "El monto debe ser mayor a cero.")
            elif "tasa" in error_msg:
                messagebox.showerror("Error", "La tasa debe ser mayor a cero.")
            else:
                messagebox.showerror("Error", str(e))