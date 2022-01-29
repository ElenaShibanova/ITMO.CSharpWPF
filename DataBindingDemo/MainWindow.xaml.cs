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
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization; 

namespace DataBindingDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Brush))]
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
        {
            Brush b = null;
            if (value != null &&
            value.GetType() == typeof(bool))
            {
                b = (bool)value ? Brushes.Green : Brushes.Red;
            }
            return b;
        }
        public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
        {
            return null;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class Student
    {
        public string StudentName { get; set; }
        public bool IsEnrolled { get; set; }
    }
    public class StudentList : ObservableCollection<Student>
    {
    }
}
