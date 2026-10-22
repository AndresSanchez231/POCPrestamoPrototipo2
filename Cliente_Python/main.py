import tkinter as tk
import gui_add_prestamo, gui_buscar_prestamo, gui_actualizar_prestamo, gui_eliminar_prestamo, gui_listar_prestamos, gui_filtrar_prestamos
import gui_add_cliente, gui_buscar_cliente, gui_actualizar_cliente, gui_eliminar_cliente, gui_listar_clientes, gui_filtrar_clientes

class MainWindow:
    def __init__(self, root):
        self.root = root
        self.root.title("Menú Principal - Préstamos")
        self.root.geometry("400x650")

        tk.Label(root, text="Sistema de Préstamos", font=("Arial", 14, "bold")).pack(pady=10)

        # --- MENÚ PRÉSTAMOS ---
        tk.Label(root, text="--- PRÉSTAMOS ---", font=("Arial", 10, "bold")).pack()
        tk.Button(root, text="Insertar Préstamo", width=25, command=lambda: gui_add_prestamo.GUIAddPrestamo(self.root)).pack(pady=2)
        tk.Button(root, text="Buscar Préstamo", width=25, command=lambda: gui_buscar_prestamo.GUIBuscarPrestamo(self.root)).pack(pady=2)
        tk.Button(root, text="Actualizar Préstamo", width=25, command=lambda: gui_actualizar_prestamo.GUIActualizarPrestamo(self.root)).pack(pady=2)
        tk.Button(root, text="Eliminar Préstamo", width=25, command=lambda: gui_eliminar_prestamo.GUIEliminarPrestamo(self.root)).pack(pady=2)
        tk.Button(root, text="Listar Préstamos", width=25, command=lambda: gui_listar_prestamos.GUIListarPrestamos(self.root)).pack(pady=2)
        tk.Button(root, text="Filtrar Préstamos (Por Tipo)", width=28, command=lambda: gui_filtrar_prestamos.GUIFiltrarPrestamos(self.root)).pack(pady=2)

        # --- MENÚ CLIENTES ---
        tk.Label(root, text="--- CLIENTES ---", font=("Arial", 10, "bold")).pack(pady=5)
        tk.Button(root, text="Insertar Cliente", width=25, command=lambda: gui_add_cliente.GUIAddCliente(self.root)).pack(pady=2)
        tk.Button(root, text="Buscar Cliente", width=25, command=lambda: gui_buscar_cliente.GUIBuscarCliente(self.root)).pack(pady=2)
        tk.Button(root, text="Actualizar Cliente", width=25, command=lambda: gui_actualizar_cliente.GUIActualizarCliente(self.root)).pack(pady=2)
        tk.Button(root, text="Eliminar Cliente", width=25, command=lambda: gui_eliminar_cliente.GUIEliminarCliente(self.root)).pack(pady=2)
        tk.Button(root, text="Listar Clientes (Todos)", width=25, command=lambda: gui_listar_clientes.GUIListarClientes(self.root)).pack(pady=2)
        tk.Button(root, text="Listar Clientes (Por Préstamo)", width=28, command=lambda: gui_filtrar_clientes.GUIFiltrarClientes(self.root)).pack(pady=2)

        tk.Button(root, text="Salir", width=25, command=root.quit, fg="red").pack(pady=15)

if __name__ == "__main__":
    root = tk.Tk()
    app = MainWindow(root)
    root.mainloop()