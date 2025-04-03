using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Drawing;

namespace Poe_prog2
{
    // Main class that initializes the cybersecurity assistant
    public class CyberSecurityAssistant
    {
        public static void Main(string[] args)
        {
            try
            {
                new Menu(); // Entry point for the menu system
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}  // End of CyberSecurityAssistant class