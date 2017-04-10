namespace SqlServerTableReaderApplication
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
            this.gb_Info = new System.Windows.Forms.GroupBox();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.gbx_Server = new System.Windows.Forms.GroupBox();
            this.cmb_Server = new System.Windows.Forms.ComboBox();
            this.btn_ConnectToServer = new System.Windows.Forms.Button();
            this.gbx_Table = new System.Windows.Forms.GroupBox();
            this.cmb_Table = new System.Windows.Forms.ComboBox();
            this.gbx_Database = new System.Windows.Forms.GroupBox();
            this.cmb_Database = new System.Windows.Forms.ComboBox();
            this.gbx_Content = new System.Windows.Forms.GroupBox();
            this.dgv_TableContent = new System.Windows.Forms.DataGridView();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.gb_Info.SuspendLayout();
            this.gbx_Server.SuspendLayout();
            this.gbx_Table.SuspendLayout();
            this.gbx_Database.SuspendLayout();
            this.gbx_Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TableContent)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Info
            // 
            this.gb_Info.Controls.Add(this.lbl_Info);
            this.gb_Info.Location = new System.Drawing.Point(10, 0);
            this.gb_Info.Name = "gb_Info";
            this.gb_Info.Size = new System.Drawing.Size(700, 50);
            this.gb_Info.TabIndex = 0;
            this.gb_Info.TabStop = false;
            this.gb_Info.Text = "Info";
            // 
            // lbl_Info
            // 
            this.lbl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(10, 20);
            this.lbl_Info.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(0, 13);
            this.lbl_Info.TabIndex = 0;
            // 
            // gbx_Server
            // 
            this.gbx_Server.Controls.Add(this.cmb_Server);
            this.gbx_Server.Controls.Add(this.btn_ConnectToServer);
            this.gbx_Server.Location = new System.Drawing.Point(10, 56);
            this.gbx_Server.Name = "gbx_Server";
            this.gbx_Server.Size = new System.Drawing.Size(317, 60);
            this.gbx_Server.TabIndex = 1;
            this.gbx_Server.TabStop = false;
            this.gbx_Server.Text = "Server";
            // 
            // cmb_Server
            // 
            this.cmb_Server.FormattingEnabled = true;
            this.cmb_Server.Location = new System.Drawing.Point(98, 21);
            this.cmb_Server.Name = "cmb_Server";
            this.cmb_Server.Size = new System.Drawing.Size(213, 21);
            this.cmb_Server.TabIndex = 1;
            this.cmb_Server.SelectedValueChanged += new System.EventHandler(this.cmb_Server_SelectedValueChanged);
            // 
            // btn_ConnectToServer
            // 
            this.btn_ConnectToServer.Location = new System.Drawing.Point(6, 19);
            this.btn_ConnectToServer.Name = "btn_ConnectToServer";
            this.btn_ConnectToServer.Size = new System.Drawing.Size(86, 23);
            this.btn_ConnectToServer.TabIndex = 0;
            this.btn_ConnectToServer.Text = "Connect";
            this.btn_ConnectToServer.UseVisualStyleBackColor = true;
            this.btn_ConnectToServer.Click += new System.EventHandler(this.btn_ConnectToServer_Click);
            // 
            // gbx_Table
            // 
            this.gbx_Table.Controls.Add(this.cmb_Table);
            this.gbx_Table.Location = new System.Drawing.Point(526, 56);
            this.gbx_Table.Name = "gbx_Table";
            this.gbx_Table.Size = new System.Drawing.Size(184, 60);
            this.gbx_Table.TabIndex = 2;
            this.gbx_Table.TabStop = false;
            this.gbx_Table.Text = "Table";
            // 
            // cmb_Table
            // 
            this.cmb_Table.FormattingEnabled = true;
            this.cmb_Table.Location = new System.Drawing.Point(6, 21);
            this.cmb_Table.Name = "cmb_Table";
            this.cmb_Table.Size = new System.Drawing.Size(172, 21);
            this.cmb_Table.TabIndex = 3;
            this.cmb_Table.SelectedValueChanged += new System.EventHandler(this.cmb_Table_SelectedValueChanged);
            // 
            // gbx_Database
            // 
            this.gbx_Database.Controls.Add(this.cmb_Database);
            this.gbx_Database.Location = new System.Drawing.Point(333, 56);
            this.gbx_Database.Name = "gbx_Database";
            this.gbx_Database.Size = new System.Drawing.Size(187, 60);
            this.gbx_Database.TabIndex = 3;
            this.gbx_Database.TabStop = false;
            this.gbx_Database.Text = "Database";
            // 
            // cmb_Database
            // 
            this.cmb_Database.FormattingEnabled = true;
            this.cmb_Database.Location = new System.Drawing.Point(6, 21);
            this.cmb_Database.Name = "cmb_Database";
            this.cmb_Database.Size = new System.Drawing.Size(170, 21);
            this.cmb_Database.TabIndex = 2;
            this.cmb_Database.SelectedValueChanged += new System.EventHandler(this.cmb_Database_SelectedValueChanged);
            // 
            // gbx_Content
            // 
            this.gbx_Content.Controls.Add(this.dgv_TableContent);
            this.gbx_Content.Controls.Add(this.btn_Refresh);
            this.gbx_Content.Location = new System.Drawing.Point(10, 122);
            this.gbx_Content.Name = "gbx_Content";
            this.gbx_Content.Size = new System.Drawing.Size(700, 428);
            this.gbx_Content.TabIndex = 4;
            this.gbx_Content.TabStop = false;
            this.gbx_Content.Text = "Content";
            // 
            // dgv_TableContent
            // 
            this.dgv_TableContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TableContent.Location = new System.Drawing.Point(6, 48);
            this.dgv_TableContent.Name = "dgv_TableContent";
            this.dgv_TableContent.Size = new System.Drawing.Size(688, 374);
            this.dgv_TableContent.TabIndex = 1;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(6, 19);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(86, 23);
            this.btn_Refresh.TabIndex = 0;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // frmCRUDv2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 562);
            this.Controls.Add(this.gbx_Content);
            this.Controls.Add(this.gbx_Database);
            this.Controls.Add(this.gbx_Table);
            this.Controls.Add(this.gbx_Server);
            this.Controls.Add(this.gb_Info);
            this.Name = "frmCRUDv2";
            this.Text = "SQL SERVER DATA TABLE READER";
            this.gb_Info.ResumeLayout(false);
            this.gb_Info.PerformLayout();
            this.gbx_Server.ResumeLayout(false);
            this.gbx_Table.ResumeLayout(false);
            this.gbx_Database.ResumeLayout(false);
            this.gbx_Content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TableContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Info;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.GroupBox gbx_Server;
        private System.Windows.Forms.Button btn_ConnectToServer;
        private System.Windows.Forms.ComboBox cmb_Server;
        private System.Windows.Forms.GroupBox gbx_Table;
        private System.Windows.Forms.GroupBox gbx_Database;
        private System.Windows.Forms.ComboBox cmb_Table;
        private System.Windows.Forms.ComboBox cmb_Database;
        private System.Windows.Forms.GroupBox gbx_Content;
        private System.Windows.Forms.DataGridView dgv_TableContent;
        private System.Windows.Forms.Button btn_Refresh;
    }
}

