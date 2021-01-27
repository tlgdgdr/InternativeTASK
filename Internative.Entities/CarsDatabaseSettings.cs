﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Internative.Entities
{
    public class CarsDatabaseSettings : ICarsDatabaseSettings
    {
        public string CarsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICarsDatabaseSettings
    {
        string CarsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
