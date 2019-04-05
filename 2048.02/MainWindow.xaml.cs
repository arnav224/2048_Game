using System;
using System.Collections.Generic;
using System.Linq;
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

namespace _2048._02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.NewGame4X4Button.Click += NewGame4X4Button_Click;
            this.NewGame6X6Button.Click += NewGame6X6Button_Click;
        }

        private void NewGame6X6Button_Click(object sender, RoutedEventArgs e)
        {
            Game6X6Window game6X6Window = new Game6X6Window();
            game6X6Window.ShowDialog();
        }

        private void NewGame4X4Button_Click(object sender, RoutedEventArgs e)
        {
            Game4X4Window game4X4Window = new Game4X4Window();
            game4X4Window.ShowDialog();
        }
    }
}
