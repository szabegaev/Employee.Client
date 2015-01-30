using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
