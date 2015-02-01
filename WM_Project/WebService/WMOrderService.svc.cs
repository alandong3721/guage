using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WM_Project.control;
using WM_Project.logical.user;
using System.Data.SqlClient;
using System.Collections;

namespace WM_Project.WebService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“WMOrderService”。
    public class WMOrderService : IWMOrderService
    {
        public static int leader_TailNumber = 0;
        public static int order_TailNumber = 0;
        // AskPriceRequest priceRequest=new AskPriceRequest();
        public QuotaResponse Quota(QuotaRequest priceRequest)
        {
            ArrayList errors = new ArrayList();
            QuotaResponse priceResponse = new QuotaResponse();
            try
            {
                if (priceRequest.Username == null)
                {
                    errors.Add("The username can't be null");
                }
                if (priceRequest.Username.Length > 50)
                {
                    errors.Add("The length of username is too long,it must between 1 and 50");
                }
                if (priceRequest.Length <= 0)
                {
                    errors.Add("The length of product must more than 0");
                }
                if (priceRequest.Height <= 0)
                {
                    errors.Add("The height of product must more than 0");
                }
                if (priceRequest.Width <= 0)
                {
                    errors.Add("The width of product must more than 0");
                }
                if (priceRequest.Weight <= 0)
                {
                    errors.Add("The weight of product must more than 0");
                }
                if (priceRequest.Destination == null)
                {
                    errors.Add("The destination can't be null");
                }
                else if (priceRequest.Destination.Length > 100)
                {
                    errors.Add("The length of destination is too long,it must between 1 and 100");
                }
                if (priceRequest.Post_way == null)
                {
                    errors.Add("The post way can't be null");
                }
                else if (!(priceRequest.Post_way.ToUpper().Contains("PF-GPR-COLLECTION")) && !(priceRequest.Post_way.ToUpper().Contains("PF-GPR-DE")) && !(priceRequest.Post_way.ToUpper().Contains("PF-IPE-COLLECTION")) && !(priceRequest.Post_way.ToUpper().Contains("PF-IPE-DEPOT")) && !(priceRequest.Post_way.ToUpper().Contains("PF-IPE-POL")) && !(priceRequest.Post_way.ToUpper().Contains("POSTNL")) && !(priceRequest.Post_way.ToUpper().Contains("EMS")) && !(priceRequest.Post_way.ToUpper().Contains("PF-IPE-TRAIL")))
                {
                    errors.Add("The post_way doesn't exist");
                }
                if (errors.Count > 0)
                {
                    priceResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        priceResponse.Errors[j] = errors[j].ToString();
                    }
                    return priceResponse;
                }
                priceResponse.Price = new InterFaceQuote().getQuote(priceRequest.Username, priceRequest.Destination, priceRequest.Weight, priceRequest.Length, priceRequest.Width, priceRequest.Height, priceRequest.Post_way);
                return priceResponse;
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());

                priceResponse.Errors = new string[errors.Count];
                for (int j = 0; j < errors.Count; j++)
                {
                    priceResponse.Errors[j] = errors[j].ToString();
                }

                return priceResponse;

            }
        }

        public LoginResponse LoginToWM(LoginRequest loginRequest)
        {
            ArrayList errors = new ArrayList();
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                if (loginRequest.Username == null)
                {
                    errors.Add("The username can't be null");
                }
                else if (loginRequest.Username.Length > 50)
                {
                    errors.Add("The length of username is too long,it must between 1 and 50");
                }
                if (loginRequest.Password == null)
                {
                    errors.Add("The password can't be null");
                }
                else if (loginRequest.Password.Length > 50)
                {
                    errors.Add("The length of Password is too long,it must between 1 and 50");
                }
                if (errors.Count > 0)
                {
                    loginResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        loginResponse.Errors[j] = errors[j].ToString();
                    }
                    return loginResponse;
                }
                int flag = new UserDAO().checkUser(loginRequest.Username, loginRequest.Password);
                if (flag == 1)
                {
                    loginResponse.Status = "Successful";
                }
                else if (flag == 0)
                {
                    loginResponse.Status = "Failed";
                    errors.Add("Password is wrong");
                }
                else if (flag == 0)
                {
                    loginResponse.Status = "Failed";
                    errors.Add("Username doesn't exist");
                }
                if (errors.Count > 0)
                {
                    loginResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        loginResponse.Errors[j] = errors[j].ToString();
                    }
                    return loginResponse;
                }
                return loginResponse;
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());

                loginResponse.Errors = new string[errors.Count];
                for (int j = 0; j < errors.Count; j++)
                {
                    loginResponse.Errors[j] = errors[j].ToString();
                }

                return loginResponse;

            }
        }

        public RegistResponse RegistToWM(RegisterRequest registerRequest)
        {
            
            ArrayList errors = new ArrayList();
            RegistResponse registeResponse = new RegistResponse();
            try
            {
                if (registerRequest.Name == null)
                {
                    errors.Add("Name can't be null");
                }


                else if (registerRequest.Name.Length > 50)
                {
                    errors.Add("The length of name is too long,it must between 1 and 50");
                }


                if (registerRequest.Password == null)
                {
                    errors.Add("Password can't be null");
                }


                else if (registerRequest.Password.Length > 50)
                {
                    errors.Add("The length of password is too long,it must between 1 and 50");
                }


                if (registerRequest.Telephone == null)
                {
                    errors.Add("Telephone can't be null");
                }


                else if (registerRequest.Telephone.Length > 50)
                {
                    errors.Add("The length of telephone is too long,it must between 1 and 50");
                }


                if (registerRequest.E_mail == null)
                {
                    errors.Add("E_mail can't be null");
                }


                else if (registerRequest.E_mail.Length > 50)
                {
                    errors.Add("The length of e_mail is too long,it must between 1 and 50");
                }


                if (registerRequest.CompanyName.Length > 50)
                {
                    errors.Add("The length of companyName is too long,it must between 1 and 50");
                }


                if (registerRequest.RecommendUser.Length > 50)
                {
                    errors.Add("The length of recommendUser is too long,it must between 1 and 50");
                }


                if (registerRequest.RecommendUser.Length > 50)
                {
                    errors.Add("The length of recommendUser is too long,it must between 1 and 50");
                }


                if (registerRequest.Website.Length > 50)
                {
                    errors.Add("The length of website is too long,it must between 1 and 50");
                }


                if (errors.Count > 0)
                {
                    registeResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        registeResponse.Errors[j] = errors[j].ToString();
                    }
                    return registeResponse;
                }


                if (new UserDAO().isUserExist(registerRequest.Name))
                {
                    registeResponse.Status = "Failed";
                    errors.Add("Name has been exist");
                }

                if (errors.Count > 0)
                {
                    registeResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        registeResponse.Errors[j] = errors[j].ToString();
                    }
                    return registeResponse;
                }

                User user = new User();
                user.Name = registerRequest.Name;
                user.Email = registerRequest.E_mail;
                user.RecommandUser = registerRequest.RecommendUser;
                user.CompanyName = registerRequest.CompanyName;
                user.Website = registerRequest.Website;
                user.Telephone = registerRequest.Telephone;
                user.Password = registerRequest.Password;
                user.Regist_time = DateTime.Now;


                if (new UserDAO().addUser(user))
                {
                    registeResponse.Status = "Successful";
                }

                return registeResponse;
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());

                registeResponse.Errors = new string[errors.Count];
                for (int j = 0; j < errors.Count; j++)
                {
                    registeResponse.Errors[j] = errors[j].ToString();
                }

                return registeResponse;

            }
        }

        public ChangePwdResponse ChangePassword(ChangePwdRequest changePwdRequest)
        {
            ArrayList errors = new ArrayList();
            ChangePwdResponse changePwdResponse = new ChangePwdResponse();

            try
            {
                if (changePwdRequest.Username == null)
                {
                    errors.Add("The username can't be null");
                }


                else if (changePwdRequest.Username.Length > 50)
                {
                    errors.Add("The length of username is too long,it must between 1 and 50");
                }


                if (changePwdRequest.OldPassword == null)
                {
                    errors.Add("The old password can't be null");
                }


                else if (changePwdRequest.OldPassword.Length > 50)
                {
                    errors.Add("The length of old password is too long,it must between 1 and 50");
                }


                if (changePwdRequest.NewPassword == null)
                {
                    errors.Add("The new password can't be null");
                }


                else if (changePwdRequest.NewPassword.Length > 50)
                {
                    errors.Add("The length of new password is too long,it must between 1 and 50");
                }


                if (errors.Count > 0)
                {
                    changePwdResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        changePwdResponse.Errors[j] = errors[j].ToString();
                    }
                    return changePwdResponse;
                }



                if (new UserDAO().checkUser(changePwdRequest.Username, changePwdRequest.OldPassword) != 1)
                {
                    changePwdResponse.Status = "Failed";
                    errors.Add("Old Password is wrong");
                }
                else
                {
                    if (new UserDAO().resetPassword(changePwdRequest.Username, changePwdRequest.NewPassword))
                    {
                        changePwdResponse.Status = "Successful";
                    }
                }
                if (errors.Count > 0)
                {
                    changePwdResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        changePwdResponse.Errors[j] = errors[j].ToString();
                    }
                    return changePwdResponse;
                }
                return changePwdResponse;
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());

                changePwdResponse.Errors = new string[errors.Count];
                for (int j = 0; j < errors.Count; j++)
                {
                    changePwdResponse.Errors[j] = errors[j].ToString();
                }

                return changePwdResponse;

            }
            
        }

        public AccountBalanceResponse GetAccountBalanceResponse(AccountBalanceRequest accountBalanceRequest)
        {
            ArrayList errors = new ArrayList();
            AccountBalanceResponse accountBalanceResponse = new AccountBalanceResponse();
            try
            {
                if (accountBalanceRequest.Username == null)
                {
                    errors.Add("The username can't be null");
                }


                else if (accountBalanceRequest.Username.Length > 50)
                {
                    errors.Add("The length of username is too long,it must between 1 and 50");
                }


                if (accountBalanceRequest.Password == null)
                {
                    errors.Add("The password can't be null");
                }


                else if (accountBalanceRequest.Password.Length > 50)
                {
                    errors.Add("The length of password is too long,it must between 1 and 50");
                }


                if (errors.Count > 0)
                {
                    accountBalanceResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        accountBalanceResponse.Errors[j] = errors[j].ToString();
                    }
                    return accountBalanceResponse;
                }


                LoginRequest loginRequest = new LoginRequest();
                loginRequest.Username = accountBalanceRequest.Username;
                loginRequest.Password = accountBalanceRequest.Password;
                if (LoginToWM(loginRequest).Status != "Successful")
                {
                    errors.Add("Authentication Failed");
                    return accountBalanceResponse;
                }
                if (errors.Count > 0)
                {
                    accountBalanceResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        accountBalanceResponse.Errors[j] = errors[j].ToString();
                    }
                    return accountBalanceResponse;
                }
                MyAccount myaccount = new MyAccount();
                myaccount = new MyAccountDAO().getMyAccount(accountBalanceRequest.Username);
                accountBalanceResponse.AccountBalance = myaccount.Balance;
                return accountBalanceResponse;
            }

            catch (Exception e)
            {
                errors.Add(e.ToString());

                accountBalanceResponse.Errors = new string[errors.Count];
                for (int j = 0; j < errors.Count; j++)
                {
                    accountBalanceResponse.Errors[j] = errors[j].ToString();
                }

                return accountBalanceResponse;

            }
        }


        public PaymentResponse Disburse(PaymentRequest paymentRequest)
        {
            ArrayList errors = new ArrayList();
            PaymentResponse paymentResponse = new PaymentResponse();
            try
            {
                if (paymentRequest.Username == null)
                {
                    errors.Add("The username can't be null");
                }


                else if (paymentRequest.Username.Length > 50)
                {
                    errors.Add("The length of username is too long,it must between 1 and 50");
                }


                if (paymentRequest.Password == null)
                {
                    errors.Add("The password can't be null");
                }


                else if (paymentRequest.Password.Length > 50)
                {
                    errors.Add("The length of password is too long,it must between 1 and 50");
                }


                if (errors.Count > 0)
                {
                    paymentResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        paymentResponse.Errors[j] = errors[j].ToString();
                    }
                    return paymentResponse;
                }
                LoginRequest loginRequest = new LoginRequest();
                loginRequest.Username = paymentRequest.Username;
                loginRequest.Password = paymentRequest.Password;
                if (LoginToWM(loginRequest).Status != "Successful")
                {
                    errors.Add("Authentication Failed");
                    return paymentResponse;
                }
                if (new MyAccountDAO().userPayUseMyAccount(paymentRequest.Username, paymentRequest.Repay))
                {
                    paymentResponse.Status = "Successful";
                }
                if (errors.Count > 0)
                {
                    paymentResponse.Errors = new string[errors.Count];
                    for (int j = 0; j < errors.Count; j++)
                    {
                        paymentResponse.Errors[j] = errors[j].ToString();
                    }
                    return paymentResponse;
                }
                return paymentResponse;
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());

                paymentResponse.Errors = new string[errors.Count];
                for (int j = 0; j < errors.Count; j++)
                {
                    paymentResponse.Errors[j] = errors[j].ToString();
                }

                return paymentResponse;

            }

        }

        public OrderResponse PlaceOrder(OrderRequest orderRequest)
        {
            ArrayList errors = new ArrayList();
            OrderResponse orderResponse = new OrderResponse();
            try
            {
                if (orderRequest.Description == null)
                {
                    errors.Add("The description can't be null");
                }

                else if (orderRequest.Description.Length != orderRequest.Items)
                {
                    errors.Add("The length of product's description isn't equal to items");
                }


                if (orderRequest.Length.Length != orderRequest.Items)
                {
                    errors.Add("The length of product's Length isn't equal to items");
                }

                if (orderRequest.Weight.Length != orderRequest.Items)
                {
                    errors.Add("The length of product's Weight isn't equal to items");
                }
                if (orderRequest.Value.Length != orderRequest.Items)
                {
                    errors.Add("The length of product's Value isn't equal to items");
                }
                if (orderRequest.Width.Length != orderRequest.Items)
                {
                    errors.Add("The length of product's Width isn't equal to items");
                }
                if (orderRequest.Items <= 0)
                {
                    errors.Add("The  product's items must be more than 0");
                }

                if (orderRequest.Password == null)
                {
                    errors.Add("The password can't be null");
                }
                else if (orderRequest.Password.Length > 50)
                {
                    errors.Add("The length of password is too long,it must between 1 and 50");
                }


                if (orderRequest.PurposeOfShipment == null)
                {
                    errors.Add("The purpose of shipment can't be null");
                }
                else if (orderRequest.PurposeOfShipment.Length > 50)
                {
                    errors.Add("The length of purpose of shipment is too long,it must between 1 and 50");
                }

                if (orderRequest.RecipeintPostCode == null)
                {
                    errors.Add("The RecipeintPostCode can't be null");
                }
                else if (orderRequest.RecipeintPostCode.Length > 6)
                {
                    errors.Add("The length of RecipeintPostCode is too long,it must between 1 and 6");
                }

                if (orderRequest.RecipientAddress == null)
                {
                    errors.Add("The RecipientAddress can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.RecipientAddress.Length > 69)
                {
                    errors.Add("The length of parcelforce's RecipientAddress is too long,it must between 1 and 69");
                }
                else if (orderRequest.RecipientAddress.Length > 100)
                {
                    errors.Add("The length of  RecipientAddress is too long,it must between 1 and 100");
                }


                if (orderRequest.SenderAddress == null)
                {
                    errors.Add("The SenderAddress can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.SenderAddress.Length > 69)
                {
                    errors.Add("The length of parcelforce's SenderAddress is too long,it must between 1 and 69");
                }
                else if (orderRequest.SenderAddress.Length > 100)
                {
                    errors.Add("The length of  SenderAddress is too long,it must between 1 and 100");
                }


                if (orderRequest.SenderCity == null)
                {
                    errors.Add("The SenderCity can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.SenderCity.Length > 24)
                {
                    errors.Add("The length of parcelforce's SenderCity is too long,it must between 1 and 24");
                }
                else if (orderRequest.SenderCity.Length > 50)
                {
                    errors.Add("The length of  SenderCity is too long,it must between 1 and 50");
                }


                if (orderRequest.SenderCompanyname == null)
                {
                    errors.Add("The SenderCompanyname can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.SenderCompanyname.Length > 24)
                {
                    errors.Add("The length of parcelforce's SenderCompanyname is too long,it must between 1 and 24");
                }
                else if (orderRequest.SenderCompanyname.Length > 50)
                {
                    errors.Add("The length of  SenderCompanyname is too long,it must between 1 and 50");
                }



                if (orderRequest.SenderContactName == null)
                {
                    errors.Add("The SenderContactName can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.SenderContactName.Length > 24)
                {
                    errors.Add("The length of parcelforce's SenderContactName is too long,it must between 1 and 24");
                }
                else if (orderRequest.SenderContactName.Length > 50)
                {
                    errors.Add("The length of  SenderContactName is too long,it must between 1 and 50");
                }



                if (orderRequest.SenderContry == null)
                {
                    errors.Add("The SenderContry can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.SenderContry.Length > 24)
                {
                    errors.Add("The length of parcelforce's SenderContry is too long,it must between 1 and 24");
                }
                else if (orderRequest.SenderContry.Length > 50)
                {
                    errors.Add("The length of  SenderContry is too long,it must between 1 and 50");
                }


                if (orderRequest.SenderPhone == null)
                {
                    errors.Add("The SenderPhone can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.SenderPhone.Length > 11)
                {
                    errors.Add("The length of parcelforce's SenderPhone is too long,it must between 1 and 11");
                }
                else if (orderRequest.SenderPhone.Length > 50)
                {
                    errors.Add("The length of  SenderPhone is too long,it must between 1 and 50");
                }



                if (orderRequest.SenderPostCode == null)
                {
                    errors.Add("The SenderPostCode can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.SenderPostCode.Length > 16)
                {
                    errors.Add("The length of parcelforce's SenderPostCode is too long,it must between 1 and 16");
                }
                else if (orderRequest.SenderPostCode.Length > 50)
                {
                    errors.Add("The length of  SenderPostCode is too long,it must between 1 and 50");
                }


                if (!(orderRequest.ServiceCode.ToUpper().Contains("PF-GPR-COLLECTION")) && !(orderRequest.ServiceCode.ToUpper().Contains("PF-GPR-DE")) && !(orderRequest.ServiceCode.ToUpper().Contains("PF-IPE-COLLECTION")) && !(orderRequest.ServiceCode.ToUpper().Contains("PF-IPE-DEPOT")) && !(orderRequest.ServiceCode.ToUpper().Contains("PF-IPE-POL")) && !(orderRequest.ServiceCode.ToUpper().Contains("POSTNL")) && !(orderRequest.ServiceCode.ToUpper().Contains("EMS")) && !(orderRequest.ServiceCode.ToUpper().Contains("PF-IPE-TRAIL")))
                {
                    errors.Add("ServiceCode doesn't exist");
                }





                if (orderRequest.RecipientCity == null)
                {
                    errors.Add("The RecipientCity can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.RecipientCity.Length > 24)
                {
                    errors.Add("The length of parcelforce's RecipientCity is too long,it must between 1 and 24");
                }
                else if (orderRequest.RecipientCity.Length > 50)
                {
                    errors.Add("The length of  RecipientCity is too long,it must between 1 and 50");
                }


                if (orderRequest.RecipientCompanyName == null)
                {
                    errors.Add("The RecipientCompanyName can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.RecipientCompanyName.Length > 24)
                {
                    errors.Add("The length of parcelforce's RecipientCompanyName is too long,it must between 1 and 24");
                }
                else if (orderRequest.RecipientCompanyName.Length > 50)
                {
                    errors.Add("The length of  RecipientCompanyName is too long,it must between 1 and 50");
                }



                if (orderRequest.RecipientContactName == null)
                {
                    errors.Add("The RecipientContactName can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.RecipientContactName.Length > 24)
                {
                    errors.Add("The length of parcelforce's RecipientContactName is too long,it must between 1 and 24");
                }
                else if (orderRequest.RecipientContactName.Length > 50)
                {
                    errors.Add("The length of  RecipientContactName is too long,it must between 1 and 50");
                }



                if (orderRequest.RecipientCountry == null)
                {
                    errors.Add("The RecipientCountry can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.RecipientCountry.Length > 24)
                {
                    errors.Add("The length of parcelforce's RecipientCountry is too long,it must between 1 and 24");
                }
                else if (orderRequest.RecipientCountry.Length > 50)
                {
                    errors.Add("The length of  RecipientCountry is too long,it must between 1 and 50");
                }


                if (orderRequest.RecipientPhone == null)
                {
                    errors.Add("The RecipientPhone can't be null");
                }
                else if (orderRequest.Shippingtype.ToLower().Contains("pf") && orderRequest.RecipientPhone.Length > 11)
                {
                    errors.Add("The length of parcelforce's RecipientPhone is too long,it must between 1 and 11");
                }
                else if (orderRequest.RecipientPhone.Length > 50)
                {
                    errors.Add("The length of  RecipientPhone is too long,it must between 1 and 50");
                }

                if (orderRequest.Shippingdate == null)
                {
                    errors.Add("Shippingdate can't be null");
                }



                Util.SetCertificatePolicy();
                string leader_order_number = "WS" + DateTime.Now.ToString("yyyyMMddhhmmss") + leader_TailNumber.ToString().PadLeft(6, '0');
                leader_TailNumber++;

                string order_number = "";
                for (int i = 0; i < orderRequest.Weight.Length; i++)
                {
                    if (i != orderRequest.Weight.Length - 1)
                        order_number += "WE" + DateTime.Now.ToString("yyyyMMddhhmmss") + order_TailNumber.ToString().PadLeft(6, '0') + ",";
                    else
                        order_number += "WE" + DateTime.Now.ToString("yyyyMMddhhmmss") + order_TailNumber.ToString().PadLeft(6, '0');
                    order_TailNumber++;
                }

                if (orderRequest.ServiceCode.ToLower().Contains("chinanl"))
                {
                    try
                    {
                        string eanumber = "";
                        for (int i = 0; i < orderRequest.Weight.Length; i++)
                        {
                            int contentLength = 1;
                            string[] Content = { "Content" };
                            string[] CostCenter = { "CostCenter" };
                            string[] CustomerOrderNumber = { "number" };
                            string[] CountryOfOrigin = { "GB" };
                            string[] Description = orderRequest.Description;
                            string[] HSTariffNr = { "10306759" };
                            string[] contentQuantity = { "1" };
                            string[] contentValue = { orderRequest.Value[i].ToString() };


                            string[] contentWeight = { orderRequest.Weight[i].ToString() };


                            CIF_SB cif = new CIF_SB();
                            //获取3S运单号
                            string barcode = cif.GenerateBarcode("Et@0!!", "23621feac2e556e9beffbd7a4f8885ba93aef578", "TKAM", "10423404", "TKAM", "0000000-9999999", "3S", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                            //获取CD运单号
                            string DownPartnerBarcode = cif.GenerateBarcode("Et@0!!", "23621feac2e556e9beffbd7a4f8885ba93aef578", "6836", "10423404", "6836", "0000-9999", "CD", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                            LabelTest1.LabellingWebServiceClient client = new LabelTest1.LabellingWebServiceClient();
                            client.ClientCredentials.UserName.UserName = "Et@0!!";
                            client.ClientCredentials.UserName.Password = "23621feac2e556e9beffbd7a4f8885ba93aef578";


                            LabelTest1.GenerateLabelRequest request = new LabelTest1.GenerateLabelRequest();
                            LabelTest1.Customer customer = new LabelTest1.Customer();
                            LabelTest1.Address address = new LabelTest1.Address();
                            address.AddressType = "02";
                            address.City = "Amsterdam";
                            address.CompanyName = "PO6836 - Scip";
                            address.Countrycode = "NL";
                            address.HouseNr = "10";
                            address.Name = "";
                            address.Remark = "true";
                            address.Street = "Gyroscoopweg";
                            address.Zipcode = "1042AB";
                            customer.Address = address;
                            customer.CollectionLocation = "103861";
                            customer.ContactPerson = orderRequest.SenderContactName;

                            customer.CustomerCode = "6836";
                            customer.CustomerNumber = "10423404";
                            customer.Email = "";
                            customer.Name = orderRequest.SenderContactName;

                            LabelTest1.Customs custome = new LabelTest1.Customs();
                            custome.ShipmentType = "Gift";

                            LabelTest1.Message message = new LabelTest1.Message();
                            message.MessageID = "1";
                            message.MessageTimeStamp = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                            message.Printertype = "GraphicFile|PDF";

                            LabelTest1.Shipment shipment = new LabelTest1.Shipment();
                            LabelTest1.Address shipmentaddress = new LabelTest1.Address();
                            shipmentaddress.AddressType = "01";
                            shipmentaddress.City = orderRequest.RecipientCity;
                            shipmentaddress.CompanyName = orderRequest.RecipientContactName + "\r\n" + orderRequest.RecipientCompanyName;
                            shipmentaddress.Countrycode = "CN";
                            shipmentaddress.HouseNr = orderRequest.RecipientPhone;
                            shipmentaddress.Street = orderRequest.RecipientAddress;
                            shipmentaddress.Zipcode = orderRequest.RecipeintPostCode;
                            LabelTest1.Address[] shipmentaddresses = new LabelTest1.Address[1];
                            shipmentaddresses[0] = shipmentaddress;
                            shipment.Addresses = shipmentaddresses;
                            shipment.Barcode = barcode;
                            LabelTest1.Contact contact = new LabelTest1.Contact();
                            contact.ContactType = "01";
                            contact.Email = "";
                            contact.SMSNr = orderRequest.RecipientPhone;
                            LabelTest1.Contact[] contacts = new LabelTest1.Contact[1];
                            contacts[0] = contact;
                            shipment.Contacts = contacts;

                            LabelTest1.Content[] contents = new LabelTest1.Content[contentLength];
                            for (int j = 0; j < contentLength; j++)
                            {
                                LabelTest1.Content content = new LabelTest1.Content();
                                shipment.Content = Content[j];
                                shipment.CostCenter = CostCenter[j];
                                shipment.CustomerOrderNumber = CustomerOrderNumber[j];
                                content.CountryOfOrigin = CountryOfOrigin[j];
                                content.Description = PinYinHelpers.ToPinYin(Description[j]);
                                content.HSTariffNr = HSTariffNr[j];
                                content.Quantity = contentQuantity[j];
                                content.Value = contentValue[j];
                                content.Weight = contentWeight[j];
                                contents[j] = content;
                            }
                            custome.Content = contents;
                            custome.Currency = "GBP";
                            custome.HandleAsNonDeliverable = "true";
                            custome.Invoice = "true";
                            custome.InvoiceNr = "4820WORMF";
                            custome.License = "true";
                            custome.LicenseNr = "true";
                            custome.Certificate = "true";
                            custome.CertificateNr = "true";
                            LabelTest1.Dimension dimenshin = new LabelTest1.Dimension();
                            dimenshin.Height = (Math.Ceiling(orderRequest.Height[0] * 100)).ToString();
                            dimenshin.Length = Math.Ceiling(orderRequest.Length[0] * 100).ToString();
                            dimenshin.Volume = Math.Ceiling((orderRequest.Height[0] * orderRequest.Length[0] * orderRequest.Width[0]) * 100).ToString();
                            dimenshin.Weight = Math.Ceiling(orderRequest.Weight[0] * 1000).ToString();
                            dimenshin.Width = Math.Ceiling(orderRequest.Width[0] * 100).ToString();
                            shipment.Dimension = dimenshin;
                            shipment.DownPartnerBarcode = DownPartnerBarcode;
                            LabelTest1.Group group = new LabelTest1.Group();
                            group.GroupCount = "2";
                            group.GroupSequence = "2";
                            group.GroupType = "03";
                            // group.MainBarcode = MainBarcode;
                            LabelTest1.Group[] groups = new LabelTest1.Group[1];
                            groups[0] = group;
                            shipment.Groups = groups;
                            shipment.Customs = custome;
                            shipment.ProductCodeDelivery = "4947"; //"3987";
                            shipment.Reference = "Gift";//"MYREF01";

                            request.Shipment = shipment;
                            request.Customer = customer;
                            request.Message = message;

                            LabelTest1.ResponseShipment request2 = client.GenerateLabel(request);

                            string PartnerID = request2.DownPartnerID;
                            string PartnerBarcode = request2.DownPartnerBarcode;
                            if (PartnerBarcode == null)
                            {

                            }
                            else
                            {
                                if (i != orderRequest.Weight.Length - 1)
                                    eanumber += PartnerBarcode + ",";
                                else
                                    eanumber += PartnerBarcode;
                            }
                        }
                        orderResponse.TrackNumber = eanumber;
                        orderResponse.LeaderOrderNumber = leader_order_number;
                        orderResponse.OrderNumber = order_number;
                    }
                    catch (Exception ee)
                    {

                    }

                }

                else if (orderRequest.ServiceCode.ToLower().Contains("ems"))
                {
                    try
                    {
                        string eanumbers = null;
                        for (int jj = 0; jj < orderRequest.Weight.Length; jj++)
                        {
                            SqlConnection conn = DBConn.getConn();
                            conn.Open();

                            SqlCommand cmd = new SqlCommand("begin tran select top 1 EMSNumber from tb_EMS with (rowlock,updlock) where EMSStatus=0 ", conn);
                            // SqlCommand ssss = new SqlCommand("update tb_EMS set EMSStatus=1 where EMSNumber='" + listdao.Ea_track_no + "'");
                            SqlDataReader dataReader = cmd.ExecuteReader();
                            string eanumber = null;
                            if (dataReader.Read())
                            {
                                eanumber = dataReader["EMSNumber"].ToString();
                            }
                            dataReader.Close();
                            cmd.CommandText = "update tb_EMS set EMSStatus=1 where EMSNumber='" + eanumber + "' commit tran";
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            if (eanumber != null)
                            {

                                if (jj != orderRequest.Weight.Length - 1)
                                    eanumbers += eanumber + ",";
                                else
                                    eanumbers += eanumber;
                            }
                        }
                        orderResponse.TrackNumber = eanumbers;
                        orderResponse.LeaderOrderNumber = leader_order_number;
                        orderResponse.OrderNumber = order_number;
                    }

                    catch (Exception ee)
                    {
                    }
                }




                else if (orderRequest.ServiceCode.ToUpper().Contains("PF-IPE"))
                {
                    if (orderRequest.ServiceCode.ToLower().Contains("collection"))
                    {
                        //ParcelForce用户名密码认证
                        //ParcelForce用户名密码认证
                        ShipServiceForApp.Authentication auth = new ShipServiceForApp.Authentication();
                        auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                        auth.Password = "kvhkwr22";//"129v2iz5";



                        //订单请求
                        ShipServiceForApp.RequestedShipment requestShipment = new ShipServiceForApp.RequestedShipment();
                        requestShipment.DepartmentId = "3";
                        //Set to COLLECTION    DELIVERY   TRAILER
                        requestShipment.ShipmentType = "COLLECTION";
                        requestShipment.ContractNumber = "P831255";
                        requestShipment.ServiceCode = "IPE";
                        requestShipment.ShippingDateSpecified = true;




                        //收件联络人
                        ShipServiceForApp.Contact contact = new ShipServiceForApp.Contact();

                        string recipientCompanyName = PinYinHelpers.ToPinYin(orderRequest.RecipientCompanyName);
                        string recipientContactName = PinYinHelpers.ToPinYin(orderRequest.RecipientContactName);
                        //收件人公司名称
                        contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//listdao.RecipientCompanyName;
                        //收件联络人姓名
                        contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// listdao.RecipientContactName;
                        //收件联络人电话
                        contact.Telephone = orderRequest.RecipientPhone;
                        //contact.EmailAddress = "1005780548@qq.com";

                        requestShipment.RecipientContact = contact;
                        //DepartmentId

                        //寄件日期设置

                        requestShipment.ShippingDate = DateTime.Parse(orderRequest.Shippingdate);


                        //收件人地址
                        ShipServiceForApp.Address recipientAddress = new ShipServiceForApp.Address();
                        string address = PinYinHelpers.ToPinYin(orderRequest.RecipientAddress);
                        recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// listdao.RecipientAddressLine;
                        if (address.Length > 24)
                            recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                        if (address.Length > 43)
                            recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));


                        string recipientTown = PinYinHelpers.ToPinYin(orderRequest.RecipientCity);
                        recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //listdao.RecipientTown;
                        recipientAddress.Postcode = orderRequest.RecipeintPostCode.Substring(0, ((orderRequest.RecipeintPostCode.Length > 16) ? 16 : orderRequest.RecipeintPostCode.Length));
                        //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                        recipientAddress.Country = "CN";
                        requestShipment.RecipientAddress = recipientAddress;

                        //寄件信息
                        ShipServiceForApp.CollectionInfo importerCollectionInfo = new ShipServiceForApp.CollectionInfo();
                        //寄件联络人信息
                        ShipServiceForApp.Contact importerContact = new ShipServiceForApp.Contact();
                        importerContact.BusinessName = orderRequest.SenderCompanyname.Substring(0, ((orderRequest.SenderCompanyname.Length > 24) ? 24 : orderRequest.SenderCompanyname.Length));
                        importerContact.ContactName = orderRequest.SenderContactName.Substring(0, ((orderRequest.SenderContactName.Length > 24) ? 24 : orderRequest.SenderContactName.Length));
                        importerContact.Telephone = orderRequest.SenderPhone.Substring(0, ((orderRequest.SenderPhone.Length > 15) ? 15 : orderRequest.SenderPhone.Length));
                        //importerContact.EmailAddress = "1005780548@qq.com";
                        requestShipment.ImporterContact = importerContact;
                        //寄件联络人地址信息
                        ShipServiceForApp.Address importerAddress = new ShipServiceForApp.Address();
                        string collectionAddress = orderRequest.SenderAddress;
                        importerAddress.AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //comm.CollectionAddressLine;
                        if (collectionAddress.Length >= 19)
                            importerAddress.AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 43) ? 19 : (collectionAddress.Length - 24)));
                        if (collectionAddress.Length >= 43)
                            importerAddress.AddressLine3 = collectionAddress.Substring(43, ((collectionAddress.Length > 67) ? 24 : (collectionAddress.Length - 43)));
                        importerAddress.Postcode = orderRequest.SenderPostCode.Substring(0, ((orderRequest.SenderPostCode.Length > 16) ? 16 : orderRequest.SenderPostCode.Length));
                        importerAddress.Town = orderRequest.SenderCity.Substring(0, ((orderRequest.SenderCity.Length > 24) ? 24 : orderRequest.SenderCity.Length));

                        //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                        importerAddress.Country = "GB";
                        requestShipment.ImporterAddress = importerAddress;

                        ////取件时间，From为起始取件时间，To为结束取件时间
                        ShipServiceForApp.DateTimeRange collectionTime = new ShipServiceForApp.DateTimeRange();


                        collectionTime.From = DateTime.Parse(orderRequest.Shippingdate + "T00:00:00");
                        collectionTime.To = DateTime.Parse(orderRequest.Shippingdate + "T00:00:00");
                        //寄件包裹的地址联络人以及取件时间的设置
                        importerCollectionInfo.CollectionAddress = importerAddress;
                        importerCollectionInfo.CollectionContact = importerContact;
                        importerCollectionInfo.CollectionTime = collectionTime;


                        //
                        requestShipment.CollectionInfo = importerCollectionInfo;
                        //设置包裹的总数量
                        //数据库中暂无此字段，这是个问题，期待解决
                        requestShipment.TotalNumberOfParcels = orderRequest.Weight.Length.ToString();

                        ShipServiceForApp.Enhancement enhancement = new ShipServiceForApp.Enhancement();

                        //增加的保险额度
                        //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                        enhancement.EnhancedCompensation = "0";
                        //周末是否取件
                        enhancement.SaturdayDeliveryRequired = false;
                        requestShipment.Enhancement = enhancement;

                        ShipServiceForApp.InternationalInfo internationalInfo = new ShipServiceForApp.InternationalInfo();
                        internationalInfo.DocumentsOnly = false;

                        requestShipment.InternationalInfo = internationalInfo;



                        ShipServiceForApp.Parcel[] parcelInfo = new ShipServiceForApp.Parcel[orderRequest.Weight.Length];
                        for (int ij = 0; ij < orderRequest.Weight.Length; ij++)
                        {
                            ShipServiceForApp.Parcel parcel = new ShipServiceForApp.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)orderRequest.Weight[ij];
                            parcel.Width = orderRequest.Width[ij].ToString().Substring(0, ((orderRequest.Width[ij].ToString().Length > 8) ? 8 : orderRequest.Width[ij].ToString().Length));
                            parcel.Height = orderRequest.Height[ij].ToString().Substring(0, ((orderRequest.Height[ij].ToString().Length > 8) ? 8 : orderRequest.Height[ij].ToString().Length));
                            parcel.Length = orderRequest.Length[ij].ToString().Substring(0, ((orderRequest.Length[ij].ToString().Length > 8) ? 8 : orderRequest.Length[ij].ToString().Length)); ;
                            parcel.PurposeOfShipment = "Gift";



                            ShipServiceForApp.ContentDetail[] contentDetails = new ShipServiceForApp.ContentDetail[1];
                            ShipServiceForApp.ContentDetail contentDetail = new ShipServiceForApp.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinYinHelpers.ToPinYin(orderRequest.Description[ij]);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)orderRequest.Weight[ij];
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)orderRequest.Value[ij];
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[ij] = parcel;
                        }
                        requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                        requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                        requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                        requestShipment.InternationalInfo.Parcels = parcelInfo;

                        ShipServiceForApp.ShipPortTypeClient client = new ShipServiceForApp.ShipPortTypeClient();

                        ShipServiceForApp.CreateShipmentRequest shipRequest = new ShipServiceForApp.CreateShipmentRequest();
                        shipRequest.Authentication = auth;
                        shipRequest.RequestedShipment = requestShipment;
                        ShipServiceForApp.CreateShipmentReply shipReply = client.createShipment(shipRequest);

                        if (shipReply.Alerts != null)
                        {

                        }
                        else
                        {
                            string shipNumber = null;
                            for (int ij = 0; ij < shipReply.CompletedShipmentInfo.CompletedShipments.Length; ij++)
                            {
                                if (ij == shipReply.CompletedShipmentInfo.CompletedShipments.Length - 1)
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber;
                                else
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber + ",";
                            }

                            if (shipNumber == null)
                            {

                            }
                            else
                            {
                                orderResponse.TrackNumber = shipNumber;
                                orderResponse.LeaderOrderNumber = leader_order_number;
                                orderResponse.OrderNumber = order_number;
                            }
                        }
                    }

                    else
                    {
                        //ParcelForce用户名密码认证
                        //ParcelForce用户名密码认证
                        ShipServiceForApp.Authentication auth = new ShipServiceForApp.Authentication();
                        auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                        auth.Password = "kvhkwr22";//"129v2iz5";
                        //订单请求
                        ShipServiceForApp.RequestedShipment requestShipment = new ShipServiceForApp.RequestedShipment();
                        //收件联络人
                        ShipServiceForApp.Contact contact = new ShipServiceForApp.Contact();
                        //收件人公司名称
                        string recipientCompanyName = PinYinHelpers.ToPinYin(orderRequest.RecipientCompanyName);
                        string recipientContactName = PinYinHelpers.ToPinYin(orderRequest.RecipientContactName);
                        //收件人公司名称
                        contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//comm.RecipientCompanyName;
                        //收件联络人姓名
                        contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// comm.RecipientContactName;
                        //收件联络人电话
                        contact.Telephone = orderRequest.RecipientPhone;
                        //contact.EmailAddress = "1005780548@qq.com";

                        requestShipment.RecipientContact = contact;
                        //DepartmentId

                        //Set to COLLECTION    DELIVERY   TRAILER
                        requestShipment.ShipmentType = "DELIVERY";
                        if (orderRequest.ServiceCode.ToLower().Contains("depot"))
                        {
                            requestShipment.DepartmentId = "4";
                            requestShipment.ContractNumber = "P831263";
                        }
                        if (orderRequest.ServiceCode.ToLower().Contains("trailer"))
                        {
                            requestShipment.DepartmentId = "5";
                            requestShipment.ContractNumber = "P831271";
                        }
                        if (orderRequest.ServiceCode.ToLower().Contains("pol"))
                        {
                            requestShipment.DepartmentId = "6";
                            requestShipment.ContractNumber = "P888907";
                        }
                        requestShipment.ServiceCode = "IPE";
                        requestShipment.ShippingDateSpecified = true;
                        //寄件日期设置

                        requestShipment.ShippingDate = DateTime.Parse(orderRequest.Shippingdate);
                        //收件人地址
                        ShipServiceForApp.Address recipientAddress = new ShipServiceForApp.Address();
                        string address = PinYinHelpers.ToPinYin(orderRequest.RecipientAddress);
                        recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// comm.RecipientAddressLine;
                        if (address.Length > 24)
                            recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                        if (address.Length > 43)
                            recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));
                        string recipientTown = PinYinHelpers.ToPinYin(orderRequest.RecipientCity);
                        recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //comm.RecipientTown;

                        recipientAddress.Postcode = orderRequest.RecipeintPostCode.Substring(0, ((orderRequest.RecipeintPostCode.Length > 16) ? 16 : orderRequest.RecipeintPostCode.Length));
                        recipientAddress.Country = "CN";
                        requestShipment.RecipientAddress = recipientAddress;
                        requestShipment.TotalNumberOfParcels = orderRequest.Weight.Length.ToString();

                        ShipServiceForApp.Enhancement enhancement = new ShipServiceForApp.Enhancement();

                        //增加的保险额度
                        //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                        enhancement.EnhancedCompensation = "0";
                        //周末是否取件
                        enhancement.SaturdayDeliveryRequired = false;
                        requestShipment.Enhancement = enhancement;

                        ShipServiceForApp.InternationalInfo internationalInfo = new ShipServiceForApp.InternationalInfo();
                        internationalInfo.DocumentsOnly = false;
                        requestShipment.InternationalInfo = internationalInfo;


                        ShipServiceForApp.Parcel[] parcelInfo = new ShipServiceForApp.Parcel[orderRequest.Weight.Length];
                        for (int ij = 0; ij < orderRequest.Weight.Length; ij++)
                        {
                            ShipServiceForApp.Parcel parcel = new ShipServiceForApp.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)orderRequest.Weight[ij];
                            parcel.Width = orderRequest.Width[ij].ToString().Substring(0, ((orderRequest.Width[ij].ToString().Length > 8) ? 8 : orderRequest.Width[ij].ToString().Length));
                            parcel.Height = orderRequest.Height[ij].ToString().Substring(0, ((orderRequest.Height[ij].ToString().Length > 8) ? 8 : orderRequest.Height[ij].ToString().Length));
                            parcel.Length = orderRequest.Length[ij].ToString().Substring(0, ((orderRequest.Length[ij].ToString().Length > 8) ? 8 : orderRequest.Length[ij].ToString().Length)); ;
                            parcel.PurposeOfShipment = orderRequest.PurposeOfShipment[ij];



                            ShipServiceForApp.ContentDetail[] contentDetails = new ShipServiceForApp.ContentDetail[1];
                            ShipServiceForApp.ContentDetail contentDetail = new ShipServiceForApp.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinYinHelpers.ToPinYin(orderRequest.Description[ij]);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)orderRequest.Weight[ij];
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)orderRequest.Value[ij];
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[ij] = parcel;
                        }
                        requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                        requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                        requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                        requestShipment.InternationalInfo.Parcels = parcelInfo;
                        ShipServiceForApp.ShipPortTypeClient client = new ShipServiceForApp.ShipPortTypeClient();

                        ShipServiceForApp.CreateShipmentRequest shipRequest = new ShipServiceForApp.CreateShipmentRequest();
                        shipRequest.Authentication = auth;
                        shipRequest.RequestedShipment = requestShipment;
                        ShipServiceForApp.CreateShipmentReply shipReply = client.createShipment(shipRequest);
                        if (shipReply.Alerts != null)
                        {

                        }
                        else
                        {
                            string shipNumber = null;
                            for (int ij = 0; ij < shipReply.CompletedShipmentInfo.CompletedShipments.Length; ij++)
                            {
                                if (ij == shipReply.CompletedShipmentInfo.CompletedShipments.Length - 1)
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber;
                                else
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber + ",";
                            }
                            if (shipNumber == null)
                            {

                            }

                            else
                            {

                                orderResponse.TrackNumber = shipNumber;
                                orderResponse.LeaderOrderNumber = leader_order_number;
                                orderResponse.OrderNumber = order_number;
                            }
                        }
                    }
                }
                else if (orderRequest.ServiceCode.ToUpper().Contains("PF-GPR"))
                {
                    if (orderRequest.ServiceCode.ToUpper().Contains("COLLECTION"))
                    {
                        //ParcelForce用户名密码认证
                        //ParcelForce用户名密码认证
                        ShipServiceForApp.Authentication auth = new ShipServiceForApp.Authentication();
                        auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                        auth.Password = "kvhkwr22";//"129v2iz5";
                        //订单请求
                        ShipServiceForApp.RequestedShipment requestShipment = new ShipServiceForApp.RequestedShipment();
                        //收件联络人
                        ShipServiceForApp.Contact contact = new ShipServiceForApp.Contact();
                        //收件人公司名称
                        string recipientCompanyName = PinYinHelpers.ToPinYin(orderRequest.RecipientCompanyName);
                        string recipientContactName = PinYinHelpers.ToPinYin(orderRequest.RecipientContactName);
                        //收件人公司名称
                        contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//comm.RecipientCompanyName;
                        //收件联络人姓名
                        contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// comm.RecipientContactName;
                        //收件联络人电话
                        contact.Telephone = orderRequest.RecipientPhone;
                        //contact.EmailAddress = "1005780548@qq.com";

                        requestShipment.RecipientContact = contact;
                        //DepartmentId
                        requestShipment.DepartmentId = "1";
                        //Set to COLLECTION    DELIVERY   TRAILER
                        requestShipment.ShipmentType = "COLLECTION";
                        requestShipment.ContractNumber = "P831239";
                        requestShipment.ServiceCode = "GPR";
                        requestShipment.ShippingDateSpecified = true;
                        //寄件日期设置

                        requestShipment.ShippingDate = DateTime.Parse(orderRequest.Shippingdate);
                        //收件人地址
                        ShipServiceForApp.Address recipientAddress = new ShipServiceForApp.Address();
                        string address = PinYinHelpers.ToPinYin(orderRequest.RecipientAddress);
                        recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// comm.RecipientAddressLine;
                        if (address.Length > 24)
                            recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                        if (address.Length > 43)
                            recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));


                        string recipientTown = PinYinHelpers.ToPinYin(orderRequest.RecipientCity);
                        recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //listdao.RecipientTown;
                        recipientAddress.Postcode = orderRequest.RecipeintPostCode.Substring(0, ((orderRequest.RecipeintPostCode.Length > 16) ? 16 : orderRequest.RecipeintPostCode.Length));
                        //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                        recipientAddress.Country = "CN";
                        requestShipment.RecipientAddress = recipientAddress;

                        //寄件信息
                        ShipServiceForApp.CollectionInfo importerCollectionInfo = new ShipServiceForApp.CollectionInfo();
                        //寄件联络人信息
                        ShipServiceForApp.Contact importerContact = new ShipServiceForApp.Contact();
                        importerContact.BusinessName = orderRequest.SenderCompanyname.Substring(0, ((orderRequest.SenderCompanyname.Length > 24) ? 24 : orderRequest.SenderCompanyname.Length));
                        importerContact.ContactName = orderRequest.SenderContactName.Substring(0, ((orderRequest.SenderContactName.Length > 24) ? 24 : orderRequest.SenderContactName.Length));
                        importerContact.Telephone = orderRequest.SenderPhone.Substring(0, ((orderRequest.SenderPhone.Length > 15) ? 15 : orderRequest.SenderPhone.Length));
                        //importerContact.EmailAddress = "1005780548@qq.com";
                        requestShipment.ImporterContact = importerContact;
                        //寄件联络人地址信息
                        ShipServiceForApp.Address importerAddress = new ShipServiceForApp.Address();
                        string collectionAddress = orderRequest.SenderAddress;
                        importerAddress.AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //comm.CollectionAddressLine;
                        if (collectionAddress.Length >= 19)
                            importerAddress.AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 43) ? 19 : (collectionAddress.Length - 24)));
                        if (collectionAddress.Length >= 43)
                            importerAddress.AddressLine3 = collectionAddress.Substring(43, ((collectionAddress.Length > 67) ? 24 : (collectionAddress.Length - 43)));
                        importerAddress.Postcode = orderRequest.SenderPostCode.Substring(0, ((orderRequest.SenderPostCode.Length > 16) ? 16 : orderRequest.SenderPostCode.Length));
                        importerAddress.Town = orderRequest.SenderCity.Substring(0, ((orderRequest.SenderCity.Length > 24) ? 24 : orderRequest.SenderCity.Length));

                        //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                        importerAddress.Country = "GB";
                        requestShipment.ImporterAddress = importerAddress;

                        ////取件时间，From为起始取件时间，To为结束取件时间
                        ShipServiceForApp.DateTimeRange collectionTime = new ShipServiceForApp.DateTimeRange();


                        collectionTime.From = DateTime.Parse(orderRequest.Shippingdate + "T00:00:00");
                        collectionTime.To = DateTime.Parse(orderRequest.Shippingdate + "T00:00:00");
                        //寄件包裹的地址联络人以及取件时间的设置
                        importerCollectionInfo.CollectionAddress = importerAddress;
                        importerCollectionInfo.CollectionContact = importerContact;
                        importerCollectionInfo.CollectionTime = collectionTime;


                        //
                        requestShipment.CollectionInfo = importerCollectionInfo;
                        //设置包裹的总数量
                        //数据库中暂无此字段，这是个问题，期待解决
                        requestShipment.TotalNumberOfParcels = orderRequest.Weight.Length.ToString();

                        ShipServiceForApp.Enhancement enhancement = new ShipServiceForApp.Enhancement();

                        //增加的保险额度
                        //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                        enhancement.EnhancedCompensation = "0";
                        //周末是否取件
                        enhancement.SaturdayDeliveryRequired = false;
                        requestShipment.Enhancement = enhancement;

                        ShipServiceForApp.InternationalInfo internationalInfo = new ShipServiceForApp.InternationalInfo();
                        internationalInfo.DocumentsOnly = false;

                        requestShipment.InternationalInfo = internationalInfo;



                        ShipServiceForApp.Parcel[] parcelInfo = new ShipServiceForApp.Parcel[orderRequest.Weight.Length];
                        for (int ij = 0; ij < orderRequest.Weight.Length; ij++)
                        {
                            ShipServiceForApp.Parcel parcel = new ShipServiceForApp.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)orderRequest.Weight[ij];
                            parcel.Width = orderRequest.Width[ij].ToString().Substring(0, ((orderRequest.Width[ij].ToString().Length > 8) ? 8 : orderRequest.Width[ij].ToString().Length));
                            parcel.Height = orderRequest.Height[ij].ToString().Substring(0, ((orderRequest.Height[ij].ToString().Length > 8) ? 8 : orderRequest.Height[ij].ToString().Length));
                            parcel.Length = orderRequest.Length[ij].ToString().Substring(0, ((orderRequest.Length[ij].ToString().Length > 8) ? 8 : orderRequest.Length[ij].ToString().Length)); ;
                            parcel.PurposeOfShipment = orderRequest.PurposeOfShipment[ij];



                            ShipServiceForApp.ContentDetail[] contentDetails = new ShipServiceForApp.ContentDetail[1];
                            ShipServiceForApp.ContentDetail contentDetail = new ShipServiceForApp.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinYinHelpers.ToPinYin(orderRequest.Description[ij]);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)orderRequest.Weight[ij];
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)orderRequest.Value[ij];
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[ij] = parcel;
                        }
                        requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                        requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                        requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                        requestShipment.InternationalInfo.Parcels = parcelInfo;

                        ShipServiceForApp.ShipPortTypeClient client = new ShipServiceForApp.ShipPortTypeClient();

                        ShipServiceForApp.CreateShipmentRequest shipRequest = new ShipServiceForApp.CreateShipmentRequest();
                        shipRequest.Authentication = auth;
                        shipRequest.RequestedShipment = requestShipment;
                        ShipServiceForApp.CreateShipmentReply shipReply = client.createShipment(shipRequest);

                        if (shipReply.Alerts != null)
                        {

                        }
                        else
                        {
                            string shipNumber = null;
                            for (int ij = 0; ij < shipReply.CompletedShipmentInfo.CompletedShipments.Length; ij++)
                            {
                                if (ij == shipReply.CompletedShipmentInfo.CompletedShipments.Length - 1)
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber;
                                else
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber + ",";
                            }

                            if (shipNumber == null)
                            {

                            }
                            else
                            {
                                orderResponse.TrackNumber = shipNumber;
                                orderResponse.LeaderOrderNumber = leader_order_number;
                                orderResponse.OrderNumber = order_number;
                            }
                        }
                    }

                    else
                    {
                        //ParcelForce用户名密码认证
                        //ParcelForce用户名密码认证
                        ShipServiceForApp.Authentication auth = new ShipServiceForApp.Authentication();
                        auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                        auth.Password = "kvhkwr22";//"129v2iz5";
                        //订单请求
                        ShipServiceForApp.RequestedShipment requestShipment = new ShipServiceForApp.RequestedShipment();
                        //收件联络人
                        ShipServiceForApp.Contact contact = new ShipServiceForApp.Contact();
                        //收件人公司名称
                        string recipientCompanyName = PinYinHelpers.ToPinYin(orderRequest.RecipientCompanyName);
                        string recipientContactName = PinYinHelpers.ToPinYin(orderRequest.RecipientContactName);
                        //收件人公司名称
                        contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//comm.RecipientCompanyName;
                        //收件联络人姓名
                        contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// comm.RecipientContactName;
                        //收件联络人电话
                        contact.Telephone = orderRequest.RecipientPhone;
                        //contact.EmailAddress = "1005780548@qq.com";
                        requestShipment.RecipientContact = contact;
                        //DepartmentId

                        //Set to COLLECTION    DELIVERY   TRAILER
                        requestShipment.ShipmentType = "DELIVERY";
                        requestShipment.DepartmentId = "1";
                        requestShipment.ContractNumber = "P831239";
                        requestShipment.ServiceCode = "GPR";
                        requestShipment.ShippingDateSpecified = true;
                        //寄件日期设置
                        requestShipment.ShippingDate = DateTime.Parse(orderRequest.Shippingdate);
                        //收件人地址
                        ShipServiceForApp.Address recipientAddress = new ShipServiceForApp.Address();
                        string address = PinYinHelpers.ToPinYin(orderRequest.RecipientAddress);
                        recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// comm.RecipientAddressLine;
                        if (address.Length > 24)
                            recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                        if (address.Length > 43)
                            recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));
                        string recipientTown = PinYinHelpers.ToPinYin(orderRequest.RecipientCity);
                        recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //comm.RecipientTown;
                        //comm.RecipientTown;
                        recipientAddress.Postcode = orderRequest.RecipeintPostCode.Substring(0, ((orderRequest.RecipeintPostCode.Length > 16) ? 16 : orderRequest.RecipeintPostCode.Length));

                        //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                        recipientAddress.Country = "CN";
                        requestShipment.RecipientAddress = recipientAddress;
                        requestShipment.TotalNumberOfParcels = orderRequest.Weight.Length.ToString();

                        ShipServiceForApp.Enhancement enhancement = new ShipServiceForApp.Enhancement();

                        //增加的保险额度
                        //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                        enhancement.EnhancedCompensation = "0";
                        //周末是否取件
                        enhancement.SaturdayDeliveryRequired = false;
                        requestShipment.Enhancement = enhancement;

                        ShipServiceForApp.InternationalInfo internationalInfo = new ShipServiceForApp.InternationalInfo();
                        internationalInfo.DocumentsOnly = false;
                        requestShipment.InternationalInfo = internationalInfo;


                        ShipServiceForApp.Parcel[] parcelInfo = new ShipServiceForApp.Parcel[orderRequest.Weight.Length];
                        for (int ij = 0; ij < orderRequest.Weight.Length; ij++)
                        {
                            ShipServiceForApp.Parcel parcel = new ShipServiceForApp.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)orderRequest.Weight[ij];
                            parcel.Width = orderRequest.Width[ij].ToString().Substring(0, ((orderRequest.Width[ij].ToString().Length > 8) ? 8 : orderRequest.Width[ij].ToString().Length));
                            parcel.Height = orderRequest.Height[ij].ToString().Substring(0, ((orderRequest.Height[ij].ToString().Length > 8) ? 8 : orderRequest.Height[ij].ToString().Length));
                            parcel.Length = orderRequest.Length[ij].ToString().Substring(0, ((orderRequest.Length[ij].ToString().Length > 8) ? 8 : orderRequest.Length[ij].ToString().Length)); ;
                            parcel.PurposeOfShipment = orderRequest.PurposeOfShipment[ij];



                            ShipServiceForApp.ContentDetail[] contentDetails = new ShipServiceForApp.ContentDetail[1];
                            ShipServiceForApp.ContentDetail contentDetail = new ShipServiceForApp.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinYinHelpers.ToPinYin(orderRequest.Description[ij]);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)orderRequest.Weight[ij];
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)orderRequest.Value[ij];
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[ij] = parcel;
                        }
                        requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                        requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                        requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                        requestShipment.InternationalInfo.Parcels = parcelInfo;
                        ShipServiceForApp.ShipPortTypeClient client = new ShipServiceForApp.ShipPortTypeClient();

                        ShipServiceForApp.CreateShipmentRequest shipRequest = new ShipServiceForApp.CreateShipmentRequest();
                        shipRequest.Authentication = auth;
                        shipRequest.RequestedShipment = requestShipment;
                        ShipServiceForApp.CreateShipmentReply shipReply = client.createShipment(shipRequest);
                        if (shipReply.Alerts != null)
                        {

                        }
                        else
                        {
                            string shipNumber = null;
                            for (int ij = 0; ij < shipReply.CompletedShipmentInfo.CompletedShipments.Length; ij++)
                            {
                                if (ij == shipReply.CompletedShipmentInfo.CompletedShipments.Length - 1)
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber;
                                else
                                    shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber + ",";
                            }
                            if (shipNumber == null)
                            {

                            }

                            else
                            {

                                orderResponse.TrackNumber = shipNumber;
                                orderResponse.LeaderOrderNumber = leader_order_number;
                                orderResponse.OrderNumber = order_number;
                            }
                        }
                    }

                }
                return orderResponse;
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());

                orderResponse.Errors = new string[errors.Count];
                for (int j = 0; j < errors.Count; j++)
                {
                    orderResponse.Errors[j] = errors[j].ToString();
                }

                return orderResponse;

            }
        }


    }
}
