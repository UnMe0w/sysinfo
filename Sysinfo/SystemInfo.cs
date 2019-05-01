// Filename: SystemInfo.cs
// Contains functions to extract information displayed in System category

using System;
using System.IO;
using System.Diagnostics;

namespace Sysinfo {
	
	public class SystemInfo {
		
		//global variables
		public String system_release = "unknown";
		
		public String system_gnomev = "unknown";
		public String system_gnomeo = "unknown";
		
		public String system_kernelv = "unknown";
		public String system_kernelb = "unknown";
		
		public String system_uptime = "unknown";
		
		public String system_ostype = "unknown";
		public String system_gcc = "unknown";
		public String system_xorg = "unknown";
		
		public String system_hostname = "unknown";
		
		public String distro = "";
		
		//read release info
		public void Release() {

		    String temp;
			
			try {
				
				if (File.Exists("/etc/redhat-release")) {
					using (TextReader textread = File.OpenText("/etc/redhat-release")) {
						
						distro = "RedHat";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/fedora-release")) {
					using (TextReader textread = File.OpenText("/etc/fedora-release")) {
						
						distro = "Fedora Core";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/SuSE-release")) {
					using (TextReader textread = File.OpenText("/etc/SuSE-release")) {
						
						distro = "SuSE";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/slackware-version")) {
					using (TextReader textread = File.OpenText("/etc/slackware-version")) {
						
						distro = "Slackware";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/debian_version")) {
					using (TextReader textread = File.OpenText("/etc/debian_version")) {
						
						if (Directory.Exists("/usr/share/ubuntu-docs") || File.Exists("/usr/share/pixmaps/splash/ubuntu-splash.png"))
							distro = "Ubuntu";
						else
							distro = "Debian";
						
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/mandrake-release")) {
					using (TextReader textread = File.OpenText("/etc/mandrake-release")) {
						
						distro = "Mandrake";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/mandrive-release")) {
					using (TextReader textread = File.OpenText("/etc/mandrive-release")) {
						
						distro = "Mandriva";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/yellowdog-release")) {
					using (TextReader textread = File.OpenText("/etc/yellowdog-release")) {
						
						distro = "Yellowdog";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/sun-release")) {
					using (TextReader textread = File.OpenText("/etc/sun-release")) {
						
						distro = "Sun";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/gentoo-release")) {
					using (TextReader textread = File.OpenText("/etc/gentoo-release")) {
						
						distro = "Gentoo";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/release")) {
					using (TextReader textread = File.OpenText("/etc/release")) {
						
						distro = "Generic";
						system_release = textread.ReadLine();
					}
				}
				
				if (File.Exists("/etc/lsb-release")) {
					using (TextReader textread = File.OpenText("/etc/lsb-release")) {

					    while ( (temp = textread.ReadLine()) != null ) {

					    	// get distro
					    	if ( temp.StartsWith("DISTRIB_ID=") ) {
					    		distro = temp.Substring(11);
					    	}

					    	// get release
					    	if ( temp.StartsWith("DISTRIB_RELEASE=") ) {
					    		system_release = temp.Substring(16);
					    	}

					    	// get codename
 					    	if ( temp.StartsWith("DISTRIB_CODENAME=") ) {
					    		system_release = String.Concat(system_release, " (", temp.Substring(17), ")");
					    	}

                        }
                        system_release = String.Concat(distro, " ", system_release);
					}
				}

			} catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
		}
		
		//read GNOME version
		public void Gnome() {
			
			String temp;
			Boolean gnomeB = false;
			
			//Fedora,RedHat,Debian,Ubuntu,...
			String gnome_about = "/usr/share/gnome/gnome-version.xml";
			//SuSE
			if (File.Exists("/opt/gnome/share/gnome-about/gnome-version.xml"))
				gnome_about = "/opt/gnome/share/gnome-about/gnome-version.xml";
			
			try {
				
				using (TextReader textread = File.OpenText(gnome_about)) {
					
					while ( gnomeB == false ) {
						
						temp = textread.ReadLine();
						
						//get version from xml
						if ( temp.EndsWith("platform>")) {

							temp = temp.Remove(0, 11);
							temp = temp.Remove(temp.IndexOf("</platform>"), 11);
							system_gnomev = temp;
						}
						
						if ( temp.EndsWith("minor>")) {

							temp = temp.Remove(0, 8);
							temp = temp.Remove(temp.IndexOf("</minor>"), 8);
							system_gnomev = system_gnomev + "." + temp;
						}
						
						if ( temp.EndsWith("micro>")) {

							temp = temp.Remove(0, 8);
							temp = temp.Remove(temp.IndexOf("</micro>"), 8);
							system_gnomev = system_gnomev + "." + temp;
						}
						
						//get distributor
						if ( temp.EndsWith("distributor>")) {

							temp = temp.Remove(0, 14);
							temp = temp.Remove(temp.IndexOf("</distributor>"), 14);
							system_gnomeo = temp;
						}
						
						//get build date
						if ( temp.EndsWith("date>")) {

							temp = temp.Remove(0, 7);
							temp = temp.Remove(temp.IndexOf("</date>"), 7);
							system_gnomeo = system_gnomeo + " " + temp;
							
							gnomeB = true;
						}

					}

				}

			}
			catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
			catch (DirectoryNotFoundException ex) {  Console.WriteLine( ex );  }
		}
		
		//read kernel version
		public void Kernel() {
			
			try {
				
				//get kernel version
				using (TextReader textread = File.OpenText("/proc/sys/kernel/osrelease")) {
					
					system_kernelv = textread.ReadLine();
				}
				
				//get kernel build date
				using (TextReader textread = File.OpenText("/proc/sys/kernel/version")) {
					
					system_kernelb = textread.ReadLine();
				}
			}catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
		}
		
		//read uptime
		public void Uptime() {

			Int32 days, hours, minutes;
			String temp = "";
					
			try {
			
				//get uptime
				using (TextReader textread = File.OpenText("/proc/uptime")) {
					
					temp = textread.ReadLine();
				}
			}catch (Exception ex) {  Console.WriteLine( ex );  }
			
			//I need just the first number from uptime
			temp = temp.Remove(temp.IndexOf("."), temp.Length - temp.IndexOf(".") );
			
			//string to int conversion - days
			days = Int32.Parse(temp);
			days = days / 86400;
			
			//hours
			hours = Int32.Parse(temp);
			hours = (hours / 3600) - (days * 24);
			
			//minutes
			minutes = Int32.Parse(temp);
			minutes = (minutes / 60) - ((days * 1440) + (hours * 60));
			
			system_uptime = days + " days " + hours + " h " + minutes + " min";
		}
		
		//read ostype
		public void Ostype() {
			
			try {
				
				//get ostype
				using (TextReader textread = File.OpenText("/proc/sys/kernel/ostype")) {
					
					system_ostype = textread.ReadLine();
				}
			}catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
		}
		
		//read gcc version
		public void Gccv() {
			
			try {
				
				//run command and read output
				//gcc version
				Process proc1 = new Process();
				proc1.StartInfo.FileName = "gcc";
				proc1.StartInfo.Arguments = "-dumpversion";
				proc1.StartInfo.UseShellExecute = false;
				proc1.StartInfo.RedirectStandardOutput = true;
				proc1.Start();
				proc1.WaitForExit(); 
				
				system_gcc = proc1.StandardOutput.ReadToEnd();
				system_gcc = system_gcc.Remove(system_gcc.Length - 1, 1);
				proc1.Close();
				
				//gcc distibutor machine
				Process proc2 = new Process();
				proc2.StartInfo.FileName = "gcc";
				proc2.StartInfo.Arguments = "-dumpmachine";
				proc2.StartInfo.UseShellExecute = false;
				proc2.StartInfo.RedirectStandardOutput = true;
				proc2.Start();
				proc2.WaitForExit();
				
				system_gcc = system_gcc + " (" + proc2.StandardOutput.ReadToEnd();
				system_gcc = system_gcc.Remove(system_gcc.Length - 1, 1) + ")";
				proc2.Close();
				
			}
			catch (System.ComponentModel.Win32Exception ex) {
				
				system_gcc = "no gcc detected";
				
				Console.WriteLine( ex );  
			}

		}
		
		//read xorg version
		public void Xorg() {
			
			String temp;
			Boolean xorgB = false;
			
			try {
				
				//get xorg version
				using (TextReader textread = File.OpenText("/var/log/Xorg.0.log")) {
					
					while ( xorgB == false ) {
						
						temp = textread.ReadLine();
						
						//version
						if ( temp.StartsWith("X Window System Version")) {
						
							system_xorg = temp.Remove(0, 24);
						}
						
						//build date
						if ( temp.StartsWith("Build Date")) {
						
							system_xorg = system_xorg + " (" + temp.Remove(0, 12) + ")";
							xorgB = true;
						}

					}
				}
			}catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
		}
		
		//read hostname
		public void Hostname() {
			
			try {
				
				//get hostname
				using (TextReader textread = File.OpenText("/proc/sys/kernel/hostname")) {
					
					system_hostname = textread.ReadLine();
				}
			}catch (FileNotFoundException ex) {  Console.WriteLine( ex );  }
		}

		
	}
}

//ghaefb
