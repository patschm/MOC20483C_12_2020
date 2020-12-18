using System;
using System.Reflection;

namespace DeOnderWereld
{
    class Program
    {
        static string asmFile = @"E:\MOC20483C_12_2020\SomeLibrary.dll";

        static void Main(string[] args)
        {
            // Person p = new Person { Name = "Marieke", Age = 23 };
            //p.Introduce();

            // ExamineAssembly();
            BetereHakwerk();
        }

        private static void BetereHakwerk()
        {
            Assembly asm = Assembly.LoadFrom(asmFile);
            Type pers = asm.GetType("SomeLibrary.Person");

            //object p = Activator.CreateInstance(pers);

            //PropertyInfo nInf = pers.GetProperty("Name");
            //PropertyInfo aInf = pers.GetProperty("Age");
            //MethodInfo mIntro = pers.GetMethod("Introduce");

            //nInf.SetValue(p, "Hans");
            //aInf.SetValue(p, 42);

            //FieldInfo fag = pers.GetField("age", BindingFlags.Instance | BindingFlags.NonPublic);
            //fag.SetValue(p, -42);

            //mIntro.Invoke(p, new object[] { });

            dynamic p = Activator.CreateInstance(pers);
            p.Name = "Petra";
            p.Age = 67;
            p.Introduce();

        }

        private static void ExamineAssembly()
        {
            Assembly asm = Assembly.LoadFrom(asmFile);
            Console.WriteLine(asm.FullName);

            foreach (Type tp in asm.GetTypes())
            {
                Console.WriteLine(tp.FullName);
                foreach (var mem in tp.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    Console.WriteLine(mem.Name);
                }
            }

        }
    }
}
