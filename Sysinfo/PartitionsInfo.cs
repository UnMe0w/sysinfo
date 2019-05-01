// Filename: PartitionsInfo.cs
// Contains functions to extract information displayed in Partitions category

using System;
using System.IO;
using System.Diagnostics;

namespace Sysinfo {
	
	public class PartitionsInfo {
		
		//global variables
		public Boolean hdaB = false;
		public String [] partitions_hda = {null, null, null, null, null, null, null, null, null};
		public Double [] partitions_hdaP = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		public Double [] partitions_hdaPc = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		
		public Boolean hdbB = false;
		public String [] partitions_hdb = {null, null, null, null, null, null, null, null, null};
		public Double [] partitions_hdbP = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		public Double [] partitions_hdbPc = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		
		public Boolean sdaB = false;
		public String [] partitions_sda = {null, null, null, null, null, null, null, null, null};
		public Double [] partitions_sdaP = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		public Double [] partitions_sdaPc = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		
		public Boolean sdbB = false;
		public String [] partitions_sdb = {null, null, null, null, null, null, null, null, null};
		public Double [] partitions_sdbP = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		public Double [] partitions_sdbPc = {0, 0, 0, 0, 0, 0, 0, 0, 0};
		
		//String partitions_path = "/home/ghaefb/devel/sysinfo_development/partitions_weird";
		String partitions_path = "/proc/partitions";
		
		/****/
		//hda
		public void PartitionsHda() {
			
			String temp;
			Int32 position = 1;
			hdaB = false;

			try {
					
				using (TextReader textread = File.OpenText(partitions_path)) {
						
					while ( textread.Peek() != (-1)  ) {
							
						temp = textread.ReadLine();
						
						if ( temp.EndsWith("hda") ) {
							
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("hda"), 3);
							partitions_hdaP[0] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {

								temp = Double.Parse(temp).ToString("#.#");
								partitions_hda[0] = temp + " MB";
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_hda[0] = temp + " GB";
							}
							
							hdaB = true;
						}
						
						if ( temp.EndsWith("hda" + position) ) {
							
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("hda" + position), 4);
							partitions_hdaP[position] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {

								if  ( Double.Parse(temp) <= 1 )
									partitions_hda[position] = "Extended";
								else {
									
									temp = Double.Parse(temp).ToString("#.#");
									partitions_hda[position] = temp + " MB";
								}
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_hda[position] = temp + " GB";
							}
							
							//Console.WriteLine("hda" + position + ": " + partitions_hda[position] );
							
							position++;
						}
						/*
						if ( temp.EndsWith("hda" + positionTemp) ) {
							
							position++;
							//Console.WriteLine("test");
						}*/
						
					}
				}

			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (IndexOutOfRangeException ex) {  Console.WriteLine( ex );  }

		}
		
		/****/
		//hdb
		public void PartitionsHdb() {
			
			String temp;
			Int32 position = 1;
			hdbB = false;

			try {
					
				using (TextReader textread = File.OpenText(partitions_path)) {
						
					while ( textread.Peek() != (-1)  ) {
							
						temp = textread.ReadLine();
							
						if ( temp.EndsWith("hdb") ) {
								
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("hdb"), 3);
							partitions_hdbP[0] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {

								temp = Double.Parse(temp).ToString("#.#");
								partitions_hdb[0] = temp + " MB";
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_hdb[0] = temp + " GB";
							}
							
							hdbB = true;
						}
							
						if ( temp.EndsWith("hdb" + position) ) {
							
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("hdb" + position), 4);
							partitions_hdbP[position] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {

								if  ( Double.Parse(temp) <= 1 )
									partitions_hdb[position] = "Extended";
								else {
									
									temp = Double.Parse(temp).ToString("#.#");
									partitions_hdb[position] = temp + " MB";
								}
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_hdb[position] = temp + " GB";
							}
							
							position++;
						}
						
					}
				}

			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (IndexOutOfRangeException ex) {  Console.WriteLine( ex );  }
			
		}
		
		/****/
		//sda
		public void PartitionsSda() {
			
			String temp;
			Int32 position = 1;
			sdaB = false;

			try {
					
				using (TextReader textread = File.OpenText(partitions_path)) {
						
					while ( textread.Peek() != (-1)  ) {
							
						temp = textread.ReadLine();
							
						if ( temp.EndsWith("sda") ) {
								
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("sda"), 3);
							partitions_sdaP[0] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {

								temp = Double.Parse(temp).ToString("#.#");
								partitions_sda[0] = temp + " MB";
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_sda[0] = temp + " GB";
							}
							
							sdaB = true;
						}
							
						if ( temp.EndsWith("sda" + position) ) {
							
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("sda" + position), 4);
							partitions_sdaP[position] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {

								if  ( Double.Parse(temp) <= 1 )
									partitions_sda[position] = "Extended";
								else {
									
									temp = Double.Parse(temp).ToString("#.#");
									partitions_sda[position] = temp + " MB";
								}
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_sda[position] = temp + " GB";
							}
							
							position++;
						}
						
					}
				}
				
			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (IndexOutOfRangeException ex) {  Console.WriteLine( ex );  }
			
		}
		
		
		/****/
		//sdb
		public void PartitionsSdb() {
			
			String temp;
			Int32 position = 1;
			sdbB = false;

			try {
					
				using (TextReader textread = File.OpenText(partitions_path)) {
						
					while ( textread.Peek() != (-1)  ) {
							
						temp = textread.ReadLine();
							
						if ( temp.EndsWith("sdb") ) {
								
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("sdb"), 3);
							partitions_sdbP[0] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {
								
								temp = Double.Parse(temp).ToString("#.#");
								partitions_sdb[0] = temp + " MB";
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_sdb[0] = temp + " GB";
							}
							
							sdbB = true;
						}
						else
							
						if ( temp.EndsWith("sdb" + position) ) {
							
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("sdb" + position), 4);
							partitions_sdbP[position] = Double.Parse(temp);
							temp = (Double.Parse(temp) / 1000).ToString();
							if ( Double.Parse(temp) < 1000 ) {

								if  ( Double.Parse(temp) <= 1 )
									partitions_sdb[position] = "Extended";
								else {
									
									temp = Double.Parse(temp).ToString("#.#");
									partitions_sdb[position] = temp + " MB";
								}
							}
							else {
								
								temp =  (Double.Parse(temp) / 1000).ToString();
								temp = Double.Parse(temp).ToString("#.#");
								partitions_sdb[position] = temp + " GB";
							}
							
							position++;
						}
						
					}
				}
				
			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (IndexOutOfRangeException ex) {  Console.WriteLine( ex );  }

		}
		
		//drawing calulations
		public void HdaDrawingCalculations(Int32 edge) {
			
			if ( hdaB == true ) {
				
				if ( partitions_hda[1] != null )
					partitions_hdaP[1] = (partitions_hdaPc[1] * edge);
				if ( partitions_hda[2] != null )
					partitions_hdaP[2] = (partitions_hdaPc[2] * edge);
				if ( partitions_hda[3] != null )
					partitions_hdaP[3] = (partitions_hdaPc[3] * edge);
				if ( partitions_hda[4] != null )
					partitions_hdaP[4] = (partitions_hdaPc[4] * edge);
				if ( partitions_hda[5] != null )
					partitions_hdaP[5] = (partitions_hdaPc[5] * edge);
				if ( partitions_hda[6] != null )
					partitions_hdaP[6] = (partitions_hdaPc[6] * edge);
				if ( partitions_hda[7] != null )
					partitions_hdaP[7] = (partitions_hdaPc[7] * edge);
				if ( partitions_hda[8] != null )
					partitions_hdaP[8] = (partitions_hdaPc[8] * edge);
				
				partitions_hdaP[0] = edge;
			}
		}//percentage calculations for drawing on window resize
		public void HdaCalculations() {
			
			if ( hdaB == true ) {
				
				if ( partitions_hda[1] != null )
					partitions_hdaPc[1] = partitions_hdaP[1] / partitions_hdaP[0];
				if ( partitions_hda[2] != null )
					partitions_hdaPc[2] = partitions_hdaP[2] / partitions_hdaP[0];
				if ( partitions_hda[3] != null )
					partitions_hdaPc[3] = partitions_hdaP[3] / partitions_hdaP[0];
				if ( partitions_hda[4] != null )
					partitions_hdaPc[4] = partitions_hdaP[4] / partitions_hdaP[0];
				if ( partitions_hda[5] != null )
					partitions_hdaPc[5] = partitions_hdaP[5] / partitions_hdaP[0];
				if ( partitions_hda[6] != null )
					partitions_hdaPc[6] = partitions_hdaP[6] / partitions_hdaP[0];
				if ( partitions_hda[7] != null )
					partitions_hdaPc[7] = partitions_hdaP[7] / partitions_hdaP[0];
				if ( partitions_hda[8] != null )
					partitions_hdaPc[8] = partitions_hdaP[8] / partitions_hdaP[0];
				
			}
		}
		
		public void HdbDrawingCalculations(Int32 edge) {
			
			if ( hdbB == true ) {
				
				if ( partitions_hdb[1] != null )
					partitions_hdbP[1] = (partitions_hdbPc[1] * edge);
				if ( partitions_hdb[2] != null )
					partitions_hdbP[2] = (partitions_hdbPc[2] * edge);
				if ( partitions_hdb[3] != null )
					partitions_hdbP[3] = (partitions_hdbPc[3] * edge);
				if ( partitions_hdb[4] != null )
					partitions_hdbP[4] = (partitions_hdbPc[4] * edge);
				if ( partitions_hdb[5] != null )
					partitions_hdbP[5] = (partitions_hdbPc[5] * edge);
				if ( partitions_hdb[6] != null )
					partitions_hdbP[6] = (partitions_hdbPc[6] * edge);
				if ( partitions_hdb[7] != null )
					partitions_hdbP[7] = (partitions_hdbPc[7] * edge);
				if ( partitions_hdb[8] != null )
					partitions_hdbP[8] = (partitions_hdbPc[8] * edge);
				
				partitions_hdbP[0] = edge;
			}
		}//percentage calculations for drawing on window resize
		public void HdbCalculations() {
			
			if ( hdbB == true ) {
				
				if ( partitions_hdb[1] != null )
					partitions_hdbPc[1] = partitions_hdbP[1] / partitions_hdbP[0];
				if ( partitions_hdb[2] != null )
					partitions_hdbPc[2] = partitions_hdbP[2] / partitions_hdbP[0];
				if ( partitions_hdb[3] != null )
					partitions_hdbPc[3] = partitions_hdbP[3] / partitions_hdbP[0];
				if ( partitions_hdb[4] != null )
					partitions_hdbPc[4] = partitions_hdbP[4] / partitions_hdbP[0];
				if ( partitions_hdb[5] != null )
					partitions_hdbPc[5] = partitions_hdbP[5] / partitions_hdbP[0];
				if ( partitions_hdb[6] != null )
					partitions_hdbPc[6] = partitions_hdbP[6] / partitions_hdbP[0];
				if ( partitions_hdb[7] != null )
					partitions_hdbPc[7] = partitions_hdbP[7] / partitions_hdbP[0];
				if ( partitions_hdb[8] != null )
					partitions_hdbPc[8] = partitions_hdbP[8] / partitions_hdbP[0];
				
			}
		}
		
		public void SdaDrawingCalculations(Int32 edge) {
			
			if ( sdaB == true ) {
				
				if ( partitions_sda[1] != null )
					partitions_sdaP[1] = (partitions_sdaPc[1] * edge);
				if ( partitions_sda[2] != null )
					partitions_sdaP[2] = (partitions_sdaPc[2] * edge);
				if ( partitions_sda[3] != null )
					partitions_sdaP[3] = (partitions_sdaPc[3] * edge);
				if ( partitions_sda[4] != null )
					partitions_sdaP[4] = (partitions_sdaPc[4] * edge);
				if ( partitions_sda[5] != null )
					partitions_sdaP[5] = (partitions_sdaPc[5] * edge);
				if ( partitions_sda[6] != null )
					partitions_sdaP[6] = (partitions_sdaPc[6] * edge);
				if ( partitions_sda[7] != null )
					partitions_sdaP[7] = (partitions_sdaPc[7] * edge);
				if ( partitions_sda[8] != null )
					partitions_sdaP[8] = (partitions_sdaPc[8] * edge);
				
				partitions_sdaP[0] = edge;
			}
		}//percentage calculations for drawing on window resize
		public void SdaCalculations() {
			
			if ( sdaB == true ) {
				
				if ( partitions_sda[1] != null )
					partitions_sdaPc[1] = partitions_sdaP[1] / partitions_sdaP[0];
				if ( partitions_sda[2] != null )
					partitions_sdaPc[2] = partitions_sdaP[2] / partitions_sdaP[0];
				if ( partitions_sda[3] != null )
					partitions_sdaPc[3] = partitions_sdaP[3] / partitions_sdaP[0];
				if ( partitions_sda[4] != null )
					partitions_sdaPc[4] = partitions_sdaP[4] / partitions_sdaP[0];
				if ( partitions_sda[5] != null )
					partitions_sdaPc[5] = partitions_sdaP[5] / partitions_sdaP[0];
				if ( partitions_sda[6] != null )
					partitions_sdaPc[6] = partitions_sdaP[6] / partitions_sdaP[0];
				if ( partitions_sda[7] != null )
					partitions_sdaPc[7] = partitions_sdaP[7] / partitions_sdaP[0];
				if ( partitions_sda[8] != null )
					partitions_sdaPc[8] = partitions_sdaP[8] / partitions_sdaP[0];
				
			}
		}
		
		public void SdbDrawingCalculations(Int32 edge) {
			
			if ( sdbB == true ) {
				
				if ( partitions_sdb[1] != null )
					partitions_sdbP[1] = (partitions_sdbPc[1] * edge);
				if ( partitions_sdb[2] != null )
					partitions_sdbP[2] = (partitions_sdbPc[2] * edge);
				if ( partitions_sdb[3] != null )
					partitions_sdbP[3] = (partitions_sdbPc[3] * edge);
				if ( partitions_sdb[4] != null )
					partitions_sdbP[4] = (partitions_sdbPc[4] * edge);
				if ( partitions_sdb[5] != null )
					partitions_sdbP[5] = (partitions_sdbPc[5] * edge);
				if ( partitions_sdb[6] != null )
					partitions_sdbP[6] = (partitions_sdbPc[6] * edge);
				if ( partitions_sdb[7] != null )
					partitions_sdbP[7] = (partitions_sdbPc[7] * edge);
				if ( partitions_sdb[8] != null )
					partitions_sdbP[8] = (partitions_sdbPc[8] * edge);
				
				partitions_sdbP[0] = edge;
			}
		}//percentage calculations for drawing on window resize
		public void SdbCalculations() {
			
			if ( sdbB == true ) {
				
				if ( partitions_sdb[1] != null )
					partitions_sdbPc[1] = partitions_sdbP[1] / partitions_sdbP[0];
				if ( partitions_sdb[2] != null )
					partitions_sdbPc[2] = partitions_sdbP[2] / partitions_sdbP[0];
				if ( partitions_sdb[3] != null )
					partitions_sdbPc[3] = partitions_sdbP[3] / partitions_sdbP[0];
				if ( partitions_sdb[4] != null )
					partitions_sdbPc[4] = partitions_sdbP[4] / partitions_sdbP[0];
				if ( partitions_sdb[5] != null )
					partitions_sdbPc[5] = partitions_sdbP[5] / partitions_sdbP[0];
				if ( partitions_sdb[6] != null )
					partitions_sdbPc[6] = partitions_sdbP[6] / partitions_sdbP[0];
				if ( partitions_sdb[7] != null )
					partitions_sdbPc[7] = partitions_sdbP[7] / partitions_sdbP[0];
				if ( partitions_sdb[8] != null )
					partitions_sdbPc[8] = partitions_sdbP[8] / partitions_sdbP[0];
				
			}
		}
		
	}
}

//ghaefb
