// project created on 10/18/2005 at 2:06 PM - continued 01/27/2006
//
// Main.cs: Main source file of Sysinfo.
//
// Author:
//   Nil Gradisnik <ghaefb@gmail.com>
//
// Copyright (C) Nil Gradisnik 2006 <http://sysinfo.r8.org>
// 
/*
 * Sysinfo is free software.
 *
 * You may redistribute it and/or modify it under the terms of the
 * GNU General Public License, as published by the Free Software
 * Foundation; version 2, or (at your option) any later version.
 *
 * Sysinfo is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Main.cs.  See the file "COPYING".  If not,
 * write to:  The Free Software Foundation, Inc.,
 *            59 Temple Place - Suite 330,
 *            Boston,  MA  02111-1307, USA.
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using Gtk;
using Glade;
using Cairo;
using GConf;
using GLib;

namespace Sysinfo {

	public class Sysinfo {
		
		//set current version string
		String sysinfo_version = "0.7";
		
		//Glade widgets
		[Widget] Window window1;
		[Widget] Notebook notebook1;
		[Widget] TreeView treeview1;
		[Widget] HPaned main_hpaned;
		[Widget] AboutDialog aboutdialog1;
		[Widget] Dialog preferences_dialog;
		[Widget] FileChooserDialog filechooserdialog1;
		[Widget] Statusbar statusbar1;
		[Widget] Image showhide_image;
		//preferences
		[Widget] CheckButton initial_animation_checkbutton, expanders_checkbutton;
		[Widget] ComboBox section_start_combobox;
		//index page
		[Widget] DrawingArea intro_top_drawingarea, intro_bottom_drawingarea;
		//system page
		[Widget] DrawingArea system_top_drawingarea;
		[Widget] Expander system_expander;
		[Widget] Image system_image;
		[Widget] Entry system_release_entry, system_gnomev_entry, system_kernelv_entry, system_uptime_entry;
		[Widget] Entry system_ostype_entry, system_gccv_entry, system_xorgv_entry, system_hostname_entry;
		//cpu page
		[Widget] DrawingArea cpu_top_drawingarea;
		[Widget] Image cpu_image;
		[Widget] Expander cpu_expander;
		[Widget] Entry cpu_vendor_entry, cpu_name_entry, cpu_frequency_entry,
		cpu_cache_entry, cpu_bogomips_entry, cpu_numbering_entry, cpu_flags_entry, cpu_cpus_entry;
		//memory page
		[Widget] DrawingArea memory_top_drawingarea;
		[Widget] Expander  memory_expander;
		[Widget] Entry memory_total_entry, memory_swaptotal_entry,
		memory_cached_entry, memory_active_entry, memory_inactive_entry;
		[Widget] ProgressBar memory_progressbar1, memory_progressbar2;
		[Widget] CheckButton memory_refresh_checkbutton;
		//storage page
		[Widget] DrawingArea storage_top_drawingarea;
		[Widget] TreeView  storage_treeview;
		//partitions
		/*[Widget] DrawingArea partitions_top_drawingarea, partitions_hda_drawingarea,
		partitions_hdb_drawingarea, partitions_sda_drawingarea, partitions_sdb_drawingarea;
		[Widget] TreeView partitions_hda_treeview, partitions_hdb_treeview, partitions_sda_treeview, partitions_sdb_treeview;
		[Widget] Notebook partitions_notebook;
		[Widget] ComboBox partitions_combobox;*/
		//hardware
		[Widget] DrawingArea hardware_top_drawingarea;
		[Widget] ComboBox hardware_combobox;
		[Widget] TreeView motherboard_treeview, graphiccard_treeview, soundcard_treeview, network_treeview;
		[Widget] Notebook hardware_notebook;
		//nvidia
		[Widget] DrawingArea nvidia_top_drawingarea;
		[Widget] Image nvidia_image;
		[Widget] Entry nvidia_model_entry, nvidia_ctype_entry, nvidia_version_entry, nvidia_videoram_entry, nvidia_gpu_entry;
		
		//base directory - not needed now
		//String base_directory = System.AppDomain.CurrentDomain.BaseDirectory;
		
		//animation timer unit
		public uint animation_timer, wait;
		public uint timedate;
		
		//gconf
		GConf.Client client;
		static String GCONF_APP_PATH = "/apps/sysinfo";
		static String INITIAL_ANIMATION_KEY = GCONF_APP_PATH + "/initial_animation";
		static String SECTION_START_KEY = GCONF_APP_PATH + "/section_start";
		static String WINDOW_WIDTH_KEY = GCONF_APP_PATH + "/window_width";
		static String WINDOW_HEIGHT_KEY = GCONF_APP_PATH + "/window_height";
		static String EXPANDERS_KEY = GCONF_APP_PATH + "/expanders_expanded";
		
		//function classes
		SystemInfo system_info = new SystemInfo();
		CpuInfo cpu_info = new CpuInfo();
		MemoryInfo memory_info = new MemoryInfo();
		StorageInfo storage_info = new StorageInfo();
		//PartitionsInfo partitions_info = new PartitionsInfo();
		HardwareInfo hardware_info = new HardwareInfo();
		NvidiaInfo nvidia_info = new NvidiaInfo();
		SaveToFile save_to_file = new SaveToFile();

		//main function
		public static void Main (string[] args) {
			
			new Sysinfo (args);
		}
		
		//global navigation list store
		ListStore liststore1 = new Gtk.ListStore (typeof (Gdk.Pixbuf), typeof (string));

		//Sysinfo
		public Sysinfo (string[] args) {
		
			Application.Init ();

			SetProcessName("sysinfo");
			
			//timedate updates
			timedate = GLib.Timeout.Add(1000, new GLib.TimeoutHandler(timedate_update));
			
			//glade xml and autoconnect
			Glade.XML gxml = new Glade.XML (null, "gui.glade", "window1", null);
			gxml.Autoconnect (this);
			Glade.XML gxml_aboutd = new Glade.XML (null, "gui.glade", "aboutdialog1", null);
			gxml_aboutd.Autoconnect (this);
			Glade.XML gxml_preferencesd = new Glade.XML (null, "gui.glade", "preferences_dialog", null);
			gxml_preferencesd.Autoconnect (this);
			Glade.XML gxml_filechooserd = new Glade.XML (null, "gui.glade", "filechooserdialog1", null);
			gxml_filechooserd.Autoconnect (this);
			
			//window1.Icon = new Gdk.Pixbuf(Path.Combine (base_directory, "pix/sysinfo_system.png"));			
			window1.Icon = new Gdk.Pixbuf(null, "sysinfo_system.png");

	   		//treeview populate
			treeview1.AppendColumn("Pix", new CellRendererPixbuf (), "pixbuf", 0);
			treeview1.AppendColumn("Text", new CellRendererText (), "text", 1);
	 		Gdk.Pixbuf  icon1 = new Gdk.Pixbuf(null, "sysinfo_system.png");
	 		Gdk.Pixbuf  icon2 = new Gdk.Pixbuf(null, "sysinfo_cpu.png");
	 		Gdk.Pixbuf  icon3 = new Gdk.Pixbuf(null, "sysinfo_memory.png");
	 		Gdk.Pixbuf  icon4 = new Gdk.Pixbuf(null, "sysinfo_storage.png");
	 		//Gdk.Pixbuf  icon5 = new Gdk.Pixbuf(null, "sysinfo_partitions.png");
	 		Gdk.Pixbuf  icon6 = new Gdk.Pixbuf(null, "sysinfo_hardware.png");

			liststore1.AppendValues (icon1, "System");
			liststore1.AppendValues (icon2, "CPU");
			liststore1.AppendValues (icon3, "Memory");
			liststore1.AppendValues (icon4, "Storage");
			//liststore1.AppendValues (icon5, "Partitions");
			liststore1.AppendValues (icon6, "Hardware");
			
			//nvidia graphic driver check, add to navigation & to preferences combobox
			if ( nvidia_info.nvidiaB ) {
				
				Gdk.Pixbuf  icon7 = new Gdk.Pixbuf(null, "sysinfo_nvidia.png");
				liststore1.AppendValues (icon7, "NVIDIA");
				
				section_start_combobox.AppendText("NVIDIA");
			}
		
			treeview1.Model = liststore1;
			treeview1.CursorChanged += on_treeview1_cursor_changed;
			
			/*****/
			//gconf
			client = new GConf.Client();
			UpdateFromGConf();
			client.AddNotify (GCONF_APP_PATH, new NotifyEventHandler (GConf_Changed));
			
			//window size
			try {
				window1.Resize( (int) client.Get (WINDOW_WIDTH_KEY), (int) client.Get(WINDOW_HEIGHT_KEY) ); }
			catch (GConf.NoSuchKeyException ex) { Console.WriteLine( ex ); }
				
			//initial animation gconf check
			try {
				
				if ( (bool) client.Get (INITIAL_ANIMATION_KEY) ) {
					
					//initial animation
					main_hpaned.Position = 0;
					wait = GLib.Timeout.Add(2000, new GLib.TimeoutHandler(animation_start));
				}
				else
					main_hpaned.Position = 100;
			}
			catch (GConf.NoSuchKeyException ex) {
				
				main_hpaned.Position = 0;
				wait = GLib.Timeout.Add(2000, new GLib.TimeoutHandler(animation_start));
				
				Console.WriteLine( ex ); 
			}
			
			//expanders expanded
			try {
				
				if ( (bool) client.Get (EXPANDERS_KEY) ) {
					
					system_expander.Expanded = true;
					cpu_expander.Expanded = true;
					memory_expander.Expanded = true;
				}
				else { }
			}
			catch (GConf.NoSuchKeyException ex) { Console.WriteLine( ex ); }
			
			if ( main_hpaned.Position == 0 )
				showhide_image.SetFromStock("gtk-goto-last", IconSize.Button);
			else
				showhide_image.SetFromStock("gtk-goto-first", IconSize.Button);
			
			//section to start in gconf check
			try {
				
				if ( (int) client.Get (SECTION_START_KEY) == 0 )
					notebook1.CurrentPage = 0;
				if ( (int) client.Get (SECTION_START_KEY) == 1 )
					notebook1.CurrentPage = 1;
				if ( (int) client.Get (SECTION_START_KEY) == 2 )
					notebook1.CurrentPage = 2;
				if ( (int) client.Get (SECTION_START_KEY) == 3 )
					notebook1.CurrentPage = 3;
				if ( (int) client.Get (SECTION_START_KEY) == 4 )
					notebook1.CurrentPage = 4;
				if ( (int) client.Get (SECTION_START_KEY) == 5 )
					notebook1.CurrentPage = 5;
				if ( (int) client.Get (SECTION_START_KEY) == 6 )
					notebook1.CurrentPage = 6;
				if ( (int) client.Get (SECTION_START_KEY) == 7 )
					notebook1.CurrentPage = 7;
				
			}catch (GConf.NoSuchKeyException ex) {
				
				section_start_combobox.Active = 0;
				client.Set (SECTION_START_KEY, 0);
				
				Console.WriteLine( ex ); 
			}

			Application.Run();
		}
		
		//set process name to sysinfo
		[DllImport("libc")]
		private static extern int prctl(int option, byte [] arg2, ulong arg3, ulong arg4, ulong arg5);
		public static void SetProcessName(string name)
		{
   			 if(prctl(15 /* PR_SET_NAME */, Encoding.ASCII.GetBytes(name + "\0"), 0, 0, 0) != 0) {
   			 	
   			 	//throw new ApplicationException("Error setting process name: " + Unix.Native.Stdlib.GetLastError());
   			 }
		}
		
		//navigation events
		public void on_treeview1_cursor_changed (object o, EventArgs e) {
			
			//Console.WriteLine("EVENT !!!");
			
			//navigation
			TreeIter iter = new TreeIter();
		    TreeModel model;
		    GLib.Value val = new GLib.Value ();
		    treeview1.Selection.GetSelected (out model, out iter);
		    liststore1.GetValue (iter, 1, ref val);
		    string navigation = (string) val;
			
			//I need to change page to trigger the notebook switch page event
			if (navigation == "System") {
				notebook1.CurrentPage = 0;
		    	notebook1.CurrentPage = 1;
		    }
		    else if (navigation == "CPU") {
		    	notebook1.CurrentPage = 0;
		    	notebook1.CurrentPage = 2;
		    }
		    else if (navigation == "Memory") {
		    	notebook1.CurrentPage = 0;
		    	notebook1.CurrentPage = 3;
		    }
		    else if (navigation == "Storage") {
		    	notebook1.CurrentPage = 0;
		    	notebook1.CurrentPage = 4;
		    }/*
		    else if (navigation == "Partitions") {
		    	notebook1.CurrentPage = 0;
		    	notebook1.CurrentPage = 7;
		    }*/
		    else if (navigation == "Hardware") {
		    	notebook1.CurrentPage = 0;
		    	notebook1.CurrentPage = 5;
		    }
		    else if (navigation == "NVIDIA") {
		    	notebook1.CurrentPage = 0;
		    	notebook1.CurrentPage = 6;
		    }
		}
		
		//global variables needed
		Boolean systemA = true;
		Boolean cpuA = true;
		//Boolean memoryA = false;
		Boolean storageA= true;
		//Boolean partitionsA= true;
		Boolean hardwareA= true;
		Boolean nvidiaA= true;
		
		String memory_freep = "unknown";
		String memory_swapfreep = "unknown";
		
		//storage treestore
		TreeStore ide_treestore = new TreeStore (typeof (string), typeof (string));
		//partitions liststore
		/*ListStore partitions_hda_liststore = new ListStore (typeof (Gdk.Pixbuf), typeof (string), typeof (string));
		ListStore partitions_hdb_liststore = new ListStore (typeof (Gdk.Pixbuf), typeof (string), typeof (string));
		ListStore partitions_sda_liststore = new ListStore (typeof (Gdk.Pixbuf), typeof (string), typeof (string));
		ListStore partitions_sdb_liststore = new ListStore (typeof (Gdk.Pixbuf), typeof (string), typeof (string));			
		//partitions device combobox
	    ListStore partitions_combobox_liststore = new ListStore (typeof (Gdk.Pixbuf), typeof (String));
		Gdk.Pixbuf storage_pix = new Gdk.Pixbuf(null, "sysinfo_storage.png");
		//partitions square pix
		Gdk.Pixbuf  square_butter = new Gdk.Pixbuf(null, "square_butter.png");
		Gdk.Pixbuf  square_chameleon = new Gdk.Pixbuf(null, "square_chameleon.png");
		Gdk.Pixbuf  square_scarletred = new Gdk.Pixbuf(null, "square_scarletred.png");
		Gdk.Pixbuf  square_skyblue = new Gdk.Pixbuf(null, "square_skyblue.png");
		Gdk.Pixbuf  square_chokolate = new Gdk.Pixbuf(null, "square_chokolate.png");
		Gdk.Pixbuf  square_plum = new Gdk.Pixbuf(null, "square_plum.png");
		Gdk.Pixbuf  square_orange = new Gdk.Pixbuf(null, "square_orange.png");
		Gdk.Pixbuf  square_aluminium = new Gdk.Pixbuf(null, "square_aluminium.png");*/
		
		/*********************/
		//NOTEBOOK SWITCH PAGE
		public void on_notebook1_switch_page (object o, SwitchPageArgs e) {
			
			/************/
			//System event
			if ( notebook1.CurrentPage == 1 ) {
				
				if ( systemA ) {
		    		
			    	system_info.Release();
			    	system_info.Gnome();
			    	system_info.Kernel();
		    		
		    		system_release_entry.Text = system_info.system_release;
					system_gnomev_entry.Text = system_info.system_gnomev;
					system_kernelv_entry.Text = system_info.system_kernelv;
			    	system_uptime_entry.Alignment = 0.5f;

			    	system_info.Ostype();
			    	system_info.Gccv();
			    	system_info.Xorg();
			    	system_info.Hostname();
		    		
		    		system_ostype_entry.Text = system_info.system_ostype;
					system_gccv_entry.Text = system_info.system_gcc;
					system_xorgv_entry.Text = system_info.system_xorg;
		    		system_hostname_entry.Text = system_info.system_hostname;
		    		
		    		//set the distribution logo image
			    	if (system_info.distro == "Fedora Core")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "fedora_logo.png");
			    	else if (system_info.distro == "RedHat")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "redhat_logo.png");
			    	else if (system_info.distro == "SuSE")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "suse_logo.png");
			    	else if (system_info.distro == "Slackware")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "slackware_logo.png");
			    	else if (system_info.distro == "Debian")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "debian_logo.png");
			    	else if (system_info.distro == "Ubuntu")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "ubuntu_logo.png");
			    	else if (system_info.distro == "Mandrake")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "mandriva_logo.png");
					else if (system_info.distro == "Mandriva")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "mandriva_logo.png");
			    	/*else if ((system_info.distro == "Yellowdog")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "yellowdog_logo.png");
			    	else if ((system_info.distro == "Sun")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "sun_logo.png");*/
			    	else if (system_info.distro == "Gentoo")
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "gentoo_logo.png");
			    	else
			    		system_image.FromPixbuf = new Gdk.Pixbuf (null, "no_image.png");
					
					//more details expander
			    	if (system_expander.Expanded == true) {
			    	
			    		system_gnomev_entry.Text = system_info.system_gnomev + " (" + system_info.system_gnomeo + ")";
						system_kernelv_entry.Text = system_info.system_kernelv + " (" + system_info.system_kernelb + ")";
			    	}
			    	else {
			    		
			    		system_gnomev_entry.Text = system_info.system_gnomev;
						system_kernelv_entry.Text = system_info.system_kernelv;
			    	}
		    	
		    	}
		    	
		    	//uptime needs to be updated every time
		    	system_info.Uptime();
		    	system_uptime_entry.Text = system_info.system_uptime;
		    	
		    	systemA = false;
			}
			
			/**********/
		    //CPU event
			if ( notebook1.CurrentPage == 2 ) {
				
				if ( cpuA ) {
		    		
		    		cpu_info.CpuStaticInfo();
					cpu_vendor_entry.Text = cpu_info.cpu_vendor;
					cpu_cpus_entry.Text = cpu_info.cpu_cpus.ToString();
		    		
		    		cpu_name_entry.Text = cpu_info.cpu_name;
		    		cpu_cache_entry.Text = cpu_info.cpu_cache;
		    		
		    		cpu_numbering_entry.Text = cpu_info.cpu_numbering;
		    		cpu_flags_entry.Text = cpu_info.cpu_flags;
		    		
		    		//set the cpu imageexpanders_checkbutton.Active = (bool) client.Get (EXPANDERS_KEY);
			    	if (cpu_vendor_entry.Text.EndsWith("Intel")) {
			    		
			    		cpu_image.FromPixbuf = new Gdk.Pixbuf (null, "intel_logo.png");
			    	}
			    	else if (cpu_vendor_entry.Text.EndsWith("AMD")) {
			    		
			    		cpu_image.FromPixbuf = new Gdk.Pixbuf (null, "amd_logo.png");
			    	}
			    	
			    	cpuA = false;
		    	}
		    	
		    	//this needs to be updated every time
		    	cpu_info.CpuDynamicInfo();
		    	cpu_frequency_entry.Text = cpu_info.cpu_frequency;
		    	cpu_bogomips_entry.Text = cpu_info.cpu_bogomips;
			}
			
			/************/
		    //Memory event
			if ( notebook1.CurrentPage == 3 ) {
				
				MemoryRefresh();
			}
			
			/************/
		    //Storage event
			if ( notebook1.CurrentPage == 4 ) {

		    	TreeIter ide_iter;
		    	
		    	if ( storageA ) {
		    		
		    		//BOLD text try
		    		//CellRendererText cellr = new CellRendererText ();
		    		//cellr.Weight = (int)Pango.Weight.Bold;
				    storage_treeview.AppendColumn("Device", new CellRendererText (), "text", 0);
				    storage_treeview.AppendColumn("Extracted information", new CellRendererText (), "text", 1);
		    		
		    		storageA = false;
		    	}
		    	
		    	//clear treestore and call function again
		    	ide_treestore.Clear();
				storage_info.IdeInfo();
				
		    	//ide info - populate treestore
		    	if (storage_info.ide_hda[1] != null ) {
		    		
		    		ide_iter = ide_treestore.AppendValues ("Primary Master /dev/hda", storage_info.ide_hda[0]);
		    		ide_treestore.AppendValues (ide_iter, "Model", storage_info.ide_hda[1]);
		    		if (storage_info.ide_hda[2] != null)
		    			ide_treestore.AppendValues (ide_iter, "Capacity", storage_info.ide_hda[2]);
		    		if (storage_info.ide_hda[3] != null)
			   			ide_treestore.AppendValues (ide_iter, "Cache", storage_info.ide_hda[3]);
		    	}
		    	if (storage_info.ide_hdb[1] != null) {
		    		
			   		ide_iter = ide_treestore.AppendValues ("Primary Slave /dev/hdb", storage_info.ide_hdb[0]);
		    		ide_treestore.AppendValues (ide_iter, "Model", storage_info.ide_hdb[1]);
		    		if (storage_info.ide_hdb[2] != null)
		    			ide_treestore.AppendValues (ide_iter, "Capacity", storage_info.ide_hdb[2]);
		    		if (storage_info.ide_hdb[3] != null)
			   			ide_treestore.AppendValues (ide_iter, "Cache", storage_info.ide_hdb[3]);
		    	}
		    	if (storage_info.ide_hdc[1] != null) {
		    		
		    		ide_iter = ide_treestore.AppendValues ("Secondary Master /dev/hdc", storage_info.ide_hdc[0]);
		    		ide_treestore.AppendValues (ide_iter, "Model", storage_info.ide_hdc[1]);
		    		if (storage_info.ide_hdc[2] != null)
		    			ide_treestore.AppendValues (ide_iter, "Capacity", storage_info.ide_hdc[2]);
		    		if (storage_info.ide_hdc[3] != null)
			   			ide_treestore.AppendValues (ide_iter, "Cache", storage_info.ide_hdc[3]);
		    	}
		    	if (storage_info.ide_hdd[1]!= null) {
		    		
			   		ide_iter = ide_treestore.AppendValues ("Secondary Slave /dev/hdd", storage_info.ide_hdd[0]);
		    		ide_treestore.AppendValues (ide_iter, "Model", storage_info.ide_hdd[1]);
		    		if (storage_info.ide_hdd[2] != null)
		    			ide_treestore.AppendValues (ide_iter, "Capacity", storage_info.ide_hdd[2]);
		    		if (storage_info.ide_hdd[3] != null)
			   			ide_treestore.AppendValues (ide_iter, "Cache", storage_info.ide_hdd[3]);
		    	}
		    		
		    	//scsi info - populate treestore
		    	storage_info.ScsiInfo();
		    	
		    	if (storage_info.scsi_1[0] != null) {
		    		
		    		ide_iter = ide_treestore.AppendValues ("SCSI device", storage_info.scsi_1[0]);;
		    		ide_treestore.AppendValues (ide_iter, "Vendor", storage_info.scsi_1[1]);
			   		ide_treestore.AppendValues (ide_iter, "Model", storage_info.scsi_1[2]);
		    	}		    	
		    	if (storage_info.scsi_2[0] != null) {
		    		
		    		ide_iter = ide_treestore.AppendValues ("SCSI device", storage_info.scsi_2[0]);;
		    		ide_treestore.AppendValues (ide_iter, "Vendor", storage_info.scsi_2[1]);
			   		ide_treestore.AppendValues (ide_iter, "Model", storage_info.scsi_2[2]);
		    	}
		    	if (storage_info.scsi_3[0] != null) {
		    		
		    		ide_iter = ide_treestore.AppendValues ("SCSI device", storage_info.scsi_3[0]);;
		    		ide_treestore.AppendValues (ide_iter, "Vendor", storage_info.scsi_3[1]);
			   		ide_treestore.AppendValues (ide_iter, "Model", storage_info.scsi_3[2]);
		    	}
		    	if (storage_info.scsi_4[0] != null) {
		    		
		    		ide_iter = ide_treestore.AppendValues ("SCSI device", storage_info.scsi_4[0]);
		    		ide_treestore.AppendValues (ide_iter, "Vendor", storage_info.scsi_4[1]);
			   		ide_treestore.AppendValues (ide_iter, "Model", storage_info.scsi_4[2]);
		    	}
		    	
		    	storage_treeview.Model = ide_treestore;
		    	//storage_treeview.ExpandAll();
			}
			
			 /*************/
		    //Partitions event
			/*if ( notebook1.CurrentPage == 7 ) {
				
				//call all functions
				partitions_info.PartitionsHda();
				partitions_info.PartitionsHdb();
				partitions_info.PartitionsSda();
				partitions_info.PartitionsSdb();
				
				//append columns to treeviews
				if ( partitionsA ) {

			    	partitions_hda_treeview.AppendColumn("Color", new CellRendererPixbuf (), "pixbuf", 0);
			    	partitions_hda_treeview.AppendColumn("Device", new CellRendererText (), "text", 1);
					partitions_hda_treeview.AppendColumn("Partition size", new CellRendererText (), "text", 2);

			    	partitions_hdb_treeview.AppendColumn("Color", new CellRendererPixbuf (), "pixbuf", 0);
			    	partitions_hdb_treeview.AppendColumn("Device", new CellRendererText (), "text", 1);
					partitions_hdb_treeview.AppendColumn("Partition size", new CellRendererText (), "text", 2);

			    	partitions_sda_treeview.AppendColumn("Color", new CellRendererPixbuf (), "pixbuf", 0);
			    	partitions_sda_treeview.AppendColumn("Device", new CellRendererText (), "text", 1);
		    		partitions_sda_treeview.AppendColumn("Partition size", new CellRendererText (), "text", 2);

			    	partitions_sdb_treeview.AppendColumn("Color", new CellRendererPixbuf (), "pixbuf", 0);
			    	partitions_sdb_treeview.AppendColumn("Device", new CellRendererText (), "text", 1);
					partitions_sdb_treeview.AppendColumn("Partition size", new CellRendererText (), "text", 2);
					
					partitions_info.HdaCalculations();
					partitions_info.HdbCalculations();
					partitions_info.SdaCalculations();
					partitions_info.SdbCalculations();
					
					partitionsA = false;
				}

				partitions_combobox.Clear();
				partitions_combobox_liststore.Clear();
				
	    		//hda
	    		if ( partitions_info.hdaB ) {
		    		
	    			partitions_hda_liststore.Clear();
	    			
			    	if ( partitions_info.partitions_hda[1] != null )
			    		partitions_hda_liststore.AppendValues (square_butter, "/dev/hda1", partitions_info.partitions_hda[1]);
			    	if ( partitions_info.partitions_hda[2] != null )
			    		partitions_hda_liststore.AppendValues (square_chameleon, "/dev/hda2", partitions_info.partitions_hda[2]);
			    	if ( partitions_info.partitions_hda[3] != null )
			    		partitions_hda_liststore.AppendValues (square_scarletred, "/dev/hda3", partitions_info.partitions_hda[3]);
			    	if ( partitions_info.partitions_hda[4] != null )
			    		partitions_hda_liststore.AppendValues (square_skyblue, "/dev/hda4", partitions_info.partitions_hda[4]);
			    	if ( partitions_info.partitions_hda[5] != null )
			    		partitions_hda_liststore.AppendValues (square_chokolate, "/dev/hda5", partitions_info.partitions_hda[5]);
			    	if ( partitions_info.partitions_hda[6] != null )
			    		partitions_hda_liststore.AppendValues (square_plum, "/dev/hda6", partitions_info.partitions_hda[6]);
			    	if ( partitions_info.partitions_hda[7] != null )
			    		partitions_hda_liststore.AppendValues (square_orange, "/dev/hda7", partitions_info.partitions_hda[7]);
			    	if ( partitions_info.partitions_hda[8] != null )
			    		partitions_hda_liststore.AppendValues (square_aluminium, "/dev/hda8", partitions_info.partitions_hda[8]);
			    		
			    	partitions_hda_treeview.Model = partitions_hda_liststore;
	    			
	    			//add to combobox
	    			partitions_combobox_liststore.AppendValues(storage_pix, " /dev/hda ");
	    		}
	    		
	    		//hdb
	    		if ( partitions_info.hdbB ) {
	    			
	    			partitions_hdb_liststore.Clear();
	    			
			    	if ( partitions_info.partitions_hdb[1] != null )
			    		partitions_hdb_liststore.AppendValues (square_butter, "/dev/hdb1", partitions_info.partitions_hdb[1]);
			    	if ( partitions_info.partitions_hdb[2] != null )
			    		partitions_hdb_liststore.AppendValues (square_chameleon, "/dev/hdb2", partitions_info.partitions_hdb[2]);
			    	if ( partitions_info.partitions_hdb[3] != null )
			    		partitions_hdb_liststore.AppendValues (square_scarletred, "/dev/hdb3", partitions_info.partitions_hdb[3]);
			    	if ( partitions_info.partitions_hdb[4] != null )
			    		partitions_hdb_liststore.AppendValues (square_skyblue, "/dev/hdb4", partitions_info.partitions_hdb[4]);
			    	if ( partitions_info.partitions_hdb[5] != null )
			    		partitions_hdb_liststore.AppendValues (square_chokolate, "/dev/hdb5", partitions_info.partitions_hdb[5]);
			    	if ( partitions_info.partitions_hdb[6] != null )
			    		partitions_hdb_liststore.AppendValues (square_plum, "/dev/hdb6", partitions_info.partitions_hdb[6]);
			    	if ( partitions_info.partitions_hdb[7] != null )
			    		partitions_hdb_liststore.AppendValues (square_orange, "/dev/hdb7", partitions_info.partitions_hdb[7]);
			    	if ( partitions_info.partitions_hdb[8] != null )
			    		partitions_hdb_liststore.AppendValues (square_aluminium, "/dev/hdb8", partitions_info.partitions_hdb[8]);

			    	partitions_hdb_treeview.Model = partitions_hdb_liststore;
	    			
	    			//add to combobox
	    			partitions_combobox_liststore.AppendValues(storage_pix, " /dev/hdb ");
	    		}
	    		
	    		//sda
	    		if ( partitions_info.sdaB ) {

	    			partitions_sda_liststore.Clear();
	    			
			    	if ( partitions_info.partitions_sda[1] != null )
			    		partitions_sda_liststore.AppendValues (square_butter, "/dev/sda1", partitions_info.partitions_sda[1]);
			    	if ( partitions_info.partitions_sda[2] != null )
			    		partitions_sda_liststore.AppendValues (square_chameleon, "/dev/sda2", partitions_info.partitions_sda[2]);
			    	if ( partitions_info.partitions_sda[3] != null )
			    		partitions_sda_liststore.AppendValues (square_scarletred, "/dev/sda3", partitions_info.partitions_sda[3]);
			    	if ( partitions_info.partitions_sda[4] != null )
			    		partitions_sda_liststore.AppendValues (square_skyblue, "/dev/sda4", partitions_info.partitions_sda[4]);
			    	if ( partitions_info.partitions_sda[5] != null )
			    		partitions_sda_liststore.AppendValues (square_chokolate, "/dev/sda5", partitions_info.partitions_sda[5]);
			    	if ( partitions_info.partitions_sda[6] != null )
			    		partitions_sda_liststore.AppendValues (square_plum, "/dev/sda6", partitions_info.partitions_sda[6]);
			    	if ( partitions_info.partitions_sda[7] != null )
			    		partitions_sda_liststore.AppendValues (square_orange, "/dev/sda7", partitions_info.partitions_sda[7]);
			    	if ( partitions_info.partitions_sda[8] != null )
			    		partitions_sda_liststore.AppendValues (square_aluminium, "/dev/sda8", partitions_info.partitions_sda[8]);

			    	partitions_sda_treeview.Model = partitions_sda_liststore;
	    			
	    			//add to combobox
	    			partitions_combobox_liststore.AppendValues(storage_pix, " /dev/sda ");
	    		}
	    		
	    		//sdb
	    		if ( partitions_info.sdbB ) {

	    			partitions_sdb_liststore.Clear();
	    			
			    	if ( partitions_info.partitions_sdb[1] != null )
			    		partitions_sdb_liststore.AppendValues (square_butter, "/dev/sdb1", partitions_info.partitions_sdb[1]);
			    	if ( partitions_info.partitions_sdb[2] != null )
			    		partitions_sdb_liststore.AppendValues (square_chameleon, "/dev/sdb2", partitions_info.partitions_sdb[2]);
			    	if ( partitions_info.partitions_sdb[3] != null )
			    		partitions_sdb_liststore.AppendValues (square_scarletred, "/dev/sdb3", partitions_info.partitions_sdb[3]);
			    	if ( partitions_info.partitions_sdb[4] != null )
			    		partitions_sdb_liststore.AppendValues (square_skyblue, "/dev/sdb4", partitions_info.partitions_sdb[4]);
			    	if ( partitions_info.partitions_sdb[5] != null )
			    		partitions_sdb_liststore.AppendValues (square_chokolate, "/dev/sdb5", partitions_info.partitions_sdb[5]);
			    	if ( partitions_info.partitions_sdb[6] != null )
			    		partitions_sdb_liststore.AppendValues (square_plum, "/dev/sdb6", partitions_info.partitions_sdb[6]);
			    	if ( partitions_info.partitions_sdb[7] != null )
			    		partitions_sdb_liststore.AppendValues (square_orange, "/dev/sdb7", partitions_info.partitions_sdb[7]);
			    	if ( partitions_info.partitions_sdb[8] != null )
			    		partitions_sdb_liststore.AppendValues (square_aluminium, "/dev/sdb8", partitions_info.partitions_sdb[8]);

			    	partitions_sdb_treeview.Model = partitions_sdb_liststore;
	    			
	    			//add to combobox
	    			partitions_combobox_liststore.AppendValues(storage_pix, " /dev/sdb ");
	    		}
	    		
	    		//combobox
	    		CellRendererPixbuf pixbuf_renderer = new CellRendererPixbuf ();
	    		CellRendererText text_renderer = new CellRendererText ();
	    		partitions_combobox.PackStart(pixbuf_renderer, false);
	    		partitions_combobox.PackStart(text_renderer, true);
	    		partitions_combobox.AddAttribute (pixbuf_renderer, "pixbuf", 0);
	    		partitions_combobox.AddAttribute (text_renderer, "text", 1);
	    		partitions_combobox.Model = partitions_combobox_liststore;
	    		partitions_combobox.Active = 0;
			}*/
			
			 /*************/
		    //Hardware event
		    if ( notebook1.CurrentPage == 5 ) {

		    	if ( hardwareA ) {
		    		
		    		//combobox
	    			ListStore hardware_combobox_liststore = new ListStore (typeof (Gdk.Pixbuf), typeof (String));
		    		Gdk.Pixbuf motherboard_pix = new Gdk.Pixbuf(null, "motherboard.png");
		    		Gdk.Pixbuf graphiccard_pix = new Gdk.Pixbuf(null, "graphiccard.png");
		    		Gdk.Pixbuf soundcard_pix = new Gdk.Pixbuf(null, "soundcard.png");
		    		Gdk.Pixbuf network_pix = new Gdk.Pixbuf(null, "network.png");
		    		hardware_combobox_liststore.AppendValues(motherboard_pix, " Motherboard ");
		    		hardware_combobox_liststore.AppendValues(graphiccard_pix, " Graphic card ");
		    		hardware_combobox_liststore.AppendValues(soundcard_pix, " Sound card ");
		    		hardware_combobox_liststore.AppendValues(network_pix, " Network ");
		    		hardware_combobox.Clear();
		    		CellRendererPixbuf pixbuf_renderer = new CellRendererPixbuf ();
	    			CellRendererText text_renderer = new CellRendererText ();
	    			hardware_combobox.PackStart(pixbuf_renderer, false);
	    			hardware_combobox.PackStart(text_renderer, true);
	    			hardware_combobox.AddAttribute (pixbuf_renderer, "pixbuf", 0);
		    		hardware_combobox.AddAttribute (text_renderer, "text", 1);
		    		
		    		hardware_combobox.Model = hardware_combobox_liststore;
		    		hardware_combobox.Active = 0;
		    		
		    		//call function
		    		hardware_info.StaticInfo();
		    		
		    		//MOTHERBOARD
		    		TreeStore motherboard_treestore = new TreeStore (typeof (string));
		    		TreeIter motherboard_iter;
				    motherboard_treeview.AppendColumn("Motherboard", new CellRendererText (), "text", 0);
			    	//host brige info - populate treestore
			    	if ( hardware_info.host_bridge[0] != null ) {
			    		
			    		motherboard_iter = motherboard_treestore.AppendValues ("Host bridge");
			    		motherboard_treestore.AppendValues (motherboard_iter, hardware_info.host_bridge[0]);
			    		if ( hardware_info.host_bridge[1] != null )
			    			motherboard_treestore.AppendValues (motherboard_iter, "Subsystem: " + hardware_info.host_bridge[1]);
			    	}
			    	//pci brige info - populate treestore
			    	if ( hardware_info.pci_bridge[0] != null ) {
			    		
			    		motherboard_iter = motherboard_treestore.AppendValues ("PCI bridge(s)");
			    		
			    		for ( int i = 0; i < 5; i++) {
			    			
			    			if ( hardware_info.pci_bridge[i] != null )
			    				motherboard_treestore.AppendValues (motherboard_iter, hardware_info.pci_bridge[i]);
						}
			    	}
			    	//usb controller info - populate treestore
			    	if ( hardware_info.usb_controller[0] != null ) {
			    		
			    		motherboard_iter = motherboard_treestore.AppendValues ("USB controller(s)");
			    		
			    		for ( int i = 0; i < 5; i++) {
			    			
			    			if ( hardware_info.usb_controller[i] != null )
			    				motherboard_treestore.AppendValues (motherboard_iter, hardware_info.usb_controller[i]);
						}
			    	}
			    	//isa brige info - populate treestore
			    	if ( hardware_info.isa_bridge[0] != null ) {
			    		
			    		motherboard_iter = motherboard_treestore.AppendValues ("ISA bridge");
			    		motherboard_treestore.AppendValues (motherboard_iter, hardware_info.isa_bridge[0]);
			    		if ( hardware_info.isa_bridge[1] != null )
			    			motherboard_treestore.AppendValues (motherboard_iter, "Subsystem: " + hardware_info.isa_bridge[1]);
			    	}
			    	//ide interface info - populate treestore
			    	if ( hardware_info.ide_interface[0] != null ) {
			    		
			    		motherboard_iter = motherboard_treestore.AppendValues ("IDE interface");
			    		motherboard_treestore.AppendValues (motherboard_iter, hardware_info.ide_interface[0]);
			    		if ( hardware_info.ide_interface[1] != null )
			    			motherboard_treestore.AppendValues (motherboard_iter, "Subsystem: " + hardware_info.ide_interface[1]);
			    	}
			    	
			    	motherboard_treeview.Model = motherboard_treestore;
		    		//motherboard_treeview.ExpandAll();
		    		
		    		//GRAPHIC CARD
		    		TreeStore graphiccard_treestore = new TreeStore (typeof (string));
		    		TreeIter graphiccard_iter;
				    graphiccard_treeview.AppendColumn("Graphic card", new CellRendererText (), "text", 0);
			    	//vga controller info - populate treestore
			    	if ( hardware_info.vga_controller[0] != null ) {
			    		
			    		graphiccard_iter = graphiccard_treestore.AppendValues ("VGA compatible controller");
			    		graphiccard_treestore.AppendValues (graphiccard_iter, hardware_info.vga_controller[0]);
			    		if ( hardware_info.vga_controller[1] != null )
			    			graphiccard_treestore.AppendValues (graphiccard_iter, "Subsystem: " + hardware_info.vga_controller[1]);
			    	}
			    	
			    	graphiccard_treeview.Model = graphiccard_treestore;
		    		//graphiccard_treeview.ExpandAll();
		    		
		    		//SOUND CARD
		    		TreeStore soundcard_treestore = new TreeStore (typeof (string));
		    		TreeIter soundcard_iter;
				    soundcard_treeview.AppendColumn("Sound card", new CellRendererText (), "text", 0);
			    	//multimedia audio info - populate treestore
			    	if ( hardware_info.multimedia_controller[0] != null ) {
			    		
			    		soundcard_iter = soundcard_treestore.AppendValues ("Multmedia audio controller");
			    		soundcard_treestore.AppendValues (soundcard_iter, hardware_info.multimedia_controller[0]);
			    		if ( hardware_info.multimedia_controller[1] != null )
			    			soundcard_treestore.AppendValues (soundcard_iter, "Subsystem: " + hardware_info.multimedia_controller[1]);
			    	}
			    	
			    	soundcard_treeview.Model = soundcard_treestore;
		    		//soundcard_treeview.ExpandAll();
		    		
		    		//NETWORK
		    		TreeStore network_treestore = new TreeStore (typeof (string));
		    		TreeIter network_iter;
				    network_treeview.AppendColumn("Network", new CellRendererText (), "text", 0);
			    	//network info - populate treestore
			    	if ( hardware_info.network_controller[0] != null ) {
			    		
			    		network_iter =  network_treestore.AppendValues ("Network controller");
			    		network_treestore.AppendValues (network_iter, hardware_info.network_controller[0]);
			    		if ( hardware_info.network_controller[1] != null )
			    			network_treestore.AppendValues (network_iter, "Subsystem: " + hardware_info.network_controller[1]);
			    	}
			    	//ethernet info - populate treestore
			    	if ( hardware_info.ethernet_controller[0] != null ) {
			    		
			    		network_iter =  network_treestore.AppendValues ("Ethernet controller");
			    		network_treestore.AppendValues (network_iter, hardware_info.ethernet_controller[0]);
			    		if ( hardware_info.ethernet_controller[1] != null )
			    			network_treestore.AppendValues (network_iter, "Subsystem: " + hardware_info.ethernet_controller[1]);
			    	}
			    	//modem info - populate treestore
			    	if ( hardware_info.modem[0] != null ) {
			    		
			    		network_iter =  network_treestore.AppendValues ("Modem");
			    		network_treestore.AppendValues (network_iter, hardware_info.modem[0]);
			    		if ( hardware_info.modem[1] != null )
			    			network_treestore.AppendValues (network_iter, "Subsystem: " + hardware_info.modem[1]);
			    	}
			    	
			    	network_treeview.Model = network_treestore;
		    		//network_treeview.ExpandAll();
		    	}
			    
			    hardwareA = false;
		    }
		    
		    /*************/
			//NVIDIA event
			if ( notebook1.CurrentPage == 6 ) {
				
				if ( nvidiaA ) {
					
				 	nvidia_image.FromPixbuf = new Gdk.Pixbuf (null, "nvidia_logo.png");
					
					nvidia_info.MainInfo();
					nvidia_info.Version();
					nvidia_info.AditionaInfo();
					
					nvidia_model_entry.Text = nvidia_info.nvidia_model;
					nvidia_ctype_entry.Text = nvidia_info.nvidia_ctype + " " + nvidia_info.nvidia_busrate;
					nvidia_videoram_entry.Text = nvidia_info.nvidia_videoram;
					nvidia_gpu_entry.Text = nvidia_info.nvidia_gpu;
					
					nvidia_version_entry.Text = nvidia_info.nvidia_version;
					
					nvidiaA = false;
				}
				
			}
		}
		
		public void MemoryRefresh() {
				
			//I guess this needs to be updated every time too...
	    	memory_info.MemoryStaticInfo();
	    	memory_total_entry.Text = memory_info.memory_total + " MiB";

	    	//check if swap exists
	    	if ( memory_info.memory_swaptotal == "0" ) {
	    		
	    		memory_swaptotal_entry.Text = "no swap";
	    	}
	    	else
	    		memory_swaptotal_entry.Text = memory_info.memory_swaptotal + " MiB";
	    	
	    	//this needs to be updated every time
	    	memory_info.MemoryDynamicInfo();
	    	
	    	try {
	    		
	    		memory_freep = ( (Int32.Parse(memory_info.memory_free_total) * 100) / Int32.Parse(memory_info.memory_total) ).ToString();
	    		memory_swapfreep = ( (Int32.Parse(memory_info.memory_swapfree) * 100) / Int32.Parse(memory_info.memory_swaptotal) ).ToString();
	    	}
			catch (DivideByZeroException ex) { Console.WriteLine( ex ); }
			
			//progress bar
	    	memory_info.Progressbar1();
	    	memory_progressbar1.Fraction = memory_info.fraction1;
	    	memory_info.Progressbar2();
	    	if ( memory_info.fraction2 > 0 )
	    		memory_progressbar2.Fraction = memory_info.fraction2;
	    	
	    	//more details expander
	    	if (memory_expander.Expanded == false) {
	    	
	    		memory_progressbar1.Text = "Free: " + memory_freep + "%";
	    		
	    		if ( memory_swaptotal_entry.Text == "no swap" )
	    			memory_progressbar2.Text = "no swap";
	    		else
	    			memory_progressbar2.Text ="Free: " +  memory_swapfreep + "%";
	    	}
	    	else {
	    	
	    		memory_progressbar1.Text = "Free: " + memory_freep + "% (" +  memory_info.memory_free_total + " MiB)";
	    		
	    		if ( memory_swaptotal_entry.Text == "no swap" )
	    			memory_progressbar2.Text = "no swap";
	    		else
	    			memory_progressbar2.Text = "Free: " + memory_swapfreep + "% (" +  memory_info.memory_swapfree + " MiB)";
	    	}
	    		
	    	memory_cached_entry.Text = memory_info.memory_cached + " MiB";
	    	memory_active_entry.Text = memory_info.memory_active + " MiB";
	    	memory_inactive_entry.Text = memory_info.memory_inactive + " MiB";

	    	//memoryA = true;
		}
		
		/***************/
		//system expander
		public void on_system_expander_activate (object o, EventArgs e) {
			
			if (system_expander.Expanded == true) {
			
				system_gnomev_entry.Text = system_info.system_gnomev + " (" + system_info.system_gnomeo + ")";
				system_kernelv_entry.Text = system_info.system_kernelv + " (" + system_info.system_kernelb + ")";
			}
			else if (system_expander.Expanded == false) {
			
				system_gnomev_entry.Text = system_info.system_gnomev;
				system_kernelv_entry.Text = system_info.system_kernelv;
			}
		}
		
		//memory expander
		public void on_memory_expander_activate (object o, EventArgs e) {
			
			if (memory_expander.Expanded == true) {
			
			memory_progressbar1.Text = "Free: " + memory_freep + "% (" +  memory_info.memory_free_total + " MiB)";
				
				if ( memory_swaptotal_entry.Text == "no swap" )
		    		memory_progressbar2.Text = "no swap";
		    	else
		    		memory_progressbar2.Text = "Free: " + memory_swapfreep + "% (" +  memory_info.memory_swapfree + " MiB)";
			}
			else if (memory_expander.Expanded == false) {
				
				memory_progressbar1.Text = "Free: " + memory_freep + "%";
				
				if ( memory_swaptotal_entry.Text == "no swap" )
		    		memory_progressbar2.Text = "no swap";
		    	else
		    		memory_progressbar2.Text = "Free: " + memory_swapfreep + "%";
			}
		}
		
		//memory refresh
		public uint memory_refresh_timer;
		
		public void on_memory_refresh_checkbutton_toggled (object o, EventArgs e) {
			
			if ( memory_refresh_checkbutton.Active )
				memory_refresh_timer = GLib.Timeout.Add( 3000 , new GLib.TimeoutHandler(memory_refresh));
		}
		
		public bool memory_refresh () {
			
			MemoryRefresh();
			
			if ( memory_refresh_checkbutton.Active )
				return true;
			else
				return false;
		}
		
		//partitions combobox
		public void on_partitions_combobox_changed (object o, EventArgs e) {
		/*	
			TreeIter iter;
			if (partitions_combobox.GetActiveIter (out iter)) {
				
				if ( partitions_combobox.Model.GetValue (iter, 1).Equals( " /dev/hda ") )
					partitions_notebook.Page = 0;
				if ( partitions_combobox.Model.GetValue (iter, 1).Equals( " /dev/hdb ") )
					partitions_notebook.Page = 1;
				if ( partitions_combobox.Model.GetValue (iter, 1).Equals( " /dev/sda ") )
					partitions_notebook.Page = 2;
				if ( partitions_combobox.Model.GetValue (iter, 1).Equals( " /dev/sdb ") )
					partitions_notebook.Page = 3;
			}*/
		}
		
		//hardware combobox
		public void on_hardware_combobox_changed (object o, EventArgs e) {

			TreeIter iter;
			if (hardware_combobox.GetActiveIter (out iter)) {
				
				if ( hardware_combobox.Model.GetValue (iter, 1).Equals( " Motherboard ") )
					hardware_notebook.Page = 0;
				if ( hardware_combobox.Model.GetValue (iter, 1).Equals( " Graphic card ") )
					hardware_notebook.Page = 1;
				if ( hardware_combobox.Model.GetValue (iter, 1).Equals( " Sound card ") )
					hardware_notebook.Page = 2;
				if ( hardware_combobox.Model.GetValue (iter, 1).Equals( " Network ") )
					hardware_notebook.Page = 3;
			}
		}
		
		Gdk.Pixbuf logoPix = new Gdk.Pixbuf(null, "sysinfo_logo.png");
		Gdk.Pixbuf iconPix = new Gdk.Pixbuf(null, "sysinfo_system.png");
		/**************/
		//welcome button
		public void on_index_clicked (object o, EventArgs e) {
			
			notebook1.CurrentPage = 0;
		}
		
		//launch nvidia-settings button
		public void on_nvidia_button_clicked (object o, EventArgs e) {
			
			System.Diagnostics.Process proc1 = new System.Diagnostics.Process();
			proc1.StartInfo.FileName = "nvidia-settings";
			//proc1.StartInfo.Arguments = "&";
			//proc1.StartInfo.UseShellExecute = false;
			//proc1.StartInfo.RedirectStandardOutput = true;
			proc1.Start();
			//proc1.WaitForExit();
			proc1.Close();
		}
		
		//window delete
		Int32 width, height;
		public void on_window1_delete_event (object sender, DeleteEventArgs a) {
			
			window1.GetSize( out width, out height );
			client.Set ( WINDOW_WIDTH_KEY,  width);
			client.Set ( WINDOW_HEIGHT_KEY,  height);
			
			Application.Quit ();
			a.RetVal = true;
		}
		
		public void on_filechooserdialog1_close (object o, EventArgs e) {
			
			filechooserdialog1.Hide();
		}
		
		//menu - quit
		public void on_quit1_activate (object o, EventArgs e) {
			
			window1.GetSize( out width, out height ); 
			client.Set ( WINDOW_WIDTH_KEY,  width);
			client.Set ( WINDOW_HEIGHT_KEY,  height);
			
			Application.Quit ();
		}
		
		//menu - save to file
		public void on_save1_activate (object o, EventArgs e) {
			
			Int32 result = filechooserdialog1.Run();
			switch ( result ) {
				
				case ( (int) Gtk.ResponseType.Ok ): {
					
					String filename = filechooserdialog1.Filename.ToString();
					save_to_file.Save(filename, system_info, cpu_info, memory_info, storage_info, hardware_info, nvidia_info);
					
					filechooserdialog1.Hide();
					break;
				}
				
				case ( (int) Gtk.ResponseType.Cancel ): {
					
					filechooserdialog1.Hide();
					break;
				}
				
				default:
					break;
				
			}
		}

		//menu - about dialog
		public void on_about1_activate (object o, EventArgs e) {
			
			aboutdialog1.Version = sysinfo_version;
			aboutdialog1.Logo = logoPix;
			aboutdialog1.Icon = iconPix;
			
			aboutdialog1.Show();
		}
		
		//menu - preferences dialog
		public void on_preferences1_activate (object o, EventArgs e) {

			preferences_dialog.Show();
		}
		
		public void on_closebutton1_clicked (object o, EventArgs e) {
			
			preferences_dialog.Hide();
		}
		
		//gconf update
		void UpdateFromGConf () {
			
			try {
				
				initial_animation_checkbutton.Active = (bool) client.Get (INITIAL_ANIMATION_KEY);

				Int32 section_start_number = (int) client.Get (SECTION_START_KEY);
				
				expanders_checkbutton.Active = (bool) client.Get (EXPANDERS_KEY);

				//Int32 window_width = (int) client.Get (WINDOW_WIDTH_KEY);
				//Int32 window_height = (int) client.Get (WINDOW_HEIGHT_KEY);
				
				section_start_combobox.Active = section_start_number; 
			}
			catch (GConf.NoSuchKeyException e) {

				initial_animation_checkbutton.Active = true;
				expanders_checkbutton.Active = false;
				
				client.Set ( INITIAL_ANIMATION_KEY,  true );
				client.Set ( EXPANDERS_KEY,  false );
				
				 Console.WriteLine( e ); 
			}
			catch (System.InvalidCastException e) {  Console.WriteLine( e ); }
			
		}
		
		//initial animation check button
		public void on_initial_animation_checkbutton_toggled (object o, EventArgs e) {

			client.Set ( INITIAL_ANIMATION_KEY,  initial_animation_checkbutton.Active );
		}

		//section to start in combobox - Preferences
		public void on_section_start_combobox_changed (object o, EventArgs e) {
			
			TreeIter iter;
			if (section_start_combobox.GetActiveIter (out iter)) {
				
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "Welcome") ) {
					
					client.Set ( SECTION_START_KEY, 0 );
				}
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "System") ) {
					
					client.Set ( SECTION_START_KEY, 1 );
				}
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "CPU") ) {
					
					client.Set ( SECTION_START_KEY, 2 );
				}
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "Memory") ) {
					
					client.Set ( SECTION_START_KEY, 3 );
				}
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "Storage") ) {
					
					client.Set ( SECTION_START_KEY, 4 );
				}/*
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "Partitions") ) {
					
					client.Set ( SECTION_START_KEY, 5 );
				}*/
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "Hardware") ) {
					
					client.Set ( SECTION_START_KEY, 5 );
				}
				if ( section_start_combobox.Model.GetValue (iter, 0).Equals( "NVIDIA") ) {
					
					client.Set ( SECTION_START_KEY, 6 );
				}
			}
		}
		
		//expaders expanded
		public void on_expanders_checkbutton_toggled (object o, EventArgs e) {
			
			client.Set ( EXPANDERS_KEY,  expanders_checkbutton.Active );
		}
		
		public void GConf_Changed (object sender, NotifyEventArgs args) {
			
			UpdateFromGConf();
		}
		
		/**************/
		//paned animation
		bool hpaned_animation_show() {

			if (main_hpaned.Position < 100) {
					
				main_hpaned.Position = main_hpaned.Position + 10;
				return true;
			}
			else {
				
				showhide_image.SetFromStock("gtk-goto-first", IconSize.Button);
				return false;
			}
		}
		bool hpaned_animation_hide() {

			if (main_hpaned.Position > 1) {
				
				main_hpaned.Position = main_hpaned.Position - 10;
				return true;
			}
			else {
				
				showhide_image.SetFromStock("gtk-goto-last", IconSize.Button);
				return false;
			}
		}
		bool animation_start () {

			animation_timer = GLib.Timeout.Add(40, new GLib.TimeoutHandler(hpaned_animation_show));
			return false;
		}
		
		//time date in statusbar updates
		bool timedate_update () {
			
			String timedate = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString();
			/*+ DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." +
			DateTime.Now.Year.ToString() + ", " +  DateTime.Now.TimeOfDay.Hours.ToString() + ":" +  DateTime.Now.TimeOfDay.Minutes.ToString() + ":" +
			DateTime.Now.TimeOfDay.Seconds.ToString();*/
			statusbar1.Push(0, timedate);
			return true;
		}
		
		//show/hide animation button
		public void on_sh_button_clicked (object o, EventArgs e) {
		
			if (main_hpaned.Position <= 1) {

				animation_timer = GLib.Timeout.Add(40, new GLib.TimeoutHandler(hpaned_animation_show));
			}
			else {
				
				main_hpaned.Position = 100;
				animation_timer = GLib.Timeout.Add(40, new GLib.TimeoutHandler(hpaned_animation_hide));
			}
		}
		
		/************/
		//Cairo drawing
		
		//main cairo drawing class
		MainCairoDrawing main_cairo_drawing = new MainCairoDrawing();
		
		//intro top graphic
		public void on_intro_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
			
			intro_top_drawingarea = (DrawingArea) o;
			Cairo.Context g = Gdk.CairoHelper.Create (intro_top_drawingarea.GdkWindow);
			
			//widget width
			Int32 width = intro_top_drawingarea.Allocation.Width - 14;

			main_cairo_drawing.IntroTop(g, width);
		}	
		
		//intro bottom graphic
		public void on_intro_bottom_drawingarea_expose_event (object o, ExposeEventArgs args) {
		
			intro_bottom_drawingarea = (DrawingArea) o;
			Cairo.Context g = Gdk.CairoHelper.Create (intro_bottom_drawingarea.GdkWindow);
			
			main_cairo_drawing.IntroBottom(g);
		}
		
		//system top graphic
		public void on_system_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
		
			system_top_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (system_top_drawingarea.GdkWindow);
			
			Int32 width = system_top_drawingarea.Allocation.Width - 10;
			
			main_cairo_drawing.SystemTop(g, width);
		}
		
		//cpu top graphic
		public void on_cpu_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
		
			cpu_top_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (cpu_top_drawingarea.GdkWindow);
		   	
			Int32 width = cpu_top_drawingarea.Allocation.Width - 10;
			
		   	main_cairo_drawing.CpuTop(g, width);
		}
		
		//memory top graphic
		public void on_memory_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
		
			memory_top_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (memory_top_drawingarea.GdkWindow);
		    
			Int32 width = memory_top_drawingarea.Allocation.Width - 10;
			
		    main_cairo_drawing.MemoryTop(g, width);
		}
		
		//storage top graphic
		public void on_storage_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
		
			storage_top_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (storage_top_drawingarea.GdkWindow);
		    
			Int32 width = storage_top_drawingarea.Allocation.Width - 10;
			
		  	main_cairo_drawing.StorageTop(g, width);
		}
		
		//partitions top graphic
		public void on_partitions_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
		/*
			partitions_top_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (partitions_top_drawingarea.GdkWindow);
		    
			Int32 width = partitions_top_drawingarea.Allocation.Width - 10;
			
		    main_cairo_drawing.PartitionsTop(g, width);*/
		}
		
		//partitions cairo drawing class
		//PartitionsCairoDrawing partitions_cairo_drawing = new PartitionsCairoDrawing();
		
		//partitions hda drawingarea graphic
		public void on_partitions_hda_drawingarea_expose_event (object o, ExposeEventArgs args) {
		/*
			partitions_hda_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (partitions_hda_drawingarea.GdkWindow);
			
			Int32 edge = partitions_sda_drawingarea.Allocation.Width - 44;
			
			partitions_info.HdaDrawingCalculations(edge);
			if ( partitions_info.hdaB == true )
				partitions_cairo_drawing.HdaDrawing(g, partitions_info.partitions_hdaP, partitions_info.partitions_hda);*/
		}
		
		//partitions hdb drawingarea graphic
		public void on_partitions_hdb_drawingarea_expose_event (object o, ExposeEventArgs args) {
		/*
			partitions_hdb_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (partitions_hdb_drawingarea.GdkWindow);
			
			Int32 edge = partitions_sda_drawingarea.Allocation.Width - 44;
			
			partitions_info.HdbDrawingCalculations(edge);
			if ( partitions_info.hdaB == true )
				partitions_cairo_drawing.HdbDrawing(g, partitions_info.partitions_hdbP, partitions_info.partitions_hdb);*/
		}
		
		//partitions sda drawingarea graphic
		public void on_partitions_sda_drawingarea_expose_event (object o, ExposeEventArgs args) {
		/*
			partitions_sda_drawingarea = (DrawingArea) o;
			Cairo.Context g = Gdk.CairoHelper.Create (partitions_sda_drawingarea.GdkWindow);
			
			Int32 edge = partitions_sda_drawingarea.Allocation.Width - 44;
			
			partitions_info.SdaDrawingCalculations(edge);
			if ( partitions_info.sdaB == true )
				partitions_cairo_drawing.SdaDrawing(g, partitions_info.partitions_sdaP, partitions_info.partitions_sda);*/
		}
		
		//partitions sdb drawingarea graphic
		public void on_partitions_sdb_drawingarea_expose_event (object o, ExposeEventArgs args) {
		/*
			partitions_sdb_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (partitions_sdb_drawingarea.GdkWindow);
			
			Int32 edge = partitions_sda_drawingarea.Allocation.Width - 44;
			
			partitions_info.SdbDrawingCalculations(edge);
			if ( partitions_info.sdbB == true )
				partitions_cairo_drawing.SdbDrawing(g, partitions_info.partitions_sdbP, partitions_info.partitions_sdb);*/
		}
		
		//hardware top graphic
		public void on_hardware_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
		
			hardware_top_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (hardware_top_drawingarea.GdkWindow);
		    
			Int32 width = intro_top_drawingarea.Allocation.Width - 10;
			
		    main_cairo_drawing.HardwareTop(g, width);
		}
		
		//nvidia top graphic
		public void on_nvidia_top_drawingarea_expose_event (object o, ExposeEventArgs args) {
		
			nvidia_top_drawingarea = (DrawingArea) o;
		    Cairo.Context g = Gdk.CairoHelper.Create (nvidia_top_drawingarea.GdkWindow);
		    
			Int32 width = intro_top_drawingarea.Allocation.Width - 10;
			
		    main_cairo_drawing.NvidiaTop(g, width);
		}

	}
}

//ghaefb
