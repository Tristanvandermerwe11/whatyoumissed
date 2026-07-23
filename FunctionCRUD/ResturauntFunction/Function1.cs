using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ResturauntFunction.Models;

namespace ResturauntFunction;

public class Function1
{
    List<MenueItem> menueItems = new();// we are using a list because databases = effort

    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("items")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", "delete")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);

        response.Headers.Add("Content-Type", "application/json");

        //we need to figure out what the client/sender want us to do
        var method = req.Method;

        switch (method)
        {
            //GET USER WANTS TO RETRIEVE INFO
            case "GET":
                //does user want something specific?
                var requestID = System.Web.HttpUtility.ParseQueryString(req.Url.Query)["id"];
                var isRequesting = string.IsNullOrEmpty(requestID);

                if(isRequesting)
                {
                    var requestedItem = menueItems.FirstOrDefault(i => i.id == int.Parse(requestID));

                    if(requestedItem != null)
                    {

                    }
                    else
                    {

                    }
                }


                break;
            //POST USER WANTS TO ADD INFO
            case "POST":
                break;
            //PUT USER WANTS TO REPLACE INFO
            case "PUT":
                break;
            //DELETE USER WANTS TO DELETE INFO
            case "DELETE":
                break;
            //WE DONT CARE TRY AGAIN
            default:
                break;
        }
    }
}