using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Framework.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Framework
{
    public class SubmissionClient
    {
        public static readonly Uri BaseAddress = new Uri("https://challenge.snapsoft.hu");

        private HttpClient Client { get; }

        public SubmissionClient(string apiKey)
        {
            Client = new HttpClient
            {
                BaseAddress = BaseAddress,
                DefaultRequestHeaders = 
                {
                    { "X-Api-Token", apiKey }
                }
            };
        }

        protected async Task<TResponse> SendAsync<TResponse>(HttpMethod method, string path, HttpContent content)
        {
            // Build request message
            using var request = new HttpRequestMessage(method, path);
            request.Content = content;

            // Send and receive response
            using var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Deserializer response
            using var stream = await response.Content.ReadAsStreamAsync();
            return JsonHelper.Deserialize<TResponse>(stream);
        }

        protected async Task<TResponse> SendAsync<TResponse, TRequest>(HttpMethod method, string path, TRequest request)
        {
            // Build content
            using var stream = new MemoryStream();
            JsonHelper.Serialize(stream, request);
            var bytes = stream.ToArray();
            await File.WriteAllBytesAsync("request.json", bytes);
            using var content = new ByteArrayContent(bytes);
            content.Headers.Add("Content-Type", "application/json");

            // Send
            return await SendAsync<TResponse>(method, path, content);
        }

        public Task<StartSubmissionResponse> StartSubmissionAsync(string problemId, int? sampleIndex)
            => SendAsync<StartSubmissionResponse, StartSubmissionRequest>(
                HttpMethod.Post,
                "/api/submissions/start-submission",
                new StartSubmissionRequest
                {
                    ProblemId = problemId,
                    SampleIndex = sampleIndex
                });

        public Task<StartTestResponse<T>> StartTestAsync<T>(string submissionId)
            => SendAsync<StartTestResponse<T>, StartTestRequest>(
                HttpMethod.Put,
                "/api/submissions/test",
                new StartTestRequest
                {
                    SubmissionId = submissionId
                });

        public Task<SubmitTestResponse> SubmitTestAsync<T>(string testId, T output)
            => SendAsync<SubmitTestResponse, SubmitTestRequest<T>>(
                HttpMethod.Post,
                $"/api/submissions/test/{HttpUtility.UrlEncode(testId)}",
                new SubmitTestRequest<T>
                {
                    Output = output
                });
    }
}
