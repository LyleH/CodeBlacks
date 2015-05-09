using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlacks.BusinessRules;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CodeBlacks.WebJob
{
    public static class Functions
    {
        public static void RunAndCompareTests(
        [QueueTrigger("run-and-compare-tests")] TestComparisonRequest request,
        [Blob("testzips/{BlobName}.zip", FileAccess.Read)] Stream input,
        [Blob("testcomparisons/{BlobName}.json")] CloudBlockBlob outputBlob)
        {

        }
    }
}
