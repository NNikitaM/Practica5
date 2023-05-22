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

namespace Zadanie5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnOKClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(TbNumberN.Text);
                double[] u = new double[n];
                double[] y = new double[n];
                u[0] = u[1] = 0;
                y[0] = y[1] = 1;

                for (int i = 2; i < n; i++)
                {
                    y[i] = u[i - 1] - y[i - 1] / (Math.Abs(u[i - 2] + y[i - 1]) + 2);
                    u[i] = u[i - 1] - u[i - 2] * y[i - 1] - y[i - 2] / (1 + u[i - 1] * u[i - 1] + y[i - 1] * y[i - 1]);
                }
                TextBlockAnswer.Text = $"Ответ:\nU[n] = {u[n - 1]:f2}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены не корректные данные");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
