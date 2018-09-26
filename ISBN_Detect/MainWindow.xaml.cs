using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using WebEye.Controls.Wpf;

namespace ISBN_Detect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBox();
        }


        /// <summary>
        /// Provides info about sources of video stream for combo box.
        /// </summary>
        public void InitializeComboBox()
        {
            comboBox.ItemsSource = webCameraControl.GetVideoCaptureDevices();
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedItem = comboBox.Items[0];
            }
            else
            {
                MessageBox.Show("Video camera wasn't detected");
            }
        }

        /// <summary>
        /// Makes buttons availiable when you have selected source of video stream. 
        /// </summary>
        public void OnSelectionChanged(object sender, SelectionChangedEventArgs eventArgs)
        {
            startButton.IsEnabled = eventArgs.AddedItems.Count > 0;
        }

        private void GetIsbnButton_Click(object sender, RoutedEventArgs e)
        {

            Bitmap image =  webCameraControl.GetCurrentImage();
            image.Save("lil.bmp");
            var t = new VIewModel.ImageRecognition();
            MessageBox.Show(t.Recognize(image));

        }
        /// <summary>
        /// Starts video stream using open source library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var cameraId = (WebCameraId)comboBox.SelectedItem;
            webCameraControl.StartCapture(cameraId);
        }
        
    }
}
