using System;

namespace EXAMEN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Colonización a Marte - Envío de material a las planicies");
            Console.WriteLine("Se realizarán 15 lanzamientos de materiales necesarios para la colonización,");
            Console.WriteLine("que estarán ubicados en las planicies(A)cidalia, (E)lysium y (U)topia.");
            Console.WriteLine("Cada lanzamiento tiene un cargamento de hasta 10.000 kg.\n");

            int totalLanzamientos = 0;
            string destino = "";
            float pesoCarga = 0;

            DESTINO[] ElDestino = new DESTINO[15];

            float[] totalesCarga = new float[3];

            int[] cantidadLanzamientos = new int[3];

            for (int i = 0; i < 3; i++)
            {
                totalesCarga[i] = 0;
                cantidadLanzamientos[i] = 0;
            }

            while (totalLanzamientos < 15)
            {
                Console.Write("\nIngresa el destino para el lanzamiento {0} (A,E,U): ", totalLanzamientos + 1);
                ElDestino[totalLanzamientos].Lugar = Console.ReadLine().ToUpper();

                if (ElDestino[totalLanzamientos].Lugar == "A" || ElDestino[totalLanzamientos].Lugar == "E" || ElDestino[totalLanzamientos].Lugar == "U")
                {
                    try
                    {
                        Console.Write("Ingresa el valor del cargamento [0;10000]: ");
                        ElDestino[totalLanzamientos].Peso = float.Parse(Console.ReadLine());

                        if (pesoCarga >= 0 && pesoCarga <= 10000)
                        {
                            //El peso de la carga está en el destino válido, procedemos a acumular en la variable respectiva
                            switch (destino)
                            {
                                case "A":
                                    cantidadLanzamientos[0]++;
                                    totalesCarga[0] += pesoCarga;
                                    break;

                                case "E":
                                    cantidadLanzamientos[1]++;
                                    totalesCarga[1] += pesoCarga;
                                    break;

                                case "U":
                                    cantidadLanzamientos[2]++;
                                    totalesCarga[2] += pesoCarga;
                                    break;
                            }

                            //Finalmente incrementamos el conteo de lanzamientos, sentencia de salida del ciclo while
                            totalLanzamientos++;
                        }
                        else
                        {
                            Console.WriteLine("Ingresaste un valor de carga fuera del rango [0;10000]. Intenta nuevamente! \n");
                        }
                    }
                    catch (FormatException error)
                    {
                        Console.WriteLine("Ingresaste un dato no numérico. Intenta nuevamente!");
                        Console.WriteLine("Error: {0} \n", error.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Ingresaste un destino inválido. Intenta nuevamente! \n");
                }
            }

            //aqui calculamos los promedios de efectividad
            float[] promedios = CalculaPromedioEfectividad(cantidadLanzamientos, totalesCarga);

            //Aqui visualizamos resultados
            Console.WriteLine("\n\nResultados obtenidos de los lanzamientos:\n");

            Console.Write("\nPlanicie: \tA \tE \tU");
            Console.Write("\nLanzamientos: \t");
            for (int i = 0; i < 3; i++)
                Console.Write(cantidadLanzamientos[i] + "\t");

            Console.Write("\nTotal Carga: \t");
            for (int i = 0; i < 3; i++)
                Console.Write(totalesCarga[i] + "\t");

            Console.Write("\nPromedio: \t");
            for (int i = 0; i < 3; i++)
                Console.Write(promedios[i] + "\t");

            Console.WriteLine();

        }

        static float[] CalculaPromedioEfectividad(int[] arregloLanzamientos, float[] arregloCargas)
        {
            float[] promedios = new float[3];

            //aqui calculamos el promedio, evitando la división por cero
            for (int i = 0; i < promedios.Length; i++)
            {
                //Si no hay lanzamientos, el promedio es cero
                if (arregloLanzamientos[i] == 0)
                    promedios[i] = 0;
                else
                    promedios[i] = arregloCargas[i] / arregloLanzamientos[i];
            }
            return promedios;
        }
    }
}
