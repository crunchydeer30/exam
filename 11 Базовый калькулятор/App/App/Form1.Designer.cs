namespace App
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
            num7 = new Button();
            num8 = new Button();
            num9 = new Button();
            num4 = new Button();
            num5 = new Button();
            num6 = new Button();
            num1 = new Button();
            num2 = new Button();
            num3 = new Button();
            clear = new Button();
            clearAll = new Button();
            equals = new Button();
            num0 = new Button();
            display = new TextBox();
            appName = new Label();
            plus = new Button();
            minus = new Button();
            multiply = new Button();
            divide = new Button();
            point = new Button();
            SuspendLayout();
            // 
            // num7
            // 
            num7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num7.Location = new Point(29, 151);
            num7.Name = "num7";
            num7.Size = new Size(65, 45);
            num7.TabIndex = 0;
            num7.Text = "7";
            num7.UseVisualStyleBackColor = true;
            num7.Click += numBtn_click;
            // 
            // num8
            // 
            num8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num8.Location = new Point(100, 151);
            num8.Name = "num8";
            num8.Size = new Size(65, 45);
            num8.TabIndex = 1;
            num8.Text = "8";
            num8.UseVisualStyleBackColor = true;
            num8.Click += numBtn_click;
            // 
            // num9
            // 
            num9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num9.Location = new Point(171, 151);
            num9.Name = "num9";
            num9.Size = new Size(65, 45);
            num9.TabIndex = 2;
            num9.Text = "9";
            num9.UseVisualStyleBackColor = true;
            num9.Click += numBtn_click;
            // 
            // num4
            // 
            num4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num4.Location = new Point(29, 202);
            num4.Name = "num4";
            num4.Size = new Size(65, 45);
            num4.TabIndex = 3;
            num4.Text = "4";
            num4.UseVisualStyleBackColor = true;
            num4.Click += numBtn_click;
            // 
            // num5
            // 
            num5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num5.Location = new Point(100, 202);
            num5.Name = "num5";
            num5.Size = new Size(65, 45);
            num5.TabIndex = 4;
            num5.Text = "5";
            num5.UseVisualStyleBackColor = true;
            num5.Click += numBtn_click;
            // 
            // num6
            // 
            num6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num6.Location = new Point(171, 202);
            num6.Name = "num6";
            num6.Size = new Size(65, 45);
            num6.TabIndex = 5;
            num6.Text = "6";
            num6.UseVisualStyleBackColor = true;
            num6.Click += numBtn_click;
            // 
            // num1
            // 
            num1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num1.Location = new Point(29, 253);
            num1.Name = "num1";
            num1.Size = new Size(65, 45);
            num1.TabIndex = 6;
            num1.Text = "1";
            num1.UseVisualStyleBackColor = true;
            num1.Click += numBtn_click;
            // 
            // num2
            // 
            num2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num2.Location = new Point(100, 253);
            num2.Name = "num2";
            num2.Size = new Size(65, 45);
            num2.TabIndex = 7;
            num2.Text = "2";
            num2.UseVisualStyleBackColor = true;
            num2.Click += numBtn_click;
            // 
            // num3
            // 
            num3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num3.Location = new Point(171, 253);
            num3.Name = "num3";
            num3.Size = new Size(65, 45);
            num3.TabIndex = 8;
            num3.Text = "3";
            num3.TextImageRelation = TextImageRelation.ImageBeforeText;
            num3.UseVisualStyleBackColor = true;
            num3.Click += numBtn_click;
            // 
            // clear
            // 
            clear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(313, 202);
            clear.Name = "clear";
            clear.Size = new Size(65, 45);
            clear.TabIndex = 10;
            clear.Text = "C";
            clear.UseVisualStyleBackColor = true;
            // 
            // clearAll
            // 
            clearAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearAll.Location = new Point(313, 151);
            clearAll.Name = "clearAll";
            clearAll.Size = new Size(65, 45);
            clearAll.TabIndex = 9;
            clearAll.Text = "CE";
            clearAll.UseVisualStyleBackColor = true;
            clearAll.Click += clearAll_Click;
            // 
            // equals
            // 
            equals.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            equals.Location = new Point(313, 253);
            equals.Name = "equals";
            equals.Size = new Size(65, 96);
            equals.TabIndex = 15;
            equals.Text = "=";
            equals.UseVisualStyleBackColor = true;
            equals.Click += equals_Click;
            // 
            // num0
            // 
            num0.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            num0.Location = new Point(29, 304);
            num0.Name = "num0";
            num0.Size = new Size(136, 45);
            num0.TabIndex = 12;
            num0.Text = "0";
            num0.UseVisualStyleBackColor = true;
            num0.Click += numBtn_click;
            // 
            // display
            // 
            display.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            display.Location = new Point(29, 101);
            display.Name = "display";
            display.Size = new Size(349, 32);
            display.TabIndex = 16;
            display.Text = "0";
            display.TextAlign = HorizontalAlignment.Right;
            // 
            // appName
            // 
            appName.AutoSize = true;
            appName.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            appName.Location = new Point(29, 60);
            appName.Name = "appName";
            appName.Size = new Size(131, 25);
            appName.TabIndex = 17;
            appName.Text = "Калькулятор";
            // 
            // plus
            // 
            plus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            plus.Location = new Point(242, 304);
            plus.Name = "plus";
            plus.Size = new Size(65, 45);
            plus.TabIndex = 21;
            plus.Text = "+";
            plus.UseVisualStyleBackColor = true;
            plus.Click += operationBtn_click;
            // 
            // minus
            // 
            minus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            minus.Location = new Point(242, 253);
            minus.Name = "minus";
            minus.Size = new Size(65, 45);
            minus.TabIndex = 20;
            minus.Text = "-";
            minus.TextImageRelation = TextImageRelation.ImageBeforeText;
            minus.UseVisualStyleBackColor = true;
            minus.Click += operationBtn_click;
            // 
            // multiply
            // 
            multiply.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            multiply.Location = new Point(242, 202);
            multiply.Name = "multiply";
            multiply.Size = new Size(65, 45);
            multiply.TabIndex = 19;
            multiply.Text = "*";
            multiply.UseVisualStyleBackColor = true;
            multiply.Click += operationBtn_click;
            // 
            // divide
            // 
            divide.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            divide.Location = new Point(242, 151);
            divide.Name = "divide";
            divide.Size = new Size(65, 45);
            divide.TabIndex = 18;
            divide.Text = "/";
            divide.UseVisualStyleBackColor = true;
            divide.Click += operationBtn_click;
            // 
            // point
            // 
            point.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            point.Location = new Point(171, 304);
            point.Name = "point";
            point.Size = new Size(65, 45);
            point.TabIndex = 22;
            point.Text = ",";
            point.TextImageRelation = TextImageRelation.ImageBeforeText;
            point.UseVisualStyleBackColor = true;
            point.Click += numBtn_click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 390);
            Controls.Add(point);
            Controls.Add(plus);
            Controls.Add(minus);
            Controls.Add(multiply);
            Controls.Add(divide);
            Controls.Add(appName);
            Controls.Add(display);
            Controls.Add(equals);
            Controls.Add(num0);
            Controls.Add(clear);
            Controls.Add(clearAll);
            Controls.Add(num3);
            Controls.Add(num2);
            Controls.Add(num1);
            Controls.Add(num6);
            Controls.Add(num5);
            Controls.Add(num4);
            Controls.Add(num9);
            Controls.Add(num8);
            Controls.Add(num7);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button num7;
        private Button num8;
        private Button num9;
        private Button num4;
        private Button num5;
        private Button num6;
        private Button num1;
        private Button num2;
        private Button num3;
        private Button button9;
        private Button clear;
        private Button clearAll;
        private Button equals;
        private Button button13;
        private Button num0;
        private TextBox display;
        private Label appName;
        private Button plus;
        private Button minus;
        private Button multiply;
        private Button divide;
        private Button point;
    }
}