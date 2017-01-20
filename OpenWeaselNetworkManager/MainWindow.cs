using System;
using Gtk;
using System.IO;
using System.Text;
using System.Windows.Forms;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		try {
			StreamReader sr = new StreamReader (@"hosts.txt");
			string line = sr.ReadLine ();

			while (line != null) {
				combobox1.AppendText (line);
				line = sr.ReadLine ();

			}

		} catch (Exception ex) {
		}




	/*
		String[] lineOfContents = File.ReadAllLines ("hosts.txt");
		foreach (var line in lineOfContents) {
			string[] tokens = line.Split (',');
			combobox1.AppendText (tokens[1]);
		}
	*/
	}
	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
		a.RetVal = true;
	}
}
