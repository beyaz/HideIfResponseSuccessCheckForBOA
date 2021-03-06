﻿using System;
using System.IO;
using JavaScriptRegions;
using BOAPlugins.HideSuccessCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class RegionParserTest
    {

        [TestMethod]
        public void MultipleAssignmentInOneLine_with_no_var_declaration()
        {
            const string sourceText = @"
            
            var requestResponse = SelectedCardNumberChanged(request, objectHelper);
            if (!requestResponse.Success)
            {
                returnObject.Results.AddRange(requestResponse.Results);
                return returnObject;
            }

            request = returnObject.Value = requestResponse.Value;

";
            var data = new RegionParserTestData
            {
                SourceText = sourceText
            };

            RegionParser.Parse(data);

            Assert.AreEqual("request = returnObject.Value = SelectedCardNumberChanged(request, objectHelper);", data.Regions?[0]?.Text);
        }

        [TestMethod]
        public void MultipleAssignmentInOneLine()
        {
            const string sourceText = @"
            
            var checkResponse =   boCardStatusChecker.CheckCardStatus(data);
            if (!checkResponse.Success)
            {
                returnObject.Results.AddRange(checkResponse.Results);
                return returnObject;
            }
            var x = returnObject.Value = abc= abt.yr = checkResponse.Value?.FirstOrDefault();

";
            var data = new RegionParserTestData
            {
                SourceText = sourceText
            };

            RegionParser.Parse(data);

            Assert.AreEqual("var x = returnObject.Value = abc = abt.yr = boCardStatusChecker.CheckCardStatus(data)?.FirstOrDefault();", data.Regions?[0]?.Text);
        }

        [TestMethod]
        public void SimpleCallWithKnownMethodWithNullConditionalOperator()
        {
            const string sourceText = @"
            
            var checkResponse =   boCardStatusChecker.CheckCardStatus(data);
            if (!checkResponse.Success)
            {
                returnObject.Results.AddRange(checkResponse.Results);
                return returnObject;
            }
            var x = checkResponse.Value?.FirstOrDefault();

";
            var data = new RegionParserTestData
            {
                SourceText = sourceText
            };

            RegionParser.Parse(data);

            Assert.AreEqual("var x = boCardStatusChecker.CheckCardStatus(data)?.FirstOrDefault();", data.Regions?[0]?.Text);
        }

        [TestMethod]
        public void SimpleCallWithKnownMethod()
        {
            const string sourceText = @"
            
            var checkResponse =   boCardStatusChecker.CheckCardStatus(data);
            if (!checkResponse.Success)
            {
                returnObject.Results.AddRange(checkResponse.Results);
                return returnObject;
            }
            var x = checkResponse.Value.GetValueOrDefault();

";
            var data = new RegionParserTestData
            {
                SourceText = sourceText
            };

            RegionParser.Parse(data);

            Assert.AreEqual("var x = boCardStatusChecker.CheckCardStatus(data).GetValueOrDefault();", data.Regions?[0]?.Text);
        }

        [TestMethod]
        public void SimpleCallWithEqualityComparison()
        {
            const string sourceText = @"
            
            var checkResponse =   boCardStatusChecker.CheckCardStatus(data);
            if (!checkResponse.Success)
            {
                returnObject.Results.AddRange(checkResponse.Results);
                return returnObject;
            }

            var x = checkResponse.Value != null;

";
            var data = new RegionParserTestData
            {
                SourceText = sourceText
            };

            RegionParser.Parse(data);

            Assert.AreEqual("var x = boCardStatusChecker.CheckCardStatus(data) != null;", data.Regions?[0]?.Text);
        }


        #region Public Methods
        [TestMethod]
        public void LongCall()
        {
            const string sourceText = @"
            
            var checkResponse = new CardStatusChecker {Context = objectHelper.Context}.CheckCardStatus(data);
            if (!checkResponse.Success)
            {
            
                // test
                
                returnObject.Results.AddRange(checkResponse.Results);
                // any comment
                return returnObject;
            }

";
            var data = new RegionParserTestData
            {
                SourceText = sourceText
            };

            RegionParser.Parse(data);

            Assert.AreEqual("new CardStatusChecker {Context = objectHelper.Context}.CheckCardStatus(data);", data.Regions?[0]?.Text);
        }

        [TestMethod]
        public void SimpleCall()
        {
            const string sourceText = @"
            
            var checkResponse =   boCardStatusChecker.CheckCardStatus(data);
            if (!checkResponse.Success)
            {
                returnObject.Results.AddRange(checkResponse.Results);
                return returnObject;
            }

";
            var data = new RegionParserTestData
            {
                SourceText = sourceText
            };

            RegionParser.Parse(data);

            Assert.AreEqual("boCardStatusChecker.CheckCardStatus(data);", data.Regions?[0]?.Text);
        }

        [TestMethod]
        public void TestFile()
        {
            const string FilePath = @"D:\Work\BOA.Kernel\Dev\BOA.Kernel.CardGeneral\DebitCard\BOA.Engine.DebitCard\Utility\Validation.cs";

            var data = new RegionParserTestData
            {
                SourceText = File.ReadAllText(FilePath)
            };

            RegionParser.Parse(data);

            Assert.IsTrue(data.Regions.Count > 0);
        }

        

        [TestMethod]
        public void ShouldLogToTxtFile()
        {
            Logger.Push(new ArgumentException("xxx"));
        }
        #endregion
    }
}