namespace EventConsole
{
    public class Worker
    {
        
        public int MyStartTime { get; set; }
        public int MyEndTime { get; set; }

        private Manager _manager;

        public int Id { get; set; }
        public Worker(Manager manager)
        {
            manager.Stop += StopWork;
            manager.Work += Work;
            _manager = manager;
        }

        public void StopWork(object sender, int currentTime)
        {
            if(currentTime == MyEndTime)
            {
                var workingHour = new WorkingHour();
                workingHour.AmountHours = MyEndTime - MyStartTime;
                workingHour.WokerId = Id;
                _manager.AddWorkingHours(workingHour);
                Console.WriteLine($"I have stopped working: {Id}, I have worked: {workingHour.AmountHours} hours");
            }

        }

        public void Work(object sender, int currentTime)
        {
            if(currentTime == MyStartTime)
            {
                Console.WriteLine($"Im working!: {Id}");
            }
        }
    }
}