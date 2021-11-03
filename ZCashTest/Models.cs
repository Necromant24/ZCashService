using System.Collections.Generic;

namespace ZCashTest
{
    public record RpcNewAddressResult(string result, string error, string id);

    public record RpcNewTransactionResult(string result);

    public record RpcRequestData(string method, List<object> Params);

    public record ZecBalance(int balance,int recieved);

    public record ZecSendToAddressData(string address, float amount);

    public record ZecAddressListResult(string Source, Dictionary<string, List<string>> Transparent);

    public record ZecDeltas(string Address, int BlockIndex, int Height, int Index, long Satoshis, string TxId);

}