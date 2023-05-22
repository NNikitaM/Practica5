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

namespace Practica5
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
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TbNumber.Text))
            {
                return;
            }
            try
            {
                int xa = Convert.ToInt32(TbNumber.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены не корректные данные");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ListBoxData.Items.Add(TbNumber.Text);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int k = -1;
                int min = 0;
                for (int i = 1; i < 1000; i++)
                {
                    int m = Convert.ToInt32(ListBoxData.Items[i]);
                    if (m == 0)
                    { break; }
                    if (m % 3 == 0)
                    {
                        if (k == -1)
                        {
                            min = m;
                            k = 0;
                        }
                        if (min > m)
                        {
                            min = m;
                        }
                    }

                }
                if (k != -1)
                {
                    TextBlockAnswer.Text = $"Ответ:\n{min}";
                }
                else
                {
                    TextBlockAnswer.Text = $"Ответ:\n Чисел кратных трем нет";
                }
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
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
