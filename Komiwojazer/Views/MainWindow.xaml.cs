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

using Komiwojazer.Logic;
using Komiwojazer.Models;
using MahApps.Metro.Controls;

namespace Komiwojazer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Cities cities = new Cities();
        public MainWindow()
        {
            InitializeComponent();
            cities.CheckBoxesList = new List<CheckBox>();
        }

      
        private void Button_CheckDistance_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxesOperations.ClearList(cities);

            int howManyChecked = CheckBoxesOperations.AddCheckedCheckBoxes(cities, grid);

            if (!CheckBoxesOperations.ExactlyTwoChecked(howManyChecked))
            {
                textBoxDistance.Text = "Make sure that you have marked exactly 2 cities!";
                return;
            }

            LinesOpearions.DeleteLinesIfNeeded(grid);

            double distance = Math.Round(Distance.DistanceBetweenTwoCity(cities.CheckBoxesList,0,1,grid,sender), 2);
            textBoxDistance.Text = $"Distance between {cities.CheckBoxesList[0].Tag.ToString()} and {cities.CheckBoxesList[1].Tag.ToString()}: {distance} km ";

        }

        private void ButtonClearClick(object sender, RoutedEventArgs e)
        {
            textBoxDistance.Text = "";
            textBoxShortestWay.Text = "";
            LinesOpearions.DeleteLinesIfNeeded(grid);

            CheckBoxesOperations.UncheckedCheckBoxes(cities, grid);

            CheckBoxesOperations.ClearList(cities);
        }

        private void Button_Way_Click(object sender, RoutedEventArgs e)
        {
            LinesOpearions.DeleteLinesIfNeeded(grid);
            textBoxShortestWay.Text = Distance.ShortestWay(cities.CheckBoxesList, grid);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxesOperations.AddCheckedCheckBox(cities, sender);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxesOperations.DeleteUnheckedCheckBox(cities, sender);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckBoxesOperations.CheckAll(grid);
        }
    }
}
