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
	public class Field : Entity
	{

		[DataMember(Name="DAC", EmitDefaultValue=false)]
		public StringValue? DAC { get; set; }

		[DataMember(Name="FieldID", EmitDefaultValue=false)]
		public StringValue? FieldID { get; set; }

		[DataMember(Name="View", EmitDefaultValue=false)]
		public StringValue? View { get; set; }

	}
}