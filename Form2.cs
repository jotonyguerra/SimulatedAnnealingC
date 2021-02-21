using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form1 frm1;

        public string orderString = "ABCDEFGHIJ";
        public string finalPath = "";
        private double shortestDistance = 0;
        public double minDist = 9999.99;
        public double Temp = 100000000;
        public double endTemp = 0.00001;
        private double coolingRate = 0.99;
        private Random random = new Random();
        public bool clicked1 = false;
        //SET 2
        Dictionary<char, int[]> keyValue2 = new Dictionary<char, int[]>()
        {
            {'A', new int[] { 8, 377 } },
            {'B', new int[] { 450, 352 } },
            {'C', new int[] { 519, 290 } },
            {'D', new int[] { 398, 604 } },
            {'E', new int[] { 417, 496 } },
            {'F', new int[] { 57, 607 } },
            {'G', new int[] { 119, 4 } },
            {'H', new int[] { 166, 663 } },
            {'I', new int[] { 280, 622 } },
            {'J', new int[] { 531, 571 } },
        };
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = "A= (8, 377)\r\nB= (450,352)\r\nC= (519,290)\r\nD= (398,604)\r\nE= (417,496)\r\nF= (57,607)\r\nG= (119,4)\r\nH= (166,663)\r\nI= (280,622)\r\nJ= (531,571)\r\n";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void plotGraph()
        {
            chart1.Series[0].Points.Clear();
            int g = this.chart1.Series["Series1"].Points.AddXY(119, 4); //G
            this.chart1.Series["Series1"].Points[g].Label = "G";
            int a = this.chart1.Series["Series1"].Points.AddXY(8, 377); //A
            this.chart1.Series["Series1"].Points[a].Label = "A";
            int f = this.chart1.Series["Series1"].Points.AddXY(57, 607); //F
            this.chart1.Series["Series1"].Points[f].Label = "F";
            int H = this.chart1.Series["Series1"].Points.AddXY(166, 663); //H
            this.chart1.Series["Series1"].Points[H].Label = "H";
            int I = this.chart1.Series["Series1"].Points.AddXY(280, 622); //I
            this.chart1.Series["Series1"].Points[I].Label = "I";
            int D = this.chart1.Series["Series1"].Points.AddXY(398, 604); //D
            this.chart1.Series["Series1"].Points[D].Label = "D";
            int J = this.chart1.Series["Series1"].Points.AddXY(531, 571); //J
            this.chart1.Series["Series1"].Points[J].Label = "J";
            int E = this.chart1.Series["Series1"].Points.AddXY(417, 496); //E
            this.chart1.Series["Series1"].Points[E].Label = "E";
            int B = this.chart1.Series["Series1"].Points.AddXY(450, 352); //B
            this.chart1.Series["Series1"].Points[B].Label = "B";
            int C = this.chart1.Series["Series1"].Points.AddXY(519, 290); //C
            this.chart1.Series["Series1"].Points[C].Label = "C";
            textBox1.Text += "\r\n\r\n\nSHOTEST PATH = " + finalPath + "\r\nMINIMUM PATH WEIGHT = " + minDist;
            textBox1.Text += "DONE";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            //textBox1.Text = "A= (8, 377)\r\nB= (450,352)\r\nC= (519,290)\r\nD= (398,604)\r\nE= (417,496)\r\nF= (57,607)\r\nG= (119,4)\r\nH= (166,663)\r\nI= (280,622)\r\nJ= (531,571)";
            if (clicked1)
            {
                textBox1.Clear();
                
                orderString = "ABCDEFGHIJ";
                finalPath = "";
                shortestDistance = 0;
                minDist = 9999.99;
                Temp = 10000000;
                sw.Start();
                Annealing(keyValue2);
                sw.Stop();
                textBox1.Text += "\r\n\r\n\nSHOTEST PATH = " + finalPath + "\r\nMINIMUM PATH WEIGHT = " + minDist + "\r\nElapsed time = " + sw.Elapsed;
                plotGraph();
                return;
            }
            textBox1.Clear();
            
            sw.Start();
            textBox1.Text = "Calculating";
            textBox1.Refresh();
            Annealing(keyValue2);
            sw.Stop();
            //Console.WriteLine("Shortes Path = " + finalPath + "\tMin Dist = " + minDist);



            int g = this.chart1.Series["Series1"].Points.AddXY(119, 4); //G
            this.chart1.Series["Series1"].Points[g].Label = "G";
            int a = this.chart1.Series["Series1"].Points.AddXY(8, 377); //A
            this.chart1.Series["Series1"].Points[a].Label = "A";
            int f = this.chart1.Series["Series1"].Points.AddXY(57, 607); //F
            this.chart1.Series["Series1"].Points[f].Label = "F";
            int H = this.chart1.Series["Series1"].Points.AddXY(166, 663); //H
            this.chart1.Series["Series1"].Points[H].Label = "H";
            int I = this.chart1.Series["Series1"].Points.AddXY(280, 622); //I
            this.chart1.Series["Series1"].Points[I].Label = "I";
            int D = this.chart1.Series["Series1"].Points.AddXY(398, 604); //D
            this.chart1.Series["Series1"].Points[D].Label = "D";
            int J = this.chart1.Series["Series1"].Points.AddXY(531, 571); //J
            this.chart1.Series["Series1"].Points[J].Label = "J";
            int E =this.chart1.Series["Series1"].Points.AddXY(417, 496); //E
            this.chart1.Series["Series1"].Points[E].Label = "E";
            int B = this.chart1.Series["Series1"].Points.AddXY(450, 352); //B
            this.chart1.Series["Series1"].Points[B].Label = "B";
            int C =this.chart1.Series["Series1"].Points.AddXY(519, 290); //C
            this.chart1.Series["Series1"].Points[C].Label = "C";
            textBox1.Text += "\r\n\r\n\nSHOTEST PATH = " + finalPath + "\r\nMINIMUM PATH WEIGHT = " + minDist + "\r\nElapsed time = " + sw.Elapsed;
            textBox1.Text += "\r\n\nDONE";
            textBox1.Text += "\r\nclick again to solve, click only if optimal path of 1501 was not found!\r\n\n";
            clicked1 = true;

        }

        private double getDistance(int x1, int y1, int x2, int y2)
        {
            double distance = Math.Sqrt((Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)));
            return distance;
        }


        /**Function returns the sum of the distances between points
         * should be used to calculate the shortest path
         * @params arr, a ArrayList containing the points, should be every permutation of the string.
         * 
         */
        public double SumOfDistance(ArrayList arr, string str)
        {
            int[] tempArray = new int[20]; //FUCKING HAVE TO CAST THE OBJECT BACK TO AN INT         
            double sumOfDistance = 0;
            double distance = 0;
            int aa = 0;
            foreach (object item in arr)
            {
                //Console.WriteLine("item: " + item + " count = " + aa);
                tempArray[aa] = (int)item; //cast item in arrayList to int
                aa++;
            }

            //For loops to iterate over the new Array of points. 
            for (int i = 0; i < 18; i += 2) //start at 2 and increment by 2 in order to get new points.
            {
                //hacky way to get out of the index out of bound             
                if (i >= 18)
                {
                    int x22 = tempArray[i - 2];
                    int x11 = tempArray[i];
                    int y22 = tempArray[i - 1];
                    int y11 = tempArray[i + 1];
                    distance = getDistance(x11, y11, x22, y22); //get the distance from the first point from the rest of the points 
                                                                //distanceArray[i] = distance;
                    sumOfDistance += distance;
                    break;
                }

                int x2 = tempArray[i + 2];
                int x1 = tempArray[i];
                int y2 = tempArray[i + 3];
                int y1 = tempArray[i + 1];
                //Below distance calculation will be terribly SLOW 
                distance = getDistance(x1, y1, x2, y2); //get the distance from the first point from the rest of the points 
                //distanceArray[i] = distance;
                sumOfDistance += distance;
            }
            if (sumOfDistance <= minDist)
            {
                minDist = sumOfDistance;
                finalPath = str;
            }

            return sumOfDistance;
        }
        /**
         * Permutations Function
         * The string is used to access the points in the dictionary
         * @param str string to calculate the permutations
         * @param start starting index 
         * @param end end index
         * Recommend referring to the dictionary initialized above. 
         * 
         * New string acts as the index for plotting different permutations of the list coordinates.
         */

        //Start Point is hard CODED
        public string Shuffle(string str)
        {
            //Console.WriteLine("shuffle string: " + str);
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            var temp2 = array[6]; //HARD CODE STARTING INDEX.
            array[6] = array[0]; //SET 1 START IS ALWAYS G!
            array[0] = temp2;
            //Console.WriteLine("Array 0: " + array[0]);
            //Console.WriteLine("Array 1: " + array[1]);
            while (n > 2)
            {
                n--;
                int k = rng.Next(n + 1);
                if (k == 0)
                    k++;
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            //Console.WriteLine("After Swap Array 0: " + array[0]);
            //Console.WriteLine("Array 1: " + array[1]);
            return new string(array);
        }
        /// <summary>
        /// Get the next random arrangements of cities
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private char[] GetNextArrangement(string order)
        {
            char[] newOrder = order.ToCharArray();

            //we will only rearrange two cities by random
            //starting point should be always zero - so zero should not be include
            int firstRandomCityIndex = random.Next(1, newOrder.Length);
            int secondRandomCityIndex = random.Next(1, newOrder.Length);

            char dummy = newOrder[firstRandomCityIndex];
            newOrder[firstRandomCityIndex] = newOrder[secondRandomCityIndex];
            newOrder[secondRandomCityIndex] = dummy;

            return newOrder;
        }
        public void Annealing(Dictionary<char, int[]> dict)
        {
            //Create the initial list of cities by shuffling the input list (ie: make the order of visit random).
            string str1 = Shuffle(orderString);
            char[] current = new char[10];
            int iteration = -1;
            double distance = 0.0;
            double cutOff = 2500;
            int cutOffCount = 0;
            int mutations = 0;

            while (Temp > endTemp)
            {
                var arlist = new ArrayList();
                var arlist2 = new ArrayList();
                char[] str2 = GetNextArrangement(str1.ToString());
                mutations++; //increment for each permutation. 
                for (int i = 0; i < str1.Length; i++)
                {
                    //Console.WriteLine("str1[{0}] = {1}", i, str1[i]);
                    arlist.AddRange(dict[str1[i]]); //add the value of the Dictionary, Value = point coord to the new list.
                }
                for (int i = 0; i < str1.Length; i++)
                {
                    arlist2.AddRange(dict[str2[i]]); //add the value of the Dictionary, Value = point coord to the new list.
                }
                distance = SumOfDistance(arlist, str1.ToString()); //call to find the distance and pass the string. Returns the sum of distance/path.
                                                                   //double deltaDistance = SumOfDistance(arlist2, str2);
      
                double deltaDistance = SumOfDistance(arlist2, new string(str2));
                if (distance > cutOff)
                {
                    cutOffCount++;
                }
                if ((distance > 0 && Math.Exp(-deltaDistance / Temp) > random.NextDouble()))
                {
                    //Console.WriteLine("if string1 = {0} current = {1}", str1, current[0]);
                    for (int i = 0; i < 10; i++)
                    {
                        current[i] = str2[i];
                    }
                    //Console.WriteLine("if 2string1 = {0} current = {1}", str1, current[0]);
                    distance = deltaDistance; //+ distance;
                    str1 = new string(current);
                }

                //cool down the temperature
                if (mutations > 90 && cutOffCount > 200)
                {
                    Temp *= coolingRate;
                    mutations = 0;
                    cutOffCount = 0;
                    if (cutOff > 1500)
                        cutOff *= 0.999;
                    //Console.WriteLine("cutoff = " + cutOff);
                }
                iteration++;
            }
            shortestDistance = minDist;
            textBox1.Text += "Shortest Distance = " + shortestDistance + " Path = " + finalPath + " iteration = " + iteration + " Temp = " + Temp;
        }
        /** 
        * Swap Characters at position 
        * @param a string value 
        * @param i position 1 
        * @param j position 2 
        * @return swapped string 
        
        public static String swap(String a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
        */
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
