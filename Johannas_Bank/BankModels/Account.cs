﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Johannas_Bank.BankModels
{
    public class Account
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public int Balance { get; set; }
    }
}