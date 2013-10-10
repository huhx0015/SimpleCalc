using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/* SIMPLECALC
 * Programmer: Michael Yoon Huh (huhx0015)
 * Last Updated: 12/11/2011
 * 
 * DEBUG CHECKLIST
 * DEBUG: TEST CASE FOR USER INPUT IN TEXT FIELD.
 * DEBUG: TEST CASE IF USER ENTERS OPERATOR AFTER VALUE, OP, VALUE SEQUENCE.
 * DEBUG: ACTION FOR -/+ BUTTON. CURRENTLY DOES NOTHING.
 * DEBUG: VALUES WITH DECIMALS DO NOT CALCULATE. */

namespace SimpleCalc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
