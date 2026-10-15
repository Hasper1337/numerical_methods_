#nullable disable
namespace GraphPlotter
{
    partial class Lab3Control
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
            btnPlot = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            lblA = new System.Windows.Forms.Label();
            txtA = new System.Windows.Forms.TextBox();
            lblB = new System.Windows.Forms.Label();
            txtB = new System.Windows.Forms.TextBox();
            lblEps = new System.Windows.Forms.Label();
            txtEps = new System.Windows.Forms.TextBox();
            btnSolve = new System.Windows.Forms.Button();
            btnZoom = new System.Windows.Forms.Button();
            radioMin = new System.Windows.Forms.RadioButton();
            radioMax = new System.Windows.Forms.RadioButton();
            txtOutput = new System.Windows.Forms.TextBox();
            graph = new GraphPlotter.GraphControl();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblFormula);
            panelTop.Controls.Add(txtFormula);
            panelTop.Controls.Add(btnPlot);
            panelTop.Controls.Add(btnReset);
            panelTop.Controls.Add(lblA);
            panelTop.Controls.Add(txtA);
            panelTop.Controls.Add(lblB);
            panelTop.Controls.Add(txtB);
            panelTop.Controls.Add(lblEps);
            panelTop.Controls.Add(txtEps);
            panelTop.Controls.Add(btnSolve);
            panelTop.Controls.Add(btnZoom);
            panelTop.Controls.Add(radioMin);
            panelTop.Controls.Add(radioMax);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(900, 108);
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
            // btnPlot
            // 
            btnPlot.Location = new System.Drawing.Point(395, 6);
            btnPlot.Name = "btnPlot";
            btnPlot.Size = new System.Drawing.Size(130, 26);
            btnPlot.TabIndex = 2;
            btnPlot.Text = "Построить график";
            btnPlot.UseVisualStyleBackColor = true;
            btnPlot.Click += btnPlot_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(535, 6);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(110, 26);
            btnReset.TabIndex = 3;
            btnReset.Text = "Сбросить вид";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Location = new System.Drawing.Point(8, 76);
            lblA.Name = "lblA";
            lblA.Size = new System.Drawing.Size(23, 15);
            lblA.TabIndex = 4;
            lblA.Text = "a =";
            // 
            // txtA
            // 
            txtA.Location = new System.Drawing.Point(34, 72);
            txtA.Name = "txtA";
            txtA.Size = new System.Drawing.Size(60, 23);
            txtA.TabIndex = 5;
            txtA.Text = "-0.5";
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Location = new System.Drawing.Point(104, 76);
            lblB.Name = "lblB";
            lblB.Size = new System.Drawing.Size(23, 15);
            lblB.TabIndex = 6;
            lblB.Text = "b =";
            // 
            // txtB
            // 
            txtB.Location = new System.Drawing.Point(130, 72);
            txtB.Name = "txtB";
            txtB.Size = new System.Drawing.Size(60, 23);
            txtB.TabIndex = 7;
            txtB.Text = "0.5";
            // 
            // lblEps
            // 
            lblEps.AutoSize = true;
            lblEps.Location = new System.Drawing.Point(200, 76);
            lblEps.Name = "lblEps";
            lblEps.Size = new System.Drawing.Size(20, 15);
            lblEps.TabIndex = 8;
            lblEps.Text = "ε =";
            // 
            // txtEps
            // 
            txtEps.Location = new System.Drawing.Point(226, 72);
            txtEps.Name = "txtEps";
            txtEps.Size = new System.Drawing.Size(70, 23);
            txtEps.TabIndex = 9;
            txtEps.Text = "0.0001";
            // 
            // btnSolve
            // 
            btnSolve.Location = new System.Drawing.Point(310, 70);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new System.Drawing.Size(135, 28);
            btnSolve.TabIndex = 10;
            btnSolve.Text = "Найти экстремум";
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += btnSolve_Click;
            // 
            // btnZoom
            // 
            btnZoom.Location = new System.Drawing.Point(450, 70);
            btnZoom.Name = "btnZoom";
            btnZoom.Size = new System.Drawing.Size(195, 28);
            btnZoom.TabIndex = 11;
            btnZoom.Text = "Показать точность (zoom)";
            btnZoom.UseVisualStyleBackColor = true;
            btnZoom.Click += btnZoom_Click;
            // 
            // radioMin
            // 
            radioMin.AutoSize = true;
            radioMin.Checked = true;
            radioMin.Location = new System.Drawing.Point(8, 42);
            radioMin.Name = "radioMin";
            radioMin.Size = new System.Drawing.Size(76, 19);
            radioMin.TabIndex = 12;
            radioMin.TabStop = true;
            radioMin.Text = "Минимум";
            radioMin.UseVisualStyleBackColor = true;
            // 
            // radioMax
            // 
            radioMax.AutoSize = true;
            radioMax.Location = new System.Drawing.Point(110, 42);
            radioMax.Name = "radioMax";
            radioMax.Size = new System.Drawing.Size(82, 19);
            radioMax.TabIndex = 13;
            radioMax.Text = "Максимум";
            radioMax.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            txtOutput.Dock = System.Windows.Forms.DockStyle.Right;
            txtOutput.Font = new System.Drawing.Font("Consolas", 9.5F);
            txtOutput.Location = new System.Drawing.Point(500, 108);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtOutput.Size = new System.Drawing.Size(400, 492);
            txtOutput.TabIndex = 1;
            txtOutput.WordWrap = false;
            // 
            // graph
            // 
            graph.Dock = System.Windows.Forms.DockStyle.Fill;
            graph.Location = new System.Drawing.Point(0, 108);
            graph.Name = "graph";
            graph.Size = new System.Drawing.Size(500, 492);
            graph.TabIndex = 0;
            // 
            // Lab3Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(graph);
            Controls.Add(txtOutput);
            Controls.Add(panelTop);
            Name = "Lab3Control";
            Size = new System.Drawing.Size(900, 600);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.TextBox txtEps;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.RadioButton radioMin;
        private System.Windows.Forms.RadioButton radioMax;
        private System.Windows.Forms.TextBox txtOutput;
        private GraphControl graph;
    }
}
