using InjectionInloggning;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace InjectionInloggningTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Ture", "123", true)]
        [InlineData("ture", "abd", false)]
        [InlineData("user'; DROP TABLE users; --", "", false)]
        public void Inloggning(string user, string pass, bool expected)
        {
            Assert.Equal(InjectionInloggning.Program.Inloggning(user, pass), expected);
        }
    }
}