using System.IO;

namespace AmazonRankDownloader.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var product = new AmazonProduct("B010S9N6OO");
			Program.PrintReviews(product);
			System.Console.ReadLine();
		}

		private static async void PrintReviews(AmazonProduct product)
		{
			var reviews = await product.GetReviews(0, 20, progressReporter: message =>
			{
				System.Console.WriteLine(message);
			});

			using (var file = File.Create("./data.txt"))
			using (TextWriter fw = new StreamWriter(file))
			{
				foreach (var review in reviews)
				{
					fw.WriteLine($"{review.Stars};{review.Title};{review.Text}");
					//System.Console.WriteLine(string.Format($"Stars: {review.Stars}, Title: {review.Title}"));
				}
			}
			
			System.Console.WriteLine(reviews.Count + " review stored in file data.txt");
			System.Console.WriteLine("Press ENTER to exit...");
		}
	}
}
