using System;
using System.Collections.Generic;
using System.Linq;
using Web_Api.online.Clients.Models;

namespace ZCashTest
{
    public class ZCashService
    {
        private ZCashRequestClient client;

        public ZCashService()
        {
            this.client = new();
        }


        public string GetNewAddress()
        {
            var resp = client.MakeRequest<string>(ZecRestMethods.getnewaddress);

            return resp;
        }

        public object GetListAddresses()
        {
            var resp = client.MakeRequest<List<ZecAddressListResult>>(ZecRestMethods.listaddresses);
            
            return resp;
        }
        
        public List<string> GetTransparentListAddresses()
        {
            var resp = client.MakeRequest<List<ZecAddressListResult>>(ZecRestMethods.listaddresses);
            var list = resp.First().Transparent["addresses"];
            
            return list;
        }


        public List<string> GetAddressTxIds(string address)
        {
            var resp = client.MakeRequest<List<string>>(ZecRestMethods.getaddresstxids, 
                new Dictionary<string, List<string>>()
                {
                    {"addresses", new List<string>(){ address }}
                });
            
            return resp;
        }
        
        

        public List<ZecDeltas> GetAddressDeltas(string address)
        {  
            var resp = client.MakeRequest<List<ZecDeltas>>(ZecRestMethods.getaddressdeltas,
                new Dictionary<string, List<string>>() { {"addresses",new List<string>(){ address } }});

            return resp;
        }


        public List<string> GetAddressIncomingTransactions(string address)
        {
            List<ZecDeltas> deltas = GetAddressDeltas(address);
            List<string> incomingTxs = deltas.Where(x => x.Satoshis > 0).Select(x => x.TxId).ToList();

            return incomingTxs;
        }


        public ZecBalance GetAddressBalance(List<string> addresses)
        {
            Dictionary<string, List<string>> addressList = new()
            {
                {"addresses", addresses}
            };
            var resp = client.MakeRequest<ZecBalance>(ZecRestMethods.getaddressbalance, addressList);
            
            return resp;
        }

        public string SendToAddress(string address,double amount)
        {
            return client.MakeRequest<string>(ZecRestMethods.sendtoaddress, address, amount);
        }

        public string SendFromToAddress(string fromAddress, string toAddress, float amount)
        {
            List<object> sendToAddressData = new List<object>()
            {
                fromAddress,
                new List<ZecSendToAddressData>(){ new ZecSendToAddressData(toAddress, amount) }
            };
            
            var resp = client.MakeRequest<string>(ZecRestMethods.z_sendmany,fromAddress,new List<ZecSendToAddressData>(){ new ZecSendToAddressData(toAddress, amount) });
            return resp;
        }
    }
}