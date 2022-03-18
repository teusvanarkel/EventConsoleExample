namespace EventConsole
{
    public class Manager
    {
        public List<WorkingHour> WorkingHours { get; set; } = new List<WorkingHour>();
        public event EventHandler<int> Work;
        public event EventHandler<int> Stop;

        public int CurremtTime { get; set; } = 6;

        private Company _company;

        public Manager(Company company)
        {
            // var timer = new System.Timers.Timer(5000);
            // timer.Elapsed += TimeElapsed;
            // timer.AutoReset = true;
            // timer.Enabled = true;
            _company = company;
        }

        public void TimeElapsed()
        {
            CurremtTime +=1;
            if (CurremtTime >= 8 && CurremtTime <= 12)
            {
                    StartWork();
            }
            else
            {
                    StopWork();
            }
            if(CurremtTime == 18)
            {
                CollectWorkingHours();
            }
        }

        

        private void CollectWorkingHours()
        {
            int totalWorked = 0;
            foreach (var workingHour in WorkingHours)
            {
                totalWorked += workingHour.AmountHours;
            }
            Console.WriteLine("");
            Console.WriteLine($"Total hours workerd today:{totalWorked}");
            Console.WriteLine("");
        }

        internal void AddWorkingHours(WorkingHour workingHour)
        {
            WorkingHours.Add(workingHour);
        }

        public void StartWork()
        {
            Work.Invoke(this, CurremtTime);
        }

        public void StopWork()
        {
            Stop.Invoke(this, CurremtTime);
        }
    }
}