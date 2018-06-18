using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Komiwojazer.Logic
{
    public static class LinesOpearions
    {
        public static Line DrawLineTwoPoints(List<CheckBox> CheckBoxesList, int elemnt1, int elemnt2)
        {
            Line line = new Line();

            string margin1 = CheckBoxesList[elemnt1].Margin.ToString();
            string margin2 = CheckBoxesList[elemnt2].Margin.ToString();

            string[] str1 = margin1.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] str2 = margin2.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            string size1 = CheckBoxesList[elemnt1].Name[0].ToString();
            string size2 = CheckBoxesList[elemnt2].Name[0].ToString();

            int add1;
            int add2;

            if (size1 == "s")
                add1 = 6;
            else if (size1 == "m")
                add1 = 10;
            else
                add1 = 13;

            if (size2 == "s")
                add2 = 6;
            else if (size2 == "m")
                add2 = 10;
            else
                add2 = 13;



            line.X1 = Convert.ToInt32(str1[0]) + add1;
            line.Y1 = Convert.ToInt32(str1[1]) + add1;

            line.X2 = Convert.ToInt32(str2[0]) + add2;
            line.Y2 = Convert.ToInt32(str2[1]) + add2;

            line.Stroke = Brushes.Red;


            return line;
        }

        public static void DeleteLinesIfNeeded(Grid grid)
        {

            UIElement el = null;
            for (int i = grid.Children.Count - 1; i >= 0; i--)
                if ((el = grid.Children[i]) is Line)
                    grid.Children.Remove(el);
        }
    }

}
