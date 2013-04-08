using System;
using TechTalk.SpecFlow;

namespace BowlingGame.Specs
{
    [Binding]
    public class ReadATextFileSteps
    {
        [Given(@"I want to load a file called ""(.*)""")]
        public void GivenIWantToLoadAFileCalled(string fileName)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"its on my local file system")]
        public void GivenItsOnMyLocalFileSystem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"its not on my local file system")]
        public void GivenItsNotOnMyLocalFileSystem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I don't have permissions to access it")]
        public void GivenIDonTHavePermissionsToAccessIt()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"its on a network share")]
        public void GivenItsOnANetworkShare()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I dont have permissions to access it")]
        public void GivenIDontHavePermissionsToAccessIt()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"its on a internet server called ""(.*)""")]
        public void GivenItsOnAInternetServerCalled(string serverName)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"its not on the internet")]
        public void GivenItsNotOnTheInternet()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press load")]
        public void WhenIPressLoad()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the app should load the file")]
        public void ThenTheAppShouldLoadTheFile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the app should notify me the file doesnt exists")]
        public void ThenTheAppShouldNotifyMeTheFileDoesntExists()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the app should notify me the file cant be accessed")]
        public void ThenTheAppShouldNotifyMeTheFileCantBeAccessed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
