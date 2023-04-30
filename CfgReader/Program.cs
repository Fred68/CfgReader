﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

using Fred68.CfgReader;


namespace Test
	{
	internal class Program
		{

		class CfgR2 : CfgReader
			{
			public int Paperino;
			public float ccc;
			public List<int> ddd;

			public string Dump()
				{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine($"CfgR2.Dump():");
				sb.AppendLine($"Paperino={Paperino}");
				sb.AppendLine($"ccc={ccc}");
				sb.AppendLine($"ddd={ddd}");

				return sb.ToString();
				}
			}

		static void Main(string[] args)
			{
			string filename = "esempio.txt";
			//string filename = "db.cfg";
			Console.WriteLine("Avvio programma.");

			
			// UTILIZZO SEMPLICE COME DIZIONARIO

			Console.WriteLine("Utilizzo come dizionario...");

			dynamic cfgR = new CfgReader();							// Crea l'oggetto della classe base
			cfgR.ReadConfiguration(filename);						// Legge la configurazione		
			Console.WriteLine(cfgR.ToString());						// Visualizza i messaggi
			try
				{
				Console.WriteLine("cc = " + cfgR.cc);
				cfgR.cc = 100.3f;
				Console.WriteLine("cc = " + cfgR.cc);
				}
			catch (Exception ex)
				{
				Console.WriteLine(ex.Message);
				}

			#if true
			Console.WriteLine("Variabili importate:");				// Comando DUMP
			Console.WriteLine(cfgR.DumpEntries());
			Console.WriteLine("Linee:");							// Comando LINES
			Console.WriteLine(cfgR.DumpLines());
			#endif


			// UTILIZZO CON CLASSE DERIVATA

			Console.WriteLine("Utilizzo con classe derivata...");
			
			CfgR2 cf2 = new CfgR2();							// Crea l'oggetto della classe derivata
			cf2.ReadConfiguration(filename);					// Legge la configurazione (classe base)
			bool ok = cf2.GetNames(true);						// Imposta le variabili (da classe base a derivata), eliminandole dal dizionario
			Console.WriteLine(cf2.ToString());					// Visualizza i messaggi (da classe base)
			
			Console.WriteLine(cf2.Dump());						// Stampa le variabili (funzione della classe derivata)
			Console.WriteLine(cf2.DumpEntries());				// Stampa il contenuto del dizionario
			cf2.Clear();										// Cancella tutti i dati letti (della classe base)

			Console.WriteLine("Fine programma.");
			Console.ReadKey();
			}
		}
	}
