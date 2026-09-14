
<div align="center">

![Header](https://capsule-render.vercel.app/api?type=waving&color=0078D4&height=200&section=header&text=CLDV6212&fontSize=60&fontColor=white&fontAlignY=35&desc=Cloud%20Development&descAlignY=55&descSize=20&descColor=white)

</div>

## TABLE OF CONTENTS
- [MEMBERS](#members)
- [WHAT EACH MEMBER DID](#what-each-member-did)





![GitHub repo size](https://img.shields.io/github/repo-size/EMECPE/cldv6212-2026-g2-poe-brandon-badenhorst?style=for-the-badge)
![GitHub contributors](https://img.shields.io/github/contributors/EMECPE/cldv6212-2026-g2-poe-brandon-badenhorst?style=for-the-badge)
![GitHub last commit](https://img.shields.io/github/last-commit/EMECPE/cldv6212-2026-g2-poe-brandon-badenhorst?style=for-the-badge)
![Azure](https://img.shields.io/badge/Azure-0078D4?style=for-the-badge&logo=microsoftazure&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)















`namespace CLDV6212_POE
{
    public class BlobFunction
    {
        // (rudderz243, 2026).
        //declared a private readonly BlobContainer variable. this is used to connect and interact with "staff-docs" container in Azure Storage.
        private readonly BlobContainerClient _blobClient;

        // (rudderz243, 2026).
        //declared a private readonly ILogger<BlobFunction> variable. this is used to generate logs for the BlobFunction.cs.
        private readonly ILogger<BlobFunction> _logger;

        // (rudderz243, 2026).
        // constructor created for BlobFunction class.
        public BlobFunction(BlobServiceClient blobService, ILogger<BlobFunction> logger)
        {

            // (rudderz243, 2026).
            // uses BlobContainerClient to get a reference to the Azure Blob Storage container named staff-docs if it exists.
            _blobClient = blobService.GetBlobContainerClient("staff-docs");

            // (rudderz243, 2026).
            // Creates the staff-docs container if it does not already exist.
            _blobClient.CreateIfNotExists();

            // (rudderz243, 2026).
            // asigns local logger to the logger given when the class gets created. 
            _logger = logger;
        }

        // (rudderz243, 2026).
        // Registers this method as an Azure Function.
        [Function("UploadStaffDocument")]

        // (rudderz243, 2026).
        // Uploads a staff document to Azure Blob Storage using an HTTP POST request.
        public async Task<HttpResponseData> UploadStaffDocument([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "documents/upload/{fileName}" )]
        HttpRequestData req, string fileName)
        {
            // (Microsoft, 2024).
            // Tries to save the content type from the request's headers to be used for MIME-validation
            if (!req.Headers.TryGetValues("Content-Type", out var contentType))
            {
                var badRequest = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                await badRequest.WriteStringAsync("error: missing Content-Type header");
                return badRequest;
            }

            //Checks that the file uploaded is of MIME-type multipart/form-data
            if (!contentType.ToArray()[0].ToString().Contains("multipart/form-data", StringComparison.OrdinalIgnoreCase))
            {
                var badRequest = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                await badRequest.WriteStringAsync("error: expected multipart/form-data");
                return badRequest;
            }

            // (rudderz243, 2026).
            // Starts the try block so errors can be caught.
            try
            {
                // (rudderz243, 2026).
                // Creates a BlobClient for the specified file in the blob container.
                BlobClient blob = _blobClient.GetBlobClient(fileName);

                // (rudderz243, 2026).
                // Uploads the file to Blob Storage and overwrites it if it already exists.
                await blob.UploadAsync(req.Body, overwrite: true);

                // (rudderz243, 2026).
                // Creates an HTTP response with a 200 OK status code, adds a success message to the response, and returns the HTTP response to the user
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                await response.WriteStringAsync("blob uploaded successfully");
                return response;
            }
            // (rudderz243, 2026).
            // Catches any unexpected errors
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading staff document");
                var errorMessage = req.CreateResponse(System.Net.HttpStatusCode.InternalServerError); 
                await errorMessage.WriteStringAsync("error: something went wrong uploading the document"); 
                return errorMessage; 
            }
        }

        // Registers this method as an Azure Function.
        [Function("DownloadStaffDocument")]

        // (rudderz243, 2026).
        // Downloads a staff document from Azure Blob Storage using the specified fileName.
        public async Task<HttpResponseData> DownloadStaffDocument([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "documents/download/{fileName}" )]
        HttpRequestData req, string fileName) 
        {   
            // Starts the try block so errors can be caught.
            try
            {  
                // Creates a BlobClient for the specified file in the blob container.
                BlobClient blob = _blobClient.GetBlobClient(fileName);

                // (rudderz243, 2026).
                // Checks if the requested blob exists and returns a Not Found response if it does not.
                if (!await blob.ExistsAsync()) 
                {
                    // (rudderz243, 2026).
                    return req.CreateResponse(System.Net.HttpStatusCode.NotFound);
                }

                // (rudderz243, 2026).
                // Opens the blob as a stream for reading and creates an HTTP response with a 200 OK status code.
                var stream = await blob.OpenReadAsync(); 
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);

                // (rudderz243, 2026).
                // Sets the response content type for the downloaded file, copies the blob data into the HTTP response body, and returns the response containing the downloaded file
                response.Headers.Add("Content-Type", "application/octet-stream");
                await stream.CopyToAsync(response.Body);
                return response;
            }

            // Catches any unexpected errors
            catch (Exception ex)
            {
                // Creates an HTTP 500 response when the download fails, writes the error text plus the exception message into the response body, and returns the error response
                _logger.LogError(ex, "Error downloading staff document {fileName}", fileName);
                var errorMessage = req.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
                await errorMessage.WriteStringAsync("error: something went wrong downloading the document");
                return errorMessage;
            }
        }

        // Registers this method as an Azure Function
        [Function("ListStaffDocuments")]

        // Retrieves a list of all staff documents stored in Azure Blob Storage
        public async Task<HttpResponseData> ListStaffDocuments([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "documents" )]
        HttpRequestData req) 
        {
            // Starts the try block so errors can be caught
            try
            {
                // Creates a list to store the staff document information
                var document = new List<object>();

                // (rudderz243, 2026).
                // Loops through each blob stored in the container
                await foreach (var item in _blobClient.GetBlobsAsync())  
                {
                    // (rudderz243, 2026).
                    // Adds the blob's file information to the document list
                    document.Add(new
                    {
                        fileName = item.Name,
                        SizeBytes = item.Properties.ContentLength,
                        DateModified = item.Properties.LastModified
                    }); 
                }

                // (rudderz243, 2026).
                // Creates an HTTP response with a 200 OK status code, writes the document list to the response as JSON, and returns the HTTP response
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                await response.WriteAsJsonAsync(document); 
                return response;
            }
            // Catches any exception thrown while trying to gte the list
            catch (Exception ex) 
            {
                // Creates an HTTP 500 response when getting the list fails, writes the error text plus the exception message into the response body, and returns the error response
                _logger.LogError(ex, "Error listing staff documents");
                var errorMessage = req.CreateResponse(System.Net.HttpStatusCode.InternalServerError); 
                await errorMessage.WriteStringAsync("error: something went wrong listing the documents");  
                return errorMessage;
            }
        }
    }
}`

</details>
























































































## MEMBERS
 
| NAME | STUDENT NUMBER |
| ----------- | ----------- |
| Brandon | [ student number asseblief ] |
| Dayyaan | [ student number asseblief ] |
| Oisín | [ student number asseblief ] |
| Tristan | [ student number asseblief ] |


## WHAT EACH MEMBER DID

| MEMBER | USED | RESPONSIBILITIES |
| ------------- | ----------- | ----------- |
| Brandon | - Azurite Containers <br>- Functions Dockerfile <br>- Docker Hub account | running and pushing the dockerfile, function image and confirming that Azureite image works. |
| Dayyaan | - Staff docs File Share/ blob | building the blob storage as well as the 3 functions. |
| Oisín | - MenueItems table <br>- Menu Azure Functions | build the table schema aswell as the 5 menu functions. |
| Tristan | - Postman <br>- README.md <br>- Youtube video | creation of the full postman collection, creating the README as well as doing the walkthrough of the project for the video. |









<div align="center">

![Footer](https://capsule-render.vercel.app/api?type=waving&color=0078D4&height=120&section=footer&text=Made%20by%20Group%202&fontSize=20&fontColor=white&fontAlignY=65)

</div>

</div>
