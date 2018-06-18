using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Komiwojazer.Logic
{
    static class Distance
    {
        public static double DistanceBetweenTwoCity(List<CheckBox> CheckBoxesList, int elemnt1, int elemnt2, Grid grid, object sender)
        {


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


            Point c1 = new Point(Convert.ToDouble(str1[0])+add1, Convert.ToDouble(str1[1])+add1);
            Point c2 = new Point(Convert.ToDouble(str2[0])+add2, Convert.ToDouble(str2[1])+add2);

            double pos1 = (c1.X - c2.X) * (c1.X - c2.X);
            double pos2 = (c1.Y - c2.Y) * (c1.Y - c2.Y);
            double d = Math.Sqrt(pos1 + pos2);

            d = Math.Abs(d);

            if(sender is Button)
            {
                Button btn = sender as Button;
                if(btn.Name == "checkDistanceButton")
                    grid.Children.Add(LinesOpearions.DrawLineTwoPoints(CheckBoxesList, 0, 1));
            }

            return d * 0.9;
        }

        public static string ShortestWay(List<CheckBox> CheckBoxesList, Grid grid)
        {
            StringBuilder result = new StringBuilder();

            if (!CheckBoxesOperations.AtLeastTwoChecked())
            {
                result.Append("Make sure that you have marked exactly 2 cities!");
                return result.ToString();
            }


            result.Append(CheckBoxesList.First().Tag.ToString());

            double totalDistance = 0;

            int startingPoint = 0;

            int howManyCities = CheckBoxesList.Count();

            int whileCounter = howManyCities;

            double[] distances = new double[howManyCities];

            List<int> usedIndexes = new List<int>();

            usedIndexes.Add(startingPoint);

            distances[0] = 0;

            while(whileCounter>=2)
            {
                distances = new double[howManyCities];

                for (int i = 0; i < howManyCities; i++)
                {
                    if (usedIndexes.Contains(i)) continue;
                    distances[i] = DistanceBetweenTwoCity(CheckBoxesList, startingPoint, i,grid,null);
                }

                double secondSmaller = (from number in distances
                                        orderby number
                                        select number).Distinct().Skip(1).First();

                int index = Array.IndexOf(distances, secondSmaller);


                result.Append(" =>\n" + CheckBoxesList[index].Tag.ToString());



                grid.Children.Add(LinesOpearions.DrawLineTwoPoints(CheckBoxesList,startingPoint,index));

                whileCounter--;  

                startingPoint = index;

                usedIndexes.Add(startingPoint);

                totalDistance += secondSmaller;
            }

            totalDistance+= DistanceBetweenTwoCity(CheckBoxesList, 0, startingPoint,grid,null);

            totalDistance = Math.Round(totalDistance, 2);

            result.Append(" =>\n" + CheckBoxesList.First().Tag.ToString());
            result.Append("\n\nTotal distance: " + totalDistance + " km");

            grid.Children.Add(LinesOpearions.DrawLineTwoPoints(CheckBoxesList, 0, startingPoint));

            return result.ToString();
        }
    }
}
