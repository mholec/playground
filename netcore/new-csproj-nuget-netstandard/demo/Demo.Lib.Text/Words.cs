using System;

namespace Demo.Lib.Text
{
	public static class Words
	{
		public static int WordCount(this string str)
		{
			return str.Split(new char[] { ' ', '.', '?' },
				StringSplitOptions.RemoveEmptyEntries).Length;
		}
	}
}
