using MyProject_Backend.Models;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_Backend.InterfaceService
{
    public interface IRate
    {
       
        Task<bool> CreateRate (RateShare rate);

    }
}
