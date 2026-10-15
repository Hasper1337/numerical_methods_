#nullable disable
namespace GraphPlotter
{
    partial class Lab61Control
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
            lblDegree = new System.Windows.Forms.Label();
            nudDegree = new System.Windows.Forms.NumericUpDown();
            lblX0 = new System.Windows.Forms.Label();
            txtX0 = new System.Windows.Forms.TextBox();
            btnBuild = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            lblResult = new System.Windows.Forms.Label();
            graph = new GraphPlotter.GraphControl();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDegree).BeginInit();
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
            panelTop.Controls.Add(lblDegree);
            panelTop.Controls.Add(nudDegree);
            panelTop.Controls.Add(lblX0);
            panelTop.Controls.Add(txtX0);
            panelTop.Controls.Add(btnBuild);
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
            txtA.Text = "-3";
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
            txtB.Text = "3";
            // 
            // lblDegree
            // 
            lblDegree.AutoSize = true;
            lblDegree.Location = new System.Drawing.Point(8, 46);
            lblDegree.Name = "lblDegree";
            lblDegree.Size = new System.Drawing.Size(54, 15);
            lblDegree.TabIndex = 6;
            lblDegree.Text = "Степень:";
            // 
            // nudDegree
            // 
            nudDegree.Location = new System.Drawing.Point(68, 42);
            nudDegree.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudDegree.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDegree.Name = "nudDegree";
            nudDegree.Size = new System.Drawing.Size(60, 23);
            nudDegree.TabIndex = 7;
            nudDegree.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblX0
            // 
            lblX0.AutoSize = true;
            lblX0.Location = new System.Drawing.Point(140, 46);
            lblX0.Name = "lblX0";
            lblX0.Size = new System.Drawing.Size(29, 15);
            lblX0.TabIndex = 8;
            lblX0.Text = "x0 =";
            // 
            // txtX0
            // 
            txtX0.Location = new System.Drawing.Point(172, 42);
            txtX0.Name = "txtX0";
            txtX0.Size = new System.Drawing.Size(70, 23);
            txtX0.TabIndex = 9;
            txtX0.Text = "0.5";
            // 
            // btnBuild
            // 
            btnBuild.Location = new System.Drawing.Point(255, 40);
            btnBuild.Name = "btnBuild";
            btnBuild.Size = new System.Drawing.Size(110, 26);
            btnBuild.TabIndex = 10;
            btnBuild.Text = "Построить";
            btnBuild.UseVisualStyleBackColor = true;
            btnBuild.Click += btnBuild_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(375, 40);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(110, 26);
            btnReset.TabIndex = 11;
            btnReset.Text = "Сбросить вид";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // lblResult
            // 
            lblResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblResult.Location = new System.Drawing.Point(0, 572);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(900, 28);
            lblResult.TabIndex = 1;
            lblResult.Text = "Нажмите «Построить».";
            lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // graph
            // 
            graph.Dock = System.Windows.Forms.DockStyle.Fill;
            graph.Location = new System.Drawing.Point(0, 76);
            graph.Name = "graph";
            graph.Size = new System.Drawing.Size(900, 496);
            graph.TabIndex = 0;
            // 
            // Lab61Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(graph);
            Controls.Add(lblResult);
            Controls.Add(panelTop);
            Name = "Lab61Control";
            Size = new System.Drawing.Size(900, 600);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDegree).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.NumericUpDown nudDegree;
        private System.Windows.Forms.Label lblX0;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblResult;
        private GraphControl graph;
    }
}
