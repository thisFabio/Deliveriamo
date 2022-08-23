namespace DeliveriamoFrontend
{
    partial class MainForm
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
            this.dgv_shopkeeper = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_shopkeeper)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_shopkeeper
            // 
            this.dgv_shopkeeper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_shopkeeper.Location = new System.Drawing.Point(12, 56);
            this.dgv_shopkeeper.Name = "dgv_shopkeeper";
            this.dgv_shopkeeper.RowHeadersWidth = 51;
            this.dgv_shopkeeper.RowTemplate.Height = 29;
            this.dgv_shopkeeper.Size = new System.Drawing.Size(776, 382);
            this.dgv_shopkeeper.TabIndex = 0;
            this.dgv_shopkeeper.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_shopkeeper);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_shopkeeper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgv_shopkeeper;
    }
}