using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
        public partial class MainWindow : Window
    {


        long number1 = 0;
        long number2 = 0;
        string operation = "";
        bool can_handle = true;

        public MainWindow()
        {
            InitializeComponent();
            display_nums(0);
        }

        private void display_nums(long number)
        {
            textblock.Text = number2.ToString() + operation + "\n" + number.ToString();
        }


        private void csnt_hrndle()
        {
            number1 = 0;
            number2 = 0;
            operation = "";
            textblock.Text = "ERROR";
        }

        private void ClrE(object sender, RoutedEventArgs e){
            number1 = 0;
            number2 = 0;
            operation = "";
            display_nums(number1);
        }

        private void btnC_Click(object sender, RoutedEventArgs e) {
            number1 = 0;
            operation = "";
            display_nums(number1);
        }
        private void btnBACK_Click(object sender, RoutedEventArgs e)
        {
            number1 /= 10;
            display_nums(number1);
        }

        private void run_culcs(int numid)
        {
            long holdnumber = number1;
            number1 = (number1 *= 10) + numid;
            if (number1 < 0)
                number1 = holdnumber;
            display_nums(number1);
        }

        private void btn7_Click(object sender, RoutedEventArgs e){ run_culcs(7); }
        private void btn8_Click(object sender, RoutedEventArgs e){ run_culcs(8); }
        private void btn9_Click(object sender, RoutedEventArgs e){ run_culcs(9); }
        private void btn4_Click(object sender, RoutedEventArgs e){ run_culcs(4); }
        private void btn5_Click(object sender, RoutedEventArgs e){ run_culcs(5); }
        private void btn6_Click(object sender, RoutedEventArgs e){ run_culcs(6); }
        private void btn1_Click(object sender, RoutedEventArgs e){ run_culcs(1); }
        private void btn2_Click(object sender, RoutedEventArgs e){ run_culcs(2); }
        private void btn3_Click(object sender, RoutedEventArgs e){ run_culcs(3); }
        private void btn0_Click(object sender, RoutedEventArgs e){ run_culcs(0); }

        private void run_ops(string OpId, bool send_out = true)
        {
            long hold_number = number2;
            bool num_sign = number2 >= 0;

            if (number2 == 0)
            {
                operation = OpId;
                number2 = number1;
                number1 = 0;
                display_nums(number1);
                return;
            }
            operation = OpId;

            try
            {

                switch (OpId)
                {
                    case "+":
                        hold_number += number1;
                        break;
                    case "-":
                        hold_number -= number1;
                        break;
                    case "*":
                        hold_number *= number1;
                        break;
                    case "/":
                        hold_number /= number1;
                        break;
                }
            }
            catch (DivideByZeroException e)
            {
                csnt_hrndle();
                return;
            }

            if (num_sign != hold_number >= 0)
            {
                can_handle = false;
                if (send_out)
                {
                    csnt_hrndle();
                    return;
                }
            }

            number2 = hold_number;
            number1 = 0;
            if (send_out)
            {
                display_nums(number1);
            }

        }

        private void btnadd_Click(object sender, RoutedEventArgs e){ run_ops("+"); }

        private void btnsub_Click(object sender, RoutedEventArgs e){ run_ops("-"); }

        private void btnmul_Click(object sender, RoutedEventArgs e){ run_ops("*"); }

        private void btndev_Click(object sender, RoutedEventArgs e){ run_ops("/"); }


        private void btnepl_Click(object sender, RoutedEventArgs e){
            run_ops(operation, false);

            if (can_handle)
                csnt_hrndle();
            else
            {
                long temp = number2;
                number1 = 0;
                operation = "";
                display_nums(number1);
            }
        }

        private void btnmaybe_Click(object sender, RoutedEventArgs e){}
    }
}
