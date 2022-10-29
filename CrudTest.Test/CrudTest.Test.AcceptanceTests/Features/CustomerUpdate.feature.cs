﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CrudTest.Test.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CustomerUpdateFeature : object, Xunit.IClassFixture<CustomerUpdateFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CustomerUpdate.feature"
#line hidden
        
        public CustomerUpdateFeature(CustomerUpdateFeature.FixtureData fixtureData, CrudTest_Test_AcceptanceTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "CustomerUpdate", "updates customer", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Update customer")]
        [Xunit.TraitAttribute("FeatureTitle", "CustomerUpdate")]
        [Xunit.TraitAttribute("Description", "Update customer")]
        [Xunit.TraitAttribute("Category", "Update")]
        [Xunit.InlineDataAttribute("1", "ipdotsetaf1@gmail.com", "+989387016860", "1212121212121212", "204", new string[0])]
        [Xunit.InlineDataAttribute("1", "ipdotsetaf1@gmail.com", "+9816860", "1212121212121212", "400", new string[0])]
        [Xunit.InlineDataAttribute("1", "ipdotsetaf1@gmail.com", "+15417737024", "1212121212121212", "201", new string[0])]
        [Xunit.InlineDataAttribute("1", "ipdotsetaf@gmail.com", "+15417737024", "1212121212121212", "400", new string[0])]
        [Xunit.InlineDataAttribute("5", "test@test.com", "+15417737024", "1212121212121212", "404", new string[0])]
        [Xunit.InlineDataAttribute("1", "ipdotsetaf1@gmail.com", "+15417737024", "13513131", "400", new string[0])]
        [Xunit.InlineDataAttribute("1", "gmail.com", "+15417737024", "1212121212121212", "400", new string[0])]
        public virtual void UpdateCustomer(string idSeed, string email, string phoneNumber, string bankAccountNumber, string statusCode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Update"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("IdSeed", idSeed);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("PhoneNumber", phoneNumber);
            argumentsOfScenario.Add("BankAccountNumber", bankAccountNumber);
            argumentsOfScenario.Add("StatusCode", statusCode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update customer", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given(string.Format("the Id of an existing customer and data ({0},{1},{2},{3})", idSeed, email, phoneNumber, bankAccountNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When("updateing this customer using the data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then(string.Format("the action should return ({0})", statusCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CustomerUpdateFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CustomerUpdateFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
