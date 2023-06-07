﻿namespace DataStructure
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            inputBox = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            HashsetButton = new RadioButton();
            linkedListButton = new RadioButton();
            listButton = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            bucketSortButton = new RadioButton();
            radioButton5 = new RadioButton();
            binaryInputBox = new TextBox();
            linearInputBox = new TextBox();
            goBinaryButton = new Button();
            lenearGoButton = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button4 = new Button();
            button6 = new Button();
            startBox = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkOrchid;
            label1.Location = new Point(312, 25);
            label1.Name = "label1";
            label1.Size = new Size(185, 31);
            label1.TabIndex = 0;
            label1.Text = "Data Structures ";
            // 
            // inputBox
            // 
            inputBox.Location = new Point(12, 118);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(259, 27);
            inputBox.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(70, 256);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(307, 139);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.ForeColor = Color.DarkViolet;
            button1.Location = new Point(286, 118);
            button1.Name = "button1";
            button1.Size = new Size(91, 27);
            button1.TabIndex = 4;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += addButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DarkOrchid;
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 5;
            label2.Text = "Enter the input:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.DarkOrchid;
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(156, 20);
            label3.TabIndex = 6;
            label3.Text = "Choose data structure:";
            // 
            // HashsetButton
            // 
            HashsetButton.AutoSize = true;
            HashsetButton.Location = new Point(12, 198);
            HashsetButton.Name = "HashsetButton";
            HashsetButton.Size = new Size(82, 24);
            HashsetButton.TabIndex = 7;
            HashsetButton.TabStop = true;
            HashsetButton.Text = "Hashset";
            HashsetButton.UseVisualStyleBackColor = true;
            // 
            // linkedListButton
            // 
            linkedListButton.AutoSize = true;
            linkedListButton.Location = new Point(135, 198);
            linkedListButton.Name = "linkedListButton";
            linkedListButton.Size = new Size(99, 24);
            linkedListButton.TabIndex = 8;
            linkedListButton.TabStop = true;
            linkedListButton.Text = "Linked List";
            linkedListButton.UseVisualStyleBackColor = true;
            // 
            // listButton
            // 
            listButton.AutoSize = true;
            listButton.Location = new Point(260, 198);
            listButton.Name = "listButton";
            listButton.Size = new Size(52, 24);
            listButton.TabIndex = 9;
            listButton.TabStop = true;
            listButton.Text = "List";
            listButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.DarkOrchid;
            label4.Location = new Point(12, 240);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 10;
            label4.Text = "Result:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DarkOrchid;
            label5.Location = new Point(421, 83);
            label5.Name = "label5";
            label5.Size = new Size(122, 20);
            label5.TabIndex = 11;
            label5.Text = "Sort algorithms:";
            // 
            // bucketSortButton
            // 
            bucketSortButton.AutoSize = true;
            bucketSortButton.Location = new Point(421, 121);
            bucketSortButton.Name = "bucketSortButton";
            bucketSortButton.Size = new Size(105, 24);
            bucketSortButton.TabIndex = 12;
            bucketSortButton.TabStop = true;
            bucketSortButton.Text = "Bucket Sort";
            bucketSortButton.UseVisualStyleBackColor = true;
            bucketSortButton.CheckedChanged += bucketSortButton_CheckedChanged;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(421, 159);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(108, 24);
            radioButton5.TabIndex = 13;
            radioButton5.TabStop = true;
            radioButton5.Text = "Bubble Sort";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // binaryInputBox
            // 
            binaryInputBox.Location = new Point(421, 293);
            binaryInputBox.Name = "binaryInputBox";
            binaryInputBox.Size = new Size(125, 27);
            binaryInputBox.TabIndex = 14;
            // 
            // linearInputBox
            // 
            linearInputBox.Location = new Point(421, 383);
            linearInputBox.Name = "linearInputBox";
            linearInputBox.Size = new Size(125, 27);
            linearInputBox.TabIndex = 15;
            // 
            // goBinaryButton
            // 
            goBinaryButton.Location = new Point(552, 291);
            goBinaryButton.Name = "goBinaryButton";
            goBinaryButton.Size = new Size(41, 29);
            goBinaryButton.TabIndex = 16;
            goBinaryButton.Text = "go!";
            goBinaryButton.UseVisualStyleBackColor = true;
            goBinaryButton.Click += goBinaryButton_Click;
            // 
            // lenearGoButton
            // 
            lenearGoButton.Location = new Point(552, 381);
            lenearGoButton.Name = "lenearGoButton";
            lenearGoButton.Size = new Size(41, 29);
            lenearGoButton.TabIndex = 17;
            lenearGoButton.Text = "go!";
            lenearGoButton.UseVisualStyleBackColor = true;
            lenearGoButton.Click += lenearGoButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.DarkOrchid;
            label6.Location = new Point(421, 217);
            label6.Name = "label6";
            label6.Size = new Size(139, 20);
            label6.TabIndex = 18;
            label6.Text = "Search algorithms:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(421, 256);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 19;
            label7.Text = "Binary search:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(421, 343);
            label8.Name = "label8";
            label8.Size = new Size(98, 20);
            label8.TabIndex = 20;
            label8.Text = "Linear search:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.DarkOrchid;
            label9.Location = new Point(657, 34);
            label9.Name = "label9";
            label9.Size = new Size(131, 20);
            label9.TabIndex = 21;
            label9.Text = "Time of execution:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(688, 69);
            label10.Name = "label10";
            label10.Size = new Size(58, 20);
            label10.TabIndex = 22;
            label10.Text = "label10";
            // 
            // button4
            // 
            button4.Location = new Point(118, 409);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 23;
            button4.Text = "Desc order";
            button4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(12, 409);
            button6.Name = "button6";
            button6.Size = new Size(100, 29);
            button6.TabIndex = 25;
            button6.Text = "Asc order";
            button6.UseVisualStyleBackColor = true;
            // 
            // startBox
            // 
            startBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            startBox.ForeColor = Color.DarkOrchid;
            startBox.Location = new Point(283, 409);
            startBox.Name = "startBox";
            startBox.Size = new Size(94, 29);
            startBox.TabIndex = 26;
            startBox.Text = "Start";
            startBox.UseVisualStyleBackColor = true;
            startBox.Click += startBox_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startBox);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(lenearGoButton);
            Controls.Add(goBinaryButton);
            Controls.Add(linearInputBox);
            Controls.Add(binaryInputBox);
            Controls.Add(radioButton5);
            Controls.Add(bucketSortButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(listButton);
            Controls.Add(linkedListButton);
            Controls.Add(HashsetButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(inputBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox inputBox;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private RadioButton HashsetButton;
        private RadioButton linkedListButton;
        private RadioButton listButton;
        private Label label4;
        private Label label5;
        private RadioButton bucketSortButton;
        private RadioButton radioButton5;
        private TextBox binaryInputBox;
        private TextBox linearInputBox;
        private Button goBinaryButton;
        private Button lenearGoButton;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button4;
        private Button button6;
        private Button startBox;
    }
}