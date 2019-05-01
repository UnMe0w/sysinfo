// Filename: StorageInfo.cs
// Contains functions to extract information displayed in Storage category

using System;
using System.IO;
using System.Diagnostics;

namespace Sysinfo {
	
	public class StorageInfo {
		
		//global variables
		public String [] ide_hda = {null, null, null, null};
		public String [] ide_hdb = {null, null, null, null};
		public String [] ide_hdc = {null, null, null, null};
		public String [] ide_hdd = {null, null, null, null};

		public String []  scsi_1 = {null, null, null};
		public String []  scsi_2 = {null, null, null};
		public String []  scsi_3 = {null, null, null};
		public String []  scsi_4 = {null, null, null};
		
		public String ide_interface = "unknown";
		
		//read ide info
		public void IdeInfo() {
			
			String temp;
			String letter = "a";
			
			for ( int i = 1; i < 5; i++ ) {
				
				try {
										
					//media
					if ( File.Exists("/proc/ide/hd" + letter + "/media") ) {
						using (TextReader textread = File.OpenText("/proc/ide/hd" + letter + "/media")) {
								
							temp = textread.ReadLine();
							
							if ( letter == "a" )
								ide_hda [0] = temp;
							if ( letter == "b" )
								ide_hdb [0] = temp;
							if ( letter == "c" )
								ide_hdc [0] = temp;
							if ( letter == "d" )
								ide_hdd [0] = temp;
						}
					}

					//model
					if ( File.Exists("/proc/ide/hd" + letter + "/model") ) {
						using (TextReader textread = File.OpenText("/proc/ide/hd" + letter + "/model")) {
								
							temp = textread.ReadLine();
							
							if ( letter == "a" )
								ide_hda [1] = temp;
							if ( letter == "b" )
								ide_hdb [1] = temp;
							if ( letter == "c" )
								ide_hdc [1] = temp;
							if ( letter == "d" )
								ide_hdd [1] = temp;
						}
					}
					
					//capacity
					if ( File.Exists("/proc/ide/hd" + letter + "/capacity") ) {
						using (TextReader textread = File.OpenText("/proc/ide/hd" + letter + "/capacity")) {
								
							temp = textread.ReadLine();
							
							if ( letter == "a" ) {
								
								temp = ( Double.Parse(temp) / 2000).ToString();
								
								if ( Double.Parse(temp) < 1000) {
									
									if ( Double.Parse(temp) <= 1 )
										ide_hda [2] = "no media";
									else {
										temp = Double.Parse(temp).ToString("#.#");
										ide_hda [2] = temp + " MB";
									}
								}
								else {
									
									temp = ( Double.Parse(temp) / 1000).ToString();
									ide_hda [2] = Double.Parse(temp).ToString("#.#") + " GB";
								}
							}
							
							if ( letter == "b" ) {
								
								temp = ( Double.Parse(temp) / 2000).ToString();
								
								if ( Double.Parse(temp) < 1000) {
									
									if ( Double.Parse(temp) <= 1 )
										ide_hdb [2] = "no media";
									else {
										temp = Double.Parse(temp).ToString("#.#");
										ide_hdb [2] = temp + " MB";
									}
								}
								else {
									
									temp = ( Double.Parse(temp) / 1000).ToString();
									ide_hdb [2] = Double.Parse(temp).ToString("#.#") + " GB";
								}
							}
							
							if ( letter == "c" ) {
								
								temp = ( Double.Parse(temp) / 2000).ToString();
								
								if ( Double.Parse(temp) < 1000) {
									
									if ( Double.Parse(temp) <= 1 )
										ide_hdc [2] = "no media";
									else {
										temp = Double.Parse(temp).ToString("#.#");
										ide_hdc [2] = temp + " MB";
									}
								}
								else {
									
									temp = ( Double.Parse(temp) / 1000).ToString();
									ide_hdc [2] = Double.Parse(temp).ToString("#.#") + " GB";
								}
							}
							
							if ( letter == "d" ) {
								
								temp = ( Double.Parse(temp) / 2000).ToString();
								
								if ( Double.Parse(temp) < 1000) {
									
									if ( Double.Parse(temp) <= 1 )
										ide_hdd [2] = "no media";
									else {
										temp = Double.Parse(temp).ToString("#.#");
										ide_hdd [2] = temp + " MB";
									}
								}
								else {
									
									temp = ( Double.Parse(temp) / 1000).ToString();
									ide_hdd [2] = Double.Parse(temp).ToString("#.#") + " GB";
								}
							}
							
						}
					}
					
					//cache
					if ( File.Exists("/proc/ide/hd" + letter + "/cache") ) {
						using (TextReader textread = File.OpenText("/proc/ide/hd" + letter + "/cache")) {
								
							temp = textread.ReadLine();
							
							if ( letter == "a" ) {
								
								temp = ( Double.Parse(temp) / 1000).ToString();
								ide_hda [3] = temp + " MB";
							}
							
							if ( letter == "b" ) {
								
								temp = ( Double.Parse(temp) / 1000).ToString();
								ide_hdb [3] = temp + " MB";
							}
							
							if ( letter == "c" ) {
								
								temp = ( Double.Parse(temp) / 1000).ToString();
								ide_hdc [3] = temp + " MB";
							}
							
							if ( letter == "d" ) {
								
								temp = ( Double.Parse(temp) / 1000).ToString();
								ide_hdd [3] = temp + " MB";
							}
							
						}
					}
					
					if ( i == 1 ) letter = "b";
					if ( i == 2 ) letter = "c";
					if ( i == 3 ) letter = "d";
				}
				catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
				catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }

			}
		}
		
		//read scsi info
		public void ScsiInfo() {
			
			String temp, temp2;
			Int32 hostN = 1;
			Int32 vendorN = 1;
			Int32 modelN = 1;
							
			try {
										
				//scsi
				if ( File.Exists("/proc/scsi/scsi") ) {
					using (TextReader textread = File.OpenText("/proc/scsi/scsi")) {
						
						scsi_1[0] = null;
						scsi_2[0] = null;
						scsi_3[0] = null;
						scsi_4[0] = null;
						
						while ( textread.Peek() != (-1)  ) {

							temp = textread.ReadLine();

							if ( temp.StartsWith("Host:") ) {
								
								temp = temp.Remove(0, 5);
								temp = temp.Remove(6, temp.Length - 6);

								if ( hostN == 1 ) scsi_1[0] = temp;
								if ( hostN == 2 ) scsi_2[0] = temp;
								if ( hostN == 3 ) scsi_3[0] = temp;
								if ( hostN == 4 ) 	scsi_4[0] = temp;

								hostN++;
							}
							
							if ( temp.StartsWith("  Vendor:") ) {
								
								temp2 = temp;
								
								temp = temp.Remove(0, 9);
								temp = temp.Remove(temp.IndexOf("Model:"), temp.Length - temp.IndexOf("Model:"));
								
								if ( vendorN == 1 ) scsi_1[1] = temp;
								if ( vendorN == 2 ) scsi_2[1] = temp;
								if ( vendorN == 3 ) scsi_3[1] = temp;
								if ( vendorN == 4 ) 	scsi_4[1] = temp;
								
								temp2 = temp2.Remove(0, temp2.IndexOf("Model:") + 6 );
								temp2 = temp2.Remove(temp2.IndexOf("Rev:"), temp2.Length - temp2.IndexOf("Rev:"));
								
								if ( modelN == 1 ) scsi_1[2] = temp2;
								if ( modelN == 2 ) scsi_2[2] = temp2;
								if ( modelN == 3 ) scsi_3[2] = temp2;
								if ( modelN == 4 ) 	scsi_4[2] = temp2;
								
								vendorN++;
								modelN++;
							}

						}
					}
					
				}
			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
		}
	
	}
}

//ghaefb
