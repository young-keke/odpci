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

namespace WordEater
{
    /// <summary>
    /// Interaction logic for Program.xaml
    /// </summary>
    public partial class Program : Window
    {
        Model MyModel;
        public Program()
        {
            InitializeComponent();
        }
        public Program(int i)
        {
            InitializeComponent();
            MyModel = new Model(i);

        }

        private void ParseBtn_Click(object sender, RoutedEventArgs e)
        {
            MyModel.StartParsing();
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = null;
            string[] actuallyText = tb.Text.Replace('\n', ' ').Split(' ');
            try
            {
                MyModel.Find(ref MyModel.FoundWords, actuallyText[0], int.Parse(actuallyText[1]));
            }
            catch (Exception)
            { }
            for (int q = 2; q < actuallyText.Length; q++)
            {
                if (q % 2 == 0)
                {
                    try
                    {
                        MyModel.Find(ref MyModel.FoundWords, actuallyText[q], int.Parse(actuallyText[q + 1]), MyModel.FoundWords);//при добавлении табуляции или пробела слетает к хуям, индекс аут оф рэндж
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                else continue;
            }
            foreach (string wo in MyModel.FoundWords)
            {
                Result.Text += wo + "\n";
            }
        }
    }
}
