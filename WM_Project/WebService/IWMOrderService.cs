using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WM_Project.control;

namespace WM_Project.WebService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWMOrderService”。
    [ServiceContract]
    public interface IWMOrderService
    {
        [OperationContract]
        QuotaResponse Quota(QuotaRequest priceRequest);
        [OperationContract]
        LoginResponse LoginToWM(LoginRequest loginRequest);
        [OperationContract]
        RegistResponse RegistToWM(RegisterRequest registerRequest);
        [OperationContract]
        ChangePwdResponse ChangePassword(ChangePwdRequest changePwdRequest);
        [OperationContract]
        AccountBalanceResponse GetAccountBalanceResponse(AccountBalanceRequest accountBalanceRequest);
        [OperationContract]
        OrderResponse PlaceOrder(OrderRequest orderRequest);
        [OperationContract]
        PaymentResponse Disburse(PaymentRequest paymentRequest);
        
    }
}
