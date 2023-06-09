using System.Collections.Generic;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace DataStructure
{
    public partial class Form1 : Form
    {

        private LinkedList<string> linkedList;
        private List<string> list;
        private Tree<string> tree;
        private object?[] values;

        public Form1()
        {
            InitializeComponent();
            linkedList = new LinkedList<string>();
            list = new List<string>();
            tree = new Tree<string>();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text;
            if (linkedListButton.Checked)
            {
                linkedList.AddLast(input);
            }
            else if (listButton.Checked)
            {
                list.Add(input);
            }
            else if (treeButton.Checked)
            {
                tree.Insert(input);
            }
            else
            {
                MessageBox.Show("Please select a data structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inputBox.Text = string.Empty;
        }

        private void startBox_Click(object sender, EventArgs e)
        {
            if (linkedListButton.Checked)
            {
                string input = inputBox.Text;
                linkedList.AddLast(input);
                inputBox.Text = string.Empty;

                string[] values = linkedList.ToArray();
                richTextBox1.Text = string.Join(Environment.NewLine, values);
            }
            else if (treeButton.Checked)
            {
                richTextBox1.Text = string.Empty;

                string[] values = tree.ToArray();

                foreach (string item in values)
                {
                    if (string.IsNullOrEmpty(item)) 
                        continue; // Skip the empty string

                    richTextBox1.AppendText(item);
                    richTextBox1.AppendText(Environment.NewLine);
                }
            }
            else if (listButton.Checked)
            {
                string[] values = list.ToArray();
                richTextBox1.Text = string.Join(Environment.NewLine, values);
            }
            else
            {
                MessageBox.Show("Please select a data structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void goBinaryButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string target = binaryInputBox.Text;

            if (!string.IsNullOrEmpty(target))
            {
                int result;
                if (linkedListButton.Checked)
                    result = linkedList.BinarySearch(target);
                else if (listButton.Checked)
                    result = list.BinarySearch(target);
                else if (treeButton.Checked)
                {
                    string[] treeValues = tree.ToArray();
                    result = Tree<string>.BinarySearch(treeValues, target);
                }
                else
                    result = -1;

                if (result >= 0)
                {
                    string[] values;
                    if (linkedListButton.Checked)
                        values = linkedList.ToArray();
                    else if (listButton.Checked)
                        values = list.ToArray();
                    else if (treeButton.Checked)
                        values = tree.ToArray();
                    else
                        values = new string[0];

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

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";
        }



       private void linearGoButton_Click(object sender, EventArgs e)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    string target = linearInputBox.Text;

    if (!string.IsNullOrEmpty(target))
    {
        int result = -1;

        if (linkedListButton.Checked)
        {
            result = linkedList.LinearSearch(target);
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
        else if (treeButton.Checked)
        {
            result = tree.LinearSearch(target);
            if (result >= 0)
            {
                string[] values = tree.ToArray();
                string foundItem = values[result];
                richTextBox1.Text = $"{foundItem}";
            }
            else
            {
                richTextBox1.Text = "Not found";
            }
        }
        else if (listButton.Checked)
        {
            result = list.LinearSearch(target);
            if (result >= 0)
            {
                string[] values = list.ToArray();
                string foundItem = values[result];
                richTextBox1.Text = $"{foundItem}";
            }
            else
            {
                richTextBox1.Text = "Not found";
            }
        }

        if (result < 0)
        {
            MessageBox.Show($"{target} not found");
        }
    }
    else
    {
        MessageBox.Show("Please enter a valid search target.");
    }

    stopwatch.Stop();
    TimeSpan elapsedTime = stopwatch.Elapsed;
    timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";

    // Clear the input box after each search
    linearInputBox.Text = string.Empty;
}





        /* private void DisplayResults()
         {
             richTextBox1.Clear();

             string[] sortedArray = linkedList.ToArray();
             foreach (string value in sortedArray)
             {
                 richTextBox1.AppendText(value + Environment.NewLine);
             }
         }*/




        private void AscOrder_Click(object sender, EventArgs e)
        {
            if (!linkedListButton.Checked && !treeButton.Checked && !linkedListButton.Checked && !listButton.Checked)
            {
                MessageBox.Show("Please select a data structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (linkedListButton.Checked)
            {
                linkedList.BubbleSort();
                Updating(linkedList.ToArray());
            }
            else if (treeButton.Checked)
            {
                tree.BubbleSort();
                Updating(tree.ToArray());
            }

            else if (listButton.Checked)
            {
                list.BubbleSort();
                Updating(tree.ToArray());
            }
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

        private void SortButton_Click(object sender, EventArgs e)
        {
            int checkedCount = 0;

            if (linkedListButton.Checked)
            {
                if (BubbleSort.Checked)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    linkedList.BubbleSort();
                    DisplayResults(linkedList);
                    checkedCount++;
                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";
                }
                else if (BucketSort.Checked)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    linkedList.BucketSort();
                    DisplayResults(linkedList);
                    checkedCount++;
                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";
                }
            }
            else if (treeButton.Checked)
            {
                if (BubbleSort.Checked && !BucketSort.Checked)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    tree.BubbleSort();
                    DisplayResults(tree);
                    checkedCount++;
                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";
                }
                else if (BucketSort.Checked && !BubbleSort.Checked)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    tree.BucketSort();
                    DisplayResults(tree);
                    checkedCount++;
                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";
                }
            }
            else if (listButton.Checked)
            {
                if (BubbleSort.Checked && !BucketSort.Checked)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    list.BubbleSort();
                    DisplayResults(list);
                    checkedCount++;
                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";
                }
                else if (BucketSort.Checked && !BubbleSort.Checked)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    list.BucketSort();
                    DisplayResults(list);
                    checkedCount++;
                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    timeExecution.Text = $"Execution Time: {elapsedTime.TotalMilliseconds} ms";
                }
            }

            if (checkedCount == 0)
            {
                MessageBox.Show("Please select a sorting algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkedCount > 1)
            {
                MessageBox.Show("Please select only one sorting algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkedCount == 0 && !(linkedListButton.Checked || treeButton.Checked || listButton.Checked))
            {
                MessageBox.Show("Please select a data structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (BucketSort.Checked && BubbleSort.Checked)
            {
                MessageBox.Show("Please select only one sorting algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResults(List<string> list)
        {
            richTextBox1.Clear();

            string[] array = list.ToArray();
            foreach (string item in array)
            {
                richTextBox1.AppendText(item);
                richTextBox1.AppendText(Environment.NewLine);
            }
        }

        private void DisplayResults(Tree<string> tree)
        {
            richTextBox1.Clear();

            string[] array = tree.ToArray();
            foreach (string item in array)
            {
                richTextBox1.AppendText(item);
                richTextBox1.AppendText(Environment.NewLine);
            }
        }

        private void DisplayResults(LinkedList<string> linkedList)
        {
            richTextBox1.Clear();

            string[] array = linkedList.ToArray();
            foreach (string item in array)
            {
                richTextBox1.AppendText(item);
                richTextBox1.AppendText(Environment.NewLine);
            }
        }
    }
}