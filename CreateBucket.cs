class StorageQuickstart
{
    static void Main(string[] args)
    {
        // Your Google Cloud Platform project ID.
        string projectId = "YOURPROJECTID";

        // [END storage_quickstart]
        Debug.Assert("YOURPROJECT" + "ID" != projectId,
            "Edit Program.cs and replace YOURPROJECTID with your Google Project Id.");
        // [START storage_quickstart]

        // Instantiates a client.
        using (StorageClient storageClient = StorageClient.Create())
        {
            // The name for the new bucket.
            string bucketName = projectId + "testbucket";
            try
            {
                // Creates the new bucket.
                storageClient.CreateBucket(projectId, bucketName);
                Console.WriteLine($"Bucket {bucketName} created.");
            }
            catch (Google.GoogleApiException e)
            when (e.Error.Code == 409)
            {
                // The bucket already exists.  That's fine.
                Console.WriteLine(e.Error.Message);
            }
        }
    }
}


