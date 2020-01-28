using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace approject
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

        public List<people> People = new List<people>();
        private void save(object sender, RoutedEventArgs e)
        {
            int sen;
            string func1 = "";
            string func2 = "";

            List<string> str1 = new List<string>();
            int lineCount = text.LineCount;
            string str2 = text.Text;
            string[] str3 = str2.Split(new string[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<str3.Length;i++)
            {
                str1.Add(str3[i]);
            }
            int j = 0;  
            while (!int.TryParse(str1[j] , out sen)) {

                 j++;
                if (j == str1.Count)
                {
                    break;
                }
              }

            for (int i = 0; i < str1.Count; i++)
            {
                if ((str1[i].Contains("=") && str1[i].Contains("+")) || (str1[i].Contains("=") && str1[i].Contains("-")))
                {
                    func1 = str1[i];
                    
                    
                }
                
            }
            for (int i = 0; i < str1.Count; i++)
            {
                if ( (str1[i].Contains("=")&& str1[i].Contains("+")) || (str1[i].Contains("=") && str1[i].Contains("-")))
                {
                    if (str1[i] == func1)
                    {
                       continue;
                    }
                    else
                    {
                        func2 = str1[i];

                    }
                }
                
                
            }

            people people = new people(str1[0], str1[1], sen, str1[2], func1, func2);
            if (func1 == null || func2 == null)
            {
                people.funcanswer();
            }
            People.Add(people);
           // People.Clear();
            text.Text = String.Empty;
            //text.Text += people.name;
            //text.Text += people.familyname;
            //text.Text += people.age+"\n";
            //text.Text += people.city;
            //text.Text += people.function1 + "\n";
            //text.Text += people.function2;
            //text.Text += people._x+"\n";
            //text.Text += people._y;
            if (People.Count != 0)
            {

                for (int f = 0; f < People.Count; f++)
                {
                    if ( str1[0] == People[f].name && str1[1] == People[f].familyname && sen == People[f].age && str1[2] == People[f].city && func1== People[f].function1 && func2 == People[f].function2)
                    {
                        break;
                    }

                }
            }
            StreamWriter sw = new StreamWriter("people.txt", true);
            sw.WriteLine(people.name+"\n" + people.familyname+"\n" + people.age +"\n" + people.city + "\n" + people.function1 +"\n"+ people.function2);
            sw.Close();

        }

        private void quit(object sender, RoutedEventArgs e)
        {
            
        }


        public List<string> boxes = new List<string>();
        IEnumerable<string> result;

        List<string> final = new List<string>();
        List<string> final2 = new List<string>();
        //List<string> many;
        public List<string> before = new List<string>();
        private void serch(object sender, RoutedEventArgs e)
        {
            resultcheck.Text = "";
            before = new List<string>();
            final = new List<string>();
            final2 = new List<string>();
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes.Count == 0)
                {
                    resultcheck.Text = "";
                    break;
                }
                
                if (boxes[i] == "name")
                {
                    string first = namecheck.Text;
               
                    IEnumerable<string> result = People.Where(p => p.name == first).Select(p => p.name + " " + p.familyname);
                    foreach(string output in result)
                    {
                        before.Add(output);
                    }
                }
                if (boxes[i] == "familyname")
                {
                    string second = familycheck.Text;
                    IEnumerable<string>  result = People.Where(p => p.familyname == second).Select(p => p.name + " " + p.familyname);
                    foreach (string output in result)
                    {
                        before.Add(output);
                    }
                }
                if (boxes[i] == "city")
                {
                    string third = citycheck.Text;
                    IEnumerable<string> result = People.Where(p => p.city == third).Select(p => p.name + " " + p.familyname);
                    foreach (string output in result)
                    {
                        before.Add(output);
                    }
                }
                if (boxes[i] == "agemore")
                {
                    int four = int.Parse(agemorecheck.Text);
                    IEnumerable<string> result = People.Where(p => p.age >= four).Select(p => p.name + " " + p.familyname);
                    foreach (string output in result)
                    {
                        before.Add(output);
                    }
                }
                if (boxes[i] == "ageless")
                {
                    int five = int.Parse(agelesscheck.Text);
                    IEnumerable<string> result = People.Where(p => p.age <= five).Select(p => p.name + " " + p.familyname); 
                    foreach (string output in result)
                    {
                        before.Add(output);
                    }
                }
                if (boxes[i] == "function")
                {
                    string six = functioncheck.Text;
                    IEnumerable<string> result = People.Where(p => p.function1 == six || p.function2 == six).Select(p => p.name + " " + p.familyname);
                    foreach (string output in result)
                    {
                        before.Add(output);
                    }
                }
                if (boxes[i] == "answers")
                {
                    int seven = int.Parse(answerscheck.Text);
                    IEnumerable<string> result = People.Where(p => p._x == seven || p._y == seven).Select(p => p.name + " " + p.familyname);
                    foreach (string output in result)
                    {
                        before.Add(output);
                    }

                }
            }
                
                if (boxes.Count == 1)
                {
                resultcheck.Text = "";
                foreach (string value in before)
                {
                    resultcheck.Text += value;
                    resultcheck.Text += Environment.NewLine;
                }

                }
                else if(boxes.Count>1)
                {
                for(int a=0; a<before.Count; a++)
                {
                    for(int b=0; b<before.Count; b++)
                    {
                        if (a == b)
                        {
                            continue;
                        }
                        if (before[a] == before[b])
                        {
                            final.Add(before[b]);
                        }
               
                    }
                }

                foreach(string o in final)
                {
                    if (final2.Contains(o))
                    {
                        continue;
                    }
                    final2.Add(o);

                }
                resultcheck.Text = "";
                foreach (string value in final2)
                {
                    resultcheck.Text += value;
                    resultcheck.Text += Environment.NewLine;
                }


            }

               
            boxes = new List<string>();
        }

  

       
        private void checkbox(object sender, RoutedEventArgs e)
        {
            boxes.Add(((CheckBox)sender).Name);
          
        }

       
    }
}
