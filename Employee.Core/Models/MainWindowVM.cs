using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Employee.Core.ViewModels;
using Employee.Core.Views;

namespace Employee.Core.Models
{
    public class MainWindowVM : IViewModel
    {
        private readonly IViewFactory viewFactory;
        private ICommand launchCommand;
        private ICommand showHelpCommand;

        public DateTime CurrentRunTime { get; set; }

        public MainWindowVM(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
            this.CurrentRunTime = DateTime.Now;
        }

        public IMainView ParentView { get; set; }

        public ICommand Launch
        {
            get { return launchCommand ?? (launchCommand = new DelegateCommand(ShowSecondWindow)); }
            set { launchCommand = value; }
        }

        private void ShowSecondWindow()
        {
            var view = viewFactory.CreateView<ISecondView>();
            //view.ShowDialog();
        }

        public ICommand ShowHelp
        {
            get { return showHelpCommand ?? (showHelpCommand = new DelegateCommand(ShowUserHelp)); }
            set { showHelpCommand = value; }
        }

        private void ShowUserHelp()
        {
            ParentView.ShowHelp();
        }

        public Help.IHelpManager Help
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
