using System;
using Acumatica.RESTClient.Client;
using Acumatica.ScreenInfo_1.Model;

namespace Acumatica.ScreenInfo_1.Api
{
	[Obsolete("For backward compatibility")]
	public class ScreenInfoApi : BaseEndpointApi<ScreenInfo>
	{
		public ScreenInfoApi(ApiClient client) : base(client)
		{ }
	}
}