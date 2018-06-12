using NUnit.Framework;
using System.Collections;
using SequenceGenerator.Helpers;

namespace SequenceGenerator.Tests.Helpers
{
    public class SequenceFormatHelperTests
    {
        [Test]
        public void Format_Should_Return_Comma_Formatted_Sequence()
        {
            var arrlist = new ArrayList();
            arrlist.Add(0);
            arrlist.Add(1);
            arrlist.Add(2);
            arrlist.Add(3);
            arrlist.Add(4);
            arrlist.Add(5);
            var result = SequenceFormatHelper.Format(",", arrlist);
            Assert.AreEqual(result, "0,1,2,3,4,5");
        }

        [Test]
        public void Format_Should_Return_Space_Formatted_Sequence()
        {
            var arrList = new ArrayList();
            arrList.Add(5);
            arrList.Add(4);
            arrList.Add(3);
            arrList.Add(2);
            arrList.Add(1);
            arrList.Add(0);
            var result = SequenceFormatHelper.Format(" ", arrList);
            Assert.AreEqual(result, "5 4 3 2 1 0");
        }
    }
}
