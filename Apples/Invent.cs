using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Apples
{
    class Invent
    {
        public Image InvImage { get;private set;}
        public Label InvLabel { get; private set; }

        public Invent(Image image, Label label)
        {
            InvLabel = label;
            InvImage = image;
        }
    }
}
