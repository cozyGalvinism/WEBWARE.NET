using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBWARE.NET.Helper
{
    public class Cursor
    {
        public string Cursorkennung { get; set; }
        public string ResultMaxLines { get; set; }
        public bool Closed => Cursorkennung == "CLOSED";

        public Cursor()
        {
            Cursorkennung = "CREATE";
            ResultMaxLines = "500";
        }

        public static Cursor CreateNewCursor(int maxLines)
        {
            return new Cursor { Cursorkennung = "CREATE", ResultMaxLines = maxLines.ToString() };
        }
    }
}
