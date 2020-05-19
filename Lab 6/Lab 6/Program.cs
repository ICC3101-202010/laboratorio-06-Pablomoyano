﻿using System;
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
                        catch(FileNotFoundException ex)
                        { Console.WriteLine("Archivo no encontrado");
                            addEmpresa(empresa);
                            SaveEmpresa(empresa);
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
    }
    
}