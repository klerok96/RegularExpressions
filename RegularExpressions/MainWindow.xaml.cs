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
using System.Text.RegularExpressions;

namespace RegularExpressions
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;

            string pattern = @"(\b\w+)\s+\1";

            while (Regex.IsMatch(text, pattern))
            {
                foreach (Match match in Regex.Matches(text, pattern, RegexOptions.IgnoreCase))
                {
                    string replacement1 = match.Groups[1].Value;

                    text = Regex.Replace(text, match.Value, replacement1);
                }
            }
            MessageBox.Show(text);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                AboutBox1 f = new AboutBox1();
                f.ShowDialog();
            }
        }
    }
}
