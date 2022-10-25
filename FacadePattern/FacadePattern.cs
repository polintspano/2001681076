namespace ST2001681076
{
    /// <summary>
    /// The facade class
    /// </summary>
    public class ComputerService
    {
        public ComputerService() { }

        public void UpgrageForGaming(Computer computer)
        {
            computer.UpgradeCpuCores(4);
            computer.UpgradeGpu();
            computer.UpgradeRam(16);
            computer.UpgradeStorage(1024);
        }

        public void UpgradeForGraphicDesign(Computer computer)
        {
            computer.UpgradeCpuCores(4);
            computer.UpgradeRam(32);
        }
    }

    /// <summary>
    /// Main entity class
    /// </summary>
    public class Computer
    {
        private int _ram;
        private int _storage;
        private int _cpuCores;
        private bool _hasExternalGpu;

        public int Ram { get => _ram; }
        public int Storage { get => _storage; }
        public int CpuCores { get => _cpuCores; }
        public bool HasExternalGpu{ get => _hasExternalGpu; }

        public Computer(int ram, int storage, int cpuCores, bool hasExternalGPU)
        {
            _ram = ram;
            _storage = storage;
            _cpuCores = cpuCores;
            _hasExternalGpu = hasExternalGPU;
        }

        public void UpgradeRam(int amount)
        {
            _ram += amount;
            Console.WriteLine($"Беше добавена {amount} рам памет.");
        }

        public void UpgradeStorage(int amount)
        {
            _storage += amount;
            Console.WriteLine($"Беше добавена {amount} памет.");
        }

        public void UpgradeCpuCores(int amount)
        {
            _cpuCores += amount;
            Console.WriteLine($"Процесорът беше сменен.");
        }

        public void UpgradeGpu()
        {
            _hasExternalGpu = true;
            Console.WriteLine("Беше добавена външна видео карта.");
        }
    }

    /// <summary>
    /// Main entry point
    /// </summary>
    public class MainAppFacade
    {
        public static void Main()
        {
            ComputerService computerService = new ComputerService();
            Computer computer1 = new Computer(4, 256, 4, false);
            Computer computer2 = new Computer(2, 256, 2, false);

            computerService.UpgrageForGaming(computer1);
            computerService.UpgradeForGraphicDesign(computer2);
            Console.ReadKey();
        }
    }
}

