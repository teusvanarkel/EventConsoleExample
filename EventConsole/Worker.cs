namespace EventConsole
{
    public class Worker
    {
        
        public int MyStartTime { get; set; }
        public int MyBreakTime { get; set; }
        public int MyEndTime { get; set; }

        private Manager _manager;

        public int Id { get; set; }
        public Worker(Manager manager)
        {
            manager.Stop += StopWork;
            manager.Break += Break;
            manager.Work += Work;
            _manager = manager;
        }

        public void StopWork(object sender, int currentTime)
        {
            if(currentTime == MyEndTime)
            {
                var workingHour = new WorkingHour();
                workingHour.AmountHours = MyEndTime - MyStartTime - 1;
                workingHour.WokerId = Id;
                _manager.AddWorkingHours(workingHour);

                if (Id < 10)
                {
                    Console.WriteLine($" {Id}: I have stopped working, I have worked: {workingHour.AmountHours} hours.");
                }
                else
                {
                    Console.WriteLine($"{Id}: I have stopped working, I have worked: {workingHour.AmountHours} hours.");
                }
            }
        }

        public void Break(object sender, int currentTime)
        {
            if(currentTime == MyBreakTime)
            {
                if(Id < 10)
                {
                    Console.WriteLine($" {Id}: I've taken a break of 1 hour.");
                }
                else
                {
                    Console.WriteLine($"{Id}: I've taken a break of 1 hour.");
                }
            }
        }

        public void Work(object sender, int currentTime)
        {
            if(currentTime == MyStartTime)
            {
                if (Id < 10)
                {
                    Console.WriteLine($" {Id}: I've started working.");
                }
                else
                {
                    Console.WriteLine($"{Id}: I've started working.");
                }
            }
        }
    }
}