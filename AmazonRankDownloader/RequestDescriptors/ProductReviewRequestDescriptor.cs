using System.Collections.Generic;

namespace AmazonRankDownloader.RequestDescriptors
{
	/// <summary>
	/// Třída popisující request na review produktu
	/// </summary>
	class ProductReviewRequestDescriptor : RequestDescriptor
	{
		public ProductReviewRequestDescriptor(AmazonProduct product, int page, int pageSize = 100)
		{
			this.body = new Dictionary<string, string>()
			{
				{ "sortBy" , "" },
				{ "reviewerType", "all_reviews" },
				{ "formatType", "" },
				{ "mediaType", "" },
				{ "filterByStar", "" },
				{ "pageNumber", page.ToString() },
				{ "filterByKeyword", "" },
				{ "shouldAppend", "undefined" },
				{ "deviceType", "desktop" },
				{ "reftag", "cm_cr_arp_d_paging_btm_2" },
				{ "pageSize", pageSize.ToString() },
				{ "asin", product.ProductId },
				{ "scope", "reviewsAjax0" },
			};

			this.Url = "https://www.amazon.com/hz/reviews-render/ajax/reviews/get/ref=cm_cr_arp_d_paging_btm_2";
		}
	}
}
