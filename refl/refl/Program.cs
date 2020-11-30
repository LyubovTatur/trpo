using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Type myType = Type.GetType("ConsoleApp1.MyClass", false, true);
            foreach (MemberInfo mi in myType.GetMembers())
            {
                Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");

            }
            foreach (ConstructorInfo ctor in myType.GetConstructors())
            {
                Console.Write(myType.Name + " (");
                // получаем параметры конструктора
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
            User bob = new User(16);
            User tom = new User(34);
            bool bobIsValid = ValidateUser(bob);    
            bool tomIsValid = ValidateUser(tom);    

            Console.WriteLine($"Реультат валидации Боба: {bobIsValid}");
            Console.WriteLine($"Реультат валидации Тома: {tomIsValid}");

            
            Type myType2 = Type.GetType("ConsoleApp1.User", false, true);
            Console.WriteLine(myType2.GetMethod("SayHi").Invoke(null, null));
            Console.ReadLine();
        }
        static bool ValidateUser(User user)
        {
            Type t = typeof(User);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (AtClass attr in attrs)
            {
                if (user.Age >= attr.Age) return true;
                else return false;
            }
            return true;
        }
    }

    class MyClass
    {
        public int i;
        public int Age { get; set; }
        public MyClass(int i)
        {
            this.i = i;
        }
        public int GetI()
        {
            return i;
        }


    }
    [AtClass(Age  = 18)]
    public class User
    {

        public int Age { get; set; }
        public User(int a)
        {

            Age = a;
        }
        public static void SayHi()
        {
            Console.WriteLine("Hi");
        }
    }
    class AtClass : System.Attribute
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public AtClass()
        { }

        
    }

}