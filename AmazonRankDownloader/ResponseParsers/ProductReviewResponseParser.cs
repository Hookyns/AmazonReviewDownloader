using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AmazonRankDownloader.ResponseParsers
{
	/// <summary>
	/// Parser pro review produktů
	/// </summary>
	class ProductReviewResponseParser : IResponseParser<AmazonProductReview>
	{
		#region Fields

		private static readonly Regex ReviewMatcher = new Regex(
			//@"&&&\s*\[[^<]*<div id=\\""[^""]+\\"" data-hook=\\""review\\"" class=\\""a-section review\\"">"
			//+ @".*title=\\""([0-9])\.0 out of 5 stars\\"""
			//+ @".*<a.*class=.*review-title.*?>(.*)</a>"
			//+ @".*<span.*class=.*review-date.*?>(.*)</span>"
			//+ @".*<span.*class=.*review-text.*?>(.*)</span>"
			// Následující Regex je více než 10x rychlejší
			@"&&&\s*\[[^<]*<div id=\\""[^""]+\\"" data-hook=\\""review\\"" class=\\""a-section review\\"">"
			+ @".*title=\\""([0-9])\.0 out of 5 stars\\"""
			+ @".*?<a data-hook=\\""review-title\\""[^>]*>([^<]*)</a>"
			+ @".*?<span data-hook=\\""review-date\\""[^>]*>([^<]*)</span>"
			+ @".*?<span data-hook=\\""review-body\\""[^>]*>(.*?)</span>"
			,
			RegexOptions.Compiled | RegexOptions.IgnoreCase);

		#endregion

		#region Methods

		/// <summary>
		/// Naparsuje Response a vrátí kolekci daného typu
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		public ICollection<AmazonProductReview> Parse(string response)
		{
			var reviews = new List<AmazonProductReview>();
			var matches = ProductReviewResponseParser.ReviewMatcher.Matches(response);
			
			foreach(Match match in matches)
			{
				var g = match.Groups;

				reviews.Add(AmazonProductReview.ConstructFrom(
					g[1].Value, 
					g[2].Value, 
					g[4].Value, 
					g[3].Value));
			}

			return reviews;
		}

		#endregion
	}
}
