using Employee.Core.Windsor;

namespace Employee.Client.Views
{
    public class Shell : IShell<MainWindow>
    {
        public MainWindow window { get; set; }

        public void Run()
        {
            window.Show();
        }
    }
}
