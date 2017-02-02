/*
 * 
 * Author James Houston
 * Email houstonjamez.1@gmail.com
 * Purpose of this program: To make updating and maintaining a weasel network simpler.
 * To have all tools available with a click.
 * To be able to troubleshoot problems that might come up.
 * To maintain and updated, clean, sanitized, and backedup weasel network
 */
using System;
using Gtk;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading;
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

		/*
		 * old file chooser instance
		 * kept in here for reference for the timebeing.
		 * 
		//filechooserbutton1.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
		//filechooserbutton1.SetCurrentFolder("/openweasel/logs");
		*/
		btSSH.Clicked += btSSH_click;
		btPing.Clicked += btPing_click;






	//	static StringBuilder sortOutput = null;



	/*
		String[] lineOfContents = File.ReadAllLines ("hosts.txt");
		foreach (var line in lineOfContents) {
			string[] tokens = line.Split (',');
			combobox1.AppendText (tokens[1]);
		}
	*/
	}
	/*
	 *Ping button method 
	 *needs to import variable from host selection drop down
	 *currently only pinging google
	 *
	*/
	void btPing_click (object obj, EventArgs args)
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

	}
	/*
	 * This method is called after you press on the launch ssh session screen
	 * goal is to have the SSH input screen be able to send ssh commands
	 * currently this method is crashing after button click
	 * may have to revert back to the ping method example
	 * another solution is to have the button open up a terminal window
	 */

	void btSSH_click (object obj, EventArgs args)
	{

		System.Diagnostics.Process procSSH = new System.Diagnostics.Process ();
		procSSH.EnableRaisingEvents = false;
		//procSSH.StartInfo.FileName = "sshpass";
		procSSH.StartInfo.FileName = "ifconfig";
		procSSH.StartInfo.UseShellExecute = false;
		procSSH.StartInfo.RedirectStandardOutput = true;
		//procSSH.StartInfo.Arguments = "-p password ssh -o StrictHostKeyChecking=no warlock@jamesweasel";

	//	sortOutput = new StringBuilder("");

		procSSH.Start();
		procSSH.BeginOutputReadLine();


	

		string dataSSH = procSSH.StandardOutput.ReadToEnd();
		Console.WriteLine(dataSSH);

		//textviewConsoleOutput.Buffer.Text = dataSSH;

	//	textviewConsoleOutput.Buffer.Text = procSSH.BeginOutputReadLine;




		//great code for ping
		/*
	
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


		*/





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
