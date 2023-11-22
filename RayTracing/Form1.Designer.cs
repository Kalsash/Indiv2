namespace RayTracing
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cubeGlassCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sphereGlassCB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.refractSphereCB = new System.Windows.Forms.CheckBox();
            this.refractCubeCB = new System.Windows.Forms.CheckBox();
            this.twoLightsCB = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.downWallGlassCB = new System.Windows.Forms.CheckBox();
            this.upWallGlassCB = new System.Windows.Forms.CheckBox();
            this.rightWallGlassCB = new System.Windows.Forms.CheckBox();
            this.leftWallGlassCB = new System.Windows.Forms.CheckBox();
            this.backWallGlassCB = new System.Windows.Forms.CheckBox();
            this.frontWallGlassCB = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1231, 643);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(839, 683);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Запустить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cubeGlassCB
            // 
            this.cubeGlassCB.AutoSize = true;
            this.cubeGlassCB.Location = new System.Drawing.Point(11, 41);
            this.cubeGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.cubeGlassCB.Name = "cubeGlassCB";
            this.cubeGlassCB.Size = new System.Drawing.Size(53, 20);
            this.cubeGlassCB.TabIndex = 2;
            this.cubeGlassCB.Text = "Куб";
            this.cubeGlassCB.UseVisualStyleBackColor = true;
            this.cubeGlassCB.CheckedChanged += new System.EventHandler(this.cubeGlassCB_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sphereGlassCB);
            this.groupBox1.Controls.Add(this.cubeGlassCB);
            this.groupBox1.Location = new System.Drawing.Point(30, 672);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(125, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Зеркальное отражение";
            // 
            // sphereGlassCB
            // 
            this.sphereGlassCB.AutoSize = true;
            this.sphereGlassCB.Location = new System.Drawing.Point(8, 69);
            this.sphereGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.sphereGlassCB.Name = "sphereGlassCB";
            this.sphereGlassCB.Size = new System.Drawing.Size(56, 20);
            this.sphereGlassCB.TabIndex = 2;
            this.sphereGlassCB.Text = "Шар";
            this.sphereGlassCB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.refractSphereCB);
            this.groupBox2.Controls.Add(this.refractCubeCB);
            this.groupBox2.Location = new System.Drawing.Point(189, 672);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(125, 97);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Прозрачность";
            // 
            // refractSphereCB
            // 
            this.refractSphereCB.AutoSize = true;
            this.refractSphereCB.Location = new System.Drawing.Point(8, 52);
            this.refractSphereCB.Margin = new System.Windows.Forms.Padding(4);
            this.refractSphereCB.Name = "refractSphereCB";
            this.refractSphereCB.Size = new System.Drawing.Size(56, 20);
            this.refractSphereCB.TabIndex = 2;
            this.refractSphereCB.Text = "Шар";
            this.refractSphereCB.UseVisualStyleBackColor = true;
            // 
            // refractCubeCB
            // 
            this.refractCubeCB.AutoSize = true;
            this.refractCubeCB.Location = new System.Drawing.Point(8, 23);
            this.refractCubeCB.Margin = new System.Windows.Forms.Padding(4);
            this.refractCubeCB.Name = "refractCubeCB";
            this.refractCubeCB.Size = new System.Drawing.Size(53, 20);
            this.refractCubeCB.TabIndex = 2;
            this.refractCubeCB.Text = "Куб";
            this.refractCubeCB.UseVisualStyleBackColor = true;
            // 
            // twoLightsCB
            // 
            this.twoLightsCB.AutoSize = true;
            this.twoLightsCB.Location = new System.Drawing.Point(696, 698);
            this.twoLightsCB.Margin = new System.Windows.Forms.Padding(4);
            this.twoLightsCB.Name = "twoLightsCB";
            this.twoLightsCB.Size = new System.Drawing.Size(108, 20);
            this.twoLightsCB.TabIndex = 4;
            this.twoLightsCB.Text = "2 источника";
            this.twoLightsCB.UseVisualStyleBackColor = true;
            this.twoLightsCB.CheckedChanged += new System.EventHandler(this.twoLightsCB_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.downWallGlassCB);
            this.groupBox3.Controls.Add(this.upWallGlassCB);
            this.groupBox3.Controls.Add(this.rightWallGlassCB);
            this.groupBox3.Controls.Add(this.leftWallGlassCB);
            this.groupBox3.Controls.Add(this.backWallGlassCB);
            this.groupBox3.Controls.Add(this.frontWallGlassCB);
            this.groupBox3.Location = new System.Drawing.Point(342, 661);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(319, 97);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Зеркальность стен";
            // 
            // downWallGlassCB
            // 
            this.downWallGlassCB.AutoSize = true;
            this.downWallGlassCB.Location = new System.Drawing.Point(199, 65);
            this.downWallGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.downWallGlassCB.Name = "downWallGlassCB";
            this.downWallGlassCB.Size = new System.Drawing.Size(78, 20);
            this.downWallGlassCB.TabIndex = 0;
            this.downWallGlassCB.Text = "Нижняя";
            this.downWallGlassCB.UseVisualStyleBackColor = true;
            // 
            // upWallGlassCB
            // 
            this.upWallGlassCB.AutoSize = true;
            this.upWallGlassCB.Location = new System.Drawing.Point(109, 65);
            this.upWallGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.upWallGlassCB.Name = "upWallGlassCB";
            this.upWallGlassCB.Size = new System.Drawing.Size(82, 20);
            this.upWallGlassCB.TabIndex = 0;
            this.upWallGlassCB.Text = "Верхняя";
            this.upWallGlassCB.UseVisualStyleBackColor = true;
            // 
            // rightWallGlassCB
            // 
            this.rightWallGlassCB.AutoSize = true;
            this.rightWallGlassCB.Location = new System.Drawing.Point(8, 65);
            this.rightWallGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.rightWallGlassCB.Name = "rightWallGlassCB";
            this.rightWallGlassCB.Size = new System.Drawing.Size(78, 20);
            this.rightWallGlassCB.TabIndex = 0;
            this.rightWallGlassCB.Text = "Правая";
            this.rightWallGlassCB.UseVisualStyleBackColor = true;
            // 
            // leftWallGlassCB
            // 
            this.leftWallGlassCB.AutoSize = true;
            this.leftWallGlassCB.Location = new System.Drawing.Point(193, 37);
            this.leftWallGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.leftWallGlassCB.Name = "leftWallGlassCB";
            this.leftWallGlassCB.Size = new System.Drawing.Size(69, 20);
            this.leftWallGlassCB.TabIndex = 0;
            this.leftWallGlassCB.Text = "Левая";
            this.leftWallGlassCB.UseVisualStyleBackColor = true;
            // 
            // backWallGlassCB
            // 
            this.backWallGlassCB.AutoSize = true;
            this.backWallGlassCB.Location = new System.Drawing.Point(109, 37);
            this.backWallGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.backWallGlassCB.Name = "backWallGlassCB";
            this.backWallGlassCB.Size = new System.Drawing.Size(76, 20);
            this.backWallGlassCB.TabIndex = 0;
            this.backWallGlassCB.Text = "Задняя";
            this.backWallGlassCB.UseVisualStyleBackColor = true;
            // 
            // frontWallGlassCB
            // 
            this.frontWallGlassCB.AutoSize = true;
            this.frontWallGlassCB.Location = new System.Drawing.Point(8, 37);
            this.frontWallGlassCB.Margin = new System.Windows.Forms.Padding(4);
            this.frontWallGlassCB.Name = "frontWallGlassCB";
            this.frontWallGlassCB.Size = new System.Drawing.Size(93, 20);
            this.frontWallGlassCB.TabIndex = 0;
            this.frontWallGlassCB.Text = "Передняя";
            this.frontWallGlassCB.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(709, 747);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(95, 22);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(839, 747);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(95, 22);
            this.numericUpDown2.TabIndex = 7;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(957, 747);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(95, 22);
            this.numericUpDown3.TabIndex = 8;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(1098, 693);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(95, 22);
            this.numericUpDown4.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(725, 776);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(873, 776);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(982, 776);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1095, 724);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Освещение";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1255, 938);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.twoLightsCB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ray Tracing";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cubeGlassCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox sphereGlassCB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox refractSphereCB;
        private System.Windows.Forms.CheckBox refractCubeCB;
        private System.Windows.Forms.CheckBox twoLightsCB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox frontWallGlassCB;
        private System.Windows.Forms.CheckBox rightWallGlassCB;
        private System.Windows.Forms.CheckBox leftWallGlassCB;
        private System.Windows.Forms.CheckBox backWallGlassCB;
        private System.Windows.Forms.CheckBox downWallGlassCB;
        private System.Windows.Forms.CheckBox upWallGlassCB;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

