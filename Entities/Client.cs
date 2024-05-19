using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Client
	{
		public int ClientId { get; set; }
		public string Name { get; set; }
		public DateTime? Birth { get; set; }
		public DateTime? RegDate { get; set; }

		public Client(int clientId, string name, DateTime? birth, DateTime? regDate)
		{
			ClientId = clientId;
			Name = name;
			Birth = birth;
			RegDate = regDate;
		}
	}
}
