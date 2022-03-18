namespace EventConsole
{
    public class Manager
    {
        public List<WorkingHour> WorkingHours { get; set; } = new List<WorkingHour>();
        public event EventHandler<int> Work;
        public event EventHandler<int> Break;
        public event EventHandler<int> Stop;

        public int CurremtTime { get; set; } = 6;

        private Company _company;

        public Manager(Company company)
        {
            _company = company;
        }

        public void TimeElapsed()
        {
            if (CurremtTime >= 8 && CurremtTime <= 10)
            {
                StartWork();
            }
            if(CurremtTime >=11 && CurremtTime <= 13);
            {
                StartBreak();
            }
            if (CurremtTime >= 15 && CurremtTime <= 18)
            {
                StopWork();
            }
            if (CurremtTime == 18)
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
            Console.WriteLine($"Total hours worked today:{totalWorked}");
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

        public void StartBreak()
        {
            Break.Invoke(this, CurremtTime);
        }
    }
}