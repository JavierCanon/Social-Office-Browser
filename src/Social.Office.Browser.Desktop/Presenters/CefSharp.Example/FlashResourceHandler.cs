// Copyright (c) 2018 Javier Cañon 
// https://www.javiercanon.com 
// https://www.xn--javiercaon-09a.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CefSharp.Example
{
    public class FlashResourceHandler : ResourceHandler
    {
        public override bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            Task.Run(() =>
            {
                using (callback)
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://samples.mplayerhq.hu/SWF/zeldaADPCM5bit.swf");

                    var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    // Get the stream associated with the response.
                    var receiveStream = httpWebResponse.GetResponseStream();
                    var mime = httpWebResponse.ContentType;

                    var stream = new MemoryStream();
                    receiveStream.CopyTo(stream);
                    httpWebResponse.Close();

                    //Reset the stream position to 0 so the stream can be copied into the underlying unmanaged buffer
                    stream.Position = 0;

                    //Populate the response values - No longer need to implement GetResponseHeaders (unless you need to perform a redirect)
                    ResponseLength = stream.Length;
                    MimeType = mime;
                    StatusCode = (int)HttpStatusCode.OK;
                    Stream = stream;

                    callback.Continue();
                }
            });

            return true;
        }
    }
}
