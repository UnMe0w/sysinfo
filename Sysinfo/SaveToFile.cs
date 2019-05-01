// Filename: SaveToFile.cs
// Contains functions to save all the information to plain text file

using System;
using System.IO;
using Gtk;

namespace Sysinfo {
	
	public class SaveToFile {
		

		public void Save(String filename, SystemInfo system_info, CpuInfo cpu_info, MemoryInfo memory_info, StorageInfo storage_info,
		HardwareInfo hardware_info, NvidiaInfo nvidia_info) {
			
			system_info.Release();
			system_info.Gnome();
			system_info.Kernel();
			system_info.Ostype();
			system_info.Gccv();
			system_info.Xorg();
			system_info.Hostname();
			system_info.Uptime();
			
			cpu_info.CpuStaticInfo();
			cpu_info.CpuDynamicInfo();
			
			memory_info.MemoryStaticInfo();
			
			storage_info.IdeInfo();
			storage_info.ScsiInfo();
			
			hardware_info.StaticInfo();
			
			nvidia_info.MainInfo();
			nvidia_info.Version();
			nvidia_info.AditionaInfo();
			
			using (TextWriter textwrite = File.CreateText(filename)) {
			
				textwrite.WriteLine("System information report, generated by Sysinfo: " + DateTime.Now);
				textwrite.WriteLine("http://sysinfo.r8.org\n");
				                        
				//system
				textwrite.WriteLine("SYSTEM INFORMATION");
				textwrite.WriteLine("\tRunning " + system_info.distro + " " + system_info.system_ostype +  ", the "+ system_info.system_release + " release.");
				textwrite.WriteLine("\tGNOME: " + system_info.system_gnomev + " (" + system_info.system_gnomeo + ")");
				textwrite.WriteLine("\tKernel version: " + system_info.system_kernelv + " (" + system_info.system_kernelb + ")");
				textwrite.WriteLine("\tGCC: " + system_info.system_gcc);
				textwrite.WriteLine("\tXorg: " + system_info.system_xorg);
				textwrite.WriteLine("\tHostname: " + system_info.system_hostname);
				textwrite.WriteLine("\tUptime: " + system_info.system_uptime);
				
				//cpu
				textwrite.WriteLine("\nCPU INFORMATION");
				textwrite.WriteLine("\t" + cpu_info.cpu_vendor + ", " + cpu_info.cpu_name);
				textwrite.WriteLine("\tNumber of CPUs: " + cpu_info.cpu_cpus);
				textwrite.WriteLine("\tCPU clock currently at " + cpu_info.cpu_frequency + " with " + cpu_info.cpu_cache + " cache");
				textwrite.WriteLine("\tNumbering: " + cpu_info.cpu_numbering);
				textwrite.WriteLine("\tBogomips: " + cpu_info.cpu_bogomips);
				textwrite.WriteLine("\tFlags: " + cpu_info.cpu_flags);
				
				//memory
				textwrite.WriteLine("\nMEMORY INFORMATION");
				textwrite.WriteLine("\tTotal memory: " + memory_info.memory_total + " MB");
				textwrite.WriteLine("\tTotal swap: " + memory_info.memory_swaptotal + " MB");
				
				//storage
				textwrite.WriteLine("\nSTORAGE INFORMATION");
				if (storage_info.ide_hda[1] != null ) {
		    		
		    		textwrite.WriteLine("\tPrimary Master /dev/hda - " + storage_info.ide_hda[0]);
					textwrite.WriteLine("\t\tModel: " + storage_info.ide_hda[1]);
					if (storage_info.ide_hda[2] != null)
		    			textwrite.WriteLine("\t\tCapacity: " + storage_info.ide_hda[2]);
		    		if (storage_info.ide_hda[3] != null)
			   			textwrite.WriteLine("\t\tCache: " + storage_info.ide_hda[3]);
				}
				if (storage_info.ide_hdb[1] != null ) {
		    		
		    		textwrite.WriteLine("\tPrimary Master /dev/hdb - " + storage_info.ide_hdb[0]);
					textwrite.WriteLine("\t\tModel: " + storage_info.ide_hdb[1]);
					if (storage_info.ide_hdb[2] != null)
		    		textwrite.WriteLine("\t\tCapacity: " + storage_info.ide_hdb[2]);
		    		if (storage_info.ide_hdb[3] != null)
			   			textwrite.WriteLine("\t\tCache: " + storage_info.ide_hdb[3]);
				}
				if (storage_info.ide_hdc[1] != null ) {
		    		
		    		textwrite.WriteLine("\tPrimary Master /dev/hdc - " + storage_info.ide_hdc[0]);
					textwrite.WriteLine("\t\tModel: " + storage_info.ide_hdc[1]);
					if (storage_info.ide_hdc[2] != null)
		    			textwrite.WriteLine("\t\tCapacity: " + storage_info.ide_hdc[2]);
		    		if (storage_info.ide_hdc[3] != null)
			   			textwrite.WriteLine("\t\tCache: " + storage_info.ide_hdc[3]);
				}
				if (storage_info.ide_hdd[1] != null ) {
		    		
		    		textwrite.WriteLine("\tPrimary Master /dev/hdd - " + storage_info.ide_hdd[0]);
					textwrite.WriteLine("\t\tModel: " + storage_info.ide_hdd[1]);
					if (storage_info.ide_hdd[2] != null)
		    			textwrite.WriteLine("\t\tCapacity: " + storage_info.ide_hdd[2]);
		    		if (storage_info.ide_hdd[3] != null)
			   			textwrite.WriteLine("\t\tCache: " + storage_info.ide_hdd[3]);
				}
				if (storage_info.scsi_1[0] != null) {
		    		
		    		textwrite.WriteLine("\tSCSI device - " + storage_info.scsi_1[0]);;
		    		textwrite.WriteLine("\t\tVendor: " + storage_info.scsi_1[1]);
			   		textwrite.WriteLine("\t\tModel: " + storage_info.scsi_1[2]);
				}
				if (storage_info.scsi_2[0] != null) {
		    		
		    		textwrite.WriteLine("\tSCSI device - " + storage_info.scsi_2[0]);;
		    		textwrite.WriteLine("\t\tVendor: " + storage_info.scsi_2[1]);
			   		textwrite.WriteLine("\t\tModel: " + storage_info.scsi_2[2]);
				}
				if (storage_info.scsi_3[0] != null) {
		    		
		    		textwrite.WriteLine("\tSCSI device - " + storage_info.scsi_3[0]);;
		    		textwrite.WriteLine("\t\tVendor: " + storage_info.scsi_3[1]);
			   		textwrite.WriteLine("\t\tModel: " + storage_info.scsi_3[2]);
				}
				if (storage_info.scsi_4[0] != null) {
		    		
		    		textwrite.WriteLine("\tSCSI device - " + storage_info.scsi_4[0]);;
		    		textwrite.WriteLine("\t\tVendor: " + storage_info.scsi_4[1]);
			   		textwrite.WriteLine("\t\tModel: " + storage_info.scsi_4[2]);
		    	}
		    	
		    	//hardware
		    	textwrite.WriteLine("\nHARDWARE INFORMATION");
				textwrite.WriteLine("MOTHERBOARD");
		    	if ( hardware_info.host_bridge[0] != null ) {
			    		
			    	textwrite.WriteLine("\tHost bridge");
		    		textwrite.WriteLine("\t\t" + hardware_info.host_bridge[0]);
			    	if ( hardware_info.host_bridge[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.host_bridge[1]);
		    	}
		    	if ( hardware_info.pci_bridge[0] != null ) {
		    		
		    		textwrite.WriteLine("\tPCI bridge(s)");
			    	for ( int i = 0; i < 5; i++) {		
			    		if ( hardware_info.pci_bridge[i] != null )
			    			textwrite.WriteLine("\t\t" + hardware_info.pci_bridge[i]);
					}
		    	}
		    	if ( hardware_info.usb_controller[0] != null ) {
		    		
		    		textwrite.WriteLine("\tUSB controller(s)");
			    	for ( int i = 0; i < 5; i++) {		
			    		if ( hardware_info.usb_controller[i] != null )
			    			textwrite.WriteLine("\t\t" + hardware_info.usb_controller[i]);
					}
		    	}
		    	if ( hardware_info.isa_bridge[0] != null ) {
			    		
			    	textwrite.WriteLine("\tISA bridge");
		    		textwrite.WriteLine("\t\t" + hardware_info.isa_bridge[0]);
			    	if ( hardware_info.isa_bridge[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.isa_bridge[1]);
		    	}
		    	if ( hardware_info.ide_interface[0] != null ) {
			    		
			    	textwrite.WriteLine("\tIDE interface");
		    		textwrite.WriteLine("\t\t" + hardware_info.ide_interface[0]);
			    	if ( hardware_info.ide_interface[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.ide_interface[1]);
		    	}
		    	textwrite.WriteLine("\nGRAPHIC CARD");
				if ( hardware_info.vga_controller[0] != null ) {
			    		
			    	textwrite.WriteLine("\tVGA controller");
		    		textwrite.WriteLine("\t\t" + hardware_info.vga_controller[0]);
			    	if ( hardware_info.vga_controller[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.vga_controller[1]);
				}
				textwrite.WriteLine("\nSOUND CARD");
				if ( hardware_info.multimedia_controller[0] != null ) {
			    		
			    	textwrite.WriteLine("\tMultimedia controller");
		    		textwrite.WriteLine("\t\t" + hardware_info.multimedia_controller[0]);
			    	if ( hardware_info.multimedia_controller[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.multimedia_controller[1]);
				}
				textwrite.WriteLine("\nNETWORK");
				if ( hardware_info.network_controller[0] != null ) {
			    		
			    	textwrite.WriteLine("\tNetwork controller");
		    		textwrite.WriteLine("\t\t" + hardware_info.network_controller[0]);
			    	if ( hardware_info.network_controller[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.network_controller[1]);
				}
				if ( hardware_info.ethernet_controller[0] != null ) {
			    		
			    	textwrite.WriteLine("\tEthernet controller");
		    		textwrite.WriteLine("\t\t" + hardware_info.ethernet_controller[0]);
			    	if ( hardware_info.ethernet_controller[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.ethernet_controller[1]);
				}
				if ( hardware_info.modem[0] != null ) {
			    		
			    	textwrite.WriteLine("\tModem");
		    		textwrite.WriteLine("\t\t" + hardware_info.modem[0]);
			    	if ( hardware_info.modem[1] != null )
			    		textwrite.WriteLine("\t\tSubsystem: " + hardware_info.modem[1]);
		    	}
		    	
		    	if ( nvidia_info.nvidiaB ) {
		    		
		    		textwrite.WriteLine("\nNVIDIA GRAPHIC CARD INFORMATION");

			    	textwrite.WriteLine("\tModel name: " + nvidia_info.nvidia_model);
		    		textwrite.WriteLine("\tCard Type: " + nvidia_info.nvidia_ctype + " " + nvidia_info.nvidia_busrate);
		    		textwrite.WriteLine("\tVideo RAM: " + nvidia_info.nvidia_videoram);
		    		textwrite.WriteLine("\tGPU Frequency: " + nvidia_info.nvidia_gpu);
		    		textwrite.WriteLine("\tDriver version: " + nvidia_info.nvidia_version);
		    	}
		    	
			}
		}
		
		
		
	}
}

//ghaefb