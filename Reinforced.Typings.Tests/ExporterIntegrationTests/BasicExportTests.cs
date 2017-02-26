﻿using Reinforced.Typings.Fluent;
using Reinforced.Typings.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Reinforced.Typings.Tests.ExporterIntegrationTests
{
    public partial class IntegrationalExporterTests : RtExporterTestBase
    {
        [Fact]
        public void JonsaEnumWithouNamespaceTest()
        {
            const string result = @"
interface IJonsaModel
{
	Enum: JonsaEnum;
}
enum JonsaEnum { 
	Foo = 0, 
	Bar = 1, 
}";
            AssertConfiguration(s =>
            {
                s.Global(a => a.DontWriteWarningComment());
                s.ExportAsInterface<JonsaModel>().WithPublicProperties().DontIncludeToNamespace();
                s.ExportAsEnum<JonsaEnum>().DontIncludeToNamespace();
            }, result);
        }
    }
}
