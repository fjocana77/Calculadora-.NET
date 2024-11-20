using System;
using ServiceReference1; // Este es el espacio de nombres correcto

namespace CalculadoraSOAPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar el cliente del servicio
            var client = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);

            while (true)
            {
                Console.WriteLine("\n--- Calculadora SOAP ---");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "5")
                {
                    Console.WriteLine("Saliendo...");
                    break;
                }

                // Pedir números al usuario
                Console.Write("Introduce el primer número: ");
                int numero1 = int.Parse(Console.ReadLine());
                Console.Write("Introduce el segundo número: ");
                int numero2 = int.Parse(Console.ReadLine());

                try
                {
                    int resultado = 0;
                    switch (opcion)
                    {
                        case "1": // Sumar
                            resultado = client.AddAsync(numero1, numero2).Result;
                            Console.WriteLine($"Resultado de la suma: {resultado}");
                            break;
                        case "2": // Restar
                            resultado = client.SubtractAsync(numero1, numero2).Result;
                            Console.WriteLine($"Resultado de la resta: {resultado}");
                            break;
                        case "3": // Multiplicar
                            resultado = client.MultiplyAsync(numero1, numero2).Result;
                            Console.WriteLine($"Resultado de la multiplicación: {resultado}");
                            break;
                        case "4": // Dividir
                            if (numero2 != 0)
                            {
                                resultado = client.DivideAsync(numero1, numero2).Result;
                                Console.WriteLine($"Resultado de la división: {resultado}");
                            }
                            else
                            {
                                Console.WriteLine("Error: No se puede dividir entre cero.");
                            }
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, elige entre 1 y 5.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al realizar la operación: {ex.Message}");
                }
            }

            // Cerrar el cliente del servicio
            client.Close();
        }
    }
}
