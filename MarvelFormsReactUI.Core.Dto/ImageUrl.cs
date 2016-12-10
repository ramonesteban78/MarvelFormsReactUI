using System;
using Newtonsoft.Json;

namespace MarvelFormsReactUI.Core.Models
{
	public class ImageUrl
	{
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("extension")]
		public string Extension { get; set; }
	}
}

