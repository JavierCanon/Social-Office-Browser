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
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.Example
{
    internal class CefSharpSchemeHandler : ResourceHandler
    {
        public override bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            var uri = new Uri(request.Url);
            var fileName = uri.AbsolutePath;

            Task.Run(() =>
            {
                using (callback)
                {
                    Stream stream = null;

                    if (string.Equals(fileName, "/PostDataTest.html", StringComparison.OrdinalIgnoreCase))
                    {
                        var postDataElement = request.PostData.Elements.FirstOrDefault();
                        stream = ResourceHandler.GetMemoryStream("Post Data: " + (postDataElement == null ? "null" : postDataElement.GetBody()), Encoding.UTF8);
                    }

                    if (string.Equals(fileName, "/PostDataAjaxTest.html", StringComparison.OrdinalIgnoreCase))
                    {
                        var postData = request.PostData;
                        if (postData == null)
                        {
                            stream = ResourceHandler.GetMemoryStream("Post Data: null", Encoding.UTF8);
                        }
                        else
                        {
                            var postDataElement = postData.Elements.FirstOrDefault();
                            stream = ResourceHandler.GetMemoryStream("Post Data: " + (postDataElement == null ? "null" : postDataElement.GetBody()), Encoding.UTF8);
                        }
                    }

                    if (stream == null)
                    {
                        callback.Cancel();
                    }
                    else
                    {
                        //Reset the stream position to 0 so the stream can be copied into the underlying unmanaged buffer
                        stream.Position = 0;
                        //Populate the response values - No longer need to implement GetResponseHeaders (unless you need to perform a redirect)
                        ResponseLength = stream.Length;
                        MimeType = "text/html";
                        StatusCode = (int)HttpStatusCode.OK;
                        Stream = stream;

                        callback.Continue();
                    }
                }
            });

            return true;
        }
    }
}
