using System;
namespace EventConsole
{
    public class WorkerFactory
    {
        public static List<Worker>? CreateWorkers(Manager manager)
        {
            List<Worker> workersList = new List<Worker>();
            for (int i = 0; i < 50; i++)
            {
                var worker = new Worker(manager){ Id = i};
                var random = new Random();
                worker.MyStartTime = random.Next(8, 11);
                worker.MyBreakTime = random.Next(11, 14);
                worker.MyEndTime = random.Next(15, 18);
            }
            return workersList;
        }
    }
}