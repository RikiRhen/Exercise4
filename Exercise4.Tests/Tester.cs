using Microsoft.VisualStudio.TestPlatform.TestHost;
using SkalProj_Datastrukturer_Minne;

namespace Exercise4.Tests
{
    public class Tester
    {
        [Theory]
        [InlineData(5, 3)]
        [InlineData(1, 0)]
        [InlineData(15, 377)]
        [InlineData(10, 34)]
        public void RecursiveFibonnachi_ReturnsExpectedValue(int input, int expected)
        {
            int result = SkalProj_Datastrukturer_Minne.Program.RunRecursiveFibonnachi(input);
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(5, 3)]
        [InlineData(1, 0)]
        [InlineData(15, 377)]
        [InlineData(10, 34)]
        public void IterativeFibonnachi_ReturnsExpectedValue(int input, int expected)
        {
            int result = SkalProj_Datastrukturer_Minne.Program.RunIterativeFibonnachi(input);
            Assert.Equal(expected, result);
        }

        
        [Theory]
        [InlineData(7, 13)]
        [InlineData(20, 39)]
        [InlineData(15, 29)]
        [InlineData(1, 1)]
        public void RecursiveOdd_ReturnsCorrectNthNumber(int input, int expected)
        {
            int result = SkalProj_Datastrukturer_Minne.Program.RecursiveOdd(input);
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(7, 14)]
        [InlineData(20, 40)]
        [InlineData(15, 30)]
        [InlineData(1, 2)]
        public void RecursiveEven_ReturnsCorrectNthNumber(int input, int expected)
        {
            int result = SkalProj_Datastrukturer_Minne.Program.RecursiveEven(input);
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData("ABC", "CBA")]
        [InlineData("Total kaoz", "zoak latoT")]
        public void ReverseString_ProperlyInvertsSentString(string input, string expected)
        {
            string result = SkalProj_Datastrukturer_Minne.Program.ReverseString(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("List<int> list = new List<int>() { 1, 2, 3, 4 }", true)]
        [InlineData("{[()]}", true)]
        [InlineData("List<int> list = new List<int>() { 1, 2, 3, 4 )", false)]
        [InlineData("((())", false)]
        public void CheckParanthesis_CorrectlyChecksOpenersAndClosers(string input, bool expected)
        {
            bool result = SkalProj_Datastrukturer_Minne.Program.CheckValidityOfParantheses(input);
            Assert.Equal(result, expected);
        }

    }

}
