using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TiCloud_Desktop.viewmodels;

namespace TiCloud_Desktop.core.data.models
{
    public class UpdateData
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }

        // Zagnieżdżona klasa IconDetails
        public class IconDetails
        {
            public string Source { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string Margin { get; set; }
        }

        public IconDetails Icon { get; set; } // Właściwość ikony

    }
}
