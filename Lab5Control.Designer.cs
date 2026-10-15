#nullable disable
namespace GraphPlotter
{
    partial class Lab5Control
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
            lblOmega = new System.Windows.Forms.Label();
            txtOmega = new System.Windows.Forms.TextBox();
            lblEps = new System.Windows.Forms.Label();
            txtEps = new System.Windows.Forms.TextBox();
            btnSolve = new System.Windows.Forms.Button();
            btnDefault = new System.Windows.Forms.Button();
            txtOutput = new System.Windows.Forms.TextBox();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblHint);
            panelTop.Controls.Add(txtMatrix);
            panelTop.Controls.Add(lblOmega);
            panelTop.Controls.Add(txtOmega);
            panelTop.Controls.Add(lblEps);
            panelTop.Controls.Add(txtEps);
            panelTop.Controls.Add(btnSolve);
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
            lblHint.Size = new System.Drawing.Size(330, 15);
            lblHint.TabIndex = 0;
            lblHint.Text = "Расширенная матрица [A | b]: по строке на уравнение, 5 чисел";
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
            // lblOmega
            // 
            lblOmega.AutoSize = true;
            lblOmega.Location = new System.Drawing.Point(490, 34);
            lblOmega.Name = "lblOmega";
            lblOmega.Size = new System.Drawing.Size(23, 15);
            lblOmega.TabIndex = 2;
            lblOmega.Text = "ω =";
            // 
            // txtOmega
            // 
            txtOmega.Location = new System.Drawing.Point(518, 30);
            txtOmega.Name = "txtOmega";
            txtOmega.Size = new System.Drawing.Size(60, 23);
            txtOmega.TabIndex = 3;
            txtOmega.Text = "1.0";
            // 
            // lblEps
            // 
            lblEps.AutoSize = true;
            lblEps.Location = new System.Drawing.Point(590, 34);
            lblEps.Name = "lblEps";
            lblEps.Size = new System.Drawing.Size(20, 15);
            lblEps.TabIndex = 4;
            lblEps.Text = "ε =";
            // 
            // txtEps
            // 
            txtEps.Location = new System.Drawing.Point(616, 30);
            txtEps.Name = "txtEps";
            txtEps.Size = new System.Drawing.Size(70, 23);
            txtEps.TabIndex = 5;
            txtEps.Text = "0.0001";
            // 
            // btnSolve
            // 
            btnSolve.Location = new System.Drawing.Point(490, 62);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new System.Drawing.Size(210, 30);
            btnSolve.TabIndex = 6;
            btnSolve.Text = "Решить (метод релаксаций)";
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += btnSolve_Click;
            // 
            // btnDefault
            // 
            btnDefault.Location = new System.Drawing.Point(490, 98);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new System.Drawing.Size(210, 26);
            btnDefault.TabIndex = 7;
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
            // Lab5Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtOutput);
            Controls.Add(panelTop);
            Name = "Lab5Control";
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
        private System.Windows.Forms.Label lblOmega;
        private System.Windows.Forms.TextBox txtOmega;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.TextBox txtEps;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TextBox txtOutput;
    }
}
