using System.Data;
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
using LIB_TWO;

namespace PracticalTwo
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

        // Обработчик кнопки "Выход"
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Обработчик кнопки "О программе"
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Сухомяткина Ксения\nНомер работы: 2\nЗадание: Найти сумму n целых, четных, случайных чисел.", "О программе");
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // Получение значения n
            if (int.TryParse(InputN.Text, out int n) && n > 0)
            {
                // Генерация случайных четных чисел
                Random random = new Random();
                int[] evenNumbers = new int[n];
                for (int i = 0; i < n; i++)
                {
                    evenNumbers[i] = random.Next(0, n + 1) * 2; // Генерируем четные числа
                }

                // Подсчет суммы четных чисел
                int sum = evenNumbers.Sum();
                ResultText.Text = $"Сумма четных чисел: {sum}";

                // Преобразование в DataTable с использованием метода из класса VisualArray
                DataTable dataTable = VisualArray.ToDataTable(evenNumbers);
                // Здесь вы можете использовать dataTable, например, для отображения в DataGrid или другой логики
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите положительное целое число.", "Ошибка ввода");
            }
        }
    }
}