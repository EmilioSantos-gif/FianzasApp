using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace FianzasApp
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);

        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            int input;
            do
            {
                Console.WriteLine("\nQue desea hacer?");
                Console.WriteLine("\t1. Registrar fianza.");
                Console.WriteLine("\t0. Salir");
                int.TryParse(Console.ReadLine(), out input);

                switch(input)
                {
                    case 1:
                        RegistrarYActulizar();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
            } while (input != 0);
        }

        private static void RegistrarYActulizar()
        {
            FinanzasAppDBEntities DBcontext = new FinanzasAppDBEntities();

            SPGetCasos_Result caso = DBcontext.SPGetCasos().ToList().FirstOrDefault();

            var dbContextTransaction = DBcontext.Database.BeginTransaction();

            if (caso is null)
            {
                //Caso(Descripcion, CantidadImputados, BalanceFianza, Estado)
                string descripcion, estado;
                int cantidadImputados;
                //float balanceFianza;

                Console.WriteLine("\n===REGISTRO DE CASO===:");
                Console.WriteLine("\nDescripcion:");
                descripcion = Console.ReadLine();

                Console.WriteLine("\nCantidad de Imputados:");
                cantidadImputados = int.Parse(Console.ReadLine());

                //Console.WriteLine("\nBalance de la Fianza:");
                //balanceFianza = float.Parse(Console.ReadLine());

                Console.WriteLine("\nEstado:");
                estado = Console.ReadLine();

                DBcontext.SPUpsertCaso(descripcion, cantidadImputados, 0, estado);

                log.Info($"Se ha registrado el caso: {descripcion} {cantidadImputados} {0} {estado}");
            }

            //Fianza(Descripcion, Monto, Cedula, Nombres, Apellidos, Sexo, Estado)
            string descripcionFianza, cedula, nombres, apellidos, sexo, estadoFianza;
            decimal monto;

            Console.WriteLine("\n===REGISTRO DE FIANZA===:");

            Console.WriteLine("\nDescripcion:");
            descripcionFianza = Console.ReadLine();

            Console.WriteLine("\nMonto:");
            monto = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\nCedula:");
            cedula = Console.ReadLine();

            Console.WriteLine("\nNombres:");
            nombres = Console.ReadLine();

            Console.WriteLine("\nApellidos:");
            apellidos = Console.ReadLine();

            Console.WriteLine("\nSexo:");
            sexo = Console.ReadLine();

            Console.WriteLine("\nEstado de la fianza:");
            estadoFianza = Console.ReadLine();

            try
            {
                DBcontext.SPInsertFianza(descripcionFianza, monto, cedula, nombres, apellidos, sexo, estadoFianza);
                log.Info($"Se ha registrado la fianza: {descripcionFianza} {monto} {cedula} {nombres} {apellidos} {sexo} {estadoFianza}");

                decimal balance = DBcontext.SPGetCasos().ToList().Select(c => c.BalanceFianza).FirstOrDefault();

                DBcontext.SPUpsertCaso(null, null, balance + monto, null);
                log.Info($"Se ha actualizado el balance a: {balance + monto}");
                dbContextTransaction.Commit();
                Console.WriteLine("\nRegistrado satisfactoriamente.");
            } catch (Exception e)
            {
                dbContextTransaction.Rollback();
                Console.WriteLine($"\n{e.Message}");
                log.Error($"No se pudo completar la transaccion, excepcion: {e.Message}",e);
                Console.WriteLine("\nRegistro invalidado.");
            }

            Console.WriteLine("\nCaso:");
            DBcontext.SPGetCasos().ToList().ForEach(c => Console.WriteLine($"{c.Descripcion}\t{c.CantidadImputados}\tRD${c.BalanceFianza}\t{c.FchUltActualizacion}\n{c.Estado}"));

            Console.WriteLine("\nFianzas:");
            DBcontext.SPGetFianzas().ToList().ForEach(f => Console.WriteLine($"{f.Id}\t{f.Nombres}\t{f.Apellidos}\t{f.Cedula}\tRD${f.Monto}\t{f.Descripcion}"));
        }
    }
}



//idCaso = DBcontext.SPGetCasos().ToList().OrderByDescending(d => d.Id).Select(d => d.Id).FirstOrDefault();

