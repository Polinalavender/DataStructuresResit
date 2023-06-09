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
            treeButton = new RadioButton();
            linkedListButton = new RadioButton();
            listButton = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            binaryInputBox = new TextBox();
            linearInputBox = new TextBox();
            goBinaryButton = new Button();
            linearGoButton = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            timeExecution = new Label();
            AscOrder = new Button();
            startBox = new Button();
            BucketSort = new CheckBox();
            BubbleSort = new CheckBox();
            SortButton = new Button();
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
            // treeButton
            // 
            treeButton.AutoSize = true;
            treeButton.Location = new Point(22, 198);
            treeButton.Name = "treeButton";
            treeButton.Size = new Size(58, 24);
            treeButton.TabIndex = 7;
            treeButton.TabStop = true;
            treeButton.Text = "Tree";
            treeButton.UseVisualStyleBackColor = true;
            // 
            // linkedListButton
            // 
            linkedListButton.AutoSize = true;
            linkedListButton.Location = new Point(129, 198);
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
            listButton.Location = new Point(283, 198);
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
            // linearGoButton
            // 
            linearGoButton.Location = new Point(552, 381);
            linearGoButton.Name = "linearGoButton";
            linearGoButton.Size = new Size(41, 29);
            linearGoButton.TabIndex = 17;
            linearGoButton.Text = "go!";
            linearGoButton.UseVisualStyleBackColor = true;
            linearGoButton.Click += linearGoButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.DarkOrchid;
            label6.Location = new Point(418, 236);
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
            // timeExecution
            // 
            timeExecution.AutoSize = true;
            timeExecution.Location = new Point(688, 69);
            timeExecution.Name = "timeExecution";
            timeExecution.Size = new Size(0, 20);
            timeExecution.TabIndex = 22;
            // 
            // AscOrder
            // 
            AscOrder.Location = new Point(70, 412);
            AscOrder.Name = "AscOrder";
            AscOrder.Size = new Size(100, 29);
            AscOrder.TabIndex = 25;
            AscOrder.Text = "Asc order";
            AscOrder.UseVisualStyleBackColor = true;
            AscOrder.Click += AscOrder_Click;
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
            // BucketSort
            // 
            BucketSort.AutoSize = true;
            BucketSort.Location = new Point(421, 120);
            BucketSort.Name = "BucketSort";
            BucketSort.Size = new Size(106, 24);
            BucketSort.TabIndex = 27;
            BucketSort.Text = "Bucket Sort";
            BucketSort.UseVisualStyleBackColor = true;
            // 
            // BubbleSort
            // 
            BubbleSort.AutoSize = true;
            BubbleSort.Location = new Point(421, 155);
            BubbleSort.Name = "BubbleSort";
            BubbleSort.Size = new Size(109, 24);
            BubbleSort.TabIndex = 28;
            BubbleSort.Text = "Bubble Sort";
            BubbleSort.UseVisualStyleBackColor = true;
            // 
            // SortButton
            // 
            SortButton.Location = new Point(421, 193);
            SortButton.Name = "SortButton";
            SortButton.Size = new Size(122, 29);
            SortButton.TabIndex = 29;
            SortButton.Text = "Press to sort";
            SortButton.UseVisualStyleBackColor = true;
            SortButton.Click += SortButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 453);
            Controls.Add(SortButton);
            Controls.Add(BubbleSort);
            Controls.Add(BucketSort);
            Controls.Add(startBox);
            Controls.Add(AscOrder);
            Controls.Add(timeExecution);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(linearGoButton);
            Controls.Add(goBinaryButton);
            Controls.Add(linearInputBox);
            Controls.Add(binaryInputBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(listButton);
            Controls.Add(linkedListButton);
            Controls.Add(treeButton);
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
        private RadioButton treeButton;
        private RadioButton linkedListButton;
        private RadioButton listButton;
        private Label label4;
        private Label label5;
        private TextBox binaryInputBox;
        private TextBox linearInputBox;
        private Button goBinaryButton;
        private Button linearGoButton;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label timeExecution;
        private Button AscOrder;
        private Button startBox;
        private CheckBox BucketSort;
        private CheckBox BubbleSort;
        private Button SortButton;
    }
}