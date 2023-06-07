using System.Collections.Generic;
using System;
using System.Windows.Forms;


namespace DataStructure
{
    public partial class Form1 : Form
    {

        private LinkedList<string> linkedList;
        public Form1()
        {
            InitializeComponent();
            linkedList = new LinkedList<string>();

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
        }
}