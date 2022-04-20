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

namespace Exercise4
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

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            if(txtAngle.Text != null)
            {
            }
            lblError.Visibility = Visibility.Hidden;
            txtAngle.Background = Brushes.White;
            if (int.TryParse(txtAngle.Text, out int angle))
            {
            RotateTransform rotate = new RotateTransform(angle);
            rotate.CenterX = 50;
            rotate.CenterY = 100;
            recObj.RenderTransform = rotate;
            } else
            {
                lblError.Visibility = Visibility.Visible;
                txtAngle.Background = Brushes.Red;
            }
            
        }
    }
}
