
namespace InsitePolygon
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbSite = new System.Windows.Forms.Label();
            this.txtListSite = new System.Windows.Forms.TextBox();
            this.btBrowserSite = new System.Windows.Forms.Button();
            this.lbPolygon = new System.Windows.Forms.Label();
            this.txtListPolygon = new System.Windows.Forms.TextBox();
            this.btBrowserPolygon = new System.Windows.Forms.Button();
            this.btRun = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSite
            // 
            this.lbSite.AutoSize = true;
            this.lbSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSite.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbSite.Location = new System.Drawing.Point(36, 34);
            this.lbSite.Name = "lbSite";
            this.lbSite.Size = new System.Drawing.Size(66, 13);
            this.lbSite.TabIndex = 0;
            this.lbSite.Text = "List of site";
            this.toolTip1.SetToolTip(this.lbSite, "Click to export form");
            this.lbSite.Click += new System.EventHandler(this.lbSite_Click);
            // 
            // txtListSite
            // 
            this.txtListSite.Location = new System.Drawing.Point(108, 31);
            this.txtListSite.Name = "txtListSite";
            this.txtListSite.Size = new System.Drawing.Size(184, 20);
            this.txtListSite.TabIndex = 1;
            // 
            // btBrowserSite
            // 
            this.btBrowserSite.Location = new System.Drawing.Point(298, 29);
            this.btBrowserSite.Name = "btBrowserSite";
            this.btBrowserSite.Size = new System.Drawing.Size(75, 23);
            this.btBrowserSite.TabIndex = 2;
            this.btBrowserSite.Text = "Browser";
            this.btBrowserSite.UseVisualStyleBackColor = true;
            this.btBrowserSite.Click += new System.EventHandler(this.btBrowserSite_Click);
            // 
            // lbPolygon
            // 
            this.lbPolygon.AutoSize = true;
            this.lbPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPolygon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbPolygon.Location = new System.Drawing.Point(12, 61);
            this.lbPolygon.Name = "lbPolygon";
            this.lbPolygon.Size = new System.Drawing.Size(90, 13);
            this.lbPolygon.TabIndex = 0;
            this.lbPolygon.Text = "List of polygon";
            this.toolTip1.SetToolTip(this.lbPolygon, "Click to export form");
            this.lbPolygon.Click += new System.EventHandler(this.lbPolygon_Click);
            // 
            // txtListPolygon
            // 
            this.txtListPolygon.Location = new System.Drawing.Point(108, 58);
            this.txtListPolygon.Name = "txtListPolygon";
            this.txtListPolygon.Size = new System.Drawing.Size(184, 20);
            this.txtListPolygon.TabIndex = 1;
            // 
            // btBrowserPolygon
            // 
            this.btBrowserPolygon.Location = new System.Drawing.Point(298, 56);
            this.btBrowserPolygon.Name = "btBrowserPolygon";
            this.btBrowserPolygon.Size = new System.Drawing.Size(75, 23);
            this.btBrowserPolygon.TabIndex = 2;
            this.btBrowserPolygon.Text = "Browser";
            this.btBrowserPolygon.UseVisualStyleBackColor = true;
            this.btBrowserPolygon.Click += new System.EventHandler(this.btBrowserPolygon_Click);
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(171, 84);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 23);
            this.btRun.TabIndex = 2;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naebolo@2020";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 155);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.btBrowserPolygon);
            this.Controls.Add(this.btBrowserSite);
            this.Controls.Add(this.txtListPolygon);
            this.Controls.Add(this.lbPolygon);
            this.Controls.Add(this.txtListSite);
            this.Controls.Add(this.lbSite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Get site in polygon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSite;
        private System.Windows.Forms.TextBox txtListSite;
        private System.Windows.Forms.Button btBrowserSite;
        private System.Windows.Forms.Label lbPolygon;
        private System.Windows.Forms.TextBox txtListPolygon;
        private System.Windows.Forms.Button btBrowserPolygon;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
    }
}

