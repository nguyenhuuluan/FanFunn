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

namespace FanFunn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag = false;
        private int currentAngle = 0;
        int high = 0;
        int s = 500;
        int goc = -5;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer(500);
        }
        void Timer(int s)
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, s);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RotateTransform rotateTransform = new RotateTransform();
            currentAngle -= goc;
            rotateTransform.Angle = currentAngle;
            rotateTransform.CenterY = 0;
            rotateTransform.CenterX = 0;
            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            img.RenderTransform = transformGroup;

            RotateTransform rotateTransform2 = new RotateTransform();
            rotateTransform2.Angle = currentAngle;
            rotateTransform2.CenterX = 0;
            rotateTransform2.CenterY = 0;
            TransformGroup transformGroup2 = new TransformGroup();
            transformGroup2.Children.Add(rotateTransform2);
            img2.RenderTransform = transformGroup2;

            RotateTransform rotateTransform3 = new RotateTransform();
            rotateTransform3.Angle = currentAngle;
            rotateTransform3.CenterY = 0;
            rotateTransform3.CenterX = 0;
            TransformGroup transformGroup3 = new TransformGroup();
            transformGroup3.Children.Add(rotateTransform3);
            img3.RenderTransform = transformGroup3;

            RotateTransform rotateTransform4 = new RotateTransform();
            rotateTransform4.Angle = currentAngle;
            rotateTransform4.CenterX = 0;
            rotateTransform4.CenterY = 0;
            TransformGroup transformGroup4 = new TransformGroup();
            transformGroup4.Children.Add(rotateTransform4);
            img4.RenderTransform = transformGroup4;


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int tmp = 1 + int.Parse(Score.Content.ToString());
                Score.Content = tmp + "";
                flag = true;
                if (tmp % 7 == 0 || tmp % 11 == 0 || tmp % 17 == 0 || tmp % 21 == 0)
                {
                    goc = goc * -1;
                }
                if (s > 100)
                {
                    s -= 200;
                }
                else if (s > 50)
                { 
                    s -= 20;
                }
                else if (s > 20)
                {
                    s -= 10;
                }
                Timer(s);
            }
            catch
            { }
        }

        private void FanFunn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (!flag)
                {
                    dispatcherTimer.Stop();
                    MessageBox.Show("YOU LOSE!");
                    int score = int.Parse(Score.Content.ToString());
                    high = int.Parse(lblBest.Content.ToString());
                    if (score > high)
                    {
                        LoseForm form = new LoseForm(high, score);
                        form.ShowDialog();
                        s = 500;
                        Timer(s);
                        lblBest.Content = score;
                        score = 0;
                        Score.Content = 0;
                    }
                    else
                    {
                        LoseForm form = new LoseForm(high, score);
                        form.ShowDialog();
                        s = 500;
                        score = 0;
                        Score.Content = 0;
                        Timer(s);

                    }
                }
                else
                {
                    flag = false;
                }
            }
            catch { }
        }
    }
}
