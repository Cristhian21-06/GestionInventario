using GestionInventario;
using System;

class Program
{
    static void Main()
    {
        Inventario inventario = new Inventario();
        while (true)
        {
            Console.WriteLine("Gestion de Inventario:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Actualizar precio de producto");
            Console.WriteLine("3. Eliminar producto");
            Console.WriteLine("4. Filtrar y ordenar productos por precio");
            Console.WriteLine("5. Contar y agrupar productos");
            Console.WriteLine("6. Generar reporte de inventario");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opcion: ");

            // Solicita una opcion hasta que sea valida 
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 7)
            {
                Console.WriteLine("Opcion invalida. Debe ingresar un numero entre 1 y 7.");
                Console.Write("Seleccione una opcion: ");
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    decimal precio;

                    do
                    {
                        Console.Write("Ingrese el precio del producto: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0);
                    inventario.AgregarProducto(new Producto(nombre, precio));
                    Console.WriteLine("Producto agregado exitosamente.");
                    break;

                case 2:
                    Console.Write("Ingrese el nombre del producto a actualizar: ");
                    string nombreActualizar = Console.ReadLine();
                    decimal nuevoPrecio;
                    do
                    {
                        Console.Write("Ingrese el nuevo precio: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0);
                    inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
                    break;

                case 3:
                    Console.Write("Ingrese el nombre del producto a eliminar: ");
                    string nombreEliminar = Console.ReadLine();
                    inventario.EliminarProducto(nombreEliminar);
                    break;

                case 4:
                    decimal precioMinimo;
                    do
                    {
                        Console.Write("Ingrese el precio minimo para filtrar: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out precioMinimo));

                    inventario.FiltrarYOrdenarProductos(precioMinimo);
                    break;

                case 5:
                    inventario.ContarYAgruparProductos();
                    break;

                case 6:
                    inventario.GenerarReporte();
                    break;

                case 7:
                    Console.WriteLine("Saliendo del programa.");
                    return;
            }
        }
    }
}
