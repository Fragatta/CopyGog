namespace CopyToUsb
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
			this.btnSelectFiles = new System.Windows.Forms.Button();
			this.getFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.lblFilesFound = new System.Windows.Forms.Label();
			this.lblFolderPath = new System.Windows.Forms.Label();
			this.lblFoldersFound = new System.Windows.Forms.Label();
			this.grpSource = new System.Windows.Forms.GroupBox();
			this.lblFolderSize = new System.Windows.Forms.Label();
			this.grpTarget = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chkClearRootFiles = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCleanFilter = new System.Windows.Forms.TextBox();
			this.chkShowLog = new System.Windows.Forms.CheckBox();
			this.chkOverwrite = new System.Windows.Forms.CheckBox();
			this.chkExtract = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRelativePath = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.chkUsbDevices = new System.Windows.Forms.CheckBox();
			this.lstTargets = new System.Windows.Forms.CheckedListBox();
			this.btnReloadTarget = new System.Windows.Forms.Button();
			this.btnCopyFolder = new System.Windows.Forms.Button();
			this.grpSource.SuspendLayout();
			this.grpTarget.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSelectFiles
			// 
			this.btnSelectFiles.Location = new System.Drawing.Point(6, 14);
			this.btnSelectFiles.Name = "btnSelectFiles";
			this.btnSelectFiles.Size = new System.Drawing.Size(92, 46);
			this.btnSelectFiles.TabIndex = 0;
			this.btnSelectFiles.Text = "Select Folder";
			this.btnSelectFiles.UseVisualStyleBackColor = true;
			this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
			// 
			// getFolderDialog
			// 
			this.getFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.getFolderDialog.ShowNewFolderButton = false;
			// 
			// lblFilesFound
			// 
			this.lblFilesFound.AutoSize = true;
			this.lblFilesFound.Location = new System.Drawing.Point(104, 31);
			this.lblFilesFound.Name = "lblFilesFound";
			this.lblFilesFound.Size = new System.Drawing.Size(61, 13);
			this.lblFilesFound.TabIndex = 1;
			this.lblFilesFound.Text = "Files found:";
			// 
			// lblFolderPath
			// 
			this.lblFolderPath.Location = new System.Drawing.Point(5, 63);
			this.lblFolderPath.Name = "lblFolderPath";
			this.lblFolderPath.Size = new System.Drawing.Size(249, 32);
			this.lblFolderPath.TabIndex = 2;
			this.lblFolderPath.Text = "Select a folder!";
			// 
			// lblFoldersFound
			// 
			this.lblFoldersFound.AutoSize = true;
			this.lblFoldersFound.Location = new System.Drawing.Point(104, 14);
			this.lblFoldersFound.Name = "lblFoldersFound";
			this.lblFoldersFound.Size = new System.Drawing.Size(74, 13);
			this.lblFoldersFound.TabIndex = 3;
			this.lblFoldersFound.Text = "Folders found:";
			// 
			// grpSource
			// 
			this.grpSource.Controls.Add(this.lblFolderSize);
			this.grpSource.Controls.Add(this.btnSelectFiles);
			this.grpSource.Controls.Add(this.lblFoldersFound);
			this.grpSource.Controls.Add(this.lblFilesFound);
			this.grpSource.Controls.Add(this.lblFolderPath);
			this.grpSource.Location = new System.Drawing.Point(12, 12);
			this.grpSource.Name = "grpSource";
			this.grpSource.Size = new System.Drawing.Size(260, 98);
			this.grpSource.TabIndex = 4;
			this.grpSource.TabStop = false;
			this.grpSource.Text = "Source";
			// 
			// lblFolderSize
			// 
			this.lblFolderSize.AutoSize = true;
			this.lblFolderSize.Location = new System.Drawing.Point(104, 47);
			this.lblFolderSize.Name = "lblFolderSize";
			this.lblFolderSize.Size = new System.Drawing.Size(57, 13);
			this.lblFolderSize.TabIndex = 4;
			this.lblFolderSize.Text = "Total Size:";
			// 
			// grpTarget
			// 
			this.grpTarget.Controls.Add(this.label4);
			this.grpTarget.Controls.Add(this.label3);
			this.grpTarget.Controls.Add(this.chkClearRootFiles);
			this.grpTarget.Controls.Add(this.label2);
			this.grpTarget.Controls.Add(this.txtCleanFilter);
			this.grpTarget.Controls.Add(this.chkShowLog);
			this.grpTarget.Controls.Add(this.chkOverwrite);
			this.grpTarget.Controls.Add(this.chkExtract);
			this.grpTarget.Controls.Add(this.label1);
			this.grpTarget.Controls.Add(this.txtRelativePath);
			this.grpTarget.Controls.Add(this.button1);
			this.grpTarget.Controls.Add(this.chkUsbDevices);
			this.grpTarget.Controls.Add(this.lstTargets);
			this.grpTarget.Controls.Add(this.btnReloadTarget);
			this.grpTarget.Location = new System.Drawing.Point(12, 116);
			this.grpTarget.Name = "grpTarget";
			this.grpTarget.Size = new System.Drawing.Size(260, 306);
			this.grpTarget.TabIndex = 5;
			this.grpTarget.TabStop = false;
			this.grpTarget.Text = "Target";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 282);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(219, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "(e.g. temp*.txt;*.pdf) Leave blank to delete all";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(61, 269);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(193, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Semi-colon seperated list with wildcards";
			// 
			// chkClearRootFiles
			// 
			this.chkClearRootFiles.AutoSize = true;
			this.chkClearRootFiles.Location = new System.Drawing.Point(161, 200);
			this.chkClearRootFiles.Name = "chkClearRootFiles";
			this.chkClearRootFiles.Size = new System.Drawing.Size(99, 17);
			this.chkClearRootFiles.TabIndex = 13;
			this.chkClearRootFiles.Text = "Delete root files";
			this.chkClearRootFiles.UseVisualStyleBackColor = true;
			this.chkClearRootFiles.CheckedChanged += new System.EventHandler(this.chkFormatTargets_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 249);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Clean Filter:";
			// 
			// txtCleanFilter
			// 
			this.txtCleanFilter.Enabled = false;
			this.txtCleanFilter.Location = new System.Drawing.Point(88, 246);
			this.txtCleanFilter.Name = "txtCleanFilter";
			this.txtCleanFilter.Size = new System.Drawing.Size(166, 20);
			this.txtCleanFilter.TabIndex = 11;
			// 
			// chkShowLog
			// 
			this.chkShowLog.AutoSize = true;
			this.chkShowLog.Checked = true;
			this.chkShowLog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowLog.Location = new System.Drawing.Point(161, 182);
			this.chkShowLog.Name = "chkShowLog";
			this.chkShowLog.Size = new System.Drawing.Size(74, 17);
			this.chkShowLog.TabIndex = 10;
			this.chkShowLog.Text = "Show Log";
			this.chkShowLog.UseVisualStyleBackColor = true;
			// 
			// chkOverwrite
			// 
			this.chkOverwrite.AutoSize = true;
			this.chkOverwrite.Checked = true;
			this.chkOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOverwrite.Location = new System.Drawing.Point(6, 182);
			this.chkOverwrite.Name = "chkOverwrite";
			this.chkOverwrite.Size = new System.Drawing.Size(130, 17);
			this.chkOverwrite.TabIndex = 9;
			this.chkOverwrite.Text = "Overwrite existing files";
			this.chkOverwrite.UseVisualStyleBackColor = true;
			// 
			// chkExtract
			// 
			this.chkExtract.AutoSize = true;
			this.chkExtract.Checked = true;
			this.chkExtract.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkExtract.Location = new System.Drawing.Point(6, 200);
			this.chkExtract.Name = "chkExtract";
			this.chkExtract.Size = new System.Drawing.Size(131, 17);
			this.chkExtract.TabIndex = 8;
			this.chkExtract.Text = "Extract selected folder";
			this.chkExtract.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 226);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Relative Path:";
			// 
			// txtRelativePath
			// 
			this.txtRelativePath.Location = new System.Drawing.Point(88, 223);
			this.txtRelativePath.Name = "txtRelativePath";
			this.txtRelativePath.Size = new System.Drawing.Size(166, 20);
			this.txtRelativePath.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(8, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Add Target";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// chkUsbDevices
			// 
			this.chkUsbDevices.AutoSize = true;
			this.chkUsbDevices.Checked = true;
			this.chkUsbDevices.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUsbDevices.Enabled = false;
			this.chkUsbDevices.Location = new System.Drawing.Point(8, 19);
			this.chkUsbDevices.Name = "chkUsbDevices";
			this.chkUsbDevices.Size = new System.Drawing.Size(90, 17);
			this.chkUsbDevices.TabIndex = 4;
			this.chkUsbDevices.Text = "USB Devices";
			this.chkUsbDevices.UseVisualStyleBackColor = true;
			// 
			// lstTargets
			// 
			this.lstTargets.CheckOnClick = true;
			this.lstTargets.FormattingEnabled = true;
			this.lstTargets.Location = new System.Drawing.Point(8, 67);
			this.lstTargets.Name = "lstTargets";
			this.lstTargets.Size = new System.Drawing.Size(246, 109);
			this.lstTargets.TabIndex = 3;
			this.lstTargets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstTargets_ItemCheck);
			// 
			// btnReloadTarget
			// 
			this.btnReloadTarget.Location = new System.Drawing.Point(200, 12);
			this.btnReloadTarget.Name = "btnReloadTarget";
			this.btnReloadTarget.Size = new System.Drawing.Size(54, 23);
			this.btnReloadTarget.TabIndex = 1;
			this.btnReloadTarget.Text = "Refresh";
			this.btnReloadTarget.UseVisualStyleBackColor = true;
			this.btnReloadTarget.Click += new System.EventHandler(this.btnReloadTarget_Click);
			// 
			// btnCopyFolder
			// 
			this.btnCopyFolder.Enabled = false;
			this.btnCopyFolder.Location = new System.Drawing.Point(12, 428);
			this.btnCopyFolder.Name = "btnCopyFolder";
			this.btnCopyFolder.Size = new System.Drawing.Size(260, 34);
			this.btnCopyFolder.TabIndex = 6;
			this.btnCopyFolder.Text = "Copy Folder";
			this.btnCopyFolder.UseVisualStyleBackColor = true;
			this.btnCopyFolder.Click += new System.EventHandler(this.btnCopyFolder_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 474);
			this.Controls.Add(this.btnCopyFolder);
			this.Controls.Add(this.grpTarget);
			this.Controls.Add(this.grpSource);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "CopyGog";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.grpSource.ResumeLayout(false);
			this.grpSource.PerformLayout();
			this.grpTarget.ResumeLayout(false);
			this.grpTarget.PerformLayout();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button btnSelectFiles;
		private System.Windows.Forms.FolderBrowserDialog getFolderDialog;
		private System.Windows.Forms.Label lblFilesFound;
		private System.Windows.Forms.Label lblFolderPath;
		private System.Windows.Forms.Label lblFoldersFound;
		private System.Windows.Forms.GroupBox grpSource;
		private System.Windows.Forms.GroupBox grpTarget;
		private System.Windows.Forms.Button btnCopyFolder;
		private System.Windows.Forms.Button btnReloadTarget;
		private System.Windows.Forms.CheckBox chkUsbDevices;
		private System.Windows.Forms.CheckedListBox lstTargets;
		private System.Windows.Forms.Label lblFolderSize;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtRelativePath;
		private System.Windows.Forms.CheckBox chkExtract;
		private System.Windows.Forms.CheckBox chkOverwrite;
		private System.Windows.Forms.CheckBox chkShowLog;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCleanFilter;
		private System.Windows.Forms.CheckBox chkClearRootFiles;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}

