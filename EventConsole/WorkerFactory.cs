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
                worker.MyStartTime = random.Next(9, 12);
                worker.MyEndTime = random.Next(13, 17);
            }
            return workersList;
        }
    }
}