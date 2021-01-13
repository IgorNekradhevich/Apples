using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples
{
    class Apple
    {
        public string FullPath { get; private set; }
        public string EmptyPath { get; private set; }
        public int Count { get; set; }

        public Apple()
        {
            FullPath = "c:\\1\\apple.png";
            EmptyPath = "c:\\1\\empty.png";
            Count = 0;
        }

        public Apple(string FullPath, string EmptyPath, int Count)
        {
            this.FullPath = FullPath;
            this.EmptyPath = EmptyPath;
            this.Count = Count;
        }

    }
}
