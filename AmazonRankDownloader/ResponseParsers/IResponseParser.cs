using System.Collections.Generic;

namespace AmazonRankDownloader.ResponseParsers
{
	/// <summary>
	/// Interface předepisující rozhranní pro parsování odpovědí
	/// </summary>
	/// <typeparam name="TResponseType"></typeparam>
	interface IResponseParser<TResponseType>
		where TResponseType : class
	{
		/// <summary>
		/// Naparsuje Response a vrátí kolekci daného typu
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		ICollection<TResponseType> Parse(string response);
	}
}
