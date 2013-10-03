using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// PROGRAMMED BY: HUHX0015

// DEBUG: TEST CASE FOR USER INPUT IN TEXT FIELD.
// DEBUG: TEST CASE IF USER ENTERS OPERATOR AFTER VALUE, OP, VALUE SEQUENCE.
// DEBUG: ACTION FOR -/+ BUTTON. CURRENTLY DOES NOTHING.
// DEBUG: VALUES WITH DECIMALS DO NOT CALCULATE.

// The SimpleCalc is a simple calculator programmed in C#, utilizing the Windows forms template. Currently does not factor in decimal or negative numbers.
namespace SimpleCalc
{
    public partial class Form1 : Form
    {
        // Global variables that are accessed throughout SimpleCalc.
        public Stack calcList = new Stack(); // The main stack of the SimpleCalc program, which stores all the values of the program.
        public Stack opStack = new Stack(); // The operator stack of SimpleCalc program, which stores all the operators of the program.
        public Boolean opTrue = false; // Used for determining if an operator button was previously pressed.
        public String lastOp; // Tracks the last operator that was pressed.
        public String currentVal; // Tracks the current value inputted into the calculator.
        public Boolean isDecimal = false; // Used for determining if the current value has a decimal point.

        public Form1()
        {
            InitializeComponent();
        }

        // Action if "1" is clicked.
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1"; // Displays the number "1" in the calculator text field.
            currentVal += "1";
        }

        // Action if "2" is clicked.
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2"; // Displays the number "2" in the calculator text field.
            currentVal += "2";
        }

        // Button "3".
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3"; // Displays the number "3" in the calculator text field.
            currentVal += "3";
        }

        // Button "4".
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4"; // Displays the number "4" in the calculator text field.
            currentVal += "4";
        }

        // Button "5".
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5"; // Displays the number "5" in the calculator text field.
            currentVal += "5";
        }

        // Button "6".
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6"; // Displays the number "6" in the calculator text field.
            currentVal += "6";
        }

        // Button "7".
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7"; // Displays the number "7" in the calculator text field.
            currentVal += "7";
        }

        // Button "8".
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8"; // Displays the number "8" in the calculator text field.
            currentVal += "8";
        }

        // Button "9".
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9"; // Displays the number "9" in the calculator text field.
            currentVal += "9";
        }

        // Button "0".
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0"; // Displays the number "1" in the calculator text field.
            currentVal += "0";
        }

        // Button "+".
        private void button11_Click(object sender, EventArgs e)
        {

            // If operator button has not been previously pressed, push the current value onto the stack.
            if (opTrue == false && currentVal != null)
            {
                opTrue = true;
                lastOp = "+";
                calcList.Push(currentVal); // Pushes currentVal onto the stack.
            }

            // [CURRENTLY DOES NOT WORK].
            // If the last operator that was pressed was the same operator and there are at least 2 values in the calcList stack.
            else if (opTrue == true && lastOp == "+" && calcList.Count >= 1)
            {
                MessageBox.Show("IT WORKS! (NOT REALLY)");
                calculate();
            }

            // Otherwise, just set the lastOp value to be the operator that was just pressed.
            else if (opTrue == true)
            {
                lastOp = "+";
            }

            isDecimal = false; // Resets the decimal flag.
            textBox1.ResetText(); // Clears the textbox on the calculator.
            currentVal = null; // Clears the currentVal string.
        }

        // Button "-".
        private void button12_Click(object sender, EventArgs e)
        {
            // If operator button has not been previously pressed, push the current value onto the stack.
            if (opTrue == false && currentVal != null)
            {
                opTrue = true;
                lastOp = "-";
                calcList.Push(currentVal); // Pushes currentVal onto the stack.
            }
            // Otherwise, just set the lastOp value to be the operator that was just pressed.
            else if (opTrue == true)
            {
                lastOp = "-";
            }

            isDecimal = false; // Resets the decimal flag.
            textBox1.ResetText(); // Clears the textbox on the calculator.
            currentVal = null; // Clears the currentVal string.
        }

        // Button "*".
        private void button13_Click(object sender, EventArgs e)
        {
            // If operator button has not been previously pressed, push the current value onto the stack.
            if (opTrue == false && currentVal != null)
            {
                opTrue = true;
                lastOp = "*";
                calcList.Push(currentVal); // Pushes currentVal onto the stack.
            }
            // Otherwise, just set the lastOp value to be the operator that was just pressed.
            else if (opTrue == true)
            {
                lastOp = "*";
            }

            isDecimal = false; // Resets the decimal flag.
            textBox1.ResetText(); // Clears the textbox on the calculator.
            currentVal = null; // Clears the currentVal string.
        }

        // Button "/".
        private void button14_Click(object sender, EventArgs e)
        {
            // If operator button has not been previously pressed, push the current value onto the stack.
            if (opTrue == false && currentVal != null)
            {
                opTrue = true;
                lastOp = "/";
                calcList.Push(currentVal); // Pushes currentVal onto the stack.
            }
            // Otherwise, just set the lastOp value to be the operator that was just pressed.
            else if (opTrue == true)
            {
                lastOp = "/";
            }

            isDecimal = false; // Resets the decimal flag.
            textBox1.ResetText(); // Clears the textbox on the calculator.
            currentVal = null; // Clears the currentVal string.
        }

        // Method which calculates the inputted values and operators.
        public void calculate()
        {
            Stack<long> values = new Stack<long>(); // Stores the values of the stack.
            String currentObject; // Stores the object read from the stack, whether a value or operator.
            String currentOp = lastOp; // Stores the current operator found in the stack.
            float totalVal = 0; // Stores the current total value that will be displayed in the SimpleCalc textbox at the end of this method.
            float value1 = 1, value2 = 1; // Stores the two value arguments.
            bool isVal = false;
            bool dbz = false; // Used for determining if a division by zero scenario has occurred.

            // Pushes value onto the stack if there is a value in the textbox.
            if (currentVal != null)
            {
                calcList.Push(currentVal); // Pushes the currentVal onto the stack before proceeding with calculation.
            }

            int stackCount = calcList.Count; // Retrives the stack count of calcList.

            // Only works if previous operator was pressed and stackCount is equal to one (second value in text box is pushed onto stack in the following lines).
            // "=" does nothing if it does not meet the following conditions or if equals is pressed without two values.
            if (opTrue && stackCount == 2)
            {

                // Logic: Use a for loop to pop data off the stack, if a number, add to the total. if a operator, keep track.
                for (int i = 0; i < stackCount; i++)
                {

                    currentObject = calcList.Peek().ToString(); // Look at the current value of top of the stack.

                    try
                    {
                        values.Push(Convert.ToInt64(currentObject)); // Converts the value and attempts to push it into the 'values' stack, if successful.
                        isVal = true;
                        calcList.Pop();
                    }

                    // If the above conversion attempt fails, the code moves along, assuming the top stack value is a non-value.
                    catch (System.OverflowException ex)
                    {
                        MessageBox.Show("ERROR: Value is too large. Please input a value between −9,223,372,036,854,775,808 to +9,223,372,036,854,775,807");
                        clear(); // Clears all values.
                    }

                }

                // Calculation logic here. Unloads the "values" stack until empty. Currently only accounts for two values.
                while (values.Count != 0)
                {
                    if (currentOp.Equals("+")) totalVal += values.Pop(); // Adds the values if the operator is "+".

                    // Subtracs the values if the operator is "-".
                    if (currentOp.Equals("-"))
                    {
                        // Sets the value2 variable to the second value variable in the stack.
                        if (values.Count == 2)
                        {
                            value2 = values.Peek();
                        }
                        // Sets the value1 variable to the first value variable in the stack and calculates the total value.
                        if (values.Count == 1)
                        {
                            value1 = values.Peek();
                            totalVal = value2 - value1;
                        }
                        values.Pop(); // Pops the value off the stack.
                    }

                    // Multiplies the values if the operator is "*".
                    if (currentOp.Equals("*"))
                    {

                        // Sets the value2 variable to the second value variable in the stack.
                        if (values.Count == 2)
                        {
                            value2 = values.Peek();
                        }
                        // Sets the value1 variable to the first value variable in the stack and calculates the total value.
                        if (values.Count == 1)
                        {
                            value1 = values.Peek();
                            totalVal = value1 * value2;
                        }
                        values.Pop(); // Pops the value off the stack.
                    }

                    // Divides the values if the operator is "/".
                    if (currentOp.Equals("/"))
                    {
                        // Sets the value2 variable to the second value variable in the stack.
                        if (values.Count == 2)
                        {
                            value2 = values.Peek();

                            // If value2 is equal to zero, set the flag and break. Done to avoid division by 0.
                            if (value2 == 0)
                            {
                                dbz = true;
                                break;
                            }

                        }
                        // Sets the value1 variable to the first value variable in the stack and calculates the total value.
                        if (values.Count == 1)
                        {
                            value1 = values.Peek();
                            // If value1 is equal to zero, set the flag and break. Done to avoid division by 0.
                            if (value1 == 0)
                            {
                                dbz = true;
                                break;
                            }

                            totalVal = value2 / value1;
                        }
                        values.Pop(); // Pops the value off the stack.
                    }
                }

                // If a divide by zero scenario has occurred, display error text in calculator text field.
                if (dbz == true)
                {
                    textBox1.ResetText();
                    textBox1.Text = "ERROR. Division by 0.";
                }
                // Otherwise, display the calculated value in the textbox.
                else
                {
                    textBox1.ResetText();
                    textBox1.Text = totalVal.ToString();
                }

                // Resets global values to defaults.
                opTrue = false;
                calcList.Clear(); // Wipes out the previous stack.
                currentVal = totalVal.ToString(); // Sets the total value to the current value.
            }
        }

        // Button "=". Performs the calculation if all fields are correct.
        private void button15_Click(object sender, EventArgs e)
        {
            calculate(); // Calls calculate() method.
        }

        // Decimal point button action. Only works if a decimal point does not currently exist in the displayed value.
        private void button18_Click(object sender, EventArgs e)
        {
            if (isDecimal == false)
            {
                textBox1.Text += "."; // Displays the decimal point in the calculator text field.
                currentVal += ".";
                isDecimal = true;
            }
        }

        // Button for "-/+". Changes current value into a negative or positive value.
        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT YET IMPLEMENTED.");
        }

        // Calculator TextBox. Method is used if user inputs any values into the text box.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //currentVal = textBox1.Text;
        }

        // Clear button.
        private void button16_Click(object sender, EventArgs e)
        {
            clear();
        }

        // Clear function resets all global values to defaults.
        private void clear()
        {
            // Resets global values to defaults.
            isDecimal = false; // Resets the decimal flag.
            textBox1.ResetText();
            opTrue = false;
            calcList.Clear(); // Wipes out the previous stack.
            currentVal = null;
            lastOp = null;
        }

        // Backspace button.
        private void button19_Click(object sender, EventArgs e)
        {
            // Check to see if there is a long enough string in the textBox display. Does nothing if nothing is in the textBox display. 
            if (textBox1.Text.Length > 0)
            {
                char[] tempString = textBox1.Text.ToCharArray(); // Converts textBox1 text from string to char[] type.
                String newString = new String(tempString, 0, textBox1.Text.Length - 1); // Creates a new string with the textBox1 text with the decrement of one character.
                textBox1.Text = newString; // Sets display text to the new string.
                currentVal = newString; // Sets currentVal to the new string.
            }
        }

    }
}
