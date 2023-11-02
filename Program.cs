using System;
using System.Collections.Generic;

namespace SistemaGestionInventario
{
    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Id { get; set; }
    }

    class Program
    {
        static List<Producto> inventario = new List<Producto>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Bienvenido al Sistema de Gestión de Inventario");
                Console.WriteLine("1. Ver inventario");
                Console.WriteLine("2. Añadir producto");
                Console.WriteLine("3. Actualizar existencias");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarInventario();
                        break;
                    case "2":
                        AgregarProducto();
                        break;
                    case "3":
                        ActualizarExistencias();
                        break;
                    case "4":
                        EliminarProducto();
                        break;
                    case "5":
                        Console.WriteLine("Gracias por utilizar el sistema");
                        return; // Salir del programa
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void MostrarInventario()
        {
            Console.WriteLine("Inventario actual: ");
            foreach (var producto in inventario)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}");
            }
        }

        static void AgregarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            int nuevoId = inventario.Count + 1; // Asignar un nuevo ID único
            inventario.Add(new Producto { Nombre = nombre, Cantidad = cantidad, Id = nuevoId });
            Console.WriteLine("Producto agregado con éxito al inventario.");
        }

        static void ActualizarExistencias()
        {
            MostrarInventario();
            Console.WriteLine("Ingrese el nombre del producto para actualizar las existencias: ");
            string nombre = Console.ReadLine();
            var producto = inventario.Find(p => p.Nombre == nombre);

            if (producto != null)
            {
                Console.WriteLine("Ingrese la nueva cantidad: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());
                producto.Cantidad = cantidad;
                Console.WriteLine("Existencias actualizadas con éxito.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado en el inventario.");
            }
        }

        static void EliminarProducto()
        {
            MostrarInventario();
            Console.WriteLine("Ingrese el nombre del producto para eliminarlo: ");
            string nombre = Console.ReadLine();
            var producto = inventario.Find(p => p.Nombre == nombre);

            if (producto != null)
            {
                inventario.Remove(producto);
                Console.WriteLine("Producto eliminado con éxito del inventario.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado en el inventario.");
            }
        }
    }
}
