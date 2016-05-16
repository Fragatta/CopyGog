using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CopyToUsb
{
	public class DriveItem
	{
		public DriveItem (DriveInfo drive)
		{
			DriveInfo = drive;
		}

		public DriveInfo DriveInfo { get; }
		public bool IsTarget { get; set; }

		public override string ToString ()
		{
			var stringBuilder = new StringBuilder ();
			stringBuilder.Append (DriveInfo.Name);
			if (string.IsNullOrWhiteSpace (DriveInfo.VolumeLabel) == false)
			{
				stringBuilder.Append ($" - {DriveInfo.VolumeLabel}");
			}
			var mbFree = (DriveInfo.AvailableFreeSpace / 1024.0) / 1024.0; // b -> kb -> mb
			var freeSpace = (mbFree < 100)
				? $"{mbFree.ToString ("N")} MB"
				: $"{(mbFree / 1024.0).ToString ("N")} GB";
			var mbTotal = (DriveInfo.TotalSize / 1024.0) / 1024.0;
			var totalSpace = (mbTotal < 100)
				? $"{mbTotal.ToString ("N")} MB"
				: $"{(mbTotal / 1024.0).ToString ("N")} GB";
			stringBuilder.Append ($" ({freeSpace} free of {totalSpace})");
			return stringBuilder.ToString ();
		}
	}

}
