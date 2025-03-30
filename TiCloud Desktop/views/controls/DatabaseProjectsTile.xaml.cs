using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TiCloud.Core.Database.Models;
using TiCloud.Core.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiCloud_Desktop.views.controls
{
    /// <summary>
    /// Logika interakcji dla klasy DatabaseProjectsTile.xaml
    /// </summary>
    public partial class DatabaseProjectsTile : System.Windows.Controls.UserControl
    {

        public static readonly DependencyProperty ProjectNameProperty =
           DependencyProperty.Register(nameof(ProjectName), typeof(string), typeof(DatabaseProjectsTile), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ProjectIDProperty =
           DependencyProperty.Register(nameof(ProjectID), typeof(string), typeof(DatabaseProjectsTile), new PropertyMetadata(string.Empty));

        public string ProjectName
        {
            get => (string)GetValue(ProjectNameProperty);
            set => SetValue(ProjectNameProperty, value);
        }

        public string ProjectID
        {
            get => (string)GetValue(ProjectIDProperty);
            set => SetValue(ProjectIDProperty, value);
        }



        public DatabaseProjectsTile()
        {
            InitializeComponent();


        }



        private void LoadProjectsFromDatabaseToComboBox()
        {
            //Pobranie listy projektów z bazy danych
            List<Project> projects = DatabaseManager.GetAllProjects().ToList();


            projects.ForEach(p => Debug.WriteLine($"{p.ProjectName}, ID:{p.ProjectID}"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
