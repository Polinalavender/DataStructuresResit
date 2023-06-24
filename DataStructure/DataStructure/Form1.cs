using System.Collections.Generic;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace DataStructure
{
    public partial class Form1 : Form
    {

        private LinkedList<string> linkedList;
        private Tree<string> tree;

        public Form1()
        {
            InitializeComponent();
            linkedList = new LinkedList<string>();
            tree = new Tree<string>();

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text;
            if (linkedListButton.Checked)
            {
                linkedList.AddLast(input);
            }
            else if (treeButton.Checked)
            {
                tree.AddLast(input);
            }
            else
            {
                MessageBox.Show("Select an option!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.Text = string.Empty;

            }
            inputBox.Text = string.Empty;
        }

        private void startBox_Click(object sender, EventArgs e)
        {
            if (linkedListButton.Checked)
            {
                string[] values = linkedList.ToArray();
                richTextBox1.Text = string.Join(Environment.NewLine, values);
            }
            else if (treeButton.Checked)
            {
                string[] values = tree.ToArray();
                richTextBox1.Text = string.Join(Environment.NewLine, values);
            }
            else
            {
                MessageBox.Show("Select an option!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.Text = string.Empty;
            }
        }

        private void goBinaryButton_Click(object sender, EventArgs e)
        {
            string target = binaryInputBox.Text;

            if (!string.IsNullOrEmpty(target))
            {
                int result = linkedList.BinarySearch(target);
                int TreeResult = tree.BinarySearch(target);

                if (result >= 0)
                {
                    string[] values = linkedList.ToArray();
                    string foundItem = values[result];
                    richTextBox1.Text = $"{foundItem}";
                }
                else if (TreeResult >= 0)
                {
                    string[] TreeValues = tree.ToArray();
                    string foundTreeItem = TreeValues[result];
                    richTextBox1.Text = $"{foundTreeItem}";
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
                int TreeResult = tree.LinearSearch(target);

                if (result >= 0)
                {
                    string[] values = linkedList.ToArray();
                    string foundItem = values[result];
                    richTextBox1.Text = $"{foundItem}";
                }
                else if (TreeResult >= 0)
                {
                    string[] TreeValue = tree.ToArray();
                    string foundTreeItem = TreeValue[result];
                    richTextBox1.Text = $"{foundTreeItem}";
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
            if (bucketSortButton.Checked && linkedListButton.Checked)
            {
                linkedList.BucketSort();
                DisplayResults();
            }
            else if (bucketSortButton.Checked && treeButton.Checked)
            {
                tree.BucketSort();
                DisplayResults();
            }
            else
            {
                MessageBox.Show("Select a Data Structure and an algorithm!")
            }
        }
        private void DisplayResults()
        {
            richTextBox1.Clear();

            string[] sortedArray = linkedList.ToArray();
            string[] sortedTreeArray = tree.ToArray();
            foreach (string value in sortedArray)
            {
                richTextBox1.AppendText(value + Environment.NewLine);
            }
            foreach (string value in sortedTreeArray)
            {
                richTextBox1.AppendText(value + Environment.NewLine);
            }
        }

        private void bucketSortButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bucketSortButton.Checked)
            {
                linkedList.BucketSort();
                DisplayResults();
            }
            else if (bucketSortButton.Checked && treeButton.Checked)
            {
                tree.BucketsSort();
                DisplayResults();
            }
        }

        private void AscOrder_Click(object sender, EventArgs e)
        {
            if (bubbleSortButton.Checked && linkedListButton.Checked)
            {
                linkedList.BubbleSort();
                Updating(linkedList.ToArray());
            }
            else if (bubbleSortButton.Checked && treeButton.Checked)
            {
                tree.BubbleSort();
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}