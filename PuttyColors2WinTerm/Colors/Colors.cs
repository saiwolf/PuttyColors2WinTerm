namespace PuttyColors2WinTerm.Colors
{
    /// <summary>
    /// Class that represents a RGB color.
    /// </summary>
    public class RGBColor
    {
        public int? Red { get; set; }
        public int? Green { get; set; }
        public int? Blue { get; set; }

        /// <summary>
        /// Class Constructor. If any value is null, then it is set to zero.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public RGBColor(int? red, int? green, int? blue)
        {            
            Red = red == null ? 0 : red;
            Blue = blue == null ? 0 : blue;
            Green = green == null ? 0 : green;
        }        
    }
}
