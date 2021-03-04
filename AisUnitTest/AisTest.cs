using NUnit.Framework;
using AisUriProviderApi;
using System.Collections.Generic;
using TechTestAis.Service;
using System;
using System.IO.Enumeration;

namespace AisUnitTest
{
    public class AisTest
    {

        private readonly AisService _aisService;


        public AisTest()
        {
            _aisService = new AisService(new AisUriProvider());
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetFiles()
        {
            var result = _aisService.GetFiles();
            Assert.That(result, Is.TypeOf<List<Uri>>());
        }

        [Test]
        public void ShowFiles()
        {
            var result = _aisService.ShowFiles();
            Assert.That(result, Is.TypeOf<FileSystemEnumerable<string>>());
        }

    }
}