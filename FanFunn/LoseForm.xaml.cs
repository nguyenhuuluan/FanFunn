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
using System.Windows.Shapes;

namespace FanFunn
{
    /// <summary>
    /// Interaction logic for LoseForm.xaml
    /// </summary>
    public partial class LoseForm : Window
    {
        int HIGH;
        int SCORE;
        public LoseForm(int high, int score)
        {
            HIGH = high;
            SCORE = score;
            InitializeComponent();
 
            checkhigh();
        }
        void checkhigh()
        {
            if (SCORE > HIGH)
            {
                lblscore.Content = SCORE;
                lblhigh.Content = SCORE;
            }
            else
            {
                lblNew.Visibility = Visibility.Hidden;
                lblscore.Content = SCORE;
                lblhigh.Content = HIGH;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
