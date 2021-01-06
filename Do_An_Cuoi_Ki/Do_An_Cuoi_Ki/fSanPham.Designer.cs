
namespace Do_An_Cuoi_Ki
{
    partial class fSanPham
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnStopSellProduct = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContinueSellProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Lọc sản phẩm";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Items.AddRange(new object[] {
            "Đơn vị tính",
            "Nước sản xuất"});
            this.comboBoxFilter.Location = new System.Drawing.Point(307, 61);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(217, 27);
            this.comboBoxFilter.TabIndex = 10;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tìm kiếm sản phẩm";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProduct.Location = new System.Drawing.Point(26, 61);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(217, 27);
            this.txtSearchProduct.TabIndex = 8;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchBill_TextChanged);
            // 
            // dgvProduct
            // 
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(29, 162);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.RowTemplate.Height = 24;
            this.dgvProduct.Size = new System.Drawing.Size(948, 462);
            this.dgvProduct.TabIndex = 7;
            // 
            // btnStopSellProduct
            // 
            this.btnStopSellProduct.Font = new System.Drawing.Font("UTM Avo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopSellProduct.Location = new System.Drawing.Point(686, 10);
            this.btnStopSellProduct.Name = "btnStopSellProduct";
            this.btnStopSellProduct.Size = new System.Drawing.Size(235, 39);
            this.btnStopSellProduct.TabIndex = 6;
            this.btnStopSellProduct.Text = "Dừng bán sản phẩm";
            this.btnStopSellProduct.UseVisualStyleBackColor = true;
            this.btnStopSellProduct.Click += new System.EventHandler(this.btnStopSellProduct_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnContinueSellProduct);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxFilter);
            this.panel1.Controls.Add(this.txtSearchProduct);
            this.panel1.Controls.Add(this.btnStopSellProduct);
            this.panel1.Location = new System.Drawing.Point(26, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 117);
            this.panel1.TabIndex = 12;
            // 
            // btnContinueSellProduct
            // 
            this.btnContinueSellProduct.Font = new System.Drawing.Font("UTM Avo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueSellProduct.Location = new System.Drawing.Point(686, 61);
            this.btnContinueSellProduct.Name = "btnContinueSellProduct";
            this.btnContinueSellProduct.Size = new System.Drawing.Size(235, 39);
            this.btnContinueSellProduct.TabIndex = 12;
            this.btnContinueSellProduct.Text = "Tiếp tục bán sản phẩm";
            this.btnContinueSellProduct.UseVisualStyleBackColor = true;
            this.btnContinueSellProduct.Click += new System.EventHandler(this.btnContinueSellProduct_Click);
            // 
            // fSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSanPham";
            this.Text = "fSanPham";
            this.Load += new System.EventHandler(this.fSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnStopSellProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnContinueSellProduct;
    }
}