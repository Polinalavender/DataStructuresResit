using System.Collections.Generic;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace DataStructure
{
    public partial class Form1 : Form
    {

        private LinkedList<string> linkedList;
        private List<string> list;
        public Form1()
        {
            InitializeComponent();
            linkedList = new LinkedList<string>();
            list = new List<string>();

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text;
            linkedList.AddLast(input);
            inputBox.Text = string.Empty;
        }


        private void startBox_Click(object sender, EventArgs e)
        {
            if (linkedListButton.Checked)
            {
                string[] values = linkedList.ToArray();
                richTextBox1.Text = string.Join(Environment.NewLine, values);
            }
            else if (listButton.Checked) 
            {
                string[] values = List.ToArray();
                richTextBox1.Text = string.Join(Environment.NewLine, values);
            }
            else
            {
                richTextBox1.Text = string.Empty;
            }
        }

        private void goBinaryButton_Click(object sender, EventArgs e)
        {
            string target = binaryInputBox.Text;

            if (!string.IsNullOrEmpty(target))
            {
                int result = linkedList.BinarySearch(target);

                if (result >= 0)
                {
                    string[] values = linkedList.ToArray();
                    string foundItem = values[result];
                    richTextBox1.Text = $"{foundItem}";
                }
                else
                {
                    richTextBox1.Text = "Not found";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid input");
            }
        }

        private void lenearGoButton_Click(object sender, EventArgs e)
        {
            string target = linearInputBox.Text;

            if (!string.IsNullOrEmpty(target))
            {
                int result = linkedList.LinearSearch(target);

                if (result >= 0)
                {
                    string[] values = linkedList.ToArray();
                    string foundItem = values[result];
                    richTextBox1.Text = $"{foundItem}";
                }
                else
                {
                    richTextBox1.Text = "Not found";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid search target.");
            }
        }

        private void bucketSortButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bucketSortButton.Checked)
            {

                linkedList.BucketSort();
                DisplayResults();
            }
        }
        private void DisplayResults()
        {
            richTextBox1.Clear();

            if (linkedListButton.Checked)
            {
                string[] sortedArray = linkedList.ToArray();
                foreach (string value in sortedArray)
                {
                    richTextBox1.AppendText(value + Environment.NewLine);
                }
            } else if (listButton.Checked)
            {
                string[] arrayList = List.ToArray();
                foreach (string value in arrayList)
                {
                    richTextBox1.AppendText(value + Environment.NewLine);
                }
            }
        }

        private void bubbleSortButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bubbleSortButton.Checked)
            {

                linkedList.BucketSort();
                DisplayResults();
            }
        }

        private void AscOrder_Click(object sender, EventArgs e)
        {
            linkedList.BubbleSort();

            Updating(linkedList.ToArray());
        }

        private void Updating<T>(T[] array)
        {
            richTextBox1.Clear();
            foreach (var item in array)
            {
                richTextBox1.AppendText(item.ToString());
                richTextBox1.AppendText(Environment.NewLine);
            }
        }

         private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}