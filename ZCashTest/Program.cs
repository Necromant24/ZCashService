using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace ZCashTest
{
    
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var service = new ZCashService();

            //var address = service.GetNewAddress();
            //var addresslist = service.GetListAddresses();
            // var transparentaddresses = service.GetTransparentListAddresses();
            // var balance = service.GetAddressBalance(transparentaddresses);
            //var operationId = service.SendFromToAddress("tmBTsUGEAPy9U4TxMrfgyHdKgPkLwEWDC8N", "tmDjFmaV7AV6FjFumvmLb5LTZ3nNNHKDAKF", 0.03f);

            // var txids = service.GetAddressTxIds("tmHb2WU7VLYDvH3Vd9BuKcZKUScjxD3vMwz");
            //
            var deltas = service.GetAddressDeltas("tmHb2WU7VLYDvH3Vd9BuKcZKUScjxD3vMwz");
            //
            // List<string> incomeTxs = service.GetAddressIncomingTransactions("tmHb2WU7VLYDvH3Vd9BuKcZKUScjxD3vMwz");

            //var txId = service.SendToAddress("tmHb2WU7VLYDvH3Vd9BuKcZKUScjxD3vMwz", 0.04);

            var a = 1;
        }
    }

}