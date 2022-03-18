namespace EventConsole
{
    public class Company
    {
        public Manager Manager { get; set; }

        private Director _director;
        private List<Worker> _workers;
        private WorkerFactory _workerFactory;


        internal void Stop()
        {
            Manager.StopWork();
        }

        public Company()
        {
            Manager = new Manager(this);
            _director = new Director();
            _workerFactory = new WorkerFactory();
            _workers = WorkerFactory.CreateWorkers(Manager);
        }

        public void Start()
        {
            var timer = new System.Timers.Timer(5000);
            timer.Elapsed += ChangeCurrentTime;
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        private void ChangeCurrentTime(object sender, EventArgs e)
        {
            Manager.TimeElapsed();
            Console.WriteLine("");
            Console.WriteLine($"CurrentTime = { Manager.CurremtTime}");
        }
    }
}