using Fitness.Controllers;
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
using Fitness.Models;
using Fitness.Windowed;



namespace Fitness
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            List<Course> arrCorse = CoursesController.GetCourse();
            List<Trainer> arrTrainer = TrainersController.GetTrainers();
            List<CourseRegistration> arrCorseReg=CourseRegistrationsController.GetCourseRegistration();
           
            DataGridRegestration.ItemsSource = arrCorseReg;


            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridRegestration.SelectedItem as CourseRegistration;
            if (row == null)
            {
                MessageBox.Show("Вы не выбрали ни одной строки");
                return;
            }

            MessageBoxResult result=MessageBox.Show("Вы уверены, что хотите удалить строку?","Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                bool resultDelete=CourseRegistrationsController.DeleteCourseRegistration(row.Id);
                if (resultDelete==true)
                {
                    MessageBox.Show("Данные удалены");
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CourseRegistration element = new CourseRegistration();
            CourseRegWindow win = new CourseRegWindow(element);
           
            win.ShowDialog();
           
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit=sender as Button;
            CourseRegistration activeElement = btnEdit.DataContext as CourseRegistration;
             var win = new CourseRegWindow(activeElement);
            win.ShowDialog();
        }

        private void DataGridRegestration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
