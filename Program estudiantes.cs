using System;

namespace GestionEstudiantes
{
    class Program
    {
        const int MAX_ESTUDIANTES = 100;

        static string[] matriculas = new string[MAX_ESTUDIANTES];
        static string[] nombres = new string[MAX_ESTUDIANTES];
        static string[] apellidos = new string[MAX_ESTUDIANTES];
        static string[] telefonos = new string[MAX_ESTUDIANTES];
        static string[] correos = new string[MAX_ESTUDIANTES];
        static string[] carreras = new string[MAX_ESTUDIANTES];
        static string[] grados = new string[MAX_ESTUDIANTES];

        static int cantidadEstudiantes = 0;

        static void Main(string[] args)
        {
            int opcion;
            bool entradaValida;

            do
            {
                Console.WriteLine("\n--- MENÚ DE GESTIÓN DE ESTUDIANTES ---");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Modificar estudiante");
                Console.WriteLine("3. Eliminar estudiante");
                Console.WriteLine("4. Buscar estudiante");
                Console.WriteLine("5. Listar estudiantes");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                entradaValida = int.TryParse(Console.ReadLine(), out opcion);

                if (!entradaValida)
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1: AgregarEstudiante(); break;
                    case 2: ModificarEstudiante(); break;
                    case 3: EliminarEstudiante(); break;
                    case 4: BuscarEstudiante(); break;
                    case 5: ListarEstudiantes(); break;
                    case 6: Console.WriteLine("Saliendo del programa..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }

            } while (opcion != 6);
        }

        static void AgregarEstudiante()
        {
            if (cantidadEstudiantes >= MAX_ESTUDIANTES)
            {
                Console.WriteLine("Capacidad máxima alcanzada.");
                return;
            }

            Console.WriteLine("\n--- AGREGAR ESTUDIANTE ---");

            Console.Write("Matrícula: ");
            matriculas[cantidadEstudiantes] = LeerTextoSeguro();

            Console.Write("Nombre: ");
            nombres[cantidadEstudiantes] = LeerTextoSeguro();

            Console.Write("Apellido: ");
            apellidos[cantidadEstudiantes] = LeerTextoSeguro();

            Console.Write("Teléfono: ");
            telefonos[cantidadEstudiantes] = LeerTextoSeguro();

            Console.Write("Correo: ");
            correos[cantidadEstudiantes] = LeerTextoSeguro();

            Console.Write("Carrera: ");
            carreras[cantidadEstudiantes] = LeerTextoSeguro();

            Console.Write("Grado: ");
            grados[cantidadEstudiantes] = LeerTextoSeguro();

            cantidadEstudiantes++;
            Console.WriteLine("Estudiante agregado correctamente.");
        }

        static void ModificarEstudiante()
        {
            Console.Write("\nIngrese la matrícula del estudiante a modificar: ");
            string matriculaBuscada = LeerTextoSeguro();
            int pos = BuscarPosicion(matriculaBuscada);

            if (pos == -1)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            Console.WriteLine("Ingrese los nuevos datos:");
            Console.Write("Nombre: ");
            nombres[pos] = LeerTextoSeguro();
            Console.Write("Apellido: ");
            apellidos[pos] = LeerTextoSeguro();
            Console.Write("Teléfono: ");
            telefonos[pos] = LeerTextoSeguro();
            Console.Write("Correo: ");
            correos[pos] = LeerTextoSeguro();
            Console.Write("Carrera: ");
            carreras[pos] = LeerTextoSeguro();
            Console.Write("Grado: ");
            grados[pos] = LeerTextoSeguro();

            Console.WriteLine("Estudiante modificado correctamente.");
        }

        static void EliminarEstudiante()
        {
            Console.Write("\nIngrese la matrícula del estudiante a eliminar: ");
            string matriculaBuscada = LeerTextoSeguro();
            int pos = BuscarPosicion(matriculaBuscada);

            if (pos == -1)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            // Mover los datos una posición hacia atrás
            for (int i = pos; i < cantidadEstudiantes - 1; i++)
            {
                matriculas[i] = matriculas[i + 1];
                nombres[i] = nombres[i + 1];
                apellidos[i] = apellidos[i + 1];
                telefonos[i] = telefonos[i + 1];
                correos[i] = correos[i + 1];
                carreras[i] = carreras[i + 1];
                grados[i] = grados[i + 1];
            }

            cantidadEstudiantes--;
            Console.WriteLine("Estudiante eliminado correctamente.");
        }

        static void BuscarEstudiante()
        {
            Console.Write("\nIngrese la matrícula del estudiante a buscar: ");
            string matriculaBuscada = LeerTextoSeguro();
            int pos = BuscarPosicion(matriculaBuscada);

            if (pos == -1)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            Console.WriteLine($"\nDatos del estudiante:");
            Console.WriteLine($"Nombre: {nombres[pos]}");
            Console.WriteLine($"Apellido: {apellidos[pos]}");
            Console.WriteLine($"Teléfono: {telefonos[pos]}");
            Console.WriteLine($"Correo: {correos[pos]}");
            Console.WriteLine($"Carrera: {carreras[pos]}");
            Console.WriteLine($"Grado: {grados[pos]}");
        }

        static void ListarEstudiantes()
        {
            Console.WriteLine("\n--- LISTADO DE ESTUDIANTES ---");
            if (cantidadEstudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
            }

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine($"{i + 1}. {matriculas[i]} - {nombres[i]} {apellidos[i]}");
            }
        }

        static int BuscarPosicion(string matricula)
        {
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                if (matriculas[i] == matricula)
                {
                    return i;
                }
            }
            return -1;
        }

        // Método auxiliar para evitar valores nulos
        static string LeerTextoSeguro()
        {
            string? entrada = Console.ReadLine();
            return entrada ?? string.Empty;
        }
    }
}
