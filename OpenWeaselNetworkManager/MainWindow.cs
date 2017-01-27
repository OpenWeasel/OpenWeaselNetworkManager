using System;
using Gtk;
using System.IO;
using System.Text;
using System.Diagnostics;
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
				comboboxSelectHost.AppendText (line);
				line = sr.ReadLine ();

			}

		} catch (Exception ex) {
		}


		//filechooserbutton1.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
		//filechooserbutton1.SetCurrentFolder("/openweasel/logs");
		btSSH.Clicked += btSSH_click;
		Console.WriteLine("test");










	/*
		String[] lineOfContents = File.ReadAllLines ("hosts.txt");
		foreach (var line in lineOfContents) {
			string[] tokens = line.Split (',');
			combobox1.AppendText (tokens[1]);
		}
	*/
	}

	void btSSH_click (object obj, EventArgs args)
	{
	
		System.Diagnostics.Process proc = new System.Diagnostics.Process ();
		proc.EnableRaisingEvents = false;
		proc.StartInfo.FileName = "ping";
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo.RedirectStandardOutput = true;
		proc.StartInfo.Arguments = "-c 1 -W 1 google.com";
		proc.Start ();

		string data = proc.StandardOutput.ReadToEnd();
		Console.WriteLine(data);
		textviewConsoleOutput.Buffer.Text = data;
		/*
		proc.StartInfo.RedirectStandardOutput = true;
		proc.StartInfo.UseShellExecute = false;
		StringBuilder q = new StringBuilder ();
		while (! proc.HasExited) {
			q.Append (proc.StandardOutput.ReadToEnd ());
		}
		string r = q.ToString();
*/


		//proc.WaitForExit();

		//string data = proc.StandardOutput.ReadToEnd();
		//Console.WriteLine(data);
		//string data = proc.StandardOutput.ReadToEnd();
		//Console.WriteLine(data + " was returned");
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
		a.RetVal = true;
	}
}
