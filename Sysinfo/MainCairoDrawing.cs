// Filename: MainCairoDrawing.cs
// Contains functions to draw main cairo graphics

using System;
using Cairo;
using Gtk;

namespace Sysinfo {
	
	public class MainCairoDrawing {
		
		//intro top Welcome
		public void IntroTop(Cairo.Context g, Int32 width) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
			p1 = new PointD (10,10); p2 = new PointD (width, 10); s1 = new PointD (width + 2, 12); s2 = new PointD (width + 2, 38);
			p3 = new PointD (width, 40); p4 = new PointD (10,40); s3 = new PointD (8, 38); s4 = new PointD (8, 12);
			    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
				
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 80);
			pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
			pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
			g.Pattern = pat; g.FillPreserve  ();

			g.SetFontSize(22);
			g.SelectFontFace ("", FontSlant.Italic, FontWeight.Bold);
			g.MoveTo ( new PointD(22, 33));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("Welcome to");
			   
			((IDisposable) g.Target).Dispose ();                               
			((IDisposable) g).Dispose ();
		}
		
		//intro bottom tips
		public void IntroBottom(Cairo.Context g) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (30,10); p2 = new PointD (420, 10); s1 = new PointD (422, 12); s2 = new PointD (422, 88);
		    p3 = new PointD (420, 90); p4 = new PointD (30,90); s3 = new PointD (28, 88); s4 = new PointD (28, 12);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 0.8);
		    g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,20, 80, 80);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0));
	        pat.AddColorStop (1, new Cairo.Color (0.3,0.4,0.6,0.3));
	        g.Pattern = pat;
		    g.FillPreserve  ();
		    	    
		    
			g.Color = new Color (0, 0, 0, 0.8);
			g.SelectFontFace ("", FontSlant.Italic , FontWeight.Bold );
			g.SetFontSize(18);
			g.MoveTo ( new PointD(88, 28) );
			g.ShowText (".");
			g.MoveTo ( new PointD(88, 58) );
			g.ShowText (".");
			g.SelectFontFace ("", FontSlant.Italic , FontWeight.Normal );
			g.SetFontSize(10);
			g.MoveTo ( new PointD(98, 30) );
			g.ShowText ("Use the navigation on the left to choose different categories");
			g.MoveTo ( new PointD(98, 42) );
			g.ShowText ("of your computer and system information to display.");
			g.MoveTo ( new PointD(98, 60) );
			g.ShowText ("When you click on a category in the navigation, the dynamic");
			g.MoveTo ( new PointD(98, 72) );
		    g.ShowText ("information is automatically refreshed.");
					
			g.MoveTo ( new PointD(38, 35));
			g.Color = new Color (0.3, 0.4, 0.6, 1);
			g.SelectFontFace ("", FontSlant.Normal , FontWeight.Bold );
			g.SetFontSize(18);
			g.ShowText ("Tips");
			
			g.NewPath ();
			/*
			g.Color = new Color (0.3, 0.4, 0.6, 0.8);
			g.Scale (34, 34);
			g.LineWidth = 0.06;
			g.Arc (1.0, 1.0, 0.6, 0, 360);
			g.Stroke ();*/
		    
		   	((IDisposable) g.Target).Dispose ();                               
		   	((IDisposable) g).Dispose ();
		}
		
		//system top
		public void SystemTop(Cairo.Context g, Int32 width) {
			
		    PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (5,5); p2 = new PointD (width, 5); s1 = new PointD (width + 2, 7); s2 = new PointD (width + 2, 28);
		    p3 = new PointD (width, 30); p4 = new PointD (5,30); s3 = new PointD (3, 28); s4 = new PointD (3, 7);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1);  g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 60);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
	       	pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
	        g.Pattern = pat;
		    g.FillPreserve  ();

		    g.SetFontSize(17);
			g.SelectFontFace ("", FontSlant.Normal, FontWeight.Bold);
			g.MoveTo ( new PointD(12, 23));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("General system information");
		   
		   ((IDisposable) g.Target).Dispose ();                               
		   ((IDisposable) g).Dispose ();
		}
		
		//cpu top
		public void CpuTop(Cairo.Context g, Int32 width) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (5,5); p2 = new PointD (width, 5); s1 = new PointD (width + 2, 7); s2 = new PointD (width + 2, 28);
		    p3 = new PointD (width, 30); p4 = new PointD (5,30); s3 = new PointD (3, 28); s4 = new PointD (3, 7);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1);  g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 60);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
	       	pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
	        g.Pattern = pat;
		    g.FillPreserve  ();

		    g.SetFontSize(17);
			g.SelectFontFace ("", FontSlant.Normal, FontWeight.Bold);
			g.MoveTo ( new PointD(12, 23));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("CPU information");
		   
		   ((IDisposable) g.Target).Dispose ();                               
		   ((IDisposable) g).Dispose ();
		}
		
		
		//memory top
		public void MemoryTop(Cairo.Context g, Int32 width) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (5,5); p2 = new PointD (width, 5); s1 = new PointD (width + 2, 7); s2 = new PointD (width + 2, 28);
		    p3 = new PointD (width, 30); p4 = new PointD (5,30); s3 = new PointD (3, 28); s4 = new PointD (3, 7);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1);  g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 60);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
	       	pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
	        g.Pattern = pat;
		    g.FillPreserve  ();
			
		    g.SetFontSize(17);
			g.SelectFontFace ("", FontSlant.Normal, FontWeight.Bold);
			g.MoveTo ( new PointD(12, 23));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("Memory information");
		   
		   ((IDisposable) g.Target).Dispose ();                               
		   ((IDisposable) g).Dispose ();
		}
		
		//storage top
		public void StorageTop(Cairo.Context g, Int32 width) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (5,5); p2 = new PointD (width, 5); s1 = new PointD (width + 2, 7); s2 = new PointD (width + 2, 28);
		    p3 = new PointD (width, 30); p4 = new PointD (5,30); s3 = new PointD (3, 28); s4 = new PointD (3, 7);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1);  g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 60);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
	       	pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
	        g.Pattern = pat;
		    g.FillPreserve  ();
			
		    g.SetFontSize(17);
			g.SelectFontFace ("", FontSlant.Normal, FontWeight.Bold);
			g.MoveTo ( new PointD(12, 23));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("Storage information");
		   
		   ((IDisposable) g.Target).Dispose ();                               
		   ((IDisposable) g).Dispose ();
		}
		
		//partitions top
		public void PartitionsTop(Cairo.Context g, Int32 width) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (5,5); p2 = new PointD (width, 5); s1 = new PointD (width + 2, 7); s2 = new PointD (width + 2, 28);
		    p3 = new PointD (width, 30); p4 = new PointD (5,30); s3 = new PointD (3, 28); s4 = new PointD (3, 7);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1);  g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 60);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
	       	pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
	        g.Pattern = pat;
		    g.FillPreserve  ();
			
		    g.SetFontSize(17);
			g.SelectFontFace ("", FontSlant.Normal, FontWeight.Bold);
			g.MoveTo ( new PointD(12, 23));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("Partitions information");
		   
		   ((IDisposable) g.Target).Dispose ();                               
		   ((IDisposable) g).Dispose ();
		}
		
		//hardware top
		public void HardwareTop(Cairo.Context g, Int32 width) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (5,5); p2 = new PointD (width, 5); s1 = new PointD (width + 2, 7); s2 = new PointD (width + 2, 28);
		    p3 = new PointD (width, 30); p4 = new PointD (5,30); s3 = new PointD (3, 28); s4 = new PointD (3, 7);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1);  g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 60);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
	       	pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
	        g.Pattern = pat;
		    g.FillPreserve  ();
			
		    g.SetFontSize(17);
			g.SelectFontFace ("", FontSlant.Normal, FontWeight.Bold);
			g.MoveTo ( new PointD(12, 23));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("Hardware information");
		   
		   ((IDisposable) g.Target).Dispose ();                               
		   ((IDisposable) g).Dispose ();
		}
		
		//nvidia top
		public void NvidiaTop(Cairo.Context g, Int32 width) {
			
			PointD p1,p2,p3,p4,s1,s2,s3,s4;
		    p1 = new PointD (5,5); p2 = new PointD (width, 5); s1 = new PointD (width + 2, 7); s2 = new PointD (width + 2, 28);
		    p3 = new PointD (width, 30); p4 = new PointD (5,30); s3 = new PointD (3, 28); s4 = new PointD (3, 7);
		    
		    g.Color = new Color (0.3, 0.4, 0.6, 1);
		    g.MoveTo (p1); g.LineTo (p2);  g.LineTo (s1);  g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
		    g.ClosePath (); g.LineWidth = 1; g.Stroke  ();
		   	
	        g.MoveTo (p1); g.LineTo (p2); g.LineTo (s1); g.LineTo (s2); g.LineTo (p3); g.LineTo (p4); g.LineTo (s3); g.LineTo (s4); g.LineTo (p1);
			g.ClosePath ();
			
		    Cairo.Gradient pat = new Cairo.LinearGradient (80,10, 80, 60);
	        pat.AddColorStop (0, new Cairo.Color (0.3,0.4,0.6,0.6));
	       	pat.AddColorStop (1, new Cairo.Color (0,0,0,1));
	        g.Pattern = pat;
		    g.FillPreserve  ();
			
		    g.SetFontSize(17);
			g.SelectFontFace ("", FontSlant.Normal, FontWeight.Bold);
			g.MoveTo ( new PointD(12, 23));
			g.Color = new Color (1, 1, 1, 1);
			g.ShowText ("NVIDIA graphic card information");
		   
		   ((IDisposable) g.Target).Dispose ();                               
		   ((IDisposable) g).Dispose ();
		}
			
	}
}

//ghaefb
