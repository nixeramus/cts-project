using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main()
        {
            //var method = new StackTrace().GetFrame(1).GetMethod();
            //Console.WriteLine(String.Format("I was called from '{0}' of class '{1}'", method.Name, method.DeclaringType));

            Assembly thisAssembly = typeof(Kendo.Mvc.FilterDescriptor).Assembly;
            foreach (MethodInfo method in GetExtensionMethods(thisAssembly,
                    typeof(HtmlHelper)))
            {
                Console.WriteLine(method);
            }
        }

        static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly,
            Type extendedType)
        {
            try
            {
                var query = from type in assembly.GetTypes()
                            //where type.IsSealed && !type.IsGenericType && !type.IsNested
                            from method in type.GetMethods(BindingFlags.Static
                                | BindingFlags.Public | BindingFlags.NonPublic)
                                where method.Name.Contains("Kendo")
                            //where method.IsDefined(typeof(ExtensionAttribute), false)
                            //where method.GetParameters()[0].ParameterType == extendedType
                            select method;
                return query;
            }
            catch(System.Reflection.ReflectionTypeLoadException ex)
            {
                throw ex;
            }
            
        }
    }
}
