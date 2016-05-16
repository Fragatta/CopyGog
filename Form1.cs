using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CopyToUsb
{
	public partial class Form1 : Form
	{
		#region CONSTRUCTION

		public Form1 ()
		{
			InitializeComponent ();
			RefreshTargets ();
		}

		#endregion

		#region PROPERTIES

		public DirectoryInfo SelectedFolder { get; private set; }
		public long FreeBytesRequired { get; private set; }

		#endregion

		#region PRIVATE METHODS

		private void RefreshTargets ()
		{
			var prevTargets = lstTargets.Items.OfType<DriveItem> ().ToList ();
			lstTargets.Items.Clear ();
			if (chkUsbDevices.Checked == true)
			{
				foreach (var drive in DriveInfo.GetDrives ())//.Where (x => x.DriveType == DriveType.Removable))
				{
					// Keep checkState of old items, default to checked for new items
					var checkState = prevTargets.FirstOrDefault (x => x.DriveInfo.Name == drive.Name)?.IsTarget ?? true;
					// IsTarget updated by event
					lstTargets.Items.Add (new DriveItem (drive), checkState);
				}
			}
		}

		private void SetSelectedFolder (string folderPath)
		{
			SelectedFolder = new DirectoryInfo (folderPath);
			if (SelectedFolder.Exists == false)
			{
				MessageBox.Show ("Unable to find folder, please try again.");
				SelectedFolder = null;
				btnCopyFolder.Enabled = false;
				return;
			}
			var files = SelectedFolder.GetFiles ("*", SearchOption.AllDirectories);
			var folderCount = SelectedFolder.EnumerateDirectories ("*", SearchOption.AllDirectories).Count ();

			lblFolderPath.Text = folderPath;
			lblFoldersFound.Text = $"Folders found: {folderCount}";
			lblFilesFound.Text = $"Files found: {files.Count ()}";

			FreeBytesRequired = files.Sum (x => x.Length);
			var sizeMb = (FreeBytesRequired / 1024.0) / 1024.0;
			lblFolderSize.Text = $"Total size: {sizeMb.ToString ("N")} MB";
			foreach (var drive in lstTargets.Items.OfType<DriveItem> ().Where (x => x.DriveInfo.AvailableFreeSpace < FreeBytesRequired).ToList ())
			{
				lstTargets.SetItemChecked (lstTargets.Items.IndexOf (drive), false);
			}
			btnCopyFolder.Enabled = true;
		}

		private void ClearSelectedFolder ()
		{
			SelectedFolder = null;
			lblFilesFound.ResetText ();
			lblFolderPath.ResetText ();
			lblFoldersFound.ResetText ();
			lblFolderSize.ResetText ();
			btnCopyFolder.Enabled = false;
		}

		#endregion

		#region COPY LOGIC

		private void CopyFolder ()
		{
			var targets = new List<string> ();

			SelectedFolder.Refresh ();
			if (SelectedFolder.Exists == false)
			{
				MessageBox.Show ("Selected folder doesn't exist anymore, what are you playing at?");
				ClearSelectedFolder ();
				return;
			}

			var resultLog = (chkShowLog.Checked == true) ? new Results () : null;
			if (resultLog != null)
			{
				resultLog.Show (this);
			}

			foreach (var item in lstTargets.Items.OfType<DriveItem> ().Where (x => x.IsTarget))
			{
				try
				{
					var sourceFolder = SelectedFolder;
					var targetPath = Path.Combine (item.DriveInfo.RootDirectory.FullName, txtRelativePath.Text);

					if (chkClearRootFiles.Checked == true)
					{
						var filters = string.IsNullOrWhiteSpace (txtCleanFilter.Text) ? new string[] { "*" } : txtCleanFilter.Text.Split (';');
						var files = filters.SelectMany (filter => item.DriveInfo.RootDirectory.GetFiles (filter, SearchOption.TopDirectoryOnly)).Where (x => x.Attributes == FileAttributes.Normal || x.Attributes == FileAttributes.Archive);
						if (files.Any ())
						{
							var result = MessageBox.Show ($"Warning: Clean filter is about to remove {files.Count ()} files from {item.DriveInfo.Name}, continue with this target?", "WARNING", MessageBoxButtons.YesNoCancel);
							switch (result)
							{
								case DialogResult.No:
									continue;
								case DialogResult.Cancel:
									return;
							}
							foreach (var file in files)
							{
								try
								{
									file.Delete ();
									Log (resultLog, $"Deleted {file.FullName}");
								}
								catch (Exception ex)
								{
									Log (resultLog, $"Error deleting {file.FullName}: {ex.Message}");
								}
							}
						}
					}

					if (chkExtract.Checked == false)
					{
						targetPath = Path.Combine (targetPath, sourceFolder.Name);
					}
					var targetFolder = new DirectoryInfo (targetPath);
					Log (resultLog, $"Copying files from {sourceFolder.FullName} to {targetPath}");
					if (targetFolder.Exists == false)
					{
						Log (resultLog, $"Creating {targetPath} as it doesn't exist");
						targetFolder.Create ();
						targetFolder.Refresh ();
					}

					if (targetFolder.Exists == false)
					{
						Log (resultLog, $"ERROR: Error creating directory, continuing to next target");
						MessageBox.Show ($"Error creating directory: '{targetPath}', continuing to next target");
						continue;
					}

					CopyFilesFromDirectory (sourceFolder, targetFolder, resultLog);
				}
				catch (UnauthorizedAccessException ex)
				{
					Log (resultLog, $"An unauthorized exception occurred: " + ex.Message);
					MessageBox.Show ("An unauthorized exception occurred (you may need to run as admin or you're doing something weird): " + ex.Message);
					continue;
				}
				catch (Exception ex)
				{
					Log (resultLog, $"An unexpected error occurred: " + ex.Message);
					MessageBox.Show ("Uh oops, an unexpected error occurred: " + ex.Message);
					continue;
				}
			}

			Log (resultLog, $"Completed copying files!");
			MessageBox.Show ("Completed copying the files to the targets! Have a great day!");
		}

		private void CopyFilesFromDirectory (DirectoryInfo source, DirectoryInfo target, Results resultLog)
		{
			foreach (var file in source.GetFiles ())
			{
				try
				{
					var targetFile = new FileInfo (Path.Combine (target.FullName, file.Name));
					if (targetFile.Exists)
					{
						if (chkOverwrite.Checked == false)
						{
							Log (resultLog, $"Skipping {targetFile.FullName} as it already exists and Overwrite files is not checked");
							continue;
						}
						else
						{
							Log (resultLog, $"Overwriting file {targetFile.FullName}");
							file.CopyTo (targetFile.FullName, true);
						}
					}
					else
					{
						Log (resultLog, $"Copying file to {targetFile.FullName}");
						file.CopyTo (targetFile.FullName, false);
					}
				}
				catch (Exception e)
				{
					Log (resultLog, $"Error copying file: {e.Message}");
					continue;
				}
			}
			foreach (var subSource in source.GetDirectories ())
			{
				var subTarget = new DirectoryInfo (Path.Combine (target.FullName, subSource.Name));
				if (subTarget.Exists == false)
				{
					Log (resultLog, $"Creating {subTarget.FullName} as it doesn't exist");
					subTarget.Create ();
				}
				// LET THE RECURSION FLOW THROUGH YOU! WE DON'T NEED NO BASE CASE WHERE WE'RE GOING!
				CopyFilesFromDirectory (subSource, subTarget, resultLog);
			}
		}

		private void Log (Results results, string value)
		{
			if (results != null)
			{
				var time = DateTime.Now;
				results.AddLine (string.Format ("[{0}] {1}", time.ToLongTimeString (), value));
			}
		}

		#endregion

		#region EVENT HANDLERS

		private void btnSelectFiles_Click (object sender, EventArgs e)
		{
			if (getFolderDialog.ShowDialog () == DialogResult.OK)
			{
				SetSelectedFolder (getFolderDialog.SelectedPath);
			}
		}

		private void btnReloadTarget_Click (object sender, EventArgs e)
		{
			RefreshTargets ();
		}

		private void btnCopyFolder_Click (object sender, EventArgs e)
		{
			CopyFolder ();
		}

		private void chkFormatTargets_CheckedChanged (object sender, EventArgs e)
		{
			if (chkClearRootFiles.Checked == true)
			{
				MessageBox.Show ($"WARNING: This will delete all files and folders from all targets! Double-check you are not deleting anything important, it will not be recoverable!");
			}
		}

		private void Form1_DragDrop (object sender, DragEventArgs e)
		{
			var data = e.Data.GetData (DataFormats.FileDrop, true) as string[];
			if (data?.Length != 1)
			{
				return;
			}

			SetSelectedFolder (data[0]);
		}

		private void Form1_DragEnter (object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.None;
			if (!e.Data.GetDataPresent (DataFormats.FileDrop))
			{
				return;
			}
			var fileList = ((string[])e.Data.GetData (DataFormats.FileDrop));
			if (fileList.Length != 1)
			{
				return;
			}

			if (!Directory.Exists (fileList[0]))
			{
				return;
			}

			e.Effect = DragDropEffects.Copy;
		}

		private void lstTargets_ItemCheck (object sender, ItemCheckEventArgs e)
		{
			var item = lstTargets.Items[e.Index] as DriveItem;
			if (item != null)
			{
				if (e.NewValue == CheckState.Checked && item.DriveInfo.AvailableFreeSpace < FreeBytesRequired)
				{
					if (MessageBox.Show ($"This target doesn't have enough space, setting this as a target is not recommended! Continue anyway?", "Whoa mate", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						e.NewValue = CheckState.Unchecked;
					}
				}
				item.IsTarget = e.NewValue == CheckState.Checked;
			}
		}

		#endregion
	}
}
