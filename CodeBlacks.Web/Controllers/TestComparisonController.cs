using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CodeBlacks.Web.Controllers
{
    public class TestComparisonController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public HttpResponseMessage Get(string id)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["TestComparisonStorage"].ToString());
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer testComparisonContainer = blobClient.GetContainerReference("testcomparisons");
            CloudBlockBlob blob = testComparisonContainer.GetBlockBlobReference(id + ".json");
            string text = blob.DownloadText();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(text, Encoding.UTF8, "application/json");
            return response;
        }
        
        // POST api/values
        public void Post([FromBody]string value)
        {
        }
    }
}
