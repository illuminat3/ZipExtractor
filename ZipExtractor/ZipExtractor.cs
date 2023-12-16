using System.IO.Compression;
using System.Net;

namespace ZipExtractor {
  class ZipExtractor {
      private static string fileName = "download.zip";
      private static string savePath = "";
  
  
      public static void Download(string downloadLink, string originalSavePath)
      {
          
          savePath = originalSavePath + "\\" + fileName;

          if (!Directory.Exists(originalSavePath))
          {
              Directory.CreateDirectory(originalSavePath);
          }
  
          using (var httpClient = new HttpClient())
          {
              using (WebClient client = new WebClient())
              {
                  client.DownloadFile(downloadLink, savePath);
              }
          }
      }
  
      public static void ExtractZipFile(string originalSavePath)
      {
            savePath = originalSavePath + "\\" + fileName;
            ZipFile.ExtractToDirectory(savePath, originalSavePath);
      }

      public static void DownloadAndExtract(string downloadLink, string originalSavePath) 
      {

            savePath = originalSavePath + "\\" + fileName;
            //Create Dir if it doesnt already exist
            if (!Directory.Exists(originalSavePath))
          {
              Directory.CreateDirectory(originalSavePath);
          }

        //Download ZipFile using webclient
        using (var httpClient = new HttpClient())
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(downloadLink, savePath);
            }
        }

        //Extract ZipFile
        ZipFile.ExtractToDirectory(savePath, originalSavePath);
      }
  }
}
