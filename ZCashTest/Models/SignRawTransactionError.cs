﻿namespace Web_Api.online.Clients.Models
{
	public class SignRawTransactionError
	{
		public string Txid { get; set; }
		public int Vout { get; set; }
		public string ScriptSig { get; set; }
		public long Sequence { get; set; }
		public string Error { get; set; }
	}
}
