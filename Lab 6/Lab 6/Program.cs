using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
            
        {
            List<Empresa> empresa = new List<Empresa>();
            List<División> division = new List<División>();
            List<Persona> personales = new List<Persona>();
            while (true)
            { 
            Console.WriteLine("Desea utilizar un archivo para cargar la informacion?");
            Console.WriteLine("1:Si");
            Console.WriteLine("2:No");
            int cho = Convert.ToInt32(Console.ReadLine());
                switch (cho)
                {
                    case 1:
                        try { StreamReader sr = new StreamReader("empresas.bin");
                            while (!sr.EndOfStream)
                            { string linea = sr.ReadLine();
                                Console.WriteLine(linea);
                            }
                            sr.Close();
                        }
                        catch (FileNotFoundException e)
                        { Console.WriteLine("Archivo no encontrado");
                            Console.WriteLine(e.Message);
                            addEmpresa(empresa);
                            SaveEmpresa(empresa);
                            DatosEmpresa(division);

                            Guardadivisiones(division);
                            Console.WriteLine("Escriba el encargado de division");
                            CreadorPersonal(personales);
                            Console.WriteLine("Escriba los nombres de los trabajadores del bloque 1 ");
                            CreadorPersonal(personales);
                            CreadorPersonal(personales);
                            Console.WriteLine("Escriba los nombres de los trabajadores del bloque 2");
                            CreadorPersonal(personales);
                            CreadorPersonal(personales);
                            Guardapersonas(personales);


                        }
                        break;
                    case 2:
                        Console.WriteLine("Escriba el nombre de la empresa");
                        string nombreempresa = Console.ReadLine();
                        Console.WriteLine("Escriba el rut de la empresa");
                        string rutempresa = Console.ReadLine();
                        Empresa newempresa = new Empresa(nombreempresa, rutempresa);
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream("empresa.bin",FileMode.Create,FileAccess.Write,FileShare.None);
                        formatter.Serialize(stream, newempresa);
                        stream.Close();
                        break;
                }
            }
        }
        static public void addEmpresa(List<Empresa> empresa)
        {
            Console.WriteLine("Introduzca nombre de la empresa");
            string ne = Console.ReadLine();
            Console.WriteLine("Introduzca el rut de la empresa");
            string re = Console.ReadLine();
            empresa.Add(new Empresa(ne, re));
        }
        static private void SaveEmpresa(List<Empresa> empresa)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresa);
            stream.Close();
        }
        static private void Deserialisador()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Empresa> empresa = (List<Empresa>)formatter.Deserialize(stream);
            stream.Close();
        }
        static private void CreadorPersonal(List<Persona> personal)
        { Console.WriteLine("Escriba el nombre del trabajador");
            string newpn = Console.ReadLine();
            Console.WriteLine("Escriba el apellido");
            string newpln = Console.ReadLine();
            Console.WriteLine("Escriba el rut");
            string newpr = Console.ReadLine();
            Console.WriteLine("Escriba el cargo");
            string newpc = Console.ReadLine();
            personal.Add(new Persona(newpn, newpln, newpr, newpc));
        }
        static private void DatosEmpresa(List<División> division)
        { Console.WriteLine("Escriba la division");
            string divi = Console.ReadLine();
            division.Add(new División(divi));
            Console.WriteLine("Escriba el departamento");
            string depa = Console.ReadLine();
            division.Add(new Departamento(depa));
            Console.WriteLine("Escriba la seccion");
            string secc = Console.ReadLine();
            division.Add(new Seccion(secc));
            Console.WriteLine("Escriba el bloque 1");
            string bl1 = Console.ReadLine();
            division.Add(new Bloque(bl1));
            Console.WriteLine("Escriba el bloque 2");
            string bl2 = Console.ReadLine();
            division.Add(new Bloque(bl2));
        }
        static private void Guardapersonas(List<Persona> personal)
        { IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            formatter.Serialize(stream, personal);
            stream.Close();
        }
        static private void Guardadivisiones(List<División> division)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            formatter.Serialize(stream, division);
            stream.Close();
        }
    }
    
}
