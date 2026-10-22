import tkinter as tk
from tkinter import messagebox
from tkcalendar import DateEntry
from cliente_service import ClienteService
from observer import GestorEventos

class GUIAddCliente:
    def __init__(self, parent):
        self.service = ClienteService()
        self.win = tk.Toplevel(parent)
        self.win.title("Insertar Cliente")
        self.win.geometry("350x400")

        tk.Label(self.win, text="ID Cliente:").pack(); self.txt_id = tk.Entry(self.win); self.txt_id.pack()
        tk.Label(self.win, text="Nombre:").pack(); self.txt_nombre = tk.Entry(self.win); self.txt_nombre.pack()
        tk.Label(self.win, text="Cédula:").pack(); self.txt_cedula = tk.Entry(self.win); self.txt_cedula.pack()
        tk.Label(self.win, text="Ingresos:").pack(); self.txt_ingresos = tk.Entry(self.win); self.txt_ingresos.pack()
        
        tk.Label(self.win, text="Fecha Nacimiento:").pack()
        self.dtp_fecha = DateEntry(self.win, width=12, background='darkblue', foreground='white', borderwidth=2)
        self.dtp_fecha.pack()
        
        tk.Label(self.win, text="ID Préstamo:").pack(); self.txt_id_prestamo = tk.Entry(self.win); self.txt_id_prestamo.pack()

        tk.Button(self.win, text="Guardar", command=self.guardar).pack(pady=15)

    def guardar(self):
        try:
            if (not self.txt_id.get().strip() or not self.txt_nombre.get().strip() or 
                not self.txt_cedula.get().strip() or not self.txt_ingresos.get().strip() or 
                not self.txt_id_prestamo.get().strip()):
                messagebox.showwarning("Campos Vacíos", "Por favor, complete todos los campos.")
                return

            fecha_iso = self.dtp_fecha.get_date().strftime("%Y-%m-%dT%H:%M:%S")
            data = {
                "idCliente": int(self.txt_id.get()),
                "nombreCompleto": self.txt_nombre.get(),
                "cedula": self.txt_cedula.get(),
                "ingresosMensuales": float(self.txt_ingresos.get()),
                "fechaNacimiento": fecha_iso,
                "idPrestamo": int(self.txt_id_prestamo.get()),
                "estado": True
            }
            self.service.insertar_cliente(data)
            messagebox.showinfo("Éxito", "Cliente guardado correctamente")
            GestorEventos.notificar_cliente()
            self.win.destroy()
        except ValueError:
            messagebox.showerror("Error", "El ID, Ingresos y ID Préstamo deben ser numéricos.")
        except Exception as e:
            error_msg = str(e).lower()
            
            # --- AQUÍ ESTÁ LA SOLUCIÓN: Validamos el texto del error ---
            if "nombre" in error_msg:
                messagebox.showerror("Error de Validación", "El nombre no puede contener números ni estar vacío.")
            elif "cédula" in error_msg or "cedula" in error_msg:
                messagebox.showerror("Error de Validación", "La cédula no puede estar vacía.")
            elif "ingresos" in error_msg:
                messagebox.showerror("Error de Validación", "Los ingresos no pueden ser negativos.")
            elif "no existe" in error_msg:
                messagebox.showerror("Error de Validación", "El préstamo ingresado no existe.")
            elif "inactivo" in error_msg:
                messagebox.showerror("Error de Validación", "El préstamo está INACTIVO. No se pueden agregar clientes.")
            elif "ya existe" in error_msg or "internal_error" in error_msg:
                messagebox.showerror("ID Duplicado", f"El ID {self.txt_id.get()} ya está en uso.")
            else:
                messagebox.showerror("Error", str(e))