#nullable disable
namespace GraphPlotter
{
    partial class Lab63Control
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
            lblFormula = new System.Windows.Forms.Label();
            txtFormula = new System.Windows.Forms.TextBox();
            lblA = new System.Windows.Forms.Label();
            txtA = new System.Windows.Forms.TextBox();
            lblB = new System.Windows.Forms.Label();
            txtB = new System.Windows.Forms.TextBox();
            lblN = new System.Windows.Forms.Label();
            nudN = new System.Windows.Forms.NumericUpDown();
            lblError = new System.Windows.Forms.Label();
            txtErrMin = new System.Windows.Forms.TextBox();
            lblDash = new System.Windows.Forms.Label();
            txtErrMax = new System.Windows.Forms.TextBox();
            btnRun = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            txtOutput = new System.Windows.Forms.TextBox();
            graph = new GraphPlotter.GraphControl();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudN).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblFormula);
            panelTop.Controls.Add(txtFormula);
            panelTop.Controls.Add(lblA);
            panelTop.Controls.Add(txtA);
            panelTop.Controls.Add(lblB);
            panelTop.Controls.Add(txtB);
            panelTop.Controls.Add(lblN);
            panelTop.Controls.Add(nudN);
            panelTop.Controls.Add(lblError);
            panelTop.Controls.Add(txtErrMin);
            panelTop.Controls.Add(lblDash);
            panelTop.Controls.Add(txtErrMax);
            panelTop.Controls.Add(btnRun);
            panelTop.Controls.Add(btnReset);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(900, 76);
            panelTop.TabIndex = 2;
            // 
            // lblFormula
            // 
            lblFormula.AutoSize = true;
            lblFormula.Location = new System.Drawing.Point(8, 12);
            lblFormula.Name = "lblFormula";
            lblFormula.Size = new System.Drawing.Size(39, 15);
            lblFormula.TabIndex = 0;
            lblFormula.Text = "f(x) =";
            // 
            // txtFormula
            // 
            txtFormula.Location = new System.Drawing.Point(55, 8);
            txtFormula.Name = "txtFormula";
            txtFormula.Size = new System.Drawing.Size(330, 23);
            txtFormula.TabIndex = 1;
            txtFormula.Text = "x^2-3-2*cos(2*pi*x)";
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Location = new System.Drawing.Point(395, 12);
            lblA.Name = "lblA";
            lblA.Size = new System.Drawing.Size(23, 15);
            lblA.TabIndex = 2;
            lblA.Text = "a =";
            // 
            // txtA
            // 
            txtA.Location = new System.Drawing.Point(421, 8);
            txtA.Name = "txtA";
            txtA.Size = new System.Drawing.Size(60, 23);
            txtA.TabIndex = 3;
            txtA.Text = "2.5";
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Location = new System.Drawing.Point(491, 12);
            lblB.Name = "lblB";
            lblB.Size = new System.Drawing.Size(23, 15);
            lblB.TabIndex = 4;
            lblB.Text = "b =";
            // 
            // txtB
            // 
            txtB.Location = new System.Drawing.Point(517, 8);
            txtB.Name = "txtB";
            txtB.Size = new System.Drawing.Size(60, 23);
            txtB.TabIndex = 5;
            txtB.Text = "5";
            // 
            // lblN
            // 
            lblN.AutoSize = true;
            lblN.Location = new System.Drawing.Point(8, 46);
            lblN.Name = "lblN";
            lblN.Size = new System.Drawing.Size(42, 15);
            lblN.TabIndex = 6;
            lblN.Text = "Точек:";
            // 
            // nudN
            // 
            nudN.Location = new System.Drawing.Point(56, 42);
            nudN.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudN.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            nudN.Name = "nudN";
            nudN.Size = new System.Drawing.Size(60, 23);
            nudN.TabIndex = 7;
            nudN.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new System.Drawing.Point(130, 46);
            lblError.Name = "lblError";
            lblError.Size = new System.Drawing.Size(99, 15);
            lblError.TabIndex = 8;
            lblError.Text = "Погрешность, %:";
            // 
            // txtErrMin
            // 
            txtErrMin.Location = new System.Drawing.Point(236, 42);
            txtErrMin.Name = "txtErrMin";
            txtErrMin.Size = new System.Drawing.Size(50, 23);
            txtErrMin.TabIndex = 9;
            txtErrMin.Text = "30";
            // 
            // lblDash
            // 
            lblDash.AutoSize = true;
            lblDash.Location = new System.Drawing.Point(292, 46);
            lblDash.Name = "lblDash";
            lblDash.Size = new System.Drawing.Size(13, 15);
            lblDash.TabIndex = 10;
            lblDash.Text = "…";
            // 
            // txtErrMax
            // 
            txtErrMax.Location = new System.Drawing.Point(310, 42);
            txtErrMax.Name = "txtErrMax";
            txtErrMax.Size = new System.Drawing.Size(50, 23);
            txtErrMax.TabIndex = 11;
            txtErrMax.Text = "300";
            // 
            // btnRun
            // 
            btnRun.Location = new System.Drawing.Point(375, 40);
            btnRun.Name = "btnRun";
            btnRun.Size = new System.Drawing.Size(220, 28);
            btnRun.TabIndex = 12;
            btnRun.Text = "Сгенерировать и построить";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(605, 40);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(110, 28);
            btnReset.TabIndex = 13;
            btnReset.Text = "Сбросить вид";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // txtOutput
            // 
            txtOutput.Dock = System.Windows.Forms.DockStyle.Right;
            txtOutput.Font = new System.Drawing.Font("Consolas", 9.5F);
            txtOutput.Location = new System.Drawing.Point(440, 76);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtOutput.Size = new System.Drawing.Size(460, 524);
            txtOutput.TabIndex = 1;
            txtOutput.WordWrap = false;
            // 
            // graph
            // 
            graph.Dock = System.Windows.Forms.DockStyle.Fill;
            graph.Location = new System.Drawing.Point(0, 76);
            graph.Name = "graph";
            graph.Size = new System.Drawing.Size(440, 524);
            graph.TabIndex = 0;
            // 
            // Lab63Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(graph);
            Controls.Add(txtOutput);
            Controls.Add(panelTop);
            Name = "Lab63Control";
            Size = new System.Drawing.Size(900, 600);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtErrMin;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.TextBox txtErrMax;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtOutput;
        private GraphControl graph;
    }
}
