﻿using System;
using System.Collections.Generic;

namespace MarsRover.Contract.Models
{
    public class Input
    {
        public string SurfaceParameter { get; set; }
        public List<Tuple<string, string>> VehicleAndCommandParameterCollection { get; set; } = new List<Tuple<string, string>>();
    }
    
    
}