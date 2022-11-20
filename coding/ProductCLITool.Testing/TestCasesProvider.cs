using System.Collections.Generic;
using System.IO;

namespace ProductCLITool.Testing
{
    public class TestCasesProvider
    {
        private static readonly string _capterraPath;
        private static readonly string _softwareadvicePath;
        static TestCasesProvider()
        {
            string _currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            _capterraPath = _currentDirectory + @"\feed-products\capterra.yaml";
            _softwareadvicePath = _currentDirectory + @"\feed-products\softwareadvice.json";
        }

        // Test Cases For Main_PassingIncompleteCommand_ShouldThrowArgumentNullException in ProgramTest.cs Class.
        public static IEnumerable<object[]> TestCasesFor_Main_PassingIncompleteCommand_ShouldThrowArgumentNullException()
        {
            yield return new object[] { "capterra" };
            yield return new object[] { "capterra", "" };
            yield return new object[] { "", _capterraPath };
            yield return new object[] { "softwareadvice" };
            yield return new object[] { "softwareadvice", "" };
            yield return new object[] { "", _softwareadvicePath };
        }

        // Test Cases For Main_PassingInvalidProvider_ShouldThrowNotImplementedException in ProgramTest.cs Class.
        public static IEnumerable<object[]> TestCasesFor_Main_PassingInvalidProvider_ShouldThrowNotImplementedException()
        {
            yield return new object[] { "thirdparty", _softwareadvicePath };
        }

        // Test Cases For Main_PassingInvalidExtensions_ShouldThrowNotSupportedException in ProgramTest.cs Class.
        public static IEnumerable<object[]> TestCasesFor_Main_PassingInvalidExtensions_ShouldThrowNotSupportedException()
        {
            yield return new object[] { "capterra", _softwareadvicePath };
            yield return new object[] { "softwareadvice", _capterraPath };
        }

        // Test Cases For Main_PassingValidParameters_ShouldNotThrowAnyException in ProgramTest.cs Class.
        public static IEnumerable<object[]> TestCasesFor_Main_PassingValidParameters_ShouldNotThrowAnyException()
        {
            yield return new object[] { "capterra", _capterraPath };
            yield return new object[] { "softwareadvice", _softwareadvicePath };
        }
    }
}
