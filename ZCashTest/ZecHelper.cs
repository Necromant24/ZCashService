using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ZCashTest
{
    public static class ZecHelper
    {
        public static string Port { get; set; } = "18232";
        public static string IpAddress { get; set; } = "192.168.233.128";
        
        public static RpcNewAddressResult GetZNewAddress()
        {
            Dictionary<string, string> jsonObj = new Dictionary<string, string>()
            {
                {"method","z_getnewaddress"}
            };

            string json = JsonConvert.SerializeObject(jsonObj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var password = "1";
                var userName = "1";
                var byteArray = Encoding.ASCII.GetBytes("1:1");
                
                var header = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
                httpClient.DefaultRequestHeaders.Authorization = header;
                // Error here
                var httpResponse = httpClient.PostAsync("http://127.0.0.1:" + Port, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    // Error Here
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;

                    RpcNewAddressResult newAddressRes = JsonConvert.DeserializeObject<RpcNewAddressResult>(responseContent);
                    
                    Console.WriteLine(newAddressRes?.result);

                    return newAddressRes;
                }
            }

            return new RpcNewAddressResult("","error","");
        }
        
        public static RpcNewAddressResult GetNewAddress()
        {
            Dictionary<string, string> jsonObj = new Dictionary<string, string>()
            {
                {"method","getnewaddress"}
            };

            string json = JsonConvert.SerializeObject(jsonObj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var password = "1";
                var userName = "1";
                var byteArray = Encoding.ASCII.GetBytes("1:1");
                
                var header = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
                httpClient.DefaultRequestHeaders.Authorization = header;
                // Error here
                var httpResponse = httpClient.PostAsync("http://"+IpAddress+":" + Port, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    // Error Here
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;

                    RpcNewAddressResult newAddressRes = JsonConvert.DeserializeObject<RpcNewAddressResult>(responseContent);
                    
                    Console.WriteLine(newAddressRes?.result);

                    return newAddressRes;
                }
            }

            return new RpcNewAddressResult("","error","");
        }
        
        public static string GetWalletInfo()
        {
            Dictionary<string, string> jsonObj = new Dictionary<string, string>()
            {
                {"method","getnewaddress"}
            };

            string json = JsonConvert.SerializeObject(jsonObj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var password = "1";
                var userName = "1";
                var byteArray = Encoding.ASCII.GetBytes("1:1");
                
                var header = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
                httpClient.DefaultRequestHeaders.Authorization = header;
                // Error here
                var httpResponse = httpClient.PostAsync("http://"+IpAddress+":" + Port, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    // Error Here
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;

                    RpcNewAddressResult newAddressRes = JsonConvert.DeserializeObject<RpcNewAddressResult>(responseContent);
                    
                    Console.WriteLine(newAddressRes?.result);

                    return "newAddressRes";
                }
            }


            return "";
        }

        public static void TestWriteJson()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"k1","v1"},
                {"k2","v2"}
            };

            List<object> ar2 = new List<object>();
            ar2.Add(dict);

            List<object> ar = new List<object>();
            ar.Add(1);
            ar.Add("2");
            ar.Add(dict);
            ar.Add(ar2);

            object obj = ar;

            string str = JsonConvert.SerializeObject(obj);


            Console.WriteLine(str);
        }
        
        public static string SendSimpleRpcRequest(string method)
        {

            Dictionary<string, string> jsonObj = new Dictionary<string, string>()
            {
                {"method", method}
            };

            string json = JsonConvert.SerializeObject(jsonObj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var password = "1";
                var userName = "1";
                var byteArray = Encoding.ASCII.GetBytes("1:1");
                
                var header = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
                httpClient.DefaultRequestHeaders.Authorization = header;
                // Error here
                var httpResponse = httpClient.PostAsync("http://"+IpAddress+":" + Port, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    // Error Here
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;

                    return responseContent;
                }
            }

            return "error";
        }
        
        public static string SendComplexRpc(string method, List<object> parameters)
        {
            return "";
        }
        
        public static RpcNewTransactionResult ZSendMany()
        {
            
            var data = new RpcRequestData("z_sendmany", new List<object>()
            {
                "[{\"txid\":\"fe459dc813ee2045ab44fba67325680699d4313d0ef33c19ceeedc997dd070c2\",\"vout\":0}]",
                "{\"9e21a5720c67358068f623ed5a05454b8640a6711412bf02472321d49c2e3616\":0.01}"
            });


            string json = JsonConvert.SerializeObject(data);

            json = json.Replace("Params", "params");
            
            
            json = "{\"method\": \"createrawtransaction\", \"params\": \"[{\"txid\":\"9e21a5720c67358068f623ed5a05454b8640a6711412bf02472321d49c2e3616\",\"vout\":0}]\", \"{\"tmVhHCfsGn2A7DMDCT6Ls5nyfK3s9uxCQU1\":0.01}\"}";




            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var password = "1";
                var userName = "1";
                var byteArray = Encoding.ASCII.GetBytes("1:1");
                
                var header = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
                httpClient.DefaultRequestHeaders.Authorization = header;
                // Error here
                var httpResponse = httpClient.PostAsync("http://"+IpAddress+":" + Port, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    // Error Here
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;

                    RpcNewTransactionResult newAddressRes = JsonConvert.DeserializeObject<RpcNewTransactionResult>(responseContent);
                    
                    Console.WriteLine(newAddressRes?.result);

                    return newAddressRes;
                }
            }

            return new RpcNewTransactionResult("");
        }


    }
}