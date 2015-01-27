using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Windsor
{
    public interface IShell<T> where T : class
    {
        /// <summary>
        /// Runs this instance.
        /// </summary>
        void Run();

        /// <summary>
        /// Gets or sets the window.
        /// </summary>
        /// <value>
        /// The window.
        /// </value>
        T window { get; set; }
    }
}
