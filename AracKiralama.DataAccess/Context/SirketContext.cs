﻿using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Context
{
    public class SirketContext : IContext
    {
        public DbSet<tblSirket> Sirketler { get; set; }
    }
}
