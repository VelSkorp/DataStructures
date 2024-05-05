namespace Tests.Data
{
	public class LinkedListTestsData
	{
		public static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(new LinkedList.LinkedList<int> { 15, 14, 12, 10 }, 15).Returns(new LinkedList.LinkedList<int> { 14, 12, 10 });
				yield return new TestCaseData(new LinkedList.LinkedList<int> { 15, 14, 12, 10 }, 14).Returns(new LinkedList.LinkedList<int> { 15, 12, 10 });
				yield return new TestCaseData(new LinkedList.LinkedList<int> { 15, 14, 12, 10 }, 10).Returns(new LinkedList.LinkedList<int> { 15, 14, 12 });
				yield return new TestCaseData(new LinkedList.LinkedList<string> { "test", "linked", "list", "remove" }, "list").Returns(new LinkedList.LinkedList<string> { "test", "linked", "remove" });
			}
		}
	}
}
