using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Komiwojazer.Models;

namespace Komiwojazer.Logic
{
   public static class CheckBoxesOperations
    {
       public static int checkedCounter = 0;
        public static int AddCheckedCheckBoxes(Cities cities, Grid grid)
        {
            int checkedCounter = 0;

            foreach (CheckBox c in grid.Children.OfType<CheckBox>())
            {
                if (c.IsChecked == true)
                {
                    checkedCounter++;
                    cities.CheckBoxesList.Add(c);
                }
            }

            return checkedCounter;
        }

        public static void AddCheckedCheckBox(Cities cities, object sender)
        {
            checkedCounter++;
            CheckBox box = sender as CheckBox;
            cities.CheckBoxesList.Add(box);
        }

        public static void DeleteUnheckedCheckBox(Cities cities, object sender)
        {
            checkedCounter--;
            CheckBox box = sender as CheckBox;
            cities.CheckBoxesList.Remove(box);
        }

        public static bool AtLeastTwoChecked()
        {
            if (checkedCounter >= 2)
                return true;
            else return false;

        }


        public static bool ExactlyTwoChecked(int checkedCounter)
        {
            if (checkedCounter != 2)
                return false;
                    else return true;
            
        }

        public static void ClearList(Cities cities)
        {
            cities.CheckBoxesList.Clear();
        }

        public static void UncheckedCheckBoxes(Cities cities, Grid grid)
        {
            foreach (CheckBox c in grid.Children.OfType<CheckBox>())
            {
                if (c.IsChecked == true)
                {
                    c.IsChecked = false;
                }
            }
        }

        public static void CheckAll(Grid grid)
        {
            foreach (CheckBox c in grid.Children.OfType<CheckBox>())
            {
                if (c.IsChecked == false)
                {
                    c.IsChecked = true;
                }
            }
        }
    }
}
