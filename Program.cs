namespace RPGYdiscover
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length>0 && args[0] == "--init" && !InitialDB.IsValid()){ // table initialization
                InitialDB init = new();
            }
            Character test = new("Mage");
        }
    }
}