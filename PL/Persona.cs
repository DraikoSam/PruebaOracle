using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Persona
    {
        public static void Add()
        {
            ML.Persona persona = new ML.Persona();

            Console.WriteLine("Ingresa el Id");
            persona.IdPersona = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el  Nombre");
            persona.Nombre = Console.ReadLine();


            Console.WriteLine("Ingresa el  Apellido Paterno");
            persona.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Materno");
            persona.ApellidoMaterno = Console.ReadLine();


            ML.Result result = PruebaOracle.Persona.Add(persona);

            if (result.Correct)
            {
                Console.WriteLine("usuario ingresada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla usuario " + result.ErrorMessage);
            }
        }

        //-----------------------------
        public static void Update()
        {
            ML.Persona persona = new ML.Persona();

            Console.WriteLine("Ingresa el Id");
            persona.IdPersona = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el  Nombre");
            persona.Nombre = Console.ReadLine();


            Console.WriteLine("Ingresa el  Apellido Paterno");
            persona.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Materno");
            persona.ApellidoMaterno = Console.ReadLine();


            ML.Result result = PruebaOracle.Persona.Update(persona);

            if (result.Correct)
            {
                Console.WriteLine("usuario actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar el registro en la tabla " + result.ErrorMessage);
            }
        }

        //-----------------------
        public static void Delete()
        {
            ML.Persona persona = new ML.Persona();

            Console.WriteLine("Ingresa el Id");
            persona.IdPersona = int.Parse(Console.ReadLine());

          
            ML.Result result = PruebaOracle.Persona.Delete(persona);

            if (result.Correct)
            {
                Console.WriteLine("usuario eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminado el registro en la tabla " + result.ErrorMessage);
            }
        }
        public static void GetAll()
        {

            ML.Result result = PruebaOracle.Persona.GetAll();

            if (result.Correct)
            {
                foreach (ML.Persona persona in result.Objects)
                {
                    Console.WriteLine("IdPersona: " + persona.IdPersona);
                    Console.WriteLine("Nombre: " + persona.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + persona.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + persona.ApellidoMaterno);
                   
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información de Producto" + result.ErrorMessage);
            }
        }
        //--------------------------------------------GETBYID
        public static void GetById(int IdPersona)
        {
            ML.Persona persona = new ML.Persona();
            Console.WriteLine("Ingrese el Id del producto a comprar");
            persona.IdPersona = int.Parse(Console.ReadLine());

            ML.Result result = PruebaOracle.Persona.GetById(IdPersona);

            if (result.Correct)
            {
                persona.Nombre = ((ML.Persona)result.Object).Nombre;
                persona.ApellidoPaterno = ((ML.Persona)result.Object).ApellidoPaterno;
                persona.ApellidoMaterno = ((ML.Persona)result.Object).ApellidoMaterno;
                

                Console.WriteLine("IdPerosna: " + persona.IdPersona);
                Console.WriteLine("Nombre: " + persona.Nombre);
                Console.WriteLine("ApellidoPaterni: " + persona.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + persona.ApellidoMaterno);


            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información de Producto" + result.ErrorMessage);
            }
        }
    }
}
