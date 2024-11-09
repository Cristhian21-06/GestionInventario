using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }
        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine("Precio actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        public void FiltrarYOrdenarProductos(decimal precioMinimo)

        {
            var productosFiltrados = productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio)
                .ToList();

            if (productosFiltrados.Any())
            {
                Console.WriteLine("Productos filtrados y ordenados:");
                foreach (var producto in productosFiltrados)
                {
                    producto.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("No se encontraron productos que cumplan con el criterio.");
            }
        }
        public void ContarYAgruparProductos()
        {
            var conteoRangos = new
            {
                MenoresA100 = productos.Count(p => p.Precio < 100),
                Entre100Y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500),
                MayoresA500 = productos.Count(p => p.Precio > 500)
            };
            Console.WriteLine("Conteo de productos por rango de precio:");
            Console.WriteLine($"Menores a 100: {conteoRangos.MenoresA100}");
            Console.WriteLine($"Entre 100 y 500: {conteoRangos.Entre100Y500}");
            Console.WriteLine($"Mayores a 500: {conteoRangos.MayoresA500}");
        }
        public void GenerarReporte()
        {
            if (productos.Any())
            {
                decimal precioPromedio = productos.Average(p => p.Precio);
                var precioMaximo = productos.Max(p => p.Precio);
                var precioMinimo = productos.Min(p => p.Precio);
                var productoMasCaro = productos.First(p => p.Precio == precioMaximo);
                var productoMasBarato = productos.First(p => p.Precio == precioMinimo);

                Console.WriteLine("Reporte de Inventario:");
                Console.WriteLine($"Numero total de productos: {productos.Count}");
                Console.WriteLine($"Precio promedio de todos los productos: {precioPromedio:C}");
                Console.WriteLine($"Producto mas caro: {productoMasCaro.Nombre} - Precio: {productoMasCaro.Precio:C}");
                Console.WriteLine($"Producto mas barato: {productoMasBarato.Nombre} - Precio: {productoMasBarato.Precio:C}");
            }
            else
            {
                Console.WriteLine("El inventario esta vacio.");
            }
        }
    }
}