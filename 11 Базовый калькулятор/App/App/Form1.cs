namespace App
{
    public partial class Form1 : Form
    {

        Double result = 0;
        String operationPerformed = "";
        bool isOpeartionPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void numBtn_click(object sender, EventArgs e)
        {
            if (display.Text == "0" || isOpeartionPerformed)
            {
                display.Clear();
            }
            isOpeartionPerformed = false;
            Button button = (Button)sender;
            display.Text += button.Text;
        }

        private void operationBtn_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            result = Double.Parse(display.Text);
            isOpeartionPerformed = true;
        }

        private void equals_Click(object sender, EventArgs e)
        {
            Double secondOperand = Double.Parse(display.Text);
            switch (operationPerformed)
            {
                case "+":
                    display.Text = add(result, secondOperand).ToString();
                    break;
                case "-":
                    display.Text = subtract(result, secondOperand).ToString();
                    break;
                case "/":
                    display.Text = div(result, secondOperand).ToString();      
                    break;
                case "*":
                    display.Text = mult(result, secondOperand).ToString();
                    break;
            }
        }

        private Double add(Double numOne, Double numTwo)
        {
            try {
                return numOne + numTwo;
            }
            catch
            {
                throw new Exception("Ошибка");
            }
            
        }

        private Double subtract(Double numOne, Double numTwo)
        {
            try
            {
                return numOne - numTwo;
            }
            catch
            {
                throw new Exception("Ошибка");
            }
            
        }

        private Double mult(Double numOne, Double numTwo)
        {
            try
            {
                return numOne * numTwo;
            }
            catch
            {
                throw new Exception("Ошибка");
            }
        }

        private Double div(Double numOne, Double numTwo)
        {

            if (numTwo == 0)
            {
                throw new DivideByZeroException("Деление на ноль запрещено");
            }
            return numOne / numTwo;
        }


        private void clearAll_Click(object sender, EventArgs e)
        {
            display.Clear();
        }

    }
}