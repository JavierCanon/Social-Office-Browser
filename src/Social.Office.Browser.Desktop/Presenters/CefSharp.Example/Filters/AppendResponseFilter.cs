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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CefSharp.Example.Filters
{
    public class AppendResponseFilter : IResponseFilter
    {
        private static Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// Overflow from the output buffer.
        /// </summary>
        private List<byte> overflow = new List<byte>();

        public AppendResponseFilter(string stringToAppend)
        {
            //Add the encoded string into the overflow.
            overflow.AddRange(encoding.GetBytes(stringToAppend));
        }

        bool IResponseFilter.InitFilter()
        {
            return true;
        }

        FilterStatus IResponseFilter.Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            if (dataIn == null)
            {
                dataInRead = 0;
                dataOutWritten = 0;

                return FilterStatus.Done;
            }

            //We'll read all the data
            dataInRead = dataIn.Length;
            dataOutWritten = Math.Min(dataInRead, dataOut.Length);

            if (dataIn.Length > 0)
            {
                //Copy all the existing data first
                dataIn.CopyTo(dataOut);
            }

            // If we have overflow data and remaining space in the buffer then write the overflow.
            if (overflow.Count > 0)
            {
                // Number of bytes remaining in the output buffer.
                var remainingSpace = dataOut.Length - dataOutWritten;
                // Maximum number of bytes we can write into the output buffer.
                var maxWrite = Math.Min(overflow.Count, remainingSpace);

                // Write the maximum portion that fits in the output buffer.
                if (maxWrite > 0)
                {
                    dataOut.Write(overflow.ToArray(), 0, (int)maxWrite);
                    dataOutWritten += maxWrite;
                }

                if (maxWrite == 0 && overflow.Count > 0)
                {
                    //We haven't yet got space to append our data
                    return FilterStatus.NeedMoreData;
                }

                if (maxWrite < overflow.Count)
                {
                    // Need to write more bytes than will fit in the output buffer. 
                    // Remove the bytes that were written already
                    overflow.RemoveRange(0, (int)(maxWrite - 1));
                }
                else
                {
                    overflow.Clear();
                }
            }

            if (overflow.Count > 0)
            {
                return FilterStatus.NeedMoreData;
            }

            return FilterStatus.Done;
        }

        public void Dispose()
        {

        }
    }
}
