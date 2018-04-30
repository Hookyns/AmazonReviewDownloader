using System.Collections.Generic;
using System.Net.Http;

namespace AmazonRankDownloader.RequestDescriptors
{
	/// <summary>
	/// Interface předepisující rozhranní pro requesty
	/// </summary>
	interface IRequestDescriptor
	{
		/// <summary>
		/// Vrátí hlavičky pro request
		/// </summary>
		IDictionary<string, string> Headers { get; }

		/// <summary>
		/// Vrátí body data pro reqest
		/// </summary>
		FormUrlEncodedContent Content { get; }

		/// <summary>
		/// Cílová URL adresa
		/// </summary>
		string Url { get; }
	}
}
