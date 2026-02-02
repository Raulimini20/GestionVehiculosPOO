using System;
using System.Collections.Generic;
using System.Globalization;

namespace GestionVehiculosPOO
{
    class Vehiculo
    {
        // Atributos privados
        private string marca;
        private string modelo;
        private int año;
        private decimal precio;

        // Métodos públicos (encapsulamiento)
        public string Marca
        {
            get { return marca; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    marca = value;
                else
                    Console.WriteLine("La marca no puede estar vacía.");
            }
        }

        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    modelo = value;
                else
                    Console.WriteLine("El modelo no puede estar vacío.");
            }
        }

        public int Año
        {
            get { return año; }
            set
            {
                if (value > 1900 && value <= DateTime.Now.Year)
                    año = value;
                else
                    Console.WriteLine("El año ingresado no es válido.");
            }
        }

        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value > 0)
                    precio = value;
                else
                    Console.WriteLine("El precio debe ser mayor a 0.");
            }
        }

        // Método para mostrar información con formato de moneda
        public void MostrarInfo()
        {
            Console.WriteLine(
                $"Vehículo: {marca} {modelo}, Año: {año}, Precio: {precio.ToString("C0", new CultureInfo("es-MX"))}"
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            string opcion;

            do
            {
                Console.WriteLine("\n--- Gestión de Vehículos ---");
                Console.WriteLine("1. Agregar vehículo");
                Console.WriteLine("2. Mostrar vehículos");
                Console.WriteLine("3. Salir");
                Console.Write("Elige una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Vehiculo v = new Vehiculo();

                        Console.Write("Marca: ");
                        v.Marca = Console.ReadLine();

                        Console.Write("Modelo: ");
                        v.Modelo = Console.ReadLine();

                        Console.Write("Año: ");
                        v.Año = int.Parse(Console.ReadLine());

                        Console.Write("Precio: ");
                        v.Precio = decimal.Parse(Console.ReadLine());

                        listaVehiculos.Add(v);
                        Console.WriteLine("Vehículo agregado correctamente.");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Lista de Vehículos ---");
                        foreach (var vehiculo in listaVehiculos)
                        {
                            vehiculo.MostrarInfo();
                        }
                        break;

                    case "3":
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida, intenta de nuevo.");
                        break;
                }

            } while (opcion != "3");
        }
    }
}
