﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface ILijstItem
    {
        string LabelNaam { get;  }
        string Waarde { get;  }
    }
}