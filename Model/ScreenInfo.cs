using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

using Acumatica.RESTClient.Client;
using Acumatica.RESTClient.ContractBasedApi;
using Acumatica.RESTClient.ContractBasedApi.Model;

namespace Acumatica.ScreenInfo_1.Model
{
	[DataContract]
	public class ScreenInfo : Entity, ITopLevelEntity
	{

		[DataMember(Name="ScreenID", EmitDefaultValue=false)]
		public StringValue? ScreenID { get; set; }

		[DataMember(Name="Fields", EmitDefaultValue=false)]
		public List<Field>? Fields { get; set; }

		public virtual string GetEndpointPath()
		{
			return "entity/ScreenInfo/1";
		}
	}
}