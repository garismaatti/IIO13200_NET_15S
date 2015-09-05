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

namespace IIO13200_15S
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double checkInputBox(TextBox input)
        {
            double value = 0;
            if (Double.TryParse(input.Text, out value))
            {
                // is value
                input.Background = Brushes.White;
                return value;
            }
            else
            {
                //is a letter or else
                input.Background = Brushes.Red;
                return 0;
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            double WindowsHeight = 1;
            double WindowsWidth = 1;
            double FrameWidth = 1;
            double WindowsArea = 0;
            double FrameLength = 0;
            double FrameArea = 0;
            double GlassArea = 0;

            txtWindowsArea.Text = "N/A";
            txtFrameLength.Text = "N/A";
            txtFrameArea.Text = "N/A";
            txtGlassArea.Text = "N/A";

            WindowsHeight = checkInputBox(txtWindowsHeight);
            WindowsWidth = checkInputBox(txtWindowsWidth);
            FrameWidth = checkInputBox(txtWindowsFrameWidth);

            //check values and other errors
            if (WindowsHeight < 1)
            {
                txtWindowsHeight.Background = Brushes.Red;
                MessageBox.Show("Ikkunan korkeus ei ole sallituissa rajoissa!");
            }
            else if (WindowsWidth < 1)
            {
                txtWindowsWidth.Background = Brushes.Red;
                MessageBox.Show("Ikkunan leveys ei ole sallituissa rajoissa!");
            }
            else
            {
                WindowsArea = WindowsHeight * WindowsWidth;
                FrameLength = WindowsHeight + WindowsHeight + WindowsWidth + WindowsWidth;
                GlassArea = (WindowsHeight - FrameWidth * 2) * (WindowsWidth - FrameWidth * 2);
                txtWindowsArea.Text = WindowsArea.ToString();
                txtFrameLength.Text = FrameLength.ToString();
                txtGlassArea.Text = GlassArea.ToString();


                if (FrameWidth < 1 || FrameWidth >= WindowsWidth / 2 || FrameWidth >= WindowsHeight / 2)
                {
                    txtWindowsFrameWidth.Background = Brushes.Red;
                    MessageBox.Show("Ikkunan reunus ei ole sallituissa rajoissa!");
                }
                else
                {
                    FrameArea = WindowsArea - GlassArea;
                    txtFrameArea.Text = FrameArea.ToString();
                }
                
            }

        }
    }
}
