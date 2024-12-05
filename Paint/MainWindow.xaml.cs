using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;


namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private Point previousPoint = new Point();
        private Point nextPoint;
        private SolidColorBrush currentBrush = new SolidColorBrush(Colors.Black);
        private int currentBrushSize = 5;
        private bool lineMode = false;
        public MainWindow()
        {
            InitializeComponent();

        }


        private void canvaMouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing&&!lineMode)
            {
                Line line = new Line
                {
                    X1 = previousPoint.X,
                    Y1 = previousPoint.Y,
                    X2 = e.GetPosition(Canvas).X,
                    Y2 = e.GetPosition(Canvas).Y,
                    Stroke = currentBrush,
                    StrokeThickness = currentBrushSize,
                };
                Canvas.Children.Add(line);
                previousPoint = e.GetPosition(Canvas);
            }

        }
        private void canvaMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDrawing = true;
                previousPoint = e.GetPosition(Canvas);
            }
            if (e.ChangedButton == MouseButton.Left && lineMode)
            {
                isDrawing = false;
                previousPoint = e.GetPosition(Canvas);
            }
        }
        private void canvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Released)
            {
                if (lineMode)
                {
                    // If in line mode, draw a straight line when mouse is released
                    Line line = new Line
                    {
                        X1 = previousPoint.X,
                        Y1 = previousPoint.Y,
                        X2 = e.GetPosition(Canvas).X,
                        Y2 = e.GetPosition(Canvas).Y,
                        Stroke = currentBrush,
                        StrokeThickness = currentBrushSize,
                    };
                    Canvas.Children.Add(line); // Add the straight line to the canvas
                }
                isDrawing = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                var selectedItem = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                currentBrushSize = int.Parse(selectedItem); // Convert string to integer for brush size
            }
        }
        private void ComboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                var selectedColor = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                switch (selectedColor)
                {
                    case "Black":
                        currentBrush = new SolidColorBrush(Colors.Black);
                        break;
                    case "Red":
                        currentBrush = new SolidColorBrush(Colors.Red);
                        break;
                    case "Green":
                        currentBrush = new SolidColorBrush(Colors.Green);
                        break;
                    case "Yellow":
                        currentBrush = new SolidColorBrush(Colors.Yellow);
                        break;
                    case "Blue":
                        currentBrush = new SolidColorBrush(Colors.Blue);
                        break;
                    default:
                        currentBrush = new SolidColorBrush(Colors.Black);
                        break;
                }
            }
        }
        private void StyleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                var selectedStyle = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                switch (selectedStyle)
                {
                    case "Straight Line":
                        lineMode = true;
                        break;
                    case "Free Draw":
                        lineMode = false;
                        break;
                }

            }
        }
    }
}