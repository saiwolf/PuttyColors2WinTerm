using System.Drawing;

namespace PuttyColors2WinTerm.Colors
{
    public class RGBColor
    {
        public int? Red { get; set; }
        public int? Green { get; set; }
        public int? Blue { get; set; }

        public RGBColor(int? red, int? green, int? blue)
        {            
            Red = red == null ? 0 : red;
            Blue = blue == null ? 0 : blue;
            Green = green == null ? 0 : green;
        }        
    }

    public class hexColor
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

        public hexColor(string name, string hexcode)
        {
            Name = string.IsNullOrEmpty(name) ? "N/A" : name;
            HexCode = string.IsNullOrEmpty(hexcode) ? "#000000" : hexcode;
        }     
    }
}
