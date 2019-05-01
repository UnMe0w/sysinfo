// Filename: HardwareInfo.cs
// Contains functions to extract information displayed in Hardware category

using System;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace Sysinfo {
	
	public class HardwareInfo {
		
		public String [] host_bridge = {null, null};
		public ArrayList pci_bridge = new ArrayList();
		public ArrayList usb_controller = new ArrayList();
		public String [] isa_bridge = {null, null};
		public String [] ide_interface = {null, null};
		
		public String [] vga_controller = {null, null};
		
		public String [] multimedia_controller = {null, null};
		
		public String [] network_controller = {null, null};
		public String [] ethernet_controller = {null, null};
		public String [] modem = {null, null};
		
		String path = "lspci";
		
		public HardwareInfo() {
			
			//lspci path
			if ( File.Exists( "/usr/sbin/lspci") )
				path = "/usr/sbin/lspci";
			if ( File.Exists( "/sbin/lspci") )
				path = "/sbin/lspci";
			if ( File.Exists( "/bin/lspci") )
				path =  "/bin/lspci";
			if ( File.Exists( "/usr/bin/lspci") )
				path = "/usr/bin/lspci";
		}
		
		//all static info
		public void StaticInfo() {
			
			String temp;
			
			Boolean host_bridgeB = false;
			Int32 pci_bridgeI = 0;
			Int32 usb_controllerI = 0;
			Boolean isa_bridgeB = false;
			Boolean ide_interfaceB = false;
			Boolean vga_controllerB = false;
			Boolean multimedia_controllerB = false;
			Boolean network_controllerB = false;
			Boolean ethernet_controllerB = false;
			Boolean modemB = false;
			
			try {
				
				//run lspci command and read output
				Process proc1 = new Process();
				proc1.StartInfo.FileName = path;
				proc1.StartInfo.Arguments = "-v";
				proc1.StartInfo.UseShellExecute = false;
				proc1.StartInfo.RedirectStandardOutput = true;
				proc1.Start();
				proc1.WaitForExit();
				
				while ( proc1.StandardOutput.Peek() != (-1) ) {
				           
					temp = proc1.StandardOutput.ReadLine();
					
					/* Motherboard */
					//host bridge
					if ( temp.Length <= 1 )
						host_bridgeB = false;
					if ( host_bridgeB && temp.StartsWith("\tSubsystem")  ) {
						
						host_bridge [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						host_bridgeB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("Host bridge") ) {
						
						host_bridge [0] = temp.Remove(0, temp.IndexOf(" ")  + 14);
						host_bridgeB = true;
					}
					
					//pci bridge
					if (temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("PCI bridge")) {
						
						pci_bridge.Add(temp.Remove(0, temp.IndexOf(" ")  + 13));
						pci_bridgeI++;
					}
					
					//usb controller
					if (temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("USB Controller")) {
						
						usb_controller.Add(temp.Remove(0, temp.IndexOf(" ")  + 17));
						usb_controllerI++;
					}
					
					//isa bridge
					if ( temp.Length <= 1 )
						isa_bridgeB = false;
					if ( isa_bridgeB && temp.StartsWith("\tSubsystem")  ) {
						
						isa_bridge [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						isa_bridgeB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("ISA bridge") ) {
						
						isa_bridge [0] = temp.Remove(0, temp.IndexOf(" ")  + 13);
						isa_bridgeB = true;
					}
					
					//ide interface
					if ( temp.Length <= 1 )
						ide_interfaceB = false;
					if ( ide_interfaceB && temp.StartsWith("\tSubsystem")  ) {
						
						ide_interface [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						ide_interfaceB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("IDE interface") ) {
						
						ide_interface [0] = temp.Remove(0, temp.IndexOf(" ")  + 16);
						ide_interfaceB = true;
					}
					
					/* Graphic card */
					//vga compatible controller
					if ( temp.Length <= 1 )
						vga_controllerB = false;
					if ( vga_controllerB && temp.StartsWith("\tSubsystem")  ) {
						
						vga_controller [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						vga_controllerB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("VGA compatible controller") ) {
						
						vga_controller [0] = temp.Remove(0, temp.IndexOf(" ")  + 28);
						vga_controllerB = true;
					}
					
					/* Sound card */
					//multimedia audio controller
					if ( temp.Length <= 1 )
						multimedia_controllerB = false;
					if ( multimedia_controllerB && temp.StartsWith("\tSubsystem")  ) {
						
						multimedia_controller [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						multimedia_controllerB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("Multimedia audio controller") ) {
						
						multimedia_controller [0] = temp.Remove(0, temp.IndexOf(" ")  + 30);
						multimedia_controllerB = true;
					}
					else if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("Audio device") ) {
						
						multimedia_controller [0] = temp.Remove(0, temp.IndexOf(" ")  + 15);
						multimedia_controllerB = true;
					}
					
					/* Network devices */
					//network controller
					if ( temp.Length <= 1 )
						network_controllerB = false;
					if ( network_controllerB && temp.StartsWith("\tSubsystem")  ) {
						
						network_controller [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						network_controllerB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("Network controller") ) {
						
						network_controller [0] = temp.Remove(0, temp.IndexOf(" ")  + 21);
						network_controllerB = true;
					}
					//ethernet controller
					if ( temp.Length <= 1 )
						ethernet_controllerB = false;
					if ( ethernet_controllerB && temp.StartsWith("\tSubsystem")  ) {
						
						ethernet_controller [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						ethernet_controllerB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("Ethernet controller") ) {
						
						ethernet_controller [0] = temp.Remove(0, temp.IndexOf(" ")  + 22);
						ethernet_controllerB = true;
					}
					//modem
					if ( temp.Length <= 1 )
						modemB = false;
					if ( modemB && temp.StartsWith("\tSubsystem")  ) {
						
						modem [1] = temp.Remove(0, temp.IndexOf(" ")  + 1);
						modemB = false;
					}
					if ( temp.Remove(0, temp.IndexOf(" ")  + 1).StartsWith("Modem:") ) {
						
						modem [0] = temp.Remove(0, temp.IndexOf(" ")  + 8);
						modemB = true;
					}

				}
				
				proc1.Close();
			}
			catch (Exception ex)	{ Console.WriteLine( ex ); }	
		}
		
		
	}
}

//ghaefb
