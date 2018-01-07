using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLog;


namespace LevelStrategy.BL
{
     public static class MutexWorker
    {
        private static readonly ILogger Logger = LogManager.GetLogger("info");

        public static void MutexOn(Mutex mtx, string directory)
        {
            //Logger.Warn($"{Thread.CurrentThread.ManagedThreadId} - Захватываю мютекс из под директории - {directory}");
            mtx.WaitOne();
        }

        public static void MutexOff(Mutex mtx, string directory)
        {
            //Logger.Warn($"{Thread.CurrentThread.ManagedThreadId} - Освобождаю мютекс из директории - {directory}");
            mtx.ReleaseMutex();
        }
    }
}
