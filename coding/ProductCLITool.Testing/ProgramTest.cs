using System;
using Xunit;

namespace ProductCLITool.Testing
{
    public class ProgramTest
    {
        // Tast Case for incompatible commands. Should Throw ArgumentNullException.
        [Theory]
        [MemberData(nameof(TestCasesProvider.TestCasesFor_Main_PassingIncompleteCommand_ShouldThrowArgumentNullException),MemberType = typeof(TestCasesProvider))]
        public void Main_PassingIncompleteCommand_ShouldThrowArgumentNullException(params string[] args)
        {
            Assert.Throws<ArgumentNullException>(() => Program.Main(args));
        }

        // Test case for sites other than Capterra and SoftwareAdvice. Should Throw NotImplementedException.
        [Theory]
        [MemberData(nameof(TestCasesProvider.TestCasesFor_Main_PassingInvalidProvider_ShouldThrowNotImplementedException), MemberType = typeof(TestCasesProvider))]
        public void Main_PassingInvalidProvider_ShouldThrowNotImplementedException(params string[] args)
        {
            Assert.Throws<NotImplementedException>(() => Program.Main(args));
        }

        // Test Case for incompatible files or extientions for each provider. Should throw NotSupportedException.
        [Theory]
        [MemberData(nameof(TestCasesProvider.TestCasesFor_Main_PassingInvalidExtensions_ShouldThrowNotSupportedException), MemberType = typeof(TestCasesProvider))]
        public void Main_PassingInvalidExtensions_ShouldThrowNotSupportedException(params string[] args)
        {
            Assert.Throws<NotSupportedException>(() => Program.Main(args));
        }
        
        // Test Case for valid commands. Should not throw exception and work properly.
        [Theory]
        [MemberData(nameof(TestCasesProvider.TestCasesFor_Main_PassingValidParameters_ShouldNotThrowAnyException), MemberType = typeof(TestCasesProvider))]
        public void Main_PassingValidParameters_ShouldNotThrowAnyException(params string[] args)
        {
            Assert.Null(Record.Exception(() => Program.Main(args)));
        }
    }
}
