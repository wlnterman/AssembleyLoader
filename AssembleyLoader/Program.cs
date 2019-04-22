using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssembleyLoader
{
    class Program
    {
        public static string from;
        static void Main(string[] args)
        {
            //Assembly assembley = new Assembly();
            Console.WriteLine("enter source directory");
            from = Console.ReadLine();
            Assembly threadPoolAssembly = GetThreadPoolAssembly(from);

            List<Type> types = threadPoolAssembly.GetTypes().ToList();
            types.Sort();
            Console.WriteLine("Public types are:");
            foreach (Type type in types)
            {
                Console.WriteLine("{0}", type);
            }
            Console.ReadLine();
        }

        private static Assembly GetThreadPoolAssembly(string TheWay)
        {
            //const string DLL_FILENAME = "ThreadPool.dll";
            string DLL_FILENAME = TheWay;

            Assembly assembly;
            try
            {
                AssemblyName name = AssemblyName.GetAssemblyName(DLL_FILENAME);
                assembly = Assembly.Load(name);
            }
            catch
            {
                throw new DllNotFoundException(DLL_FILENAME + " not found");
            }

            return assembly;
        }
    }
}
