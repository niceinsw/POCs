using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PocReportingCache
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string fileName = "cache_20181121.json";
            //var res = ReadBlobFileWithSasToken(BuildSasToken(fileName)).Result;

            ReadBlobFileWithoutSasToken().Wait();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static async Task<string> ReadBlobFileWithSasToken(Func<string> sasUriBuilder)
        {
            string sasUri = sasUriBuilder();
            var blob = new CloudBlockBlob(new Uri(sasUri));
            try
            {
                return await blob.DownloadTextAsync();

            }
            catch (StorageException ex)
            {
                return string.Empty;
            }
        }

        private static Func<string> BuildSasToken(string resource)
        {
            string containerName = "cacheupdates";
            string endPoint = "";
            string sasToken = "";

            return new Func<string>(() => $@"{endPoint}/{containerName}/{resource}{sasToken}");
        }

        public static async Task ReadBlobFileWithoutSasToken()
        {
            try
            {
                string fileName = "cache_20181121.json";
                string containerName = "cacheupdates";

                string storageConnectionString = "";

                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

                CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);

                //MemoryStream memStream = new MemoryStream();
                //await blockBlob.DownloadToStreamAsync(memStream);
                //var exists = await blockBlob.ExistsAsync();

                if (!await blockBlob.ExistsAsync())
                {
                    return;
                }

                var res = await blockBlob.DownloadTextAsync();
                return;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
