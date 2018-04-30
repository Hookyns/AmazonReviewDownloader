using System;

namespace AmazonRankDownloader
{
	/// <summary>
	/// Třída představující hodnocení produktu
	/// </summary>
	public class AmazonProductReview
	{
		#region Properties

		/// <summary>
		/// Počet udělených hvězd
		/// </summary>
		public byte Stars { get; private set; }

		/// <summary>
		/// Titulek
		/// </summary>
		public string Title { get; private set; }

		/// <summary>
		/// Text hodnocení
		/// </summary>
		public string Text { get; private set; }

		/// <summary>
		/// Datum vytvoření hodnocení
		/// </summary>
		public DateTime CreateDate { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// Sestaví AmazonProductReview z obdržených surových dat
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		internal static AmazonProductReview ConstructFrom(string stars, string title, string text, string date)
		{
			return new AmazonProductReview()
			{
				Stars = byte.Parse(stars),
				Title = title,
				Text= text
			};
		}

		#endregion
	}
}