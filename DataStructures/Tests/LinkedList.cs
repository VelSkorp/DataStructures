using Tests.Data;

namespace Tests
{
	[TestFixture]
	public class LinkedListTests
	{
		[Test]
		[TestCaseSource(typeof(LinkedListTestsData), nameof(LinkedListTestsData.TestCases))]
		public LinkedList.LinkedList<T> LinkedListTest<T>(LinkedList.LinkedList<T> linkedList, T removeData)
		{
			linkedList.Remove(removeData);
			return linkedList;
		}
	}
}