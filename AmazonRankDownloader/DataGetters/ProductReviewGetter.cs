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

		public async Task<ICollection<AmazonProductReview>> GetReviews(AmazonProduct product, Action<string> progressReporter)
		{
			using (var req = new AmazonAjaxRequest<ProductReviewRequestDescriptor, ProductReviewResponseParser, AmazonProductReview>())
			{
				var results = new List<AmazonProductReview>();

				try
				{
					for (int i = 0; i < 200; i++) // 200x stažení
					{
						results.AddRange(
								await req.GetResponseFor(new ProductReviewRequestDescriptor(product, i, pageSize: 10)) // 10 položek
							);
						progressReporter.Invoke($"Iteration {i} finished.");
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
