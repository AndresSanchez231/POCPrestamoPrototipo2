import tkinter as tk
from tkinter import messagebox, ttk
from tkcalendar import DateEntry
from prestamo_service import PrestamoService
from observer import GestorEventos

class GUIAddPrestamo:
    def __init__(self, parent):
        self.service = PrestamoService()
        self.win = tk.Toplevel(parent)
        self.win.title("Insertar Préstamo")
        self.win.geometry("350x350")

        tk.Label(self.win, text="ID Préstamo:").pack(); self.txt_id = tk.Entry(self.win); self.txt_id.pack()
        tk.Label(self.win, text="Monto:").pack(); self.txt_monto = tk.Entry(self.win); self.txt_monto.pack()
        tk.Label(self.win, text="Tasa:").pack(); self.txt_tasa = tk.Entry(self.win); self.txt_tasa.pack()
        
        tk.Label(self.win, text="Fecha Registro:").pack()
        self.dtp_fecha = DateEntry(self.win, width=12, background='darkblue', foreground='white', borderwidth=2)
        self.dtp_fecha.pack()
        
        tk.Label(self.win, text="Tipo:").pack()
        self.combo_tipo = ttk.Combobox(self.win, values=["Casa", "Apartamento", "Local Comercial"], state="readonly")
        self.combo_tipo.pack()

        tk.Button(self.win, text="Guardar", command=self.guardar).pack(pady=15)

    def guardar(self):
        try:
            if (not self.txt_id.get().strip() or not self.txt_monto.get().strip() or 
                not self.txt_tasa.get().strip() or not self.combo_tipo.get().strip()):
                messagebox.showwarning("Campos Vacíos", "Por favor, complete todos los campos antes de guardar.")
                return

            fecha_iso = self.dtp_fecha.get_date().strftime("%Y-%m-%dT%H:%M:%S")
            data = {
                "idPrestamo": int(self.txt_id.get()),
                "monto": float(self.txt_monto.get()),
                "tasaIntereses": float(self.txt_tasa.get()),
                "fechaRegistro": fecha_iso,
                "tipo": self.combo_tipo.get(),
                "estado": True
            }
            self.service.insertar_prestamo(data)
            messagebox.showinfo("Éxito", "Préstamo guardado")
            GestorEventos.notificar_prestamo()
            self.win.destroy()
        except ValueError:
            messagebox.showerror("Error de Formato", "El ID, el Monto y la Tasa deben ser números.")
        except Exception as e:
            error_msg = str(e).lower()
            
            # --- PRIORIDAD DE ERRORES ---
            if "ya existe" in error_msg:
                messagebox.showerror("Error", f"El ID {self.txt_id.get()} ya está en uso.")
            elif "monto" in error_msg:
                messagebox.showerror("Error", "El monto debe ser mayor a cero.")
            elif "tasa" in error_msg:
                messagebox.showerror("Error", "La tasa de interés debe ser mayor a cero.")
            elif "tipo de inmueble inválido" in error_msg:
                messagebox.showerror("Error", "Seleccione un tipo de inmueble válido.")
            elif "inactivo" in error_msg:
                messagebox.showerror("Error", "El préstamo está INACTIVO. No se puede actualizar.")
            else:
                messagebox.showerror("Error", str(e))