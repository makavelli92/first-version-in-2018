using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDispose
{
    class MyDataBase : IDisposable
    {
        private bool disposed = false;

        public void Add()
        {

        }
        public void Dispose()
        {
            CleanApp(true);
            GC.SuppressFinalize(this); //предотвращает вызов финализатора. 
        }
        ~MyDataBase()
        {
            CleanApp(false);
        }
        public void CleanApp(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Очитска управляемых ресурсов.");
                }
                Console.WriteLine("Очитска неуправляемых ресурсов.");
            }
            disposed = true;
        }
    }
    class Reader : IDisposable
    {
        public void Dispose()
        {
        }
        
    }
    class Server : IDisposable
    {
        public void Dispose()
        {
        }
    }

    class Program
    {
        public static void Clean(IDisposable ob)
        {
            ob.Dispose();
        }
        static void Main(string[] args)
        {

            using (MyDataBase ob = new MyDataBase())
            {
                ob.Add();
            }



            Console.ReadLine();
        }
    }
}
