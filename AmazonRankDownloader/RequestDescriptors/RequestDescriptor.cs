using System.Collections.Generic;
using System.Net.Http;

namespace AmazonRankDownloader.RequestDescriptors
{
	/// <summary>
	/// Základní implementace třídy předepisující rozhranní pro requesty
	/// </summary>
	abstract class RequestDescriptor : IRequestDescriptor
	{
		#region Fields

		/// <summary>
		/// Editovatlný slovník tvořící BODY pro dotaz
		/// </summary>
		protected IDictionary<string, string> body = new Dictionary<string, string>();

		#endregion

		#region Properties

		/// <summary>
		/// Cílová URL adresa
		/// </summary>
		public string Url { get; protected set; }

		/// <summary>
		/// Vrátí hlavičky pro request
		/// </summary>
		public IDictionary<string, string> Headers { get; protected set; } = new Dictionary<string, string>()
		{
			{ "Accept", "text/html,*/*" },
			{ "Accept-Language", "cs-CZ,cs;q=0.9" },
			{ "Connection", "keep-alive" },
			{ "Content-Type", "application/x-www-form-urlencoded;charset=UTF-8" },
			{ "Cookie", "aws-target-static-id=1521305722173-225487; aws-target-data=%7B%22support%22%3A%221%22%7D; s_fid=7F491E23D9B74745-1CAC3BA5CCDEC6A8; regStatus=pre-register; aws-target-visitor-id=1521305722178-371098.26_28; aws-ubid-main=986-6168464-8617724; s_dslv=1522954066343; s_vn=1552841722799%26vn%3D2; s_nr=1522954066370-Repeat; c_m=undefinedwww.google.czNatural%20Search; s_cc=true; session-id=130-0000728-6280816; session-id-time=2082787201l; ubid-main=134-2996895-7515104; x-wl-uid=1/JHPPMrGb86H/sp3yfPixm316uIe/4j4hQzJpNKN1UIegmwkzD0aUu3Zdq6EVEBubR/xRj6Te40=; session-token=WDAxNVM1/9HY2MFC48n1yl4/6ygCJPkQVCTyeZAlZDMnuuK7w6mCwxGmbE8PxcBDyzumI88bq8BVqcZkje3cTJj5qxtfK1BvCXIywhuNsVP3FqPsyLQrkFGTW7EE8CPSiOGzJ1+X+tnYJARCJN4M/TTCYTvxfVHed5ylYp+JWRoMN4SGY/+Jsivy/LWx3UR/eV4uIt/u9QEjlossyYA54DuDfybfpya8lS7IBt4Shnr4//ekaEIRTQocXGiktcAe; skin=noskin; amznacsleftnav-40686997-c1cc-4ad7-ad22-2b2770cd6261=1; csm-hit=tb:SGWGM7XRX6E7Z1FS35C9+s-6BM8SYZP10ZSZKX5VC2H|1525074086779&adb:adblk_no" },
			{ "Host", "www.amazon.com" },
			{ "Origin", "https://www.amazon.com" },
			{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36 OPR/52.0.2871.64" },
			{ "X-Requested-With", "XMLHttpRequest" },
		};

		/// <summary>
		/// Vrátí obsah pro request
		/// </summary>
		public FormUrlEncodedContent Content => this.CreateContent();
		
		#endregion

		#region Private methods

		/// <summary>
		/// Sestaví Content pro HTTP request
		/// </summary>
		/// <returns></returns>
		private FormUrlEncodedContent CreateContent()
		{
			return new FormUrlEncodedContent(this.body);
		}

		#endregion
	}
}
