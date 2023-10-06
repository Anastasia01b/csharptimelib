using NUnit.Framework;
using CSharpTimeLib;

namespace TimeLibTestProject
{
    [TestFixture]
    public class TimeTests
    {
        [TestCase(3, 10, 56, "03:10:56")]
        [TestCase(13, 40, 10, "13:40:10")]
        [TestCase(14, 15, 10, "14:15:10")]
        [TestCase(24, 50, 22, "24:50:22")]
        public void TestToStringValid(int h, int m, int s, string expected)
        {
        var actual = new Time(h, m, s);
        Assert.AreEqual(expected, actual.ToString());
        }
        
        [TestCase(2, 40, 56, "03:10:56")]
        [TestCase(12, 19, 70, "13:40:10")]
        [TestCase(13, 15, 10, "14:15:10")]
        [TestCase(22, 49, 82, "24:50:22")]
        public void TestToStringInvalid(int h, int m, int s, string expected)
        {
        var actual = new Time(h, m, s);
        Assert.AreNotEqual(expected, actual.ToString(),$"expected:{expected} actual:{actual}");
        }


        [TestCase(2, 38, 54, 10, 12, 4, 12, 50, 58)]
        [TestCase(12, 45, 10, 1, 9, 12, 13, 54, 22)]
        [TestCase(5, 39, 52, 18, 10, 30, 23, 50, 22)]
        [TestCase(8,20, 18, 10, 50, 38, 19, 10, 56)]
        public void TestAddTime(int h1,int m1, int s1, int h2, int m2, int s2, int h3, int m3, int s3)
        {
            Time time1 = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Time result = time1.AddTime(time2);

            Assert.AreEqual(h3, result.Hours);
            Assert.AreEqual(m3, result.Minutes);
            Assert.AreEqual(s3, result.Seconds);

        }


        [TestCase(4, 52, 18, 2, 40, 10, 2, 12, 8)]
        [TestCase(12, 18, 46, 2, 2, 20, 10, 16, 26)]
        [TestCase(20, 48, 13, 16, 18, 5, 4, 30, 8)]
        [TestCase(7, 36, 12, 7, 18, 10, 0, 18, 2)]
        public void TestSubtractTime(int h1, int m1, int s1, int h2, int m2, int s2, int h3, int m3, int s3)
        {
            Time time1 = new Time(h1, m1, s1);
            Time time2 = new Time(h2, m2, s2);
            Time result = time1.SubtractTime(time2);

            Assert.AreEqual(h3, result.Hours);
            Assert.AreEqual(m3, result.Minutes);
            Assert.AreEqual(s3, result.Seconds);
        }

        [TestCase(5, 48, 52, 20932)]
        [TestCase(3, 10, 30, 11430)]
        [TestCase(10, 1, 10, 36070)]
        [TestCase(18, 10, 12, 65412)]
        public void TestToSeconds(int h, int m, int s, int expectedSeconds)
        {
            var time = new Time(h, m, s);
            Assert.AreEqual(expectedSeconds, time.ToSeconds());
        }


        [TestCase(20932, 5, 48, 52)]
        [TestCase(11430, 3, 10, 30)]
        [TestCase(36070, 10, 1, 10)]
        [TestCase(65412, 18, 10, 12)]
        public void TestFromSeconds(int s1, int h, int m, int s)
        {
            var result = Time.FromSeconds(s1);

            Assert.AreEqual(h, result.Hours);
            Assert.AreEqual(m, result.Minutes);
            Assert.AreEqual(s, result.Seconds);
        }

    }
}
