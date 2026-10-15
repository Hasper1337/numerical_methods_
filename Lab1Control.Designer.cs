#nullable disable
namespace GraphPlotter
{
    partial class Lab1Control
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
            radioAnalytical = new System.Windows.Forms.RadioButton();
            radioTable = new System.Windows.Forms.RadioButton();
            txtFormula = new System.Windows.Forms.TextBox();
            btnPlot = new System.Windows.Forms.Button();
            btnLoad = new System.Windows.Forms.Button();
            lblFile = new System.Windows.Forms.Label();
            btnReset = new System.Windows.Forms.Button();
            graph = new GraphPlotter.GraphControl();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(radioAnalytical);
            panelTop.Controls.Add(radioTable);
            panelTop.Controls.Add(txtFormula);
            panelTop.Controls.Add(btnPlot);
            panelTop.Controls.Add(btnLoad);
            panelTop.Controls.Add(lblFile);
            panelTop.Controls.Add(btnReset);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(900, 72);
            panelTop.TabIndex = 1;
            // 
            // radioAnalytical
            // 
            radioAnalytical.AutoSize = true;
            radioAnalytical.Checked = true;
            radioAnalytical.Location = new System.Drawing.Point(8, 9);
            radioAnalytical.Name = "radioAnalytical";
            radioAnalytical.Size = new System.Drawing.Size(156, 19);
            radioAnalytical.TabIndex = 0;
            radioAnalytical.TabStop = true;
            radioAnalytical.Text = "Аналитическая функция";
            radioAnalytical.UseVisualStyleBackColor = true;
            radioAnalytical.CheckedChanged += radioAnalytical_CheckedChanged;
            // 
            // radioTable
            // 
            radioTable.AutoSize = true;
            radioTable.Location = new System.Drawing.Point(8, 40);
            radioTable.Name = "radioTable";
            radioTable.Size = new System.Drawing.Size(134, 19);
            radioTable.TabIndex = 1;
            radioTable.Text = "Табличная функция";
            radioTable.UseVisualStyleBackColor = true;
            // 
            // txtFormula
            // 
            txtFormula.Location = new System.Drawing.Point(200, 8);
            txtFormula.Name = "txtFormula";
            txtFormula.Size = new System.Drawing.Size(380, 23);
            txtFormula.TabIndex = 2;
            txtFormula.Text = "sin(x) + 0.5*cos(2*x)";
            // 
            // btnPlot
            // 
            btnPlot.Location = new System.Drawing.Point(590, 7);
            btnPlot.Name = "btnPlot";
            btnPlot.Size = new System.Drawing.Size(110, 26);
            btnPlot.TabIndex = 3;
            btnPlot.Text = "Построить";
            btnPlot.UseVisualStyleBackColor = true;
            btnPlot.Click += btnPlot_Click;
            // 
            // btnLoad
            // 
            btnLoad.Enabled = false;
            btnLoad.Location = new System.Drawing.Point(200, 37);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new System.Drawing.Size(140, 26);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Загрузить файл...";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.ForeColor = System.Drawing.SystemColors.GrayText;
            lblFile.Location = new System.Drawing.Point(350, 42);
            lblFile.Name = "lblFile";
            lblFile.Size = new System.Drawing.Size(88, 15);
            lblFile.TabIndex = 5;
            lblFile.Text = "Файл не выбран";
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(710, 7);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(110, 26);
            btnReset.TabIndex = 6;
            btnReset.Text = "Сбросить вид";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // graph
            // 
            graph.Dock = System.Windows.Forms.DockStyle.Fill;
            graph.Location = new System.Drawing.Point(0, 72);
            graph.Name = "graph";
            graph.Size = new System.Drawing.Size(900, 528);
            graph.TabIndex = 0;
            // 
            // Lab1Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(graph);
            Controls.Add(panelTop);
            Name = "Lab1Control";
            Size = new System.Drawing.Size(900, 600);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.RadioButton radioAnalytical;
        private System.Windows.Forms.RadioButton radioTable;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnReset;
        private GraphControl graph;
    }
}
