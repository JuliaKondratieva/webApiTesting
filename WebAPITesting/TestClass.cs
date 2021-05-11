using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;
using System.IO;
using System.Net;

namespace WebAPITesting
{
    public class TestClass
    {
        public string token = Environment.GetEnvironmentVariable("TOKEN");

        [Test]
        public void UploadEndpointTest()
        {
            //
            RestClient client = new RestClient("https://content.dropboxapi.com/2/");
            IRestRequest request = new RestRequest("files/upload", Method.POST);

            //FileInfo fileInfo = new FileInfo(filePath);
            //long fileLength = fileInfo.Length;

            request.AddHeader("Authorization", "Bearer "+token);

            FileClass fileInfo = new FileClass()
            {
                path = "/webAPITestingTRPZ2021/HelloWorld.txt",
                mode = "add",
                autorename = true,
                mute = false,
                strict_conflict = false
            };

            string stringjson = JsonConvert.SerializeObject(fileInfo);
            //Console.WriteLine(stringjson);
            request.AddHeader("Dropbox-API-Arg", stringjson);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddJsonBody("{}");

            IRestResponse response = client.Execute(request);
            //

            // act
            //IRestResponse response = client.Execute(request);

            // assert
            Console.WriteLine("CODE: ", response.StatusCode);
            Console.WriteLine("Content: ", response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }



        [Test]
        public void GetFileMetadataTest()
        {
            RestClient client = new RestClient("https://api.dropboxapi.com/2/");
            IRestRequest request = new RestRequest("files/get_metadata", Method.POST);

            request.AddHeader("Authorization", "Bearer "+token);

            File2Class fileInfo = new File2Class()
            {
                path = "/webAPITestingTRPZ2021/ToGet.txt",
                include_media_info= false,
                include_deleted = false,
                include_has_explicit_shared_members= false
            };

            string stringjson = JsonConvert.SerializeObject(fileInfo);
            request.AddHeader("Content-Type", "application/json");
            //byte[] data = File.ReadAllBytes(filePath);
            //request.AddJsonBody(stringjson);
            request.AddParameter("application/json", stringjson, ParameterType.RequestBody);
            //request.AddParameter("application/json", stringjson);


            IRestResponse response = client.Execute(request);

            Console.WriteLine("CODE: ", response.StatusCode);
            Console.WriteLine("Content: ", response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DeleteTest()
        {
            RestClient client = new RestClient("https://content.dropboxapi.com/2/");
            IRestRequest request = new RestRequest("files/upload", Method.POST);

            //FileInfo fileInfo = new FileInfo(filePath);
            //long fileLength = fileInfo.Length;

            request.AddHeader("Authorization", "Bearer " + token);

            FileClass fileInfo = new FileClass()
            {
                path = "/webAPITestingTRPZ2021/ToDelete.txt",
                mode = "add",
                autorename = true,
                mute = false,
                strict_conflict = false
            };

            string stringjson = JsonConvert.SerializeObject(fileInfo);
            //Console.WriteLine(stringjson);
            request.AddHeader("Dropbox-API-Arg", stringjson);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddJsonBody("{}");

            IRestResponse response = client.Execute(request);
            //

            // act
            //IRestResponse response = client.Execute(request);

            RestClient client2 = new RestClient("https://api.dropboxapi.com/2/");
            IRestRequest request2 = new RestRequest("files/delete_v2", Method.POST);

            request2.AddHeader("Authorization", "Bearer "+token);

            File3Class fileInfo2 = new File3Class()
            {
                path = "/webAPITestingTRPZ2021/ToDelete.txt",
            };

            string stringjson2 = JsonConvert.SerializeObject(fileInfo2);
            request2.AddHeader("Content-Type", "application/json");
            //byte[] data = File.ReadAllBytes(filePath);
            //request.AddJsonBody(stringjson);
            request2.AddParameter("application/json", stringjson2, ParameterType.RequestBody);
            //request.AddParameter("application/json", stringjson);


            IRestResponse response2 = client2.Execute(request2);

            Console.WriteLine("CODE: ", response.StatusCode);
            Console.WriteLine("Content: ", response.Content);
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


    }
}
