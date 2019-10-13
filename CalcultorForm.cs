using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalcultorForm : Form
    {

        Button[] btnSysmbolsList;
        Button[] btnNumbersList;
        bool isNumberSymbol = false;
        bool  onOff = false;
        string Operand1 = string.Empty;
        string Operand2 = string.Empty;
        string Operator = string.Empty;
        double result = 0.0;
        bool isAnswer = false;

        public CalcultorForm()
        {
            InitializeComponent();
        }

        private void CalcultorForm_Load(object sender, EventArgs e)
        {
            Loadbtn();
            
        }
        /// <summary>
        /// Event Handler to Perform Some Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender,EventArgs e)
        {
            if (onOff)
            {
                ///Append the Button on clicking the Number button
                ///
                int flage = 0;
                foreach (Button btnnumber in btnNumbersList)
                {
                    if (btnnumber == (Button)sender && txtInput.Text.Length <= 15)
                    {
                        if (txtInput.Text == Buttons.Zero)
                        {
                            txtInput.Text = ((Button)sender).Text; isNumberSymbol = false; break;
                        }
                        else
                        if (txtInput.Text != Buttons.Zero)
                        {
                            if ((isNumberSymbol) || (isAnswer))
                            {

                                txtInput.Text = ((Button)sender).Text;
                                isNumberSymbol = false;
                                isAnswer = false;
                            }
                            else
                            {
                                txtInput.Text += ((Button)sender).Text;

                            }
                            break;
                        }
                        flage = 1;
                    }
                }
                //if flage is zero then only go for symbol checking 
                if (flage == 0)
                {
                    foreach (Button btnSymbol in btnSysmbolsList)
                    {
                        //coding for Appending Back button into Text box
                        if (((Button)sender).Text == Buttons.Back)
                        {
                            if (!isAnswer)
                            {
                                // Console.WriteLine("txtinput value=" + txtInput.Text);
                                if ((txtInput.Text.IndexOf(Buttons.Minus) > -1 && txtInput.Text.Length == 2) || (txtInput.Text.Length == 1))
                                {
                                    txtInput.Text = Buttons.Zero; break;
                                }


                                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
                                break;
                            }

                        }
                        //coding for Appending Dot into Text box
                        if (((Button)sender).Text == Buttons.Dot)
                        {

                            //for checking if dot is not  available inside input box then add dot inside input box
                            int noOfDot = txtInput.Text.IndexOf(Buttons.Dot);
                            if (noOfDot == -1)
                            {
                                if (!isAnswer)
                                { txtInput.Text += ((Button)sender).Text; break; }
                                else { txtInput.Text = Buttons.Zero + Buttons.Dot; }

                            }
                        }

                        //coding for Appending Clear Button into Text box
                        if (((Button)sender).Text == Buttons.Clear)
                        {
                            txtInput.Text = Buttons.Zero;
                            txtPrivious.Text = "";
                            Operand1 = string.Empty;
                            Operand2 = string.Empty;
                            result = 0.0;
                            break;
                        }

                        //coding for Appending PlusMinus Button into Text box
                        if (((Button)sender).Text == Buttons.PlusMinus)
                        {
                            if (txtInput.Text != Buttons.Zero)
                            {
                                int minus = (txtInput.Text).IndexOf(Buttons.Minus);
                                if (minus > -1)
                                {
                                    txtInput.Text = txtInput.Text.Substring(1, txtInput.Text.Length - 1);
                                    break;
                                }
                                else
                                if (minus == -1)
                                {
                                    txtInput.Text = Buttons.Minus + txtInput.Text;
                                    break;
                                }

                            }

                        }
                        //coding for Appending Plus Button into Text box
                        if (((Button)sender).Text == Buttons.Plus)
                        {
                            if ((txtPrivious.Text != Buttons.Blank) && !isAnswer)
                            {
                                DataTable dt = new DataTable();
                                string lbl = txtPrivious.Text + Convert.ToDouble(txtInput.Text).ToString() + Buttons.Plus; ;
                                //object v = null;
                                if (txtPrivious.Text.LastIndexOf("+") == txtPrivious.Text.Length - 1)
                                {
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();
                                    Console.WriteLine("value1==" + (lbl.Substring(0, lbl.Length - 1)));
                                }
                                else
                                {
                                    Console.WriteLine("value2==" + (lbl.Substring(0, lbl.Length - 1)));
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();

                                }
                                Operand1 = txtInput.Text;


                                //txtInput.Text = v.ToString();
                                txtPrivious.Text = lbl;
                                isAnswer = true;

                                Operator = Buttons.Plus;
                            }
                            else
                            {

                                Operator = Buttons.Plus;
                                Operand1 = Convert.ToDouble(txtInput.Text).ToString();
                                txtPrivious.Text = Convert.ToDouble(txtInput.Text).ToString() + Buttons.Plus;
                                isNumberSymbol = true;
                            }
                            break;

                        }
                        //coding for Appending Plus Button into Text box
                        if (((Button)sender).Text == Buttons.Minus)
                        {
                            if ((txtPrivious.Text != Buttons.Blank) && !isAnswer)
                            {
                                DataTable dt = new DataTable();
                                string lbl = txtPrivious.Text + Convert.ToDouble(txtInput.Text).ToString() + Buttons.Minus; ;
                                //object v = null;
                                if (txtPrivious.Text.LastIndexOf("+") == txtPrivious.Text.Length - 1)
                                {
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();
                                    Console.WriteLine("value1==" + (lbl.Substring(0, lbl.Length - 1)));
                                }
                                else
                                {
                                    Console.WriteLine("value2==" + (lbl.Substring(0, lbl.Length - 1)));
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();

                                }
                                Operand1 = txtInput.Text;

                                Operator = Buttons.Minus;
                                //txtInput.Text = v.ToString();
                                txtPrivious.Text = lbl;
                                isAnswer = true;
                            }
                            else
                            {

                                Operator = Buttons.Minus;
                                Operand1 = Convert.ToDouble(txtInput.Text).ToString();
                                txtPrivious.Text = Convert.ToDouble(txtInput.Text).ToString() + Buttons.Minus;
                                isNumberSymbol = true;
                            }
                            break;

                        }
                        if (((Button)sender).Text == Buttons.Astrick)
                        {

                            if ((txtPrivious.Text != Buttons.Blank) && !isAnswer)
                            {
                                DataTable dt = new DataTable();
                                string lbl = txtPrivious.Text + Convert.ToDouble(txtInput.Text).ToString() + Buttons.Astrick; ;
                                //object v = null;
                                if (txtPrivious.Text.LastIndexOf("+") == txtPrivious.Text.Length - 1)
                                {
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();
                                    Console.WriteLine("value1==" + (lbl.Substring(0, lbl.Length - 1)));
                                }
                                else
                                {
                                    Console.WriteLine("value2==" + (lbl.Substring(0, lbl.Length - 1)));
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();

                                }
                                Operand1 = txtInput.Text;
                                Operator = Buttons.Astrick;

                                //txtInput.Text = v.ToString();
                                txtPrivious.Text = lbl;
                                isAnswer = true;
                            }
                            else
                            {
                                Operator = Buttons.Astrick;
                                Operand1 = Convert.ToDouble(txtInput.Text).ToString();
                                txtPrivious.Text = Convert.ToDouble(txtInput.Text).ToString() + Buttons.Astrick;
                                isNumberSymbol = true;
                            }

                        }
                        //coding for Appending Plus Button into Text box
                        if (((Button)sender).Text == Buttons.divide)
                        {
                            if ((txtPrivious.Text != Buttons.Blank) && !isAnswer)
                            {
                                DataTable dt = new DataTable();
                                string lbl = txtPrivious.Text + Convert.ToDouble(txtInput.Text).ToString() + Buttons.Astrick; ;
                                //object v = null;
                                if (txtPrivious.Text.LastIndexOf("+") == txtPrivious.Text.Length - 1)
                                {
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();
                                    Console.WriteLine("value1==" + (lbl.Substring(0, lbl.Length - 1)));
                                }
                                else
                                {
                                    Console.WriteLine("value2==" + (lbl.Substring(0, lbl.Length - 1)));
                                    txtInput.Text = dt.Compute(lbl.Substring(0, lbl.Length - 1), null).ToString();

                                }
                                Operand1 = txtInput.Text;


                                //txtInput.Text = v.ToString();
                                txtPrivious.Text = lbl;
                                isAnswer = true;

                                Operator = Buttons.divide;
                            }
                            else
                            {

                                Operator = Buttons.divide;
                                Operand1 = Convert.ToDouble(txtInput.Text).ToString();
                                txtPrivious.Text = Convert.ToDouble(txtInput.Text).ToString() + Buttons.divide;
                                isNumberSymbol = true;
                            }
                            break;

                        }


                    }

                }

            }

        }
        /// <summary>
        /// this is used to perform arthmetic Operation on given Operand Like (+,-,*,/)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arthmetic_Click(object sender,EventArgs e)
        {
           
                
                Operand2 = txtInput.Text;
            if(Operand1!="")
                switch (Operator)
                {
                    case Buttons.Plus:
                   
                             result = Convert.ToDouble(Operand1) + Convert.ToDouble(Operand2);
                        break;
                    case Buttons.Minus:

                        result = Convert.ToDouble(Operand1) -Convert.ToDouble(Operand2);
                        break;
                    case Buttons.Astrick:

                        result = Convert.ToDouble(Operand1) + Convert.ToDouble(Operand2);
                        break;
                    case Buttons.divide:
                    
                        result = Convert.ToDouble(Operand1) + Convert.ToDouble(Operand2);
                        break;
                    default:
                        break;
                }
           
            txtPrivious.Text = Buttons.Blank;
            if (result.ToString().Length > 17)
            {
                //txtInput.Font.Size = 8;
                txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            }
            txtInput.Text = result.ToString();
            isAnswer = true;
        }
        /// <summary>
        /// this method are used to initialize the Text value to any button
        /// </summary>
        private void Loadbtn()
        {
            ///initialize the symbols into one list and numbers into another list
            Button[] btnSysmbolsList1 = { btnPlusMinis, btnDot, btnEqual, btnPlus, btnMinus, btnAstrick, btnDivide, btnBack, btnClear, btnOnOff };
            Button[] btnNumbersList1 = { btnZero, btnOne, btnTwo, btnThree, btnFour, btnFive, btnSix, btnSeven, btnEieght, btnNine };
            btnSysmbolsList = btnSysmbolsList1;
            btnNumbersList = btnNumbersList1;

            //Initialize the default text for Button Control
            txtInput.Text = Buttons.Zero;
            txtPrivious.Text = Buttons.Blank;
            btnPlusMinis.Text = Buttons.PlusMinus ;
            btnOnOff.Text = Buttons.OnOff;
            btnClear.Text = Buttons.Clear;
            btnBack.Text = Buttons.Back;
            btnAstrick.Text = Buttons.Astrick;
            btnDivide.Text = Buttons.divide;
            btnDot.Text = Buttons.Dot;
            btnEqual.Text = Buttons.Equal;
            btnMinus.Text = Buttons.Minus;
            btnPlus.Text = Buttons.Plus;
            btnZero.Text = Buttons.Zero;

            btnOne.Text = Buttons.One;
            btnTwo.Text = Buttons.Two;
            btnThree.Text = Buttons.Three;
            btnFour.Text = Buttons.Four;
            btnFive.Text = Buttons.Five;
            btnSix.Text = Buttons.Six;
            btnSeven.Text = Buttons.Seven;
            btnEieght.Text = Buttons.Eieght;
            btnNine.Text = Buttons.Nine;
            

        }

        private void OnOff_Click(object sender, EventArgs e)
        {
            if (onOff)
            {
                onOff = false;

                btnOnOff.Text = "On";
            }
            else
            {
                onOff = true;
                btnOnOff.Text = "Off";
            }
        }
    }
}
