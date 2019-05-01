// Filename: NvidiaInfo.cs
// Contains functions to extract information displayed in NVIDIA category

using System;
using System.IO;
using System.Diagnostics;

namespace Sysinfo {
	
	public class NvidiaInfo {
		
		public Boolean nvidiaB = false;
		
		public String nvidia_model = "unknown";
		public String nvidia_ctype = "unknown";
		
		public String nvidia_version = "unknown";
		
		public String nvidia_videoram = "unknown";
		public String nvidia_busrate = "";
		public String nvidia_gpu = "unknown";
		
		//check for nvidia driver
		public NvidiaInfo() {
			
			if ( Directory.Exists("/proc/driver/nvidia/") )
				nvidiaB = true;
		}
		
		//read some basic info
		public void MainInfo(){
			
			String temp;
			
			try {
					
				using (TextReader textread = File.OpenText("/proc/driver/nvidia/gpus/0000:01:00.0/information")) {
						
					while ( textread.Peek() != (-1)  ) {
							
						temp = textread.ReadLine();
						
						if ( temp.StartsWith("Model:") ) {
							
							temp = temp.Remove(0, 10);
							
							nvidia_model = temp;
						}
						
						if ( temp.StartsWith("Card Type:") ) {
							
							temp = temp.Remove(0, 13);
							
							nvidia_ctype = temp;
						}
						
					}
				}
			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
		}
		
		//read driver version
		public void Version() {
			
			String temp;
			
			try {
				
				using (TextReader textread = File.OpenText("/proc/driver/nvidia/version")) {
							
					while ( textread.Peek() != (-1)  ) {
								
						temp = textread.ReadLine();
							
						if ( temp.StartsWith("NVRM version:") ) {
								
							temp = temp.Remove(0, 14);
								
							nvidia_version = temp;
						}
					}
				}
			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
		}
		
		//read extra info using nvidia-settings
		public void AditionaInfo() {
			
			String temp;
			
			try {
				
				//run command and read output: nvidia-settings --query VideoRam
				Process proc1 = new Process();
				proc1.StartInfo.FileName = "nvidia-settings";
				proc1.StartInfo.Arguments = "-q VideoRam";
				proc1.StartInfo.UseShellExecute = false;
				proc1.StartInfo.RedirectStandardOutput = true;
				proc1.Start();
				proc1.WaitForExit(); 
				
				temp = proc1.StandardOutput.ReadLine();
				temp = proc1.StandardOutput.ReadLine();
	
				temp = temp.Remove(0, temp.LastIndexOf(":") + 2);
				nvidia_videoram = ( Double.Parse(temp) / 1024 ).ToString() + " MB";
				
				proc1.Close();
				
				//bus rate
				Process proc2 = new Process();
				proc2.StartInfo.FileName = "nvidia-settings";
				proc2.StartInfo.Arguments = "-q BusRate";
				proc2.StartInfo.UseShellExecute = false;
				proc2.StartInfo.RedirectStandardOutput = true;
				proc2.Start();
				proc2.WaitForExit(); 
				
				temp = proc2.StandardOutput.ReadLine();
				temp = proc2.StandardOutput.ReadLine();
	
				temp = temp.Remove(0, temp.LastIndexOf(":") + 2);
				nvidia_busrate = temp.Remove(temp.LastIndexOf("."), 1) + "x";
				
				proc2.Close();
				
				//gpu frequency
				Process proc3 = new Process();
				proc3.StartInfo.FileName = "nvidia-settings";
				proc3.StartInfo.Arguments = "-q GPUCurrentClockFreqs";
				proc3.StartInfo.UseShellExecute = false;
				proc3.StartInfo.RedirectStandardOutput = true;
				proc3.Start();
				proc3.WaitForExit(); 
				
				temp = proc3.StandardOutput.ReadLine();
				temp = proc3.StandardOutput.ReadLine();
	
				temp = temp.Remove(0, temp.LastIndexOf(":") + 2);
				nvidia_gpu = temp.Remove(temp.LastIndexOf(","), 5) + " MHz";
				
				proc3.Close();
			}
			catch (System.ComponentModel.Win32Exception ex) {  Console.WriteLine( ex );  }
			catch (ArgumentOutOfRangeException ex) {  Console.WriteLine( ex );  }
			catch (FormatException ex) {  Console.WriteLine( ex );  }
			
		}
		
	}
}

//ghaefb
