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
        private Point previousPoint = new Point();
        private SolidColorBrush currentBrush = new SolidColorBrush(Colors.Black);
        private int currentBrushSize=5;
        private string currentDrawStyle = "Free Draw";
        public MainWindow()
        {
            InitializeComponent();
     
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void canvaMouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Line line = new Line
                {
                    X1 = previousPoint.X,
                    Y1 = previousPoint.Y,
                    X2 = e.GetPosition(Canvas).X,
                    Y2 = e.GetPosition(Canvas).Y,
                    Stroke = currentBrush,
                    StrokeThickness = currentBrushSize
                };
                Canvas.Children.Add(line);
                previousPoint=e.GetPosition(Canvas);
            }
        }
        private void canvaMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                
                isDrawing = true;
                previousPoint=e.GetPosition(Canvas);
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
        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            if (DrawStyle.SelectedItem is ComboBoxItem selectedItem)
            {
                currentDrawStyle = selectedItem.Content.ToString();
            }
        }
    }
}