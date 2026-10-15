#nullable disable
namespace GraphPlotter
{
    partial class Lab4Control
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new System.Windows.Forms.Panel();
            lblHint = new System.Windows.Forms.Label();
            txtMatrix = new System.Windows.Forms.TextBox();
            btnCompute = new System.Windows.Forms.Button();
            btnDefault = new System.Windows.Forms.Button();
            txtOutput = new System.Windows.Forms.TextBox();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblHint);
            panelTop.Controls.Add(txtMatrix);
            panelTop.Controls.Add(btnCompute);
            panelTop.Controls.Add(btnDefault);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(900, 130);
            panelTop.TabIndex = 1;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Location = new System.Drawing.Point(8, 8);
            lblHint.Name = "lblHint";
            lblHint.Size = new System.Drawing.Size(430, 15);
            lblHint.TabIndex = 0;
            lblHint.Text = "Матрица A: по строке на уравнение (берутся первые 4 числа, 5-й столбец b не нужен)";
            // 
            // txtMatrix
            // 
            txtMatrix.AcceptsReturn = true;
            txtMatrix.Font = new System.Drawing.Font("Consolas", 9.5F);
            txtMatrix.Location = new System.Drawing.Point(8, 30);
            txtMatrix.Multiline = true;
            txtMatrix.Name = "txtMatrix";
            txtMatrix.Size = new System.Drawing.Size(470, 90);
            txtMatrix.TabIndex = 1;
            txtMatrix.WordWrap = false;
            // 
            // btnCompute
            // 
            btnCompute.Location = new System.Drawing.Point(490, 30);
            btnCompute.Name = "btnCompute";
            btnCompute.Size = new System.Drawing.Size(210, 30);
            btnCompute.TabIndex = 2;
            btnCompute.Text = "Вычислить определитель";
            btnCompute.UseVisualStyleBackColor = true;
            btnCompute.Click += btnCompute_Click;
            // 
            // btnDefault
            // 
            btnDefault.Location = new System.Drawing.Point(490, 68);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new System.Drawing.Size(210, 30);
            btnDefault.TabIndex = 3;
            btnDefault.Text = "Значения по умолчанию";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += btnDefault_Click;
            // 
            // txtOutput
            // 
            txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            txtOutput.Font = new System.Drawing.Font("Consolas", 9.5F);
            txtOutput.Location = new System.Drawing.Point(0, 130);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtOutput.Size = new System.Drawing.Size(900, 470);
            txtOutput.TabIndex = 0;
            txtOutput.WordWrap = false;
            // 
            // Lab4Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtOutput);
            Controls.Add(panelTop);
            Name = "Lab4Control";
            Size = new System.Drawing.Size(900, 600);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TextBox txtMatrix;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TextBox txtOutput;
    }
}
