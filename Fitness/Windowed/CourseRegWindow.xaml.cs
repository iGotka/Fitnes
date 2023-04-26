using Fitness.Controllers;
using Fitness.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Fitness.Windowed
{
    /// <summary>
    /// Логика взаимодействия для CourseRegWindow.xaml
    /// </summary>
    public partial class CourseRegWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public CourseRegWindow(CourseRegistration currentElement)
        {
            InitializeComponent();
            this.DataContext = currentElement;
            List<Course> arrCorse = CoursesController.GetCourse();
            List<Trainer> arrTrainer = TrainersController.GetTrainers();
            CourseComboBox.ItemsSource = arrCorse.ToList();
            TrainerComboBox.ItemsSource = arrTrainer.ToList();
            
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CourseRegistration newRegistration = new CourseRegistration {
             
            };   
            CourseRegistrationsController.PostCourseRegistration(newRegistration);
        }



        private void ImageSaveButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog per = new OpenFileDialog();
            if (per.ShowDialog() == true)
            {
                //перенос файла в проект
                string newfilename = "\\Img\\";
                //путь к проекту
                string appFolderPath = Directory.GetCurrentDirectory();
                appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

                string imageName = System.IO.Path.GetFileName(per.FileName);//имя картинки с расширением

                newfilename = appFolderPath + newfilename + imageName;

                File.Copy(per.FileName, newfilename);
            }
        }

        private void CourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CourseComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
