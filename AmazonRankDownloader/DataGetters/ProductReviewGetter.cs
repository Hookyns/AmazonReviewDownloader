using System.Collections.Generic;
using System.Threading.Tasks;
using AmazonRankDownloader.RequestDescriptors;
using AmazonRankDownloader.ResponseParsers;
using System;

namespace AmazonRankDownloader.DataGetters
{
	/// <summary>
	/// Třída starající se o stahování a generování Review produktů
	/// </summary>
	class ProductReviewGetter
	{
		#region Methods

		public async Task<ICollection<AmazonProductReview>> GetReviews(AmazonProduct product, 
			int fromPage, int pageCount, Action<string> progressReporter)
		{
			if (fromPage < 0)
				throw new ArgumentException(nameof(fromPage));

			if (pageCount < 1)
				throw new ArgumentException(nameof(pageCount));

			using (var req = new AmazonAjaxRequest<ProductReviewRequestDescriptor, ProductReviewResponseParser, AmazonProductReview>())
			{
				var results = new List<AmazonProductReview>();

				try
				{
					int c = fromPage + pageCount;

					for (int i = fromPage; i < c; i++)
					{
						results.AddRange(
								await req.GetResponseFor(new ProductReviewRequestDescriptor(product, i, pageSize: 10)) // 10 položek na stráku
							);
						if (progressReporter != null) progressReporter.Invoke($"Iteration {i} finished.");
					}
				}
				catch (Exception ex) // Pokud nastane chyba, vrátí alespoň to co se zatím podařilo stáhnout; Je dost možné, že server dočasně zablokoval IP
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}

				return results;
			}
		}

		#endregion
	}
}
