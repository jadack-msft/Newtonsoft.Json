﻿#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

#if !NET20
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
#if !(NET20 || NET35 || NET40 || PORTABLE40)
using System.Threading.Tasks;
#endif
using NewtonsoftMRE.Json.Converters;
using NewtonsoftMRE.Json.Linq;
using NewtonsoftMRE.Json.Serialization;
using NewtonsoftMRE.Json.Utilities;
#if DNXCORE50
using Xunit;
using Test = Xunit.FactAttribute;
using Assert = NewtonsoftMRE.Json.Tests.XUnitAssert;
#else
using NUnit.Framework;
#endif

namespace NewtonsoftMRE.Json.Tests.Issues
{
    [TestFixture]
    public class Issue1778 : TestFixtureBase
    {
        [Test]
        public void Test()
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(@"{""enddate"":-1}"));
            reader.Read();
            reader.Read();

            ExceptionAssert.Throws<JsonReaderException>(
                () => reader.ReadAsDateTime(),
                "Cannot read number value as type. Path 'enddate', line 1, position 13.");
        }

#if !(NET20 || NET35 || NET40 || PORTABLE40)
        [Test]
        public async Task Test_Async()
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(@"{""enddate"":-1}"));
            reader.Read();
            reader.Read();

            await ExceptionAssert.ThrowsAsync<JsonReaderException>(
                () => reader.ReadAsDateTimeAsync(),
                "Cannot read number value as type. Path 'enddate', line 1, position 13.");
        }
#endif
    }
}
#endif