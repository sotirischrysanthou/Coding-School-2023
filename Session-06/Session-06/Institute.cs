﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    internal class Institute {
        // Properties
        public Guid ID { get; set; }
        public String? Name { get; set; }
        public int YearsInService { get; set; }

        // Constructors

        public Institute() {

        }

        public Institute() : this() {
            ID = Guid.NewGuid();
        }

        public Institute(String name) : this() {
            Name = name;
        }

        public Institute(String name, int yearsInService) : this(name) {
            YearsInService = yearsInService;
        }
        // Methods

        public String GetName() { return Name; }
        public void SetName(String name) { Name = name; }
    }
}
