// Filename: MemoryInfo.cs
// Contains functions to extract information displayed in Memory category

using System;
using System.IO;

namespace Sysinfo {
	
	public class MemoryInfo {
		
		//global variables
		public String memory_total = "unknown";
		public String memory_free = "unknown";
		public String memory_free_total = "unknown";
		
		public String memory_swaptotal = "unknown";
		public String memory_swapfree = "unknown";
		
		public String memory_buffers = "unknown";
		public String memory_cached = "unknown";
		public String memory_active = "unknown";
		public String memory_inactive = "unknown";
		
		public Double fraction1, fraction2;
		
		//read memory info
		public void MemoryStaticInfo() {
			
			String temp;
			Boolean staticB = false;

			try {
				
				//get memory information from /proc
				using (TextReader textread = File.OpenText("/proc/meminfo")) {

					while ( staticB == false ) {
						
						temp = textread.ReadLine();
						
						//total
						if ( temp.StartsWith("MemTotal:")) {
							
							temp = temp.Remove(0, 9);
							temp = temp.Remove(temp.IndexOf("kB"), 2);
							
							memory_total = ( Int32.Parse(temp) / 1024 ).ToString();
						}
						
						//swap total
						if ( temp.StartsWith("SwapTotal:")) {
							
							temp = temp.Remove(0, 10);
							temp = temp.Remove(temp.IndexOf("kB"), 2);
							
							if ( temp == "0" )
								memory_swaptotal = "no swap";
							else
								memory_swaptotal = ( Int32.Parse(temp) / 1024 ).ToString();
							
							staticB = true;
						}
						
					}
				}
			}catch (FileNotFoundException ex) { Console.WriteLine( ex); }
		}
		
		//read memory info
		public void MemoryDynamicInfo() {
			
			String temp;
			Boolean dynamicB = false;

			try {
				
				//get memory information from /proc
				using (TextReader textread = File.OpenText("/proc/meminfo")) {

					while ( dynamicB == false ) {
						
						temp = textread.ReadLine();
						
						//free
						if ( temp.StartsWith("MemFree:")) {
							
							temp = temp.Remove(0, 8);
							temp = temp.Remove(temp.IndexOf("kB"), 2);
							
							memory_free = ( Int32.Parse(temp) / 1024 ).ToString();
						}
						
						//buffers
						if ( temp.StartsWith("Buffers:")) {
							
							temp = temp.Remove(0, 8);
							temp = temp.Remove(temp.IndexOf("kB"), 2);
							
							memory_buffers = ( Int32.Parse(temp) / 1024 ).ToString();
						}
						
						//swap free
						if ( temp.StartsWith("SwapFree:")) {
							
							temp = temp.Remove(0, 9);
							temp = temp.Remove(temp.IndexOf("kB"), 2);

							memory_swapfree = ( Int32.Parse(temp) / 1024 ).ToString();
							
							dynamicB = true;
						}
						
						//cached memory
						if ( temp.StartsWith("Cached:")) {
							
							temp = temp.Remove(0, 7);
							temp = temp.Remove(temp.IndexOf("kB"), 2);

							memory_cached = ( Int32.Parse(temp) / 1024 ).ToString();
						}
						
						//active memory
						if ( temp.StartsWith("Active:")) {
							
							temp = temp.Remove(0, 7);
							temp = temp.Remove(temp.IndexOf("kB"), 2);

							memory_active = ( Int32.Parse(temp) / 1024 ).ToString();
						}
						
						//inactive memory
						if ( temp.StartsWith("Inactive:")) {
							
							temp = temp.Remove(0, 9);
							temp = temp.Remove(temp.IndexOf("kB"), 2);

							memory_inactive = ( Int32.Parse(temp) / 1024 ).ToString();
						}

					}
				}
			}catch (FileNotFoundException ex) { Console.WriteLine( ex); }
			
			memory_free_total = ( Double.Parse(memory_free) + Double.Parse(memory_buffers) + Double.Parse(memory_cached) ).ToString();
		}
		
		
		//memory free progressbar
		public void Progressbar1() {
			
			try {
				
				fraction1 = Int32.Parse(memory_total) - Int32.Parse(memory_free_total);
				fraction1 = fraction1 / Int32.Parse(memory_total);
			}
			catch (DivideByZeroException ex) { fraction1 = 0;  Console.WriteLine( ex );  }
		}
		
		//swap free progressbar
		public void Progressbar2() {
			
			try {
				
				fraction2 =Int32.Parse(memory_swaptotal) - Int32.Parse(memory_swapfree);
				fraction2 = fraction2 / Int32.Parse(memory_swaptotal);
			}
			catch (DivideByZeroException ex) { fraction2 = 0;  Console.WriteLine( ex );  }
		}
		
	}
}

//ghaefb
