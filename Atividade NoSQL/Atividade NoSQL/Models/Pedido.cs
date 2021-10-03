using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_NoSQL.Models
{
	public class Pedido
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string orderID { get; set; }
		public DateTime eventDate { get; set; }
		public string description { get; set; }
		public string api { get; set; }
		public ContentObject content { get; set; }
	}
}
