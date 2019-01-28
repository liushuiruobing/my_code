namespace RobotWorkstation
{
    partial class Salver
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SalverPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // SalverPanel
            // 
            this.SalverPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.SalverPanel.ColumnCount = 6;
            this.SalverPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.SalverPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.SalverPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.SalverPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.SalverPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.SalverPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.675F));
            this.SalverPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalverPanel.Location = new System.Drawing.Point(0, 0);
            this.SalverPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SalverPanel.Name = "SalverPanel";
            this.SalverPanel.RowCount = 3;
            this.SalverPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
            this.SalverPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.SalverPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.SalverPanel.Size = new System.Drawing.Size(224, 94);
            this.SalverPanel.TabIndex = 0;
            // 
            // Salver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.SalverPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Salver";
            this.Size = new System.Drawing.Size(224, 94);
            this.Load += new System.EventHandler(this.Salver_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel SalverPanel;
    }
}
