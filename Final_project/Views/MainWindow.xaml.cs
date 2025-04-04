﻿using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
namespace Final_project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParm, int lparm);

        private void panelcontrol_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            WindowInteropHelper helper = new WindowInteropHelper(parentWindow);
            SendMessage(helper.Handle, 0xA1, 2, 0);
        }


        private void panelcontrol_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void closebtn_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to quit?",
                    "Quit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {

            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }

        private void maximizeBtn_Click(object sender, RoutedEventArgs e)
        {

            Window window = Window.GetWindow(this);
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
            }
            else
            {
                window.WindowState = WindowState.Maximized;
            }
        }





    }

}

