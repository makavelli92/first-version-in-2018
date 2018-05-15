using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDispose
{
    class MyDataBase : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Очистка неуправляемых рксурсов.");
        }
        public void Add()
        {

        }
        public void Delete() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDataBase ob = new MyDataBase();
            try
            {
                ob.Add();
            }
            finally
            {
                ob.Dispose();
            }
            using (MyDataBase ob2 = new MyDataBase())
            {
                ob2.Add();
            }

            Console.ReadLine();
        }
    }
}
