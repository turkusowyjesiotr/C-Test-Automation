using RestSharp;
using examproject.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace examproject.Framework
{
    public class ApiClient
    {
        private static ApiClient instance;
        public static RestClient client;
        private ApiClient(string URL)
        {
            client = new RestClient(URL);
        }

        public static ApiClient GetApiClient(string URL)
        {
            if (instance == null)
            {
                instance = new ApiClient(URL);
            }
            return instance;
        }

        private RestRequest BuildRequest(string path, Dictionary<string, string> parametersValues)
        {
            var request = new RestRequest(path, Method.Post);
            foreach (var paramValuePair in parametersValues)
            {
                request.AddParameter(paramValuePair.Key, paramValuePair.Value);
            }
            return request;
        }

        public RestResponse GetToken(string variantNumber)
        {
            var parametersValues = new Dictionary<string, string>() {
                { "variant", variantNumber }
            };
            var request = BuildRequest(ApiEndpoints.TOKEN, parametersValues);
            return client.Post(request);
        }

        public RestResponse GetTestsJson(string projectId, int maxAttempt)
        {
            bool validJson;
            int attempt = 0;
            RestResponse response;
            var parametersValues = new Dictionary<string, string>() {
                { "projectId", projectId }
            };
            var request = BuildRequest(ApiEndpoints.TESTS_JSON, parametersValues);
            do
            {
                response = client.Post(request);
                var result = response.Content;
                validJson = JsonUtil.IsValidJson(result);
                attempt += 1;
                if (validJson) break;
            }
            while (attempt != maxAttempt);            
            return response;
        }

        public RestResponse AddTest(string SID, string projectName, string testName, string methodName, string env)
        {
            var parametersValues = new Dictionary<string, string>() {
                { "SID", SID },
                { "projectName", projectName },
                { "testName", testName },
                { "methodName", methodName },
                { "env", env }
            };
            var request = BuildRequest(ApiEndpoints.ADD_TEST, parametersValues);
            var response = client.Post(request);
            return response;
        }

        public RestResponse AddLogToTest(string testId, string content)
        {
            var parametersValues = new Dictionary<string, string>() {
                { "testId", testId },
                { "content", content }
            };
            var request = BuildRequest(ApiEndpoints.ADD_TEST_LOG, parametersValues);
            var response = client.Post(request);
            return response;
        }

        public RestResponse AddScreenshotToTest(string testId, string base64attachment)
        {
            var parametersValues = new Dictionary<string, string>() {
                { "testId", testId },
                { "content", base64attachment },
                { "contentType", ContentType.IMAGE }
            };
            var request = BuildRequest(ApiEndpoints.ADD_TEST_ATTACHMENT, parametersValues);
            var response = client.Post(request);
            return response;
        }

        public void AddTestToProject(string SID, string projectName, string testName, string methodName, string env, string base64attachment, string logString)
        {
            var testId = AddTest(SID, projectName, testName, methodName, env).Content;
            AddLogToTest(testId, logString);
            AddScreenshotToTest(testId, base64attachment);
        }
    }
}
