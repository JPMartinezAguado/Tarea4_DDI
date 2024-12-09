using System;


namespace Tarea4_Jose_Placido_Martinez_Aguado
{
    internal class Program
    {
        //Declaramos variables estaticas que guarden el tamaño y datos del array
        //para poder ser llamadas por los distintos métodos
        private static int intTamanoArray;
        private static int[] serieAleatoria;

        static void Main(string[] args)
        {
            //Secuencia de llamada a los metodos del programa
            intTamanoArray = DimensionarArray();
            serieAleatoria = CrearArray();
            PreguntarPorCambios(serieAleatoria);
            RefinarSerieAleatoria(serieAleatoria);
        }

        /// <summary>
        /// Solicita al usuario un numero para dimensionar el array
        /// </summary>
        /// <returns>tamaño del array inicial</returns>
        public static int DimensionarArray()
        {
            Console.WriteLine("Introduce la cantidad de numeros que contendrá el array:");
            string strEntrada = Console.ReadLine();
            if (int.TryParse(strEntrada, out int intTamanoArray))
            {
                Console.WriteLine($"Su lista de numeros contendrá {intTamanoArray} numeros");
                return intTamanoArray;
            }
            else
            {
                Console.WriteLine($"{strEntrada} no es un valor valido. Intentelo de nuevo");
                return DimensionarArray();//Mientras no escriba un valor valido, se vuelve a llamar al metodo
            }
        }

        /// <summary>
        /// Creamos un array aleatorio 
        /// </summary>
        /// <returns>array creado</returns>
        public static int[] CrearArray()
        {
            Random rnd = new Random();//creacion de objeto random para usar en llenado de array
            int[] serieAleatoria = new int[intTamanoArray];

            for (int i = 0; i < intTamanoArray; i++)//a cada posicion del array se le asigna un numero entre el 0 y el 100
            {
                serieAleatoria[i] = rnd.Next(101);
            }
            //se muestran los numeros creados en una linea, con dos eespacios entre cada uno
            Console.WriteLine("Los numeros que componen su lista de numeros son:");
            foreach (int numero in serieAleatoria)
            {
                Console.Write(numero + "  ");
            }
            Console.WriteLine();
            return serieAleatoria;
        }

        /// <summary>
        /// metodo que 
        /// </summary>
        /// <param name="serieAleatoria"></param>
        public static void PreguntarPorCambios(int[] serieAleatoria)
        {
            string respuesta;
            //bucle que se repetirá hasta que el usuario responda si o no
            do
            {
                Console.WriteLine("¿Desea modificar algunos numeros? Escriba Si o No:");
                respuesta = Console.ReadLine().ToLower();
                if (respuesta == "si")
                {
                    CambioElementos(serieAleatoria);
                }
                else if (respuesta == "no")
                {
                    // si elige que no quiere hacer cambios, sale del bucle do while sin hacer nada
                }
                else
                {
                    Console.WriteLine("Por favor, escriba solo si o no.");
                }
            }
            while (respuesta != "si" && respuesta != "no");
        }

        /// <summary>
        /// metodo para cambiar numeros del array por otros
        /// </summary>
        /// <param name="serieAleatoria"></param>
        public static void CambioElementos(int[] serieAleatoria)
        {
            Console.WriteLine("Escriba los numeros que desee cambiar separados por comas:");
            //recogo los numeros que el usuario desea cambiar
            //y los guardo en elementos de un array, usando la coma como delimitador de los substrings
            string[] datoRecogido = Console.ReadLine().Split(',');

            //recorro con un foreach cada dato del array creado
            foreach (string dato in datoRecogido)
            {
                //parseo cada dato del array a integer
                if (int.TryParse(dato, out int numero))
                {
                    //defino una condicion que indica si el numero parseado esta en el array creado o no
                    bool encontrado = false;

                    for (int i = 0; i < serieAleatoria.Length; i++)
                    {
                        if (serieAleatoria[i] == numero)//si alguno de los numeros del array coincide...
                        {
                            //...solicio y recogo el numero que se desea introducir en su lugar
                            Console.WriteLine($"Escriba el numero que desee que sustituya {numero}:");
                            string strSubstituto = Console.ReadLine();
                            //si el nuevo numero pasa el parse, igualo el valor del array original al nuevo numero introducido
                            if (int.TryParse(strSubstituto, out int intSubstituto))
                            {
                                serieAleatoria[i] = intSubstituto;
                                Console.WriteLine("Numero cambiado correctamente");
                            }
                            else
                            {
                                Console.WriteLine("Numero no valido, no se efectuará el cambio");
                            }
                            //informo que en este caso el numero a cambiar coincide con alguno del array original,
                            //y prosigo el bucle que recorre el array.
                            encontrado = true;
                            break;
                        }
                    }
                    //si el numero parseado no ha encontrado ocincidencia, informo al usuario
                    if (!encontrado)
                    {
                        Console.WriteLine($"El numero {numero} no se encuentra en la serie aleatoria");
                    }
                }
                //caso de que el substring recogido no pueda ser convertido a integer
                else
                {
                    Console.WriteLine($"{dato} no es un número válido.");
                }
            }
        }

        /// <summary>
        /// metodo que modifica el array eliminando las entradas duplicadas 
        /// </summary>
        /// <param name="serieAleatoria"></param>
        public static void RefinarSerieAleatoria(int[] serieAleatoria)
        {
            //creo un array temporal que con el metodo Distinct() guarda solo una copia de cada valor que esté duplicado
            int[] arrayRefinado =  serieAleatoria.Distinct().ToArray();
            
            serieAleatoria = arrayRefinado;
            Console.WriteLine("Los numeros que componen su lista de numeros sin duplicados son:");
            foreach (int numero in serieAleatoria)
            {
                Console.Write(numero + "  ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

