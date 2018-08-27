/*
 * 2015 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Lupus_Titanium_GUI {
    static class Program {
        private static Mutex _namedMutex = new Mutex(true, Assembly.GetExecutingAssembly().FullName);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            if (_namedMutex.WaitOne(0, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main(args));
            }
        }
    }
}
