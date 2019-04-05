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
using System.Windows.Shapes;

namespace _2048._02
{
    /// <summary>
    /// Interaction logic for Game4X4Window.xaml
    /// </summary>
    public partial class Game4X4Window : Window
    {
        const int SIZE = 4;
        Game_2048 Game;
        public Game4X4Window()
        {
            InitializeComponent();
            this.Game = new Game_2048(SIZE);
            this.Game.GameOver += Game_GameOver;
            this.Game.UpdateScore += Game_UpdateScore;
            this.KeyDown += Game4X4Window_KeyDown;
            this.NewGameButton.Click += NewGameButton_Click;
            //this.Closed += Game4X4Window_Closed;
            Refresh();
        }

        //private void Game4X4Window_Closed(object sender, EventArgs e)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.Show();
        //}

        private void Game4X4Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    Game.LeftKey(sender, e);
                    Refresh();
                    break;
                case Key.Right:
                    Game.RightKey(sender, e);
                    Refresh();
                    break;
                case Key.Up:
                    Game.UpKey(sender, e);
                    Refresh();
                    break;
                case Key.Down:
                    Game.DownKey(sender, e);
                    Refresh();
                    break;
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Game = new Game_2048(SIZE);
            this.Game.GameOver += Game_GameOver;
            this.Game.UpdateScore += Game_UpdateScore;
            Refresh();
        }

        private void Game_UpdateScore(object sender, EventArgs e)
        {
            this.ScoreLable.Content = "ניקוד: " + this.Game.Score.ToString() + "   השיא: " + Game.HighestScore.ToString();
        }

        private void Game_GameOver(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("Game Over ):");
        }
        void Refresh()
        {
            int index = 0;
            foreach (System.Windows.Controls.Label lable in (from System.Windows.Controls.Control item in this.PlayGrid.Children where item is System.Windows.Controls.Label && index < SIZE*SIZE select item))
            {
                this.Game_UpdateScore(this, new EventArgs());
                int value = Game.Matrix[index / SIZE, index++ % SIZE];
                switch (value)
                {
                    case 0:
                        lable.Content = "";
                        lable.Background = new SolidColorBrush(Colors.Transparent);
                        break;
                    case 2:
                        lable.Content = "2";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xF2, 0xE8, 0xAE));
                        break;
                    case 4:
                        lable.Content = "4";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xF8, 0xCA, 0x85));
                        break;
                    case 8:
                        lable.Content = "8";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xB7, 0x4A));
                        break;
                    case 16:
                        lable.Content = "16";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x83, 0x27));
                        break;
                    case 32:
                        lable.Content = "32";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xF8, 0x44, 0x13));
                        break;
                    case 64:
                        lable.Content = "64";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x16, 0x00));
                        break;
                    case 128:
                        lable.Content = "128";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xD2, 0x3C));
                        break;
                    case 256:
                        lable.Content = "256";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE4, 0xAA, 0x10));
                        break;
                    case 512:
                        lable.Content = "512";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xF4, 0x86, 0xB0));
                        break;
                    case 1024:
                        lable.Content = "1024";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEB, 0x5E, 0xCB));
                        break;
                    case 2048:
                        lable.Content = "2048";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xB4, 0x12, 0xB2));
                        break;
                    case 4096:
                        lable.Content = "4096";
                        lable.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEE, 0x18, 0xF4));
                        break;
                }
            }
        }


    }
}
