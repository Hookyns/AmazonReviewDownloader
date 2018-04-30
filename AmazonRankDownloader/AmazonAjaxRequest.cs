using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AmazonRankDownloader.RequestDescriptors;
using AmazonRankDownloader.ResponseParsers;
using System.Text;

namespace AmazonRankDownloader
{
	/// <summary>
	/// Třída starající se o vytváření dotazů na Ajaxové entry-pointy Amazonu
	/// </summary>
	/// <typeparam name="TReqDescriptor"></typeparam>
	/// <typeparam name="TResParser"></typeparam>
	/// <typeparam name="TResponseType"></typeparam>
	class AmazonAjaxRequest<TReqDescriptor, TResParser, TResponseType> : IDisposable
		where TReqDescriptor : IRequestDescriptor
		where TResParser : IResponseParser<TResponseType>
		where TResponseType : class
	{
		#region Fields
		
		/// <summary>
		/// Parser na odpovědi
		/// </summary>
		private readonly TResParser responseParser;

		/// <summary>
		/// HTTP client pro provedení dotazů
		/// </summary>
		private readonly HttpClient client = new HttpClient();

		#endregion

		#region Ctors

		public AmazonAjaxRequest()
		{
			this.responseParser = Activator.CreateInstance<TResParser>();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Provede dotaz a vrátí odpověď v požadovaném formátu
		/// </summary>
		/// <param name="reqDesc"></param>
		/// <returns></returns>
		public async Task<ICollection<TResponseType>> GetResponseFor(TReqDescriptor reqDesc)
		{
			// Vytvoření requestu
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqDesc.Url)
			{
				Content = reqDesc.Content
			};

			// Zkopírování headers
			foreach (var item in reqDesc.Headers)
			{
				request.Headers.TryAddWithoutValidation(item.Key, item.Value);
			}

			// Získání odpovědi serveru
			var response = await client.SendAsync(request);
			var str = Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync());

			// Naparsování
			return this.responseParser.Parse(str);
		}

		public void Dispose()
		{
			client.Dispose();
		}

		#endregion
	}
}
