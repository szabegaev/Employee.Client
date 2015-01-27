using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Core.Help;

namespace Employee.Core.ViewModels
{
    public interface IViewModel
    {
        IHelpManager Help { get; set; }
    }
}
