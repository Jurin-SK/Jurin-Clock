using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Jurin_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int clockType { get; set; }
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void close_MouseEnter(object sender, MouseEventArgs e)
        {
            close.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 150, 0, 0));
        }

        private void close_MouseLeave(object sender, MouseEventArgs e)
        {
            close.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
        }
        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            float hour = DateTime.Now.Hour;
            float hour2 = hour / 12 * 360 + 90;
            float minute = DateTime.Now.Minute;
            float minute2 = minute / 60 * 360 + 90;
            float second = DateTime.Now.Second;
            float second2 = second / 60 * 360 + 90;
            RotateTransform rotateTransform1 = new RotateTransform(hour2);
            rotateTransform1.CenterX = 60;
            rotateTransform1.CenterY = 3;
            hourHand.RenderTransform = rotateTransform1;
            RotateTransform rotateTransform2 = new RotateTransform(minute2);
            rotateTransform2.CenterX = 75;
            rotateTransform2.CenterY = 2;
            minuteHand.RenderTransform = rotateTransform2;
            RotateTransform rotateTransform3 = new RotateTransform(second2);
            rotateTransform3.CenterX = 90;
            rotateTransform3.CenterY = 1;
            secondHand.RenderTransform = rotateTransform3;
            string hourst = hour.ToString();
            string minutest = minute.ToString();
            string secondst2 = second.ToString();
            if (Math.Floor(Math.Log10(hour) + 1) == 1 || hourst == "0") 
            {
                hourst = "0" + hour;
            }
            if (Math.Floor(Math.Log10(minute) + 1) == 1 || minutest == "0")
            {
                minutest = "0" + minute;
            }
            if (Math.Floor(Math.Log10(second) + 1) == 1 || secondst2 == "0")
            {
                secondst2 = "0" + second;
            }
            timeFull.Text = hourst + ":" + minutest + ":" + secondst2;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void classic_Checked(object sender, RoutedEventArgs e)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                clockType = 0;
                clock.Source = new BitmapImage(new Uri("/Resources/clock.png", UriKind.Relative));
                setupClockTheme();
            };
        }

        private void empty_Checked(object sender, RoutedEventArgs e)
        {
            clockType = 1;
            clock.Source = new BitmapImage(new Uri("/Resources/clockEmpty.png", UriKind.Relative));
            setupClockTheme();
        }

        private void old_Checked(object sender, RoutedEventArgs e)
        {
            clockType = 2;
            clock.Source = new BitmapImage(new Uri("/Resources/clockOld.png", UriKind.Relative));
            setupClockTheme();
        }

        private void roman_Checked(object sender, RoutedEventArgs e)
        {
            clockType = 3;
            clock.Source = new BitmapImage(new Uri("/Resources/clockRoman.png", UriKind.Relative));
            setupClockTheme();
        }

        private void setupClockTheme()
        {
            if (dark.IsChecked == true)
            {
                Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 30, 30, 30));
                timeFull.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
                minuteHand.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
                hourHand.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
                styl.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
                about.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
                menu.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 30, 30, 30));
                if (clockType == 0)
                {
                    clock.Source = new BitmapImage(new Uri("/Resources/clockLight.png", UriKind.Relative));
                }
                else if (clockType == 1)
                {
                    clock.Source = new BitmapImage(new Uri("/Resources/clockEmptyLight.png", UriKind.Relative));
                }
                else if (clockType == 2)
                {
                    clock.Source = new BitmapImage(new Uri("/Resources/clockOldLight.png", UriKind.Relative));
                }
                else
                {
                    clock.Source = new BitmapImage(new Uri("/Resources/clockRomanLight.png", UriKind.Relative));
                }
            }
            else if (dark.IsChecked == false) {
                {
                    Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
                    timeFull.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    minuteHand.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    hourHand.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    styl.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    about.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    styles.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    about.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    abouts.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                    gith.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));

                    if (clockType == 0)
                    {
                        clock.Source = new BitmapImage(new Uri("/Resources/clock.png", UriKind.Relative));
                    }
                    else if (clockType == 1)
                    {
                        clock.Source = new BitmapImage(new Uri("/Resources/clockEmpty.png", UriKind.Relative));
                    }
                    else if (clockType == 2)
                    {
                        clock.Source = new BitmapImage(new Uri("/Resources/clockOld.png", UriKind.Relative));
                    }
                    else
                    {
                        clock.Source = new BitmapImage(new Uri("/Resources/clockRoman.png", UriKind.Relative));
                    }
                }
            }
        }

        private void dark_Click(object sender, RoutedEventArgs e)
        {
            setupClockTheme();
        }

        private void abouts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A simple clock for Windows by Jurin-SK", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void gith_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("https://github.com/Jurin-SK", "Github", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}