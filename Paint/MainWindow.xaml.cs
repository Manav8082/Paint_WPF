using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;


namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private SolidColorBrush currentBrush = new SolidColorBrush(Colors.Black);
        private int currentBrushSize=5;
        public MainWindow()
        {
            InitializeComponent();
     
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

       
        private void canvaMouseMove(object sender, MouseEventArgs e)
        {
            if(isDrawing)
            {
                Point position = e.GetPosition(Canvas);
                Ellipse point = new Ellipse
                {
                    Width = currentBrushSize,
                    Height = currentBrushSize,
                    Fill = currentBrush,
                };

                Canvas.SetLeft(point, position.X-(currentBrushSize/2));
                Canvas.SetTop(point, position.Y - (currentBrushSize / 2));

                Canvas.Children.Add(point);

            }
        }
        private void canvaMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {

                isDrawing = true;
            }
        }
        private void canvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                // Stop drawing on MouseUp
                isDrawing = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (BrushSize.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                currentBrushSize = int.Parse(selectedItem.Content.ToString());
            }
        }
        private void ComboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (BrushColor.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                currentBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedItem.Content.ToString()));
            }
        }

        
    }
}