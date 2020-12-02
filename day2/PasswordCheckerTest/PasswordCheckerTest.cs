using System;
using Xunit;
using PasswordChecker;

namespace PasswordCheckerTest
{
    public class PasswordCheckerTest
    {
        [Fact]
        public void CountCorrectPasswordsTest()
        {
            string[] inputs = new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };

            Assert.Equal(2, PasswordCheckerApp.CountCorrectPasswords(inputs));
        }

        [Fact]
        public void CheckPasswordMatchPatternTest()
        {
            Assert.True(PasswordCheckerApp.CheckPasswordMatchPattern("abcde", "1-3 a"));
            Assert.False(PasswordCheckerApp.CheckPasswordMatchPattern("cdefg", "1-3 b"));
            Assert.True(PasswordCheckerApp.CheckPasswordMatchPattern("ccccccccc", "2-9 c"));
        }

        [Fact]
        public void CountCorrectPasswords2Test()
        {
            string[] inputs = new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };

            Assert.Equal(1, PasswordCheckerApp.CountCorrectPasswords2(inputs));
        }

        [Fact]
        public void CheckPasswordMatch2PatternTest()
        {
            Assert.True(PasswordCheckerApp.CheckPasswordMatch2Pattern("abcde", "1-3 a"));
            Assert.False(PasswordCheckerApp.CheckPasswordMatch2Pattern("cdefg", "1-3 b"));
            Assert.False(PasswordCheckerApp.CheckPasswordMatch2Pattern("ccccccccc", "2-9 c"));
        }
    }
}
