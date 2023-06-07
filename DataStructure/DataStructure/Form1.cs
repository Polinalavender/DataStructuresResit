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
    }
}