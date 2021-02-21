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
    public partial class Form1 : Form
    {
        //GLOBALS
        //Initialize the Coordinates as global for easier access
        public string orderString = "ABCDEFGHIJ";
        public string finalPath = "";
        private double shortestDistance = 0;
        public double minDist = 9999.99;
        public double Temp = 1000000000;
        public double endTemp = 0.00001;
        private double coolingRate = 0.99;
        private Random random = new Random();
        //SET 1
        //Dictionary of Points with Key of point name. 
        Dictionary<char, int[]> keyValue = new Dictionary<char, int[]>()
        {
            {'A', new int[] { 834, 707 } },
            {'B', new int[] { 843, 626 } },
            {'C', new int[] { 140, 733 } },
            {'D', new int[] { 109, 723 } },
            {'E', new int[] { 600, 747 } },
            {'F', new int[] { 341, 94 } },
            {'G', new int[] { 657, 197 } },
            {'H', new int[] { 842, 123 } },
            {'I', new int[] { 531, 194 } },
            {'J', new int[] { 286, 336 } },
        };
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
        //SET 3
        Dictionary<char, int[]> keyValue3 = new Dictionary<char, int[]>()
        {
            {'A', new int[] { 518, 995 } },
            {'B', new int[] { 590, 935 } },
            {'C', new int[] { 600, 985 } },
            {'D', new int[] { 151, 225 } },
            {'E', new int[] { 168, 657 } },
            {'F', new int[] { 202, 454 } },
            {'G', new int[] { 310, 717 } },
            {'H', new int[] { 425, 802 } },
            {'I', new int[] { 480, 940 } },
            {'J', new int[] { 300, 1035 } },
        };

 


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Points in Set 1:\t     A= (834, 707)\t\tB= (843,626)\t\tC= (140,733)\t\tD= (109,723)\t\tE= (600,747)\t\tF= (341,94)\t\tG= (657,197)\t\tH= (842,123)\t\tI= (531,194)\t\tJ= (286,336)";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
            //textBox1.Text = "A= (8, 377)\t\tB= (450,352)\t\tC= (519,290)\t\tD= (398,604)\t\tE= (417,496)\t\tF= (57,607)\t\tG= (119,4)\t\tH= (166,663)\t\tI= (280,622)\t\tJ= (531,571)";
            //int n = orderString.Length;
            //permute(orderString, 0, n - 1, keyValue2);
            //Console.WriteLine("Shortes Path = " + finalPath + "\tMin Dist = " + minDist);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
            textBox1.Text = "A= (518, 995)\t\tB= (590,935)\t\tC= (600,985)\t\tD= (151,225)\t\tE= (168,657)\t\tF= (202,454)\t\tG= (310,717)\t\tH= (425,802)\t\tI= (480,940)\t\tJ= (300,1035)";
    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        //uses the distance formula to weight/distance between two points.
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
            for (int i = 0; i < 18; i +=2) //start at 2 and increment by 2 in order to get new points.
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

                int x2 = tempArray[i+2];
                int x1 = tempArray[i];
                int y2 = tempArray[i + 3];
                int y1 = tempArray[i+1];
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
        //SHUFFLE STRING 
        public string Shuffle(string str)
        {
            //Console.WriteLine("shuffle string: " + str);
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            var temp = array[7]; //HARD CODE STARTING INDEX.
            array[7] = array[0]; //SET 1 START IS ALWAYS H!
            array[0] = temp;
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
            char[] current = new char [10];
            int iteration = -1;
            double distance = 0.0;
            double cutOff = 4000;
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
                /*
                 * At every iteration, two cities are swapped in the list.The cost value is the distance traveled by the salesman for the whole tour.
                 */               
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
                    if (cutOff > 2300)
                        cutOff *= 0.999;
                    //Console.WriteLine("cutoff = " + cutOff);
                }
                iteration++;
            }
            shortestDistance = minDist;        
            textBox1.Text += "Shortest Distance = " + shortestDistance + " Path = " + finalPath + " iteration = " + iteration + " Temp = " + Temp;
    }
        //Print the permutation of the string.



        /**
         * Permutations Function
         * The string is used to access the points in the dictionary
         * @param str string to calculate the permutations
         * @param start starting index 
         * @param end end index
         * Recommend referring to the dictionary initialized above. 
         
        public void permute(String str,int start, int end, Dictionary<char, int[]> dict)
        {
            if (start == end)
            {
                var arlist = new ArrayList();
                //Console.WriteLine(str); Print the permutation of the string.  
                for (int i = 0; i < str.Length; i++)
                {
                    //Console.WriteLine(keyValue[str[i].ToString()]);
                    arlist.AddRange(dict[str[i]]); //add the value of the Dictionary, Value = point coord to the new list.
                }
                SumOfDistance(arlist, str); //call to find the distance and pass the string.
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    str = swap(str, start, i);
                    permute(str, start + 1, end, dict);
                    str = swap(str, start, i);
                }
            }
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
        //wait some time asynch method. Borrowed from stack overflow.
        public async void WaitSomeTime()
        {
            await Task.Delay(800);
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void working_Button()
        {
            button4.Text = "Finished Calculating";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.Cursor = Cursors.No;

            button4.Text = "Working";
            button4.Refresh();
            Annealing(keyValue);
            //textBox1.Clear();
            sw.Stop();
            textBox1.Text += "\r\n\r\n Annealing Run Time =  " + sw.Elapsed;
            textBox1.Text += "\r\n\nBrute Force Runtime ~= 17 seconds"; 
            /*
            sw.Start();
            int n = orderString.Length;
            permute(orderString, 0, n - 1, keyValue);
            sw.Stop();
            textBox1.Text += "\r\n Brute Force Runtime = " + sw.Elapsed;
            */
            int H = this.chart1.Series["Series1"].Points.AddXY(842, 123); //H
            this.chart1.Series["Series1"].Points[H].Label = "H";

            int G = this.chart1.Series["Series1"].Points.AddXY(657, 197); //G
            this.chart1.Series["Series1"].Points[G].Label = "G";

            int I = this.chart1.Series["Series1"].Points.AddXY(531, 194); //I
            this.chart1.Series["Series1"].Points[I].Label = "I";

            int F = this.chart1.Series["Series1"].Points.AddXY(341, 94); //F
            this.chart1.Series["Series1"].Points[F].Label = "F";

            int J = this.chart1.Series["Series1"].Points.AddXY(286, 336); //J
            this.chart1.Series["Series1"].Points[J].Label = "J";

            int D = this.chart1.Series["Series1"].Points.AddXY(109, 723); //D
            this.chart1.Series["Series1"].Points[D].Label = "D";

            int C = this.chart1.Series["Series1"].Points.AddXY(140, 733); //C
            this.chart1.Series["Series1"].Points[C].Label = "C";

            int E = this.chart1.Series["Series1"].Points.AddXY(600, 747); //E
            this.chart1.Series["Series1"].Points[E].Label = "E";

            int A = this.chart1.Series["Series1"].Points.AddXY(834, 707); //A
            this.chart1.Series["Series1"].Points[A].Label = "A";

            int B = this.chart1.Series["Series1"].Points.AddXY(843, 626); //B
            this.chart1.Series["Series1"].Points[B].Label = "B";
            this.Cursor = Cursors.Default;
            working_Button();
        }
    }
}
