using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Utils
{
    public class JDoodleRequest
    {
		public string script { get; private set; }

		public string language { get; private set; }

		public int versionIndex { get; private set; }

		public string clientId { get; private set; }

		public string clientSecret { get; private set; }

		public JDoodleRequest(string _script, string _clientId, string _clientSecret)
		{
			script = _script;
			language = "csharp";
			versionIndex = 2;
			clientId = _clientId;
			clientSecret = _clientSecret;
		}


	}
}
