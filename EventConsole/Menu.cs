namespace EventConsole
{
    public class Menu
    {
        public static bool MainMenu(Manager manager)
        {
            //Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) start working");
            Console.WriteLine("2) stop working");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    manager.StartWork();
                    return true;
                case "2":
                    manager.StopWork();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}