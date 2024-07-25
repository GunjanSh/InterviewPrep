﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Factory
{
    internal interface ILawnMowerCatalogFactory
    {
        public ILawnMowerCatalog CreateLawnMowerCatalog(string type);
    }
}
