
namespace ServiceInstaller
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblVersion = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnRefreshLog = new System.Windows.Forms.Button();
            this.chkLastLog100 = new System.Windows.Forms.CheckBox();
            this.btnAssemblyInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPath.Location = new System.Drawing.Point(12, 332);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(634, 19);
            this.txtPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowse.Location = new System.Drawing.Point(652, 330);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(78, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(442, 403);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(99, 39);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUninstall.Enabled = false;
            this.btnUninstall.Location = new System.Drawing.Point(547, 403);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(99, 39);
            this.btnUninstall.TabIndex = 3;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // lblServiceName
            // 
            this.lblServiceName.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblServiceName.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceName.ForeColor = System.Drawing.Color.White;
            this.lblServiceName.Location = new System.Drawing.Point(12, 9);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(620, 78);
            this.lblServiceName.TabIndex = 5;
            this.lblServiceName.Text = "RemoveRegisterKeyService";
            this.lblServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStopService
            // 
            this.btnStopService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStopService.Enabled = false;
            this.btnStopService.Location = new System.Drawing.Point(547, 444);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(99, 39);
            this.btnStopService.TabIndex = 9;
            this.btnStopService.Text = "Stop Service";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartService.Enabled = false;
            this.btnStartService.Location = new System.Drawing.Point(442, 444);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(99, 39);
            this.btnStartService.TabIndex = 8;
            this.btnStartService.Text = "Start Service";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(652, 362);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 121);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 362);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(424, 147);
            this.dataGridView1.TabIndex = 14;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.Location = new System.Drawing.Point(442, 485);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(287, 24);
            this.lblVersion.TabIndex = 15;
            this.lblVersion.Text = "Ver.";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 97);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(717, 225);
            this.dataGridView2.TabIndex = 16;
            // 
            // btnRefreshLog
            // 
            this.btnRefreshLog.Location = new System.Drawing.Point(638, 31);
            this.btnRefreshLog.Name = "btnRefreshLog";
            this.btnRefreshLog.Size = new System.Drawing.Size(92, 56);
            this.btnRefreshLog.TabIndex = 17;
            this.btnRefreshLog.Text = "Fetch Log";
            this.btnRefreshLog.UseVisualStyleBackColor = true;
            this.btnRefreshLog.Click += new System.EventHandler(this.btnRefreshLog_Click);
            // 
            // chkLastLog100
            // 
            this.chkLastLog100.AutoSize = true;
            this.chkLastLog100.Location = new System.Drawing.Point(641, 11);
            this.chkLastLog100.Name = "chkLastLog100";
            this.chkLastLog100.Size = new System.Drawing.Size(84, 16);
            this.chkLastLog100.TabIndex = 18;
            this.chkLastLog100.Text = "Lastest 100";
            this.chkLastLog100.UseVisualStyleBackColor = true;
            // 
            // btnAssemblyInfo
            // 
            this.btnAssemblyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAssemblyInfo.Location = new System.Drawing.Point(442, 362);
            this.btnAssemblyInfo.Name = "btnAssemblyInfo";
            this.btnAssemblyInfo.Size = new System.Drawing.Size(204, 39);
            this.btnAssemblyInfo.TabIndex = 19;
            this.btnAssemblyInfo.Text = "Fetch File Infomation";
            this.btnAssemblyInfo.UseVisualStyleBackColor = true;
            this.btnAssemblyInfo.Click += new System.EventHandler(this.btnAssemblyInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 521);
            this.Controls.Add(this.btnAssemblyInfo);
            this.Controls.Add(this.chkLastLog100);
            this.Controls.Add(this.btnRefreshLog);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.lblServiceName);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.MinimumSize = new System.Drawing.Size(760, 560);
            this.Name = "Form1";
            this.Text = "Service Installer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnRefreshLog;
        private System.Windows.Forms.CheckBox chkLastLog100;
        private System.Windows.Forms.Button btnAssemblyInfo;
    }
}

