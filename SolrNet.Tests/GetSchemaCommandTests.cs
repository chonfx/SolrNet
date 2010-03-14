﻿#region license

// Copyright (c) 2007-2010 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Collections.Generic;
using MbUnit.Framework;
using Rhino.Mocks;
using SolrNet.Commands;

namespace SolrNet.Tests
{
    [TestFixture]
    public class GetSchemaCommandTests
    {
        [Test]
        public void GetSchemaCommand()
        {
            var mocks = new MockRepository();
            var conn = mocks.CreateMock<ISolrConnection>();
            With.Mocks(mocks).Expecting(delegate
            {
                Expect.Call(conn.Get("/admin/file", new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("file", "schema.xml") })).Repeat.Once().Return("");
            }).Verify(delegate
            {
                var cmd = new GetSchemaCommand();
                cmd.Execute(conn);
            });
       }
    }
}