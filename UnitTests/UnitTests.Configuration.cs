﻿using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using XamlMagic.Service.Options;

namespace XamlMagic.UnitTests
{
    [TestFixture]
    public sealed partial class UnitTests
    {
        [Test]
        public void TestConfiguration_Default()
        {
            var stylerOptions = new StylerOptions(config: this.GetConfiguration(@"TestConfigurations\Default.json"));
            this.TestConfig(stylerOptions, @"TestConfigurations\SerializedDefault.json");
        }

        [Test]
        public void TestConfiguration_Empty()
        {
            var stylerOptions = new StylerOptions(config: this.GetConfiguration(@"TestConfigurations\Empty.json"));
            this.TestConfig(stylerOptions, @"TestConfigurations\SerializedDefault.json");
        }

        [Test]
        public void TestConfiguration_Single()
        {
            var stylerOptions = new StylerOptions(config: this.GetConfiguration(@"TestConfigurations\Single.json"));
            this.TestConfig(stylerOptions, @"TestConfigurations\SerializedSingle.json");
        }

        [Test]
        public void TestConfiguration_BadSetting()
        {
            var stylerOptions = new StylerOptions(config: this.GetConfiguration(@"TestConfigurations\BadSetting.json"));
            this.TestConfig(stylerOptions, @"TestConfigurations\SerializedDefault.json");
        }

        [Test]
        public void TestConfiguration_AllDifferent()
        {
            var stylerOptions = new StylerOptions(config: this.GetConfiguration(@"TestConfigurations\AllDifferent.json"));
            this.TestConfig(stylerOptions, @"TestConfigurations\AllDifferent.json");
        }

        private void TestConfig(StylerOptions stylerOptions, string expectedConfiguration)
        {
            var actualOptions = JsonConvert.SerializeObject(stylerOptions);
            var expectedOptions = File.ReadAllText(this.GetConfiguration(expectedConfiguration));

            Assert.That(Regex.Replace(actualOptions, @"\s+", ""), Is.EqualTo(Regex.Replace(expectedOptions, @"\s+", "")));
        }
    }
}
