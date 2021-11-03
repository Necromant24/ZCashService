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

            var txids = service.GetAddressTxIds("tmBTsUGEAPy9U4TxMrfgyHdKgPkLwEWDC8N");

            var deltas = service.GetAddressDeltas("tmBZcaTUgymzn4fHJP4fGfHoE3RZM5WYmhP");

            var a = 1;
        }
    }

}