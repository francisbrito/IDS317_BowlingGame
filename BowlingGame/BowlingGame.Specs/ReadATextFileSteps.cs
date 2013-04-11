using System;
using System.IO;
using System.Text.RegularExpressions;
using BowlingGame.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Net;

namespace BowlingGame.Specs
{
    [Binding]
    public class ReadATextFileSteps
    {
        private string _fileName = string.Empty;
        private string _serverName = string.Empty;
        private IFileReader _reader;

        [Given(@"I want to load a file called ""(.*)""")]
        public void GivenIWantToLoadAFileCalled(string fileName)
        {
            _fileName = fileName;
        }

        [Given(@"its on my local file system")]
        public void GivenItsOnMyLocalFileSystem()
        {
            Assert.IsTrue(File.Exists(_fileName));

            _reader = new LocalFileReader();
        }

        [Given(@"its not on my local file system")]
        public void GivenItsNotOnMyLocalFileSystem()
        {
            Assert.IsFalse(File.Exists(_fileName));
        }

        [Given(@"its on a network share")]
        public void GivenItsOnANetworkShare()
        {
            Assert.IsTrue(File.Exists(_fileName) && Regex.IsMatch(_fileName, @"//.*"));

            _reader = new NetShareFileReader();
        }

        [Given(@"I dont have permissions to access it")]
        public void GivenIDontHavePermissionsToAccessIt()
        {
            var canAccess = true;

            try
            {
                File.ReadAllLines(_fileName);
            }
            catch (UnauthorizedAccessException)
            {

                canAccess = false;
            }

            Assert.IsFalse(canAccess);
        }

        [Given(@"its on a internet server called ""(.*)""")]
        public void GivenItsOnAInternetServerCalled(string serverName)
        {
            _serverName = serverName;

            // NOTE:
            // Passing server name is a little 'trick' to get the IFileReader#ReadFile method
            // to work without adding and extra field or hacking the unit test.
            _reader = new InternetFileReader(_serverName);
        }

        [Given(@"its not on the internet")]
        public void GivenItsNotOnTheInternet()
        {
            var is404 = false;
            var uri = string.Format("http://{0}/{1}", _serverName, _fileName);

            var request = (HttpWebRequest)WebRequest.Create(uri);

            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                is404 = true;
            }

            Assert.IsTrue(is404);
        }

        [When(@"I press load")]
        public void WhenIPressLoad()
        {
            _reader.ReadFile(_fileName);
        }

        [Then(@"the app should load the file")]
        public void ThenTheAppShouldLoadTheFile()
        {
            Assert.IsTrue(_reader.State == FileState.Loaded);
        }

        [Then(@"the app should notify me the file doesnt exists")]
        public void ThenTheAppShouldNotifyMeTheFileDoesntExists()
        {
            Assert.IsTrue(_reader.State == FileState.NotFound);
        }

        [Then(@"the app should notify me the file cant be accessed")]
        public void ThenTheAppShouldNotifyMeTheFileCantBeAccessed()
        {
            Assert.IsTrue(_reader.State == FileState.CantBeAccessed);
        }
    }
}
