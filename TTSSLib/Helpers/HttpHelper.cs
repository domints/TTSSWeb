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
        /// <summary>
        /// Gets the string from given URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        internal static async Task<Response> GetString(string url)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

            var response = await httpClient.GetAsync(new Uri(url)).ConfigureAwait(false);

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
