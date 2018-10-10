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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace CefSharp.Example
{
    public class AsyncBoundObject
    {
        //We expect an exception here, so tell VS to ignore
        [DebuggerHidden]
        public void Error()
        {
            throw new Exception("This is an exception coming from C#");
        }

        //We expect an exception here, so tell VS to ignore
        [DebuggerHidden]
        public int Div(int divident, int divisor)
        {
            return divident / divisor;
        }

        public string Hello(string name)
        {
            return "Hello " + name;
        }

        public string DoSomething()
        {
            Thread.Sleep(1000);

            return "Waited for 1000ms before returning";
        }

        public JsSerializableStruct ReturnObject(string name)
        {
            return new JsSerializableStruct
            {
                Value = name
            };
        }

        public JsSerializableClass ReturnClass(string name)
        {
            return new JsSerializableClass
            {
                Value = name
            };
        }

        public JsSerializableStruct[] ReturnStructArray(string name)
        {
            return new[]
            {
                new JsSerializableStruct { Value = name + "Item1" },
                new JsSerializableStruct { Value = name + "Item2" }
            };
        }

        public JsSerializableClass[] ReturnClassesArray(string name)
        {
            return new[]
            {
                new JsSerializableClass { Value = name + "Item1" },
                new JsSerializableClass { Value = name + "Item2" }
            };
        }

        public string[] EchoArray(string[] arg)
        {
            return arg;
        }

        public int[] EchoValueTypeArray(int[] arg)
        {
            return arg;
        }

        public int[][] EchoMultidimensionalArray(int[][] arg)
        {
            return arg;
        }

        public string DynamiObjectList(IList<dynamic> objects)
        {
            var builder = new StringBuilder();

            foreach (var browser in objects)
            {
                builder.Append("Browser(Name:" + browser.Name + ";Engine:" + browser.Engine.Name + ");");
            }

            return builder.ToString();
        }

        public List<string> MethodReturnsList()
        {
            return new List<string>()
            {
                "Element 0 - First",
                "Element 1",
                "Element 2 - Last",
            };
        }

        public List<List<string>> MethodReturnsListOfLists()
        {
            return new List<List<string>>()
            {
                new List<string>() {"Element 0, 0", "Element 0, 1" },
                new List<string>() {"Element 1, 0", "Element 1, 1" },
                new List<string>() {"Element 2, 0", "Element 2, 1" },
            };
        }

        public Dictionary<string, int> MethodReturnsDictionary1()
        {
            return new Dictionary<string, int>()
            {
                {"five", 5},
                {"ten", 10}
            };
        }

        public Dictionary<string, object> MethodReturnsDictionary2()
        {
            return new Dictionary<string, object>()
            {
                {"onepointfive", 1.5},
                {"five", 5},
                {"ten", "ten"},
                {"twotwo", new Int32[]{2, 2} }
            };
        }

        public Dictionary<string, IDictionary> MethodReturnsDictionary3()
        {
            return new Dictionary<string, IDictionary>()
            {
                {"data", MethodReturnsDictionary2()}
            };
        }
    }
}
