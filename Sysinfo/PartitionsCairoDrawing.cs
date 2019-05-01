// Filename: PartitionsCairoDrawing.cs
// Contains functions to draw partitions cairo graphics

using System;
using Cairo;
using Gtk;

namespace Sysinfo {
	
	public class PartitionsCairoDrawing {
		
		/**********/
		//hda drawing
		public void HdaDrawing(Cairo.Context g, Double [] partitions_hdaP, String [] partitions_hda) {
			
			g.LineWidth = 3;
			//total space
			PointD p1,s1,p2,s2,p3,s3,p4,s4;
			p1 = new PointD (16 ,28);
			s1 = new PointD (18, 26);
			p2 = new PointD (20 + partitions_hdaP[0] + 2, 26);
			s2 = new PointD (20 + partitions_hdaP[0] + 4, 28);
			p3 = new PointD (20 + partitions_hdaP[0] + 4, 78);
			s3 = new PointD (20 + partitions_hdaP[0] + 2, 80);
			p4 = new PointD (18 , 80);
			s4 = new PointD (16 , 78);
			 
			g.Color = new Color (0, 0, 0, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Stroke();
			g.Color = new Color (1, 1, 1, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Fill();
			
			if ( partitions_hda[1] != null ) {
				
				//hda1 space
				PointD p11,p21,p31,p41;
				p11 = new PointD (20, 30);
				p21 = new PointD (20 + (partitions_hdaP[1]), 30);
				p31 = new PointD (20 + (partitions_hdaP[1]), 76);
				p41 = new PointD (20, 76);
				
				g.Color = new Color (0.93, 0.83, 0, 1);
				g.MoveTo (p11); g.LineTo (p21); g.LineTo (p31); g.LineTo (p41); g.LineTo (p11);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hda[2] != null ) {
				
				//hda2 space
				PointD p12,p22,p32,p42;
				p12 = new PointD (20 + (partitions_hdaP[1]), 30);
				p22 = new PointD (20 + (partitions_hdaP[1]) + (partitions_hdaP[2]), 30);
				p32 = new PointD (20 + (partitions_hdaP[1]) + (partitions_hdaP[2]), 76);
				p42 = new PointD (20 + (partitions_hdaP[1]), 76);
				
				g.Color = new Color (0.45, 0.82, 0.09, 1);
				g.MoveTo (p12); g.LineTo (p22); g.LineTo (p32); g.LineTo (p42);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hda[3] != null ) {
				
				//hda3 space
				PointD p13,p23,p33,p43;
				p13 = new PointD (20 + (partitions_hdaP[1]) + (partitions_hdaP[2]), 30);
				p23 = new PointD (20 + (partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]), 30);
				p33 = new PointD (20 + (partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]), 76);
				p43 = new PointD (20 + (partitions_hdaP[1]) + (partitions_hdaP[2]), 76);
				
				g.Color = new Color (0.8, 0, 0, 1);
				g.MoveTo (p13); g.LineTo (p23); g.LineTo (p33); g.LineTo (p43);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hda[4] != null ) {
				
				//hda4 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]), 30);
				p24 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]), 30);
				p34 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]), 76);
				p44 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]), 76);
				
				g.Color = new Color (0.2, 0.4, 0.64, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hda[5] != null ) {
				
				//hda5 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]), 30);
				p24 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]), 30);
				p34 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]), 76);
				p44 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]), 76);
				
				g.Color = new Color (0.75, 0.5, 0.07, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hda[6] != null ) {
				
				//hda6 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]), 30);
				p24 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]) + (partitions_hdaP[6]), 30);
				p34 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]) + (partitions_hdaP[6]), 76);
				p44 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]), 76);
				
				g.Color = new Color (0.45, 0.31, 0.48, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hda[7] != null ) {
				
				//hda7 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5])+ (partitions_hdaP[6]), 30);
				p24 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]) + (partitions_hdaP[6])+ (partitions_hdaP[7]), 30);
				p34 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]) + (partitions_hdaP[6])+ (partitions_hdaP[7]), 76);
				p44 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5])+ (partitions_hdaP[6]), 76);
				
				g.Color = new Color (0.96, 0.47, 0, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hda[8] != null ) {
				
				//hda8 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5])+ (partitions_hdaP[6])+ (partitions_hdaP[7]), 30);
				p24 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]) + (partitions_hdaP[6])+ (partitions_hdaP[7])+ (partitions_hdaP[8]), 30);
				p34 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5]) + (partitions_hdaP[6])+ (partitions_hdaP[7])+ (partitions_hdaP[8]), 76);
				p44 = new PointD(20+(partitions_hdaP[1]) + (partitions_hdaP[2]) + (partitions_hdaP[3]) +
				                     (partitions_hdaP[4]) + (partitions_hdaP[5])+ (partitions_hdaP[6])+ (partitions_hdaP[7]), 76);
				
				g.Color = new Color (0.33, 0.34, 0.33, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			g.SetFontSize(12);
			g.MoveTo ( new PointD((partitions_hdaP[0] - 80) / 2, 15));
			g.Color = new Color (0, 0, 0, 1);
			g.ShowText ("Total space: " + partitions_hda[0]);
			
			((IDisposable) g.Target).Dispose ();                               
		   	((IDisposable) g).Dispose ();
		}
		
		/**********/
		//hdb drawing
		public void HdbDrawing(Cairo.Context g, Double [] partitions_hdbP, String [] partitions_hdb) {
			
			g.LineWidth = 3;
			//total space
			PointD p1,s1,p2,s2,p3,s3,p4,s4;
			p1 = new PointD (16 ,28);
			s1 = new PointD (18, 26);
			p2 = new PointD (20 + partitions_hdbP[0] + 2, 26);
			s2 = new PointD (20 + partitions_hdbP[0] + 4, 28);
			p3 = new PointD (20 + partitions_hdbP[0] + 4, 78);
			s3 = new PointD (20 + partitions_hdbP[0] + 2, 80);
			p4 = new PointD (18 , 80);
			s4 = new PointD (16 , 78);
			 
			g.Color = new Color (0, 0, 0, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Stroke();
			g.Color = new Color (1, 1, 1, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Fill();
			
			if ( partitions_hdb[1] != null ) {
				
				//hdb1 space
				PointD p11,p21,p31,p41;
				p11 = new PointD (20, 30);
				p21 = new PointD (20 + (partitions_hdbP[1]), 30);
				p31 = new PointD (20 + (partitions_hdbP[1]), 76);
				p41 = new PointD (20, 76);
				
				g.Color = new Color (0.93, 0.83, 0, 1);
				g.MoveTo (p11); g.LineTo (p21); g.LineTo (p31); g.LineTo (p41); g.LineTo (p11);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hdb[2] != null ) {
				
				//hdb2 space
				PointD p12,p22,p32,p42;
				p12 = new PointD (20 + (partitions_hdbP[1]), 30);
				p22 = new PointD (20 + (partitions_hdbP[1]) + (partitions_hdbP[2]), 30);
				p32 = new PointD (20 + (partitions_hdbP[1]) + (partitions_hdbP[2]), 76);
				p42 = new PointD (20 + (partitions_hdbP[1]), 76);
				
				g.Color = new Color (0.45, 0.82, 0.09, 1);
				g.MoveTo (p12); g.LineTo (p22); g.LineTo (p32); g.LineTo (p42);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hdb[3] != null ) {
				
				//hdb3 space
				PointD p13,p23,p33,p43;
				p13 = new PointD (20 + (partitions_hdbP[1]) + (partitions_hdbP[2]), 30);
				p23 = new PointD (20 + (partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]), 30);
				p33 = new PointD (20 + (partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]), 76);
				p43 = new PointD (20 + (partitions_hdbP[1]) + (partitions_hdbP[2]), 76);
				
				g.Color = new Color (0.8, 0, 0, 1);
				g.MoveTo (p13); g.LineTo (p23); g.LineTo (p33); g.LineTo (p43);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hdb[4] != null ) {
				
				//hdb4 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]), 30);
				p24 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]), 30);
				p34 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]), 76);
				p44 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]), 76);
				
				g.Color = new Color (0.2, 0.4, 0.64, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hdb[5] != null ) {
				
				//hdb5 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]), 30);
				p24 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]), 30);
				p34 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]), 76);
				p44 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]), 76);
				
				g.Color = new Color (0.75, 0.5, 0.07, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hdb[6] != null ) {
				
				//hdb6 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]), 30);
				p24 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]) + (partitions_hdbP[6]), 30);
				p34 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]) + (partitions_hdbP[6]), 76);
				p44 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]), 76);
				
				g.Color = new Color (0.45, 0.31, 0.48, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hdb[7] != null ) {
				
				//hdb7 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5])+ (partitions_hdbP[6]), 30);
				p24 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]) + (partitions_hdbP[6])+ (partitions_hdbP[7]), 30);
				p34 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]) + (partitions_hdbP[6])+ (partitions_hdbP[7]), 76);
				p44 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5])+ (partitions_hdbP[6]), 76);
				
				g.Color = new Color (0.96, 0.47, 0, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_hdb[8] != null ) {
				
				//hdb8 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5])+ (partitions_hdbP[6])+ (partitions_hdbP[7]), 30);
				p24 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]) + (partitions_hdbP[6])+ (partitions_hdbP[7])+ (partitions_hdbP[8]), 30);
				p34 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5]) + (partitions_hdbP[6])+ (partitions_hdbP[7])+ (partitions_hdbP[8]), 76);
				p44 = new PointD(20+(partitions_hdbP[1]) + (partitions_hdbP[2]) + (partitions_hdbP[3]) +
				                     (partitions_hdbP[4]) + (partitions_hdbP[5])+ (partitions_hdbP[6])+ (partitions_hdbP[7]), 76);
				
				g.Color = new Color (0.33, 0.34, 0.33, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			g.SetFontSize(12);
			g.MoveTo ( new PointD((partitions_hdbP[0] - 80) / 2, 15));
			g.Color = new Color (0, 0, 0, 1);
			g.ShowText ("Total space: " + partitions_hdb[0]);
			
			((IDisposable) g.Target).Dispose ();                               
		   	((IDisposable) g).Dispose ();
		}
		
		/**********/
		//sda drawing
		public void SdaDrawing(Cairo.Context g, Double [] partitions_sdaP, String [] partitions_sda) {
			
			g.LineWidth = 3;
			//total space
			PointD p1,s1,p2,s2,p3,s3,p4,s4;
			p1 = new PointD (16 ,28);
			s1 = new PointD (18, 26);
			p2 = new PointD (20 + partitions_sdaP[0] + 2, 26);
			s2 = new PointD (20 + partitions_sdaP[0] + 4, 28);
			p3 = new PointD (20 + partitions_sdaP[0] + 4, 78);
			s3 = new PointD (20 + partitions_sdaP[0] + 2, 80);
			p4 = new PointD (18 , 80);
			s4 = new PointD (16 , 78);
			 
			g.Color = new Color (0, 0, 0, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Stroke();
			g.Color = new Color (1, 1, 1, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Fill();
			
			if ( partitions_sda[1] != null ) {
				
				//sda1 space
				PointD p11,p21,p31,p41;
				p11 = new PointD (20 , 30);
				p21 = new PointD (20 + (partitions_sdaP[1]), 30);
				p31 = new PointD (20 + (partitions_sdaP[1]), 76);
				p41 = new PointD (20 , 76);
				
				g.Color = new Color (0.93, 0.83, 0, 1);
				g.MoveTo (p11); g.LineTo (p21); g.LineTo (p31); g.LineTo (p41); g.LineTo (p11);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sda[2] != null ) {
				
				//sda2 space
				PointD p12,p22,p32,p42;
				p12 = new PointD (20 + (partitions_sdaP[1]), 30);
				p22 = new PointD (20 + (partitions_sdaP[1]) + (partitions_sdaP[2]), 30);
				p32 = new PointD (20 + (partitions_sdaP[1]) + (partitions_sdaP[2]), 76);
				p42 = new PointD (20 + (partitions_sdaP[1]), 76);
				
				g.Color = new Color (0.45, 0.82, 0.09, 1);
				g.MoveTo (p12); g.LineTo (p22); g.LineTo (p32); g.LineTo (p42);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sda[3] != null ) {
				
				//sda3 space
				PointD p13,p23,p33,p43;
				p13 = new PointD (20 + (partitions_sdaP[1]) + (partitions_sdaP[2]), 30);
				p23 = new PointD (20 + (partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]), 30);
				p33 = new PointD (20 + (partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]), 76);
				p43 = new PointD (20 + (partitions_sdaP[1]) + (partitions_sdaP[2]), 76);
				
				g.Color = new Color (0.8, 0, 0, 1);
				g.MoveTo (p13); g.LineTo (p23); g.LineTo (p33); g.LineTo (p43);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sda[4] != null ) {
				
				//sda4 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]), 30);
				p24 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]), 30);
				p34 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]), 76);
				p44 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]), 76);
				
				g.Color = new Color (0.2, 0.4, 0.64, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sda[5] != null ) {
				
				//sda5 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]), 30);
				p24 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]), 30);
				p34 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]), 76);
				p44 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]), 76);
				
				g.Color = new Color (0.75, 0.5, 0.07, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sda[6] != null ) {
				
				//sda6 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]), 30);
				p24 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]) + (partitions_sdaP[6]), 30);
				p34 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]) + (partitions_sdaP[6]), 76);
				p44 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]), 76);
				
				g.Color = new Color (0.45, 0.31, 0.48, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sda[7] != null ) {
				
				//sda7 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5])+ (partitions_sdaP[6]), 30);
				p24 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]) + (partitions_sdaP[6])+ (partitions_sdaP[7]), 30);
				p34 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]) + (partitions_sdaP[6])+ (partitions_sdaP[7]), 76);
				p44 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5])+ (partitions_sdaP[6]), 76);
				
				g.Color = new Color (0.96, 0.47, 0, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sda[8] != null ) {
				
				//sda8 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5])+ (partitions_sdaP[6])+ (partitions_sdaP[7]), 30);
				p24 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]) + (partitions_sdaP[6])+ (partitions_sdaP[7])+ (partitions_sdaP[8]), 30);
				p34 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5]) + (partitions_sdaP[6])+ (partitions_sdaP[7])+ (partitions_sdaP[8]), 76);
				p44 = new PointD(20+(partitions_sdaP[1]) + (partitions_sdaP[2]) + (partitions_sdaP[3]) +
				                     (partitions_sdaP[4]) + (partitions_sdaP[5])+ (partitions_sdaP[6])+ (partitions_sdaP[7]), 76);
				
				g.Color = new Color (0.33, 0.34, 0.33, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			g.SetFontSize(12);
			g.MoveTo ( new PointD((partitions_sdaP[0] - 80) / 2, 15));
			g.Color = new Color (0, 0, 0, 1);
			g.ShowText ("Total space: " + partitions_sda[0]);
			
			((IDisposable) g.Target).Dispose ();                               
		   	((IDisposable) g).Dispose ();
		}
		
		/**********/
		//sdb drawing
		public void SdbDrawing(Cairo.Context g, Double [] partitions_sdbP, String [] partitions_sdb) {
			
			g.LineWidth = 3;
			//total space
			PointD p1,s1,p2,s2,p3,s3,p4,s4;
			p1 = new PointD (16 ,28);
			s1 = new PointD (18, 26);
			p2 = new PointD (20 + partitions_sdbP[0] + 2, 26);
			s2 = new PointD (20 + partitions_sdbP[0] + 4, 28);
			p3 = new PointD (20 + partitions_sdbP[0] + 4, 78);
			s3 = new PointD (20 + partitions_sdbP[0] + 2, 80);
			p4 = new PointD (18 , 80);
			s4 = new PointD (16 , 78);
			 
			g.Color = new Color (0, 0, 0, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Stroke();
			g.Color = new Color (1, 1, 1, 1);
			g.MoveTo (p1); g.LineTo (s1); g.LineTo (p2); g.LineTo (s2); g.LineTo (p3); g.LineTo (s3); g.LineTo (p4); g.LineTo (s4);
			g.ClosePath (); g.Fill();
			
			if ( partitions_sdb[1] != null ) {
				
				//sdb1 space
				PointD p11,p21,p31,p41;
				p11 = new PointD (20, 30);
				p21 = new PointD (20 + (partitions_sdbP[1]), 30);
				p31 = new PointD (20 + (partitions_sdbP[1]), 76);
				p41 = new PointD (20, 76);
				
				g.Color = new Color (0.93, 0.83, 0, 1);
				g.MoveTo (p11); g.LineTo (p21); g.LineTo (p31); g.LineTo (p41); g.LineTo (p11);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sdb[2] != null ) {
				
				//sdb2 space
				PointD p12,p22,p32,p42;
				p12 = new PointD (20 + (partitions_sdbP[1]), 30);
				p22 = new PointD (20 + (partitions_sdbP[1]) + (partitions_sdbP[2]), 30);
				p32 = new PointD (20 + (partitions_sdbP[1]) + (partitions_sdbP[2]), 76);
				p42 = new PointD (20 + (partitions_sdbP[1]), 76);
				
				g.Color = new Color (0.45, 0.82, 0.09, 1);
				g.MoveTo (p12); g.LineTo (p22); g.LineTo (p32); g.LineTo (p42);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sdb[3] != null ) {
				
				//sdb3 space
				PointD p13,p23,p33,p43;
				p13 = new PointD (20 + (partitions_sdbP[1]) + (partitions_sdbP[2]), 30);
				p23 = new PointD (20 + (partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]), 30);
				p33 = new PointD (20 + (partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]), 76);
				p43 = new PointD (20 + (partitions_sdbP[1]) + (partitions_sdbP[2]), 76);
				
				g.Color = new Color (0.8, 0, 0, 1);
				g.MoveTo (p13); g.LineTo (p23); g.LineTo (p33); g.LineTo (p43);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sdb[4] != null ) {
				
				//sdb4 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]), 30);
				p24 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]), 30);
				p34 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]), 76);
				p44 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]), 76);
				
				g.Color = new Color (0.2, 0.4, 0.64, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sdb[5] != null ) {
				
				//sdb5 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]), 30);
				p24 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]), 30);
				p34 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]), 76);
				p44 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]), 76);
				
				g.Color = new Color (0.75, 0.5, 0.07, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sdb[6] != null ) {
				
				//sdb6 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]), 30);
				p24 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]) + (partitions_sdbP[6]), 30);
				p34 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]) + (partitions_sdbP[6]), 76);
				p44 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]), 76);
				
				g.Color = new Color (0.45, 0.31, 0.48, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sdb[7] != null ) {
				
				//sdb7 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5])+ (partitions_sdbP[6]), 30);
				p24 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]) + (partitions_sdbP[6])+ (partitions_sdbP[7]), 30);
				p34 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]) + (partitions_sdbP[6])+ (partitions_sdbP[7]), 76);
				p44 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5])+ (partitions_sdbP[6]), 76);
				
				g.Color = new Color (0.96, 0.47, 0, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			if ( partitions_sdb[8] != null ) {
				
				//sdb8 space
				PointD p14,p24,p34,p44;
				p14 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5])+ (partitions_sdbP[6])+ (partitions_sdbP[7]), 30);
				p24 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]) + (partitions_sdbP[6])+ (partitions_sdbP[7])+ (partitions_sdbP[8]), 30);
				p34 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5]) + (partitions_sdbP[6])+ (partitions_sdbP[7])+ (partitions_sdbP[8]), 76);
				p44 = new PointD(20+(partitions_sdbP[1]) + (partitions_sdbP[2]) + (partitions_sdbP[3]) +
				                     (partitions_sdbP[4]) + (partitions_sdbP[5])+ (partitions_sdbP[6])+ (partitions_sdbP[7]), 76);
				
				g.Color = new Color (0.33, 0.34, 0.33, 1);
				g.MoveTo (p14); g.LineTo (p24); g.LineTo (p34); g.LineTo (p44);
				g.ClosePath(); g.Fill();
			}
			
			g.SetFontSize(12);
			g.MoveTo ( new PointD((partitions_sdbP[0] - 80) / 2, 15));
			g.Color = new Color (0, 0, 0, 1);
			g.ShowText ("Total space: " + partitions_sdb[0]);
			
			((IDisposable) g.Target).Dispose ();                               
		   	((IDisposable) g).Dispose ();
		}
		
	}
}

//ghaefb
