using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace szyfr
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;
            int.TryParse(ShiftTextBox.Text, out int ShiftVal);

            OutputTextBlock.Text = Caesar(inputText, ShiftVal);
        }

        private string Caesar(string input, int shift)
        {
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char c = buffer[i];
                if (char.IsLetter(c))
                {
                    char d = char.IsUpper(c) ? 'A' : 'a';
                    c = (char)((((c - d) + shift) % 26 + 26) % 26 + d);
                }
                buffer[i] = c;
            }
            return new string(buffer);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FileName = "zaszyfrowany.txt";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, OutputTextBlock.Text);
            }
        }
    }
}