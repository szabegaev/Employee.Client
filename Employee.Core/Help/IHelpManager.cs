﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Help
{
    public interface IHelpManager
    {
        void AddHelpFile(string applicationName, string filePath);
    }
}
