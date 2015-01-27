using System.ComponentModel;

namespace Employee.Core.Models
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
