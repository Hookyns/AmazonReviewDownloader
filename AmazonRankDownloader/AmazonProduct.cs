using AmazonRankDownloader.DataGetters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonRankDownloader
{
	/// <summary>
	/// Třída představující produkt na amazonu
	/// </summary>
	public class AmazonProduct
	{
		#region Properties

		/// <summary>
		/// Id produktu
		/// </summary>
		public string ProductId { get; private set; }

		#endregion

		#region Ctors

		public AmazonProduct(string productId)
		{
			this.ProductId = productId;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Vrátí hodnocení produktu
		/// </summary>
		/// <returns></returns>
		public Task<ICollection<AmazonProductReview>> GetReviews(int fromPage, int pageCount, Action<string> progressReporter = null)
		{
			var req = new ProductReviewGetter();
			return req.GetReviews(this, fromPage, pageCount, progressReporter);
		}

		#endregion
	}
}
