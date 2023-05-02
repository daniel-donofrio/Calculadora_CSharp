using System.Timers;

namespace Calculadora
{
    internal class Program
    {
        static int Suma(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Mostrar Menu es un procedimiento. Recuerden que para que sea un procedimiento
        /// no tiene que retornar un valor. No tiene que estar la sentencia return dentro del cuerpo
        /// del procedimiento. Para indicar que no retorna un valor está la palabra void en en nombre
        /// del metodo
        /// A modo de ejercicio, si ponen la sentencia return dentro del cuerpo le va a dar error.
        /// deje return "esto les va a dar error" para que lo descomenten y vean.
        /// </summary>
        static void MostrarMenu()
        {
            Console.WriteLine("************************");
            Console.WriteLine("**     Calculadora    **");
            Console.WriteLine("************************");
            Console.WriteLine("** 1 - Suma           **");
            Console.WriteLine("** 2 - Resta          **");
            Console.WriteLine("** 3 - Multiplicacion **");
            Console.WriteLine("** 4 - Division       **");
            Console.WriteLine("** 5 - Salir De Menu  **");
            Console.WriteLine("************************");
            // return "esto les va a dar error";
        }


        /// <summary>
        /// ValidarOpcion es una funcion por lo tanto, tiene que tener un tipo de retorno definido en el nombre del metodo
        /// en este caso es bool. y tiene que tener la sentencia return para devolver un valor.
        /// En este caso ValidarOpcion chequea que la opcion ingresada sea el string 1 o 2 o 3 o 4 o 5;
        /// </summary>
        /// <param name="validarOpcion"></param>
        /// <returns></returns>
        static bool ValidarOpcion(string validarOpcion)
        {
            return (validarOpcion == "1" || validarOpcion == "2" || validarOpcion == "3" || validarOpcion == "4" || validarOpcion == "5");
        }

        static bool EsOpcionDeSalida(string opcion)
        {
            return opcion == "5";
        }
        static bool esArgumentoValido(string numeroString, out int numeroEntero)
        {


            // try parse es una funcion, con lo cual retorna un resultado. En este caso va a retornar si numero string 
            // puede convertirse a entero o no.
            //Recuerdan cuando vimos en los primeros practicos, que los algoritmos tienen datos de salida.
            //Cuando una funcion necesita devolver mas de un valor o un procedimiento necesita devolver
            //mas uno o mas valores, se utiliza en la llamada la palabra reservada out. 
            //Esto significa que el valor asignado en la ejecucion de la funcion, se copiará en la variable result
            //cuando es por valor , por mas que asigne un valor, no sucede nunca la asignacion a result.
            bool esConvertibleAEntero = int.TryParse(numeroString, out numeroEntero);

            return esConvertibleAEntero;
        }

        /// <summary>
        /// lee un argumento por pantalla y la funcion retorna si el numero es valido o no.
        /// Si es valido se asigna el valor a la variable de salida numero.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        static bool LeerArgumento(out int numero)
        {
            Console.Write("ingrese una numero: ");
            string argumento1 = Console.ReadLine();
            bool esValido = esArgumentoValido(argumento1, out numero);
            if (!esValido)
            {
                Console.WriteLine("El numero no es valido");
            }
            return esValido;

        }

        static int EjecutarOpcion(string opcion, int argumento1, int argumento2)
        {

            int resultado = 0;

            if (opcion == "1")
            {
                resultado = argumento1 + argumento2;
            }
            else if (opcion == "2")
            {
                resultado = argumento1 - argumento2;
            }
            else if (argumento2 == 3)
            {
                resultado = argumento1 * argumento2;
            }
            else if (opcion == "4")
            {
                resultado = argumento1 / argumento2;
            }
            return resultado;
        }


        static void Main(string[] args)
        {
            // La variable esOpcionSalida es usada tanto como para no leer los argumentos de las operaciones
            // en caso que quiera salir, como para el corte del while. si la declara dentro del cuerpo del
            // do (Adentro del ciclo) no se podria ver en la condicion de corte.A modo de ejemplo les dejo la sentencia 
            //comentada para que la descomenten y comenten estay puedan ver el error           
            bool esOpcionSalida = false;
            bool arg1Valido, arg2Valido;
            int numero1, numero2, resultado;


            do
            {
                //bool esOpcionSalida = false;
                MostrarMenu();
                Console.WriteLine("Ingrese una opcion:");

                string opcion = Console.ReadLine();
                bool esOpcionValida = ValidarOpcion(opcion);
                if (esOpcionValida)
                {
                    esOpcionSalida = EsOpcionDeSalida(opcion);
                    //Si es opcion de salida, no hace falta leer los argumentos.
                    if (!esOpcionSalida)
                    {
                        do
                        {
                            arg1Valido = LeerArgumento(out numero1);
                        } while (!arg1Valido);
                        do
                        {
                            arg2Valido = LeerArgumento(out numero2);
                            if (arg2Valido && numero2 == 0)
                            {
                                Console.WriteLine("El divisor no puedo ser cero.");
                                arg2Valido = false;
                            }
                        } while (!arg2Valido);

                        resultado = EjecutarOpcion(opcion, numero1, numero2);
                        Console.WriteLine("El resultado de la operacion es:" + resultado);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("La opcion ingresada no es una opcion valida, por favor vuelva a ingresar el numero asociado a la operacion que quiere realizar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!esOpcionSalida);

            Console.WriteLine("Gracias por usar el programa.");

        }
    }
}