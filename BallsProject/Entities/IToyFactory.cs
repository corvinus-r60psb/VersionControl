﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsProject.Entities
{
    public interface IToyFactory
    {
        Toy CreateNew();
    }
}