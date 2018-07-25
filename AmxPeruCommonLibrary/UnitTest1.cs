using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary
{
    public partial class UnitTest1 : Component
    {
        public UnitTest1()
        {
            InitializeComponent();
        }

        public UnitTest1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
