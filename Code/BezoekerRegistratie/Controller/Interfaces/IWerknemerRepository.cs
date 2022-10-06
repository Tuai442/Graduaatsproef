﻿using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IWerknemerRepository: IPersoonRepository
    {
        Werknemer GeefWerknemerOpNaam(string contactPersoon);
        Werknemer GeefWerknemerOpId(int id);
        List<Werknemer> GeefAlleWerknemers();
    }
}