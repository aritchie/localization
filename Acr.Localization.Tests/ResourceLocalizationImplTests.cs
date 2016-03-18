using System;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;


namespace Acr.Localization.Tests
{
    [TestFixture]
    public class ResourceLocalizationImplTests
    {
        readonly ILocalization localizer = new ResourceLocalizationImpl("Acr.Localization.Tests.Test", Assembly.GetExecutingAssembly());


        [Test]
        public void Basic()
        {
            this.localizer
                .GetString("Key1")
                .Should()
                .Be("Hi");
        }


        [Test]
        public void EnumTest()
        {
            this.localizer
                .GetString(TestEnum.Value1)
                .Should()
                .Be("testing value1");

            this.localizer
                .GetString(TestEnum.Value2)
                .Should()
                .Be("testing value2");
        }


        [Test]
        public void RegularBind()
        {
            var obj = this.localizer.Bind<TestObject>(errorOnMissingKeys: false);
            obj.Key1.Should().Be("Hi");
            obj.Key2.Should().StartWith("ERROR");
        }


        [Test]
        public void PrefixBind()
        {
            var obj = this.localizer.Bind<TestObject>("TestObject.", errorOnMissingKeys: false);
            obj.Key1.Should().Be("Hi Prefix");
            obj.Key2.Should().StartWith("ERROR");
        }
    }
}
