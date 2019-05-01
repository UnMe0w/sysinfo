// Filename: CpuInfo.cs
// Contains functions to extract information displayed in CPU category

using System;
using System.IO;

namespace Sysinfo {
	
	public class CpuInfo {
		
		//global variables
		public String cpu_vendor = "unknown";
		public Int32 cpu_cpus = 0;
		
		public String cpu_name = "unknown";
		public String cpu_frequency = "unknown";
		public String cpu_cache = "unknown";
		
		public String cpu_bogomips = "unknown";
		public String cpu_numbering = "unknown";
		public String cpu_flags = "unknown";
		
		//read cpu function
		public void CpuStaticInfo() {
			
			String temp;
			Boolean modelB = true;
			Boolean staticB = true;
			cpu_cpus = 0;
			
			try {
				
				//get cpu information from /proc
				using (TextReader textread = File.OpenText("/proc/cpuinfo")) {

					while ( textread.Peek() != (-1) ) {
						
						temp = textread.ReadLine();

						//vendor
						if ( temp.StartsWith("vendor_id") && staticB )
							cpu_vendor = temp.Remove(0, 12);
						
						//model name
						if ( temp.StartsWith("model name") && staticB )
							cpu_name =  temp.Remove(0, 13);
										
						//cache
						if ( temp.StartsWith("cache size") && staticB ) 
							cpu_cache =  temp.Remove(0, 13);
						
						//numbering1 family
						if ( temp.StartsWith("cpu family") && staticB )
							cpu_numbering =  "family(" + temp.Remove(0, 13);

						//numbering2 model
						if ( temp.StartsWith("model") && modelB  && staticB ) {
							
							cpu_numbering =  cpu_numbering + ") model(" + temp.Remove(0, 9);
							modelB = false;
						}	

						//numbering3 stepping
						if ( temp.StartsWith("stepping") && staticB )
							cpu_numbering =  cpu_numbering + ") stepping(" + temp.Remove(0, 11) + ")";
						
						//flags
						if ( temp.StartsWith("flags") && staticB ) {
						
							cpu_flags =  temp.Remove(0, 9);
							staticB = false;
						}
						
						//number of cpus
						if ( temp.StartsWith("processor"))
							cpu_cpus++;
						
					}
				}
			}catch (FileNotFoundException ex) { Console.WriteLine(ex); }
		}
		
		//this function needs to be called more than once, to update info
		public void CpuDynamicInfo() {
			
			String temp;
			Boolean dynamicB = true;
			
			try {
				
				//get cpu information from /proc
				using (TextReader textread = File.OpenText("/proc/cpuinfo")) {
					
					while ( dynamicB ) {
						
						temp = textread.ReadLine();
						
						//frequency
						if ( temp.StartsWith("cpu MHz"))
							cpu_frequency =  temp.Remove(0, 11) + " MHz";
						
						//bogomips
						if ( temp.StartsWith("bogomips")) {
						
							cpu_bogomips =  temp.Remove(0, 11);
							dynamicB = false;
						}

					}
				}
			}catch (FileNotFoundException ex) { Console.WriteLine( ex ); }
		}
		
	}
}

//ghaefb
