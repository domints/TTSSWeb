using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Internal;

namespace TTSSLib.Helpers
{
    internal static class HttpHelper
    {
        private static HttpClient busClient;
        private static HttpClient tramClient;

        public static HttpClient BusClient => busClient != null ? busClient : InitClient(true);
        public static HttpClient TramClient => tramClient != null ? tramClient : InitClient(false);
        private static HttpClient InitClient(bool bus)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            if(bus)
            {
                httpClient.BaseAddress = new Uri(Addresses.BusHost);
                busClient = httpClient;
            }
            else 
            {
                httpClient.BaseAddress = new Uri(Addresses.TramHost);
                tramClient = httpClient;
            }

            return httpClient;
        }
        /// <summary>
        /// Gets the string from given URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        internal static async Task<Response> GetString(string url, bool bus = false)
        {
            var httpClient = bus ? BusClient : TramClient;

            var response = await httpClient.GetAsync(new Uri(url, UriKind.Relative)).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            IEnumerable<string> encoding = new List<string>();
            if (response.Content.Headers.TryGetValues("Content-Encoding", out encoding) && (string.Join(" ", encoding).Contains("gzip") || (string.Join(" ", encoding).Contains("deflate"))))
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                using (var streamReader = new StreamReader(decompressedStream))
                {
                    return new Response(await streamReader.ReadToEndAsync().ConfigureAwait(false));
                }
            }
            else
            {
                return new Response(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
        }
    }
}
