namespace C698Project
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.InventoryManagmentSystem = new System.Windows.Forms.Label();
            this.groupParts = new System.Windows.Forms.GroupBox();
            this.groupProducts = new System.Windows.Forms.GroupBox();
            this.partsSearchButton = new System.Windows.Forms.Button();
            this.productsSearchButton = new System.Windows.Forms.Button();
            this.partsSearchText = new System.Windows.Forms.TextBox();
            this.productsSearchText = new System.Windows.Forms.TextBox();
            this.partsDataGridView = new System.Windows.Forms.DataGridView();
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.partsAddButton = new System.Windows.Forms.Button();
            this.productsAddButton = new System.Windows.Forms.Button();
            this.productsModifyButton = new System.Windows.Forms.Button();
            this.partsModifyButton = new System.Windows.Forms.Button();
            this.partsDeleteButton = new System.Windows.Forms.Button();
            this.productsDeleteButton = new System.Windows.Forms.Button();
            this.partsLabel = new System.Windows.Forms.Label();
            this.productsLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.groupParts.SuspendLayout();
            this.groupProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryManagmentSystem
            // 
            this.InventoryManagmentSystem.AutoSize = true;
            this.InventoryManagmentSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryManagmentSystem.ForeColor = System.Drawing.Color.DarkBlue;
            this.InventoryManagmentSystem.Location = new System.Drawing.Point(41, 34);
            this.InventoryManagmentSystem.Name = "InventoryManagmentSystem";
            this.InventoryManagmentSystem.Size = new System.Drawing.Size(210, 16);
            this.InventoryManagmentSystem.TabIndex = 0;
            this.InventoryManagmentSystem.Text = "Inventory Managment System";
            // 
            // groupParts
            // 
            this.groupParts.Controls.Add(this.partsLabel);
            this.groupParts.Controls.Add(this.partsDeleteButton);
            this.groupParts.Controls.Add(this.partsModifyButton);
            this.groupParts.Controls.Add(this.partsAddButton);
            this.groupParts.Controls.Add(this.partsDataGridView);
            this.groupParts.Controls.Add(this.partsSearchText);
            this.groupParts.Controls.Add(this.partsSearchButton);
            this.groupParts.Location = new System.Drawing.Point(44, 102);
            this.groupParts.Name = "groupParts";
            this.groupParts.Size = new System.Drawing.Size(532, 311);
            this.groupParts.TabIndex = 1;
            this.groupParts.TabStop = false;
            // 
            // groupProducts
            // 
            this.groupProducts.Controls.Add(this.productsLabel);
            this.groupProducts.Controls.Add(this.productsDeleteButton);
            this.groupProducts.Controls.Add(this.productsModifyButton);
            this.groupProducts.Controls.Add(this.productsAddButton);
            this.groupProducts.Controls.Add(this.productsDataGridView);
            this.groupProducts.Controls.Add(this.productsSearchText);
            this.groupProducts.Controls.Add(this.productsSearchButton);
            this.groupProducts.Location = new System.Drawing.Point(635, 102);
            this.groupProducts.Name = "groupProducts";
            this.groupProducts.Size = new System.Drawing.Size(532, 311);
            this.groupProducts.TabIndex = 2;
            this.groupProducts.TabStop = false;
            // 
            // partsSearchButton
            // 
            this.partsSearchButton.Location = new System.Drawing.Point(260, 28);
            this.partsSearchButton.Name = "partsSearchButton";
            this.partsSearchButton.Size = new System.Drawing.Size(91, 32);
            this.partsSearchButton.TabIndex = 0;
            this.partsSearchButton.Text = "Search";
            this.partsSearchButton.UseVisualStyleBackColor = true;
            // 
            // productsSearchButton
            // 
            this.productsSearchButton.Location = new System.Drawing.Point(281, 28);
            this.productsSearchButton.Name = "productsSearchButton";
            this.productsSearchButton.Size = new System.Drawing.Size(91, 32);
            this.productsSearchButton.TabIndex = 1;
            this.productsSearchButton.Text = "Search";
            this.productsSearchButton.UseVisualStyleBackColor = true;
            // 
            // partsSearchText
            // 
            this.partsSearchText.Location = new System.Drawing.Point(357, 35);
            this.partsSearchText.Name = "partsSearchText";
            this.partsSearchText.Size = new System.Drawing.Size(169, 20);
            this.partsSearchText.TabIndex = 1;
            // 
            // productsSearchText
            // 
            this.productsSearchText.Location = new System.Drawing.Point(378, 35);
            this.productsSearchText.Name = "productsSearchText";
            this.productsSearchText.Size = new System.Drawing.Size(148, 20);
            this.productsSearchText.TabIndex = 2;
            // 
            // partsDataGridView
            // 
            this.partsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsDataGridView.Location = new System.Drawing.Point(10, 92);
            this.partsDataGridView.Name = "partsDataGridView";
            this.partsDataGridView.Size = new System.Drawing.Size(515, 163);
            this.partsDataGridView.TabIndex = 2;
            // 
            // productsDataGridView
            // 
            this.productsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGridView.Location = new System.Drawing.Point(11, 92);
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.Size = new System.Drawing.Size(515, 163);
            this.productsDataGridView.TabIndex = 3;
            // 
            // partsAddButton
            // 
            this.partsAddButton.Location = new System.Drawing.Point(156, 261);
            this.partsAddButton.Name = "partsAddButton";
            this.partsAddButton.Size = new System.Drawing.Size(98, 35);
            this.partsAddButton.TabIndex = 3;
            this.partsAddButton.Text = "Add";
            this.partsAddButton.UseVisualStyleBackColor = true;
            // 
            // productsAddButton
            // 
            this.productsAddButton.Location = new System.Drawing.Point(196, 261);
            this.productsAddButton.Name = "productsAddButton";
            this.productsAddButton.Size = new System.Drawing.Size(98, 35);
            this.productsAddButton.TabIndex = 4;
            this.productsAddButton.Text = "Add";
            this.productsAddButton.UseVisualStyleBackColor = true;
            // 
            // productsModifyButton
            // 
            this.productsModifyButton.Location = new System.Drawing.Point(300, 261);
            this.productsModifyButton.Name = "productsModifyButton";
            this.productsModifyButton.Size = new System.Drawing.Size(98, 34);
            this.productsModifyButton.TabIndex = 5;
            this.productsModifyButton.Text = "Modify";
            this.productsModifyButton.UseVisualStyleBackColor = true;
            // 
            // partsModifyButton
            // 
            this.partsModifyButton.Location = new System.Drawing.Point(260, 261);
            this.partsModifyButton.Name = "partsModifyButton";
            this.partsModifyButton.Size = new System.Drawing.Size(98, 34);
            this.partsModifyButton.TabIndex = 6;
            this.partsModifyButton.Text = "Modify";
            this.partsModifyButton.UseVisualStyleBackColor = true;
            // 
            // partsDeleteButton
            // 
            this.partsDeleteButton.Location = new System.Drawing.Point(364, 261);
            this.partsDeleteButton.Name = "partsDeleteButton";
            this.partsDeleteButton.Size = new System.Drawing.Size(98, 34);
            this.partsDeleteButton.TabIndex = 7;
            this.partsDeleteButton.Text = "Delete";
            this.partsDeleteButton.UseVisualStyleBackColor = true;
            // 
            // productsDeleteButton
            // 
            this.productsDeleteButton.Location = new System.Drawing.Point(404, 261);
            this.productsDeleteButton.Name = "productsDeleteButton";
            this.productsDeleteButton.Size = new System.Drawing.Size(98, 34);
            this.productsDeleteButton.TabIndex = 8;
            this.productsDeleteButton.Text = "Delete";
            this.productsDeleteButton.UseVisualStyleBackColor = true;
            // 
            // partsLabel
            // 
            this.partsLabel.AutoSize = true;
            this.partsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partsLabel.Location = new System.Drawing.Point(22, 35);
            this.partsLabel.Name = "partsLabel";
            this.partsLabel.Size = new System.Drawing.Size(67, 25);
            this.partsLabel.TabIndex = 8;
            this.partsLabel.Text = "Parts";
            // 
            // productsLabel
            // 
            this.productsLabel.AutoSize = true;
            this.productsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsLabel.Location = new System.Drawing.Point(37, 35);
            this.productsLabel.Name = "productsLabel";
            this.productsLabel.Size = new System.Drawing.Size(105, 25);
            this.productsLabel.TabIndex = 9;
            this.productsLabel.Text = "Products";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(1041, 419);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(96, 38);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 496);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupProducts);
            this.Controls.Add(this.groupParts);
            this.Controls.Add(this.InventoryManagmentSystem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            this.groupParts.ResumeLayout(false);
            this.groupParts.PerformLayout();
            this.groupProducts.ResumeLayout(false);
            this.groupProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InventoryManagmentSystem;
        private System.Windows.Forms.GroupBox groupParts;
        private System.Windows.Forms.GroupBox groupProducts;
        private System.Windows.Forms.TextBox partsSearchText;
        private System.Windows.Forms.Button partsSearchButton;
        private System.Windows.Forms.TextBox productsSearchText;
        private System.Windows.Forms.Button productsSearchButton;
        private System.Windows.Forms.Label partsLabel;
        private System.Windows.Forms.Button partsDeleteButton;
        private System.Windows.Forms.Button partsModifyButton;
        private System.Windows.Forms.Button partsAddButton;
        private System.Windows.Forms.DataGridView partsDataGridView;
        private System.Windows.Forms.Label productsLabel;
        private System.Windows.Forms.Button productsDeleteButton;
        private System.Windows.Forms.Button productsModifyButton;
        private System.Windows.Forms.Button productsAddButton;
        private System.Windows.Forms.DataGridView productsDataGridView;
        private System.Windows.Forms.Button exitButton;
    }
}

