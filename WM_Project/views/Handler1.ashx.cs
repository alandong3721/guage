using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using WM_Project.logical.common;
using WM_Project.control;
using System.IO;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using CollectionPlus;
using PostNL.control;
using System.Threading;

namespace WM_Project.views
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler, IRequiresSessionState
    {

        public string alertMsg = null;
        public int successOrder = 0;
        public string unsuccess = null;
        public ArrayList unsuccesses = new ArrayList();
        public static int LocalTrackNumber = 9999999;
        public string trackNumber = "";
        public void ProcessRequest(HttpContext context)
        {
            int shun = System.Int32.Parse(context.Request["shunxu"]);

            ArrayList order_number_array = (ArrayList)(context.Session["AllOrderMsg"]);

            string order_no = order_number_array[shun - 1].ToString();
            
            CommonMsg comm = new CommonMsg();


            if (order_no.Contains("WA")) 
           {
                
                AutoOrderList listdao = new AutoOrderListDAO().getAutoOrderList(order_no);
                
                comm.Ordernumber = listdao.Order_no;
                
                comm.CollectionContactName = listdao.CollectionContactName;
                comm.CollectionCompanyName = listdao.CollectionCompanyName;
                comm.CollectionCountry = listdao.CollectionCountry;
                comm.CollectionPhone = listdao.CollectionPhone;
                comm.CollectionPostCode = listdao.CollectionPostCode;
                comm.CollectionTown = listdao.CollectionTown;
                comm.CollectionAddress = listdao.CollectionAddressLine;

                comm.RecipientContactName = listdao.RecipientContactName;
                comm.RecipientCompanyName = listdao.RecipientCompanyName;
                comm.RecipientCountry = listdao.RecipientCountry;
                comm.RecipientPhone = listdao.RecipientPhone;
                comm.RecipientTown = listdao.RecipientTown;
                comm.RecipeintPostCode = listdao.RecipeintPostCode;
                comm.RecipientAddress = listdao.RecipientAddressLine;

                comm.Shiptype = listdao.Shippingtype;
                comm.Servicecode = listdao.ServiceCode;
                comm.ShippingDate = listdao.Shippingdate;


                float[] weight = { listdao.Weight };
                float[] length = { listdao.Length };
                float[] height = { listdao.Height };
                float[] width = { listdao.Width };
                float[] value = { listdao.PackageValue };
                string[] purposeOfShipment = { listdao.Shippingpurpose };
                string[] description = { listdao.PackageDescription };

                comm.Value = value;
                comm.Weight = weight;
                comm.Length = length;
                comm.Width = width;
                comm.Height = height;
                comm.PurposeOfShipment = purposeOfShipment;
                comm.Description = description;

                
            }
            else if (order_no.Contains("WM"))
            {
                Order order = new OrderDAO().getOrder(order_no);
                ArrayList package_array = new PackageDAO().getPackage(order_no);

                comm.Ordernumber = order.Order_number;

                comm.CollectionContactName = order.CollectionContactName;
                comm.CollectionCompanyName = order.CollectionCompanyName;
                comm.CollectionCountry = order.CollectionCountry;
                comm.CollectionPhone = order.CollectionPhone;
                comm.CollectionPostCode = order.CollectionPostCode;
                comm.CollectionTown = order.CollectionTown;
                comm.CollectionAddress = order.CollectionAddressLine;

                comm.RecipientContactName = order.RecipientContactName;
                comm.RecipientCompanyName = order.RecipientCompanyName;
                comm.RecipientCountry = order.RecipientCountry;
                comm.RecipientPhone = order.RecipientPhone;
                comm.RecipientTown = order.RecipientTown;
                comm.RecipeintPostCode = order.RecipientPostCode;
                comm.RecipientAddress = order.RecipientAddressLine;

                if (order.Post_way.Contains("China-IPE"))
                {
                    order.Post_way =order.Post_way.Replace("China-IPE","PF-IPE");
                }
                else if (order.Post_way.Contains("China-GPR"))
                {
                    order.Post_way = order.Post_way.Replace("China-GPR", "PF-GPR");
                }
                if (order.Delivery_way == "上门取件")
                {
                    order.Delivery_way = "Collection";
                }
                comm.Shiptype = order.Delivery_way;
                comm.Servicecode = order.Post_way;
                comm.ShippingDate = order.Delivery_date;
                
                float[] weight = new float[package_array.Count];
                float[] length = new float[package_array.Count];
                float[] width = new float[package_array.Count];
                float[] height = new float[package_array.Count];
                string[] purposeOfShipment = new string[package_array.Count];
                string[] description = new string[package_array.Count];
                float[] value= new float[package_array.Count];

                for (int k = 0; k < package_array.Count;k++ )
                {
                    Package package = (Package) package_array[k];
                    weight[k] = package.Weight;
                    length[k] = package.Length;
                    width[k] = package.Width;
                    height[k] = package.Height;
                    purposeOfShipment[k] = "Gift";
                    value[k]=package.Package_value;
                    description[k] = package.Description;
                }

                comm.Weight = weight;
                comm.Length = length;
                comm.Width = width;
                comm.Height = height;
                comm.PurposeOfShipment = purposeOfShipment;
                comm.Description = description;
                comm.Value=value;

            }

            
            
            Util.SetCertificatePolicy();



            if (comm.Servicecode.ToLower().Contains("postnl"))
            {
                try
                {
                    if (comm.Shiptype.Equals("UKMail"))
                    {

                        //UKMail ukmail = new UKMail();
                        //string senderAddress = comm.CollectionAddress;
                        //string senderAddress2 = null;
                        //string senderAddress3 = null;
                        //string senderAddress1 = senderAddress.Substring(0, (senderAddress.Length > 40) ? 40 : senderAddress.Length);
                        //if (senderAddress.Length > 40)
                        //    senderAddress2 = senderAddress.Substring(40, (senderAddress.Length > 80) ? 40 : senderAddress.Length);
                        //if (senderAddress.Length > 80)
                        //    senderAddress3 = senderAddress.Substring(80, (senderAddress.Length > 120) ? 40 : senderAddress.Length);

                        //float totalWeight = 0;
                        //for (int i = 0; i < comm.Weight.Length; i++)
                        //{
                        //    totalWeight += comm.Weight[i];
                        //}
                        //string ConsignmentNumber = ukmail.GetConsignmentNumber(comm.CollectionContactName, comm.CollectionCompanyName, senderAddress1, senderAddress2,
                        //      senderAddress3, comm.CollectionTown, comm.CollectionPostCode, comm.CollectionPhone, comm.ShippingDate, comm.Weight.Length, totalWeight);

                        //new OrderDAO().updateLocalTrack(ConsignmentNumber, comm.Ordernumber);

                        //UkmailLabel ukmailLabel = new UkmailLabel(comm.Ordernumber, ConsignmentNumber, comm.CollectionAddress, getTotalWeight(comm.Weight),comm.Weight.Length);
                    }
                    else if (comm.Shiptype.ToLower() == "collectionplus")
                    {
                        ArrayList package_array = new PackageDAO().getPackage(comm.Ordernumber);
                        for (int j = 0; j < package_array.Count; j++)
                        {
                            Package package = (Package)package_array[j];
                            LocalTrackNumber++;
                            CollectionPlusLabel collectionplus = new CollectionPlusLabel(comm.CollectionContactName, LocalTrackNumber.ToString(), "", DateTime.Parse(comm.ShippingDate).ToString("dd/MM/yyyy"));
                            trackNumber = "8M6W" + LocalTrackNumber + "A025";
                            collectionplus.makeCollectionPlusLabel(AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\local\\" + trackNumber + ".pdf");
                            package.Local_track_no = trackNumber;

                            new PackageDAO().updateLocalTrackNo(package);
                        }

                    }
                    string shipNumber = "";
                    for (int i = 0; i < comm.Weight.Length; i++)
                    {
                        int contentLength = 1;
                        string[] Content = { "Content" };
                        string[] CostCenter = { "CostCenter" };
                        string[] CustomerOrderNumber = { "number" };
                        string[] CountryOfOrigin = { "GB" };
                        string[] Description = comm.Description;
                        string[] HSTariffNr = { "10306759" };
                        string[] contentQuantity = { "1" };
                        string[] contentValue = { comm.Value[i].ToString() };


                        string[] contentWeight = { comm.Weight[i].ToString() };


                        CIF_SB cif = new CIF_SB();
                        //获取3S运单号
                        string barcode = cif.GenerateBarcode("Et@0!!", "23621feac2e556e9beffbd7a4f8885ba93aef578", "TKAM", "10423404", "TKAM", "0000000-9999999", "3S", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                        //获取CD运单号
                        string DownPartnerBarcode = cif.GenerateBarcode("Et@0!!", "23621feac2e556e9beffbd7a4f8885ba93aef578", "6836", "10423404", "6836", "0000-9999", "CD", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                        // listdao.S_track_no = barcode;

                        // string DownPartnerBarcode = cif.GenerateBarcode("Et@0!!", "23621feac2e556e9beffbd7a4f8885ba93aef578", "6836", "10423404", "6836", "0000-9999", "CD", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                        //listdao.Cd_track_no = DownPartnerBarcode;

                        LabelTest1.LabellingWebServiceClient client = new LabelTest1.LabellingWebServiceClient();
                        client.ClientCredentials.UserName.UserName = "Et@0!!";
                        client.ClientCredentials.UserName.Password = "23621feac2e556e9beffbd7a4f8885ba93aef578";
                        //CustomerCode和CustomerNumber的设置，正式版和测试版不同，CustomerCode为CD的CustomerCode

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
                        customer.ContactPerson = comm.CollectionContactName;

                        customer.CustomerCode = "6836";
                        customer.CustomerNumber = "10423404";
                        customer.Email = "";
                        customer.Name = comm.CollectionContactName;

                        LabelTest1.Customs custome = new LabelTest1.Customs();
                        custome.ShipmentType = "Gift";

                        LabelTest1.Message message = new LabelTest1.Message();
                        message.MessageID = "1";
                        message.MessageTimeStamp = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                        message.Printertype = "GraphicFile|PDF";

                        LabelTest1.Shipment shipment = new LabelTest1.Shipment();
                        LabelTest1.Address shipmentaddress = new LabelTest1.Address();
                        shipmentaddress.AddressType = "01";
                        shipmentaddress.City = comm.RecipientTown;
                        shipmentaddress.CompanyName = comm.RecipientContactName + "\r\n" + comm.RecipientCompanyName;
                        shipmentaddress.Countrycode = "CN";
                        shipmentaddress.HouseNr = comm.RecipientPhone;
                        shipmentaddress.Street = comm.RecipientAddress;
                        shipmentaddress.Zipcode = comm.RecipeintPostCode;
                        LabelTest1.Address[] shipmentaddresses = new LabelTest1.Address[1];
                        shipmentaddresses[0] = shipmentaddress;
                        shipment.Addresses = shipmentaddresses;
                        shipment.Barcode = barcode;
                        LabelTest1.Contact contact = new LabelTest1.Contact();
                        contact.ContactType = "01";
                        contact.Email = "";
                        contact.SMSNr = comm.RecipientPhone;
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
                        dimenshin.Height = (Math.Ceiling(comm.Height[0] * 100)).ToString();
                        dimenshin.Length = Math.Ceiling(comm.Length[0] * 100).ToString();
                        dimenshin.Volume = Math.Ceiling((comm.Height[0] * comm.Length[0] * comm.Width[0]) * 100).ToString();
                        dimenshin.Weight = Math.Ceiling(comm.Weight[0] * 1000).ToString();
                        dimenshin.Width = Math.Ceiling(comm.Width[0] * 100).ToString();
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
                        if (PartnerBarcode.Contains("EA"))
                        {
                            successOrder = 1;
                            if (i == comm.Weight.Length - 1)
                                shipNumber += PartnerBarcode;
                            else
                                shipNumber += PartnerBarcode + ",";
                            int m = request2.Labels.Length;
                            byte[][] byt = new byte[m][];
                            for (int ii = 0; ii < m; ii++)
                            {
                                byt[ii] = request2.Labels[ii].Content;
                                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + comm.Ordernumber + i.ToString() + "-" + ii.ToString() + ".pdf", byt[ii]);
                            }
                            string[] pdflist = new string[m];
                            for (int jj = 0; jj < m; jj++)
                            {
                                pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + comm.Ordernumber + i.ToString() + "-" + jj.ToString() + ".pdf";
                            }
                            mergePDFFiles(pdflist, AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + PartnerBarcode + ".pdf", false);
                        }
                    }
                    //string[] pdflists = new string[comm.Weight.Length];
                    //for (int jj = 0; jj < comm.Weight.Length; jj++)
                    //{
                    //    pdflists[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + comm.Ordernumber + jj.ToString() + ".pdf";
                    //}
                    //mergePDFFiles(pdflists, AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + comm.Ordernumber  + "2.pdf", false);
                    if (comm.Ordernumber.Contains("WM"))
                    {
                        // 界面下单
                        ArrayList array_package = new PackageDAO().getPackage(comm.Ordernumber);
                        string[] track_array = shipNumber.Split(',');

                        for (int i = 0; i < track_array.Length; i++)
                        {
                            Package temp_package = (Package)array_package[i];
                            new PackageDAO().updateTrackNo(temp_package.Wp_track_no, "", track_array[i], "");
                        }

                        new OrderDAO().updateTrackNo(comm.Ordernumber, shipNumber);


                    }
                    else if (comm.Ordernumber.Contains("WA"))
                    {
                        // Excel 下单 跟新 包裹的追踪号
                        new AutoOrderListDAO().updateAutoOrderListTrackNo(comm.Ordernumber, "", "", shipNumber);

                    }
                }
    
                catch (Exception ee)
                {
                    unsuccess = comm.Ordernumber;
                    alertMsg += "订单号" + order_number_array[shun - 1] + "的postnl出错了,请查看网络以及请求的数据，重新下此单\r\n";

                }

            }

            else if (comm.Servicecode.ToLower().Contains("ems"))
            {
                try
                {
                    string eanumbers = null;
                    if (comm.Shiptype.Equals("UKMail"))
                    {

                        //UKMail ukmail = new UKMail();
                        //string senderAddress = comm.CollectionAddress;
                        //string senderAddress2 = null;
                        //string senderAddress3 = null;
                        //string senderAddress1 = senderAddress.Substring(0, (senderAddress.Length > 40) ? 40 : senderAddress.Length);
                        //if (senderAddress.Length > 40)
                        //    senderAddress2 = senderAddress.Substring(40, (senderAddress.Length > 80) ? 40 : senderAddress.Length);
                        //if (senderAddress.Length > 80)
                        //    senderAddress3 = senderAddress.Substring(80, (senderAddress.Length > 120) ? 40 : senderAddress.Length);

                        //float totalWeight = 0;
                        //for (int i = 0; i < comm.Weight.Length; i++)
                        //{
                        //    totalWeight += comm.Weight[i];
                        //}
                        //string ConsignmentNumber = ukmail.GetConsignmentNumber(comm.CollectionContactName, comm.CollectionCompanyName, senderAddress1, senderAddress2,
                        //      senderAddress3, comm.CollectionTown, comm.CollectionPostCode, comm.CollectionPhone, comm.ShippingDate, comm.Weight.Length, totalWeight);

                        //new OrderDAO().updateLocalTrack(ConsignmentNumber, comm.Ordernumber);
                    }
                    else if (comm.Shiptype.ToLower() == "collectionplus")
                    {
                        ArrayList package_array = new PackageDAO().getPackage(comm.Ordernumber);
                        for (int j = 0; j < package_array.Count; j++)
                        {
                            Package package = (Package)package_array[j];
                            LocalTrackNumber++;
                            CollectionPlusLabel collectionplus = new CollectionPlusLabel(comm.CollectionContactName, LocalTrackNumber.ToString(), "", DateTime.Parse(comm.ShippingDate).ToString("dd/MM/yyyy"));
                            trackNumber = "8M6W" + LocalTrackNumber + "A025";
                            collectionplus.makeCollectionPlusLabel(AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\local\\" + trackNumber + ".pdf");
                            package.Local_track_no = trackNumber;

                            new PackageDAO().updateLocalTrackNo(package);
                        }

                    }
                    for (int jj = 0; jj < comm.Weight.Length; jj++)
                    {
                        SqlConnection conn = DBConn.getConn();
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("begin tran select top 1 EMSNumber from tb_EMS with (rowlock,updlock) where EMSStatus=0 ", conn);
                        // SqlCommand ssss = new SqlCommand("update tb_EMS set EMSStatus=1 where EMSNumber='" + listdao.Ea_track_no + "'");
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        string eanumber = null;
                        if (dataReader.Read())
                        {
                            eanumber = dataReader["EMSNumber"].ToString().Trim();
                        }
                        dataReader.Close();
                        cmd.CommandText = "update tb_EMS set EMSStatus=1 where EMSNumber='" + eanumber + "' commit tran";
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if (eanumber != null)
                        {
                            successOrder = 1;
                            if (jj != comm.Weight.Length - 1)
                                eanumbers += eanumber + ",";
                            else
                                eanumbers += eanumber;
                            PdfPrint EMSLabel = new PdfPrint(comm.Ordernumber, eanumber, comm.RecipientContactName, comm.RecipientPhone, comm.RecipientAddress, comm.RecipeintPostCode, comm.RecipientTown, comm.CollectionContactName, comm.CollectionPhone, comm.CollectionAddress, "", comm.Weight[jj], comm.Value[jj], "", comm.Description[jj], 1, jj);
                        }
                    }


                    if (comm.Ordernumber.Contains("WM"))
                    {
                        // 界面下单
                        ArrayList array_package = new PackageDAO().getPackage(comm.Ordernumber);
                        string[] track_array = eanumbers.Split(',');

                        for (int i = 0; i < track_array.Length; i++)
                        {
                            Package temp_package = (Package)array_package[i];
                            new PackageDAO().updateTrackNo(temp_package.Wp_track_no, "", track_array[i], "");
                        }
                        new OrderDAO().updateTrackNo(comm.Ordernumber, eanumbers);

                    }
                    else if (comm.Ordernumber.Contains("WA"))
                    {
                        // Excel 下单 跟新 包裹的追踪号
                        new AutoOrderListDAO().updateAutoOrderListTrackNo(comm.Ordernumber, "", "", eanumbers);

                    }


                    //string[] pdflists = new string[comm.Weight.Length];
                    //for (int jj = 0; jj < comm.Weight.Length; jj++)
                    //{
                    //    pdflists[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + comm.Ordernumber + jj.ToString() + "0.pdf";
                    //}
                    //mergePDFFiles(pdflists, AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + comm.Ordernumber + "2.pdf", false);

                }

                catch (Exception ee)
                {
                    unsuccess = order_number_array[shun - 1].ToString();
                    alertMsg += "订单号" + order_number_array[shun - 1] + "的EMS订单出错了,请查看网络以及请求的数据，重新下此单\r\n";
                }
            }




            else if (comm.Servicecode.ToUpper().Contains("PF-IPE"))
            {
                if (comm.Servicecode.ToLower().Contains("collection"))
                {
                    //ParcelForce用户名密码认证
                    //ParcelForce用户名密码认证
                    ShipService.Authentication auth = new ShipService.Authentication();
                    auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                    auth.Password = "kvhkwr22";//"129v2iz5";

                    

                    //订单请求
                    ShipService.RequestedShipment requestShipment = new ShipService.RequestedShipment();
                    requestShipment.DepartmentId = "3";
                    //Set to COLLECTION    DELIVERY   TRAILER
                    requestShipment.ShipmentType = "COLLECTION";
                    requestShipment.ContractNumber = "P831255";
                    requestShipment.ServiceCode = "IPE";
                    requestShipment.ShippingDateSpecified = true;




                    //收件联络人
                    ShipService.Contact contact = new ShipService.Contact();

                    string recipientCompanyName = PinYinHelpers.ToPinYin(comm.RecipientCompanyName);
                    string recipientContactName = PinYinHelpers.ToPinYin(comm.RecipientContactName);
                    //收件人公司名称
                    contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//listdao.RecipientCompanyName;
                    //收件联络人姓名
                    contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// listdao.RecipientContactName;
                    //收件联络人电话
                    contact.Telephone = comm.RecipientPhone;
                    //contact.EmailAddress = "1005780548@qq.com";

                    requestShipment.RecipientContact = contact;
                    //DepartmentId
                   
                    //寄件日期设置

                    requestShipment.ShippingDate = DateTime.Parse(comm.ShippingDate);


                    //收件人地址
                    ShipService.Address recipientAddress = new ShipService.Address();
                    string address = PinYinHelpers.ToPinYin(comm.RecipientAddress);
                    recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// listdao.RecipientAddressLine;
                    if (address.Length > 24)
                        recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                    if (address.Length > 43)
                        recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));


                    string recipientTown = PinYinHelpers.ToPinYin(comm.RecipientTown);
                    recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //listdao.RecipientTown;
                    recipientAddress.Postcode = comm.RecipeintPostCode.Substring(0, ((comm.RecipeintPostCode.Length > 16) ? 16 : comm.RecipeintPostCode.Length));
                    //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                    recipientAddress.Country = "CN";
                    requestShipment.RecipientAddress = recipientAddress;

                    //寄件信息
                    ShipService.CollectionInfo importerCollectionInfo = new ShipService.CollectionInfo();
                    //寄件联络人信息
                    ShipService.Contact importerContact = new ShipService.Contact();
                    importerContact.BusinessName = comm.CollectionCompanyName.Substring(0, ((comm.CollectionCompanyName.Length > 24) ? 24 : comm.CollectionCompanyName.Length));
                    importerContact.ContactName = comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length));
                    importerContact.Telephone = comm.CollectionPhone.Substring(0, ((comm.CollectionPhone.Length > 15) ? 15 : comm.CollectionPhone.Length));
                    //importerContact.EmailAddress = "1005780548@qq.com";
                    requestShipment.ImporterContact = importerContact;
                    //寄件联络人地址信息
                    ShipService.Address importerAddress = new ShipService.Address();
                    string collectionAddress = comm.CollectionAddress;
                    importerAddress.AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //comm.CollectionAddressLine;
                    if (collectionAddress.Length >= 19)
                        importerAddress.AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 43) ? 19 : (collectionAddress.Length - 24)));
                    if (collectionAddress.Length >= 43)
                        importerAddress.AddressLine3 = collectionAddress.Substring(43, ((collectionAddress.Length > 67) ? 24 : (collectionAddress.Length - 43)));
                    importerAddress.Postcode = comm.CollectionPostCode.Substring(0, ((comm.CollectionPostCode.Length > 16) ? 16 : comm.CollectionPostCode.Length));
                    importerAddress.Town = comm.CollectionTown.Substring(0, ((comm.CollectionTown.Length > 24) ? 24 : comm.CollectionTown.Length));

                    //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                    importerAddress.Country = "GB";
                    requestShipment.ImporterAddress = importerAddress;

                    ////取件时间，From为起始取件时间，To为结束取件时间
                    ShipService.DateTimeRange collectionTime = new ShipService.DateTimeRange();


                    collectionTime.From = DateTime.Parse(comm.ShippingDate + "T00:00:00");
                    collectionTime.To = DateTime.Parse(comm.ShippingDate + "T00:00:00");
                    //寄件包裹的地址联络人以及取件时间的设置
                    importerCollectionInfo.CollectionAddress = importerAddress;
                    importerCollectionInfo.CollectionContact = importerContact;
                    importerCollectionInfo.CollectionTime = collectionTime;


                    //
                    requestShipment.CollectionInfo = importerCollectionInfo;
                    //设置包裹的总数量
                    //数据库中暂无此字段，这是个问题，期待解决
                    requestShipment.TotalNumberOfParcels = comm.Weight.Length.ToString();

                    ShipService.Enhancement enhancement = new ShipService.Enhancement();

                    //增加的保险额度
                    //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                    enhancement.EnhancedCompensation = "0";
                    //周末是否取件
                    enhancement.SaturdayDeliveryRequired = false;
                    requestShipment.Enhancement = enhancement;

                    ShipService.InternationalInfo internationalInfo = new ShipService.InternationalInfo();
                    internationalInfo.DocumentsOnly = false;

                    requestShipment.InternationalInfo = internationalInfo;



                    ShipService.Parcel[] parcelInfo = new ShipService.Parcel[comm.Weight.Length];
                    for (int ij = 0; ij < comm.Weight.Length; ij++)
                    {
                        ShipService.Parcel parcel = new ShipService.Parcel();
                        parcel.WeightSpecified = true;
                        parcel.Weight = (decimal)comm.Weight[ij];
                        parcel.Width = comm.Width[ij].ToString().Substring(0, ((comm.Width[ij].ToString().Length > 8) ? 8 : comm.Width[ij].ToString().Length));
                        parcel.Height = comm.Height[ij].ToString().Substring(0, ((comm.Height[ij].ToString().Length > 8) ? 8 : comm.Height[ij].ToString().Length));
                        parcel.Length = comm.Length[ij].ToString().Substring(0, ((comm.Length[ij].ToString().Length > 8) ? 8 : comm.Length[ij].ToString().Length)); ;
                        parcel.PurposeOfShipment = comm.PurposeOfShipment[ij];



                        ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                        ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                        contentDetail.CountryOfManufacture = "GB";
                        string sss = PinYinHelpers.ToPinYin(comm.Description[ij]);
                        if (sss.Length > 30)
                        {
                            sss = sss.Substring(0, 30);
                        }
                        contentDetail.Description = sss;
                        contentDetail.UnitWeight = (decimal)comm.Weight[ij];
                        contentDetail.UnitQuantity = "1";
                        contentDetail.UnitValue = (decimal)comm.Value[ij];
                        contentDetail.Currency = "gbp";
                        contentDetails[0] = contentDetail;
                        parcel.ContentDetails = contentDetails;
                        parcelInfo[ij] = parcel;
                    }
                    requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                    requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                    requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                    requestShipment.InternationalInfo.Parcels = parcelInfo;

                    ShipService.ShipPortTypeClient client = new ShipService.ShipPortTypeClient();

                    ShipService.CreateShipmentRequest shipRequest = new ShipService.CreateShipmentRequest();
                    shipRequest.Authentication = auth;
                    shipRequest.RequestedShipment = requestShipment;
                    ShipService.CreateShipmentReply shipReply = client.createShipment(shipRequest);

                    if (shipReply.Alerts != null)
                    {
                        alertMsg += comm.Ordernumber + ":";
                        //string alertMsg = null;
                        for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                        {
                            alertMsg += shipReply.Alerts[ij].Message;
                        }
                        alertMsg += "\r\n";
                        //alert("订单号" + order_number_array[shun-1 ] + alertMsg);
                    }
                    else
                    {
                        string shipNumber=null;
                        for (int ij = 0; ij < shipReply.CompletedShipmentInfo.CompletedShipments.Length; ij++)
                        {
                            if (ij == shipReply.CompletedShipmentInfo.CompletedShipments.Length - 1)
                                shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber;
                            else
                                shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber + ",";
                        }
                       
                        if (shipNumber == null)
                        {
                            unsuccess = comm.Ordernumber.ToString();
                        }
                        else
                        {
                            successOrder = 1;

                            if (comm.Ordernumber.Contains("WM"))
                            {
                                // 界面下单
                                ArrayList array_package = new PackageDAO().getPackage(comm.Ordernumber);
                                string[] track_array = shipNumber.Split(',');

                                for(int i=0;i<track_array.Length;i++)
                                {
                                    Package temp_package = (Package)array_package[i];
                                    new PackageDAO().updateTrackNo(temp_package.Wp_track_no,"",track_array[i],"");
                                }

                                new OrderDAO().updateTrackNo(comm.Ordernumber,shipNumber);
                                

                            }
                            else if(comm.Ordernumber.Contains("WA"))
                            {
                                // Excel 下单 跟新 包裹的追踪号
                                new AutoOrderListDAO().updateAutoOrderListTrackNo(comm.Ordernumber, "", "", shipNumber);

                            }


                            //comm.Ea_track_no = shipNumber;

                           // new AutoOrdercomm().updateAutoOrderListTrackNo(comm.Order_no, comm.S_track_no, comm.Cd_track_no, comm.Ea_track_no);

                            PFLabel pflabel = new PFLabel(comm.Ordernumber, shipNumber, importerContact.ContactName, importerAddress.Town, "China", importerAddress.AddressLine1, importerAddress.Postcode, contact.ContactName, comm.Weight, importerAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, "IPECOLLECTION", comm.Description);
                            PFCN21 pfcn21 = new PFCN21(comm.Ordernumber, shipNumber, importerContact.BusinessName, importerContact.ContactName, importerAddress.Town, contact.BusinessName, "China", importerAddress.AddressLine1, importerAddress.AddressLine2, importerAddress.AddressLine3, importerAddress.Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);
                            PFCommercial pfcommercial = new PFCommercial(comm.Ordernumber, shipNumber, importerContact.ContactName, importerContact.Telephone, importerAddress.Town, "China", importerAddress.AddressLine1, importerAddress.AddressLine2, importerAddress.AddressLine3, importerAddress.Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);
                            string[] track = shipNumber.Split(',');
                            for (int trac = 0; trac < track.Length; trac++)
                            {
                                string[] pdflist = new string[3];
                                for (int jj = 0; jj < 3; jj++)
                                {
                                    if (jj == 2)
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + "3.pdf";
                                    else
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + jj.ToString() + ".pdf";
                                }

                                mergePDFFiles(pdflist, AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + ".pdf", true);
                            }
                        }
                    }
                }

                else
                {
                    //ParcelForce用户名密码认证
                    //ParcelForce用户名密码认证
                    ShipService.Authentication auth = new ShipService.Authentication();
                    auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                    auth.Password = "kvhkwr22";//"129v2iz5";
                    //订单请求
                    ShipService.RequestedShipment requestShipment = new ShipService.RequestedShipment();
                    //收件联络人
                    ShipService.Contact contact = new ShipService.Contact();
                    //收件人公司名称
                    string recipientCompanyName = PinYinHelpers.ToPinYin(comm.RecipientCompanyName);
                    string recipientContactName = PinYinHelpers.ToPinYin(comm.RecipientContactName);
                    //收件人公司名称
                    contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//comm.RecipientCompanyName;
                    //收件联络人姓名
                    contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// comm.RecipientContactName;
                    //收件联络人电话
                    contact.Telephone = comm.RecipientPhone;
                    //contact.EmailAddress = "1005780548@qq.com";

                    requestShipment.RecipientContact = contact;
                    //DepartmentId

                    //Set to COLLECTION    DELIVERY   TRAILER
                    requestShipment.ShipmentType = "DELIVERY";
                    if (comm.Servicecode.ToLower().Contains("depot"))
                    {
                        requestShipment.DepartmentId = "4";
                        requestShipment.ContractNumber = "P831263";
                    }
                    if (comm.Servicecode.ToLower().Contains("trailer"))
                    {
                        requestShipment.DepartmentId = "5";
                        requestShipment.ContractNumber = "P831271";
                    }
                    if (comm.Servicecode.ToLower().Contains("pol"))
                    {
                        requestShipment.DepartmentId = "6";
                        requestShipment.ContractNumber = "P888907";
                    }
                    requestShipment.ServiceCode = "IPE";
                    requestShipment.ShippingDateSpecified = true;
                    //寄件日期设置

                    requestShipment.ShippingDate = DateTime.Parse(comm.ShippingDate);
                    //收件人地址
                    ShipService.Address recipientAddress = new ShipService.Address();
                    string address = PinYinHelpers.ToPinYin(comm.RecipientAddress);
                    recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// comm.RecipientAddressLine;
                    if (address.Length > 24)
                        recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                    if (address.Length > 43)
                        recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));
                    string recipientTown = PinYinHelpers.ToPinYin(comm.RecipientTown);
                    recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //comm.RecipientTown;

                    recipientAddress.Postcode = comm.RecipeintPostCode.Substring(0, ((comm.RecipeintPostCode.Length > 16) ? 16 : comm.RecipeintPostCode.Length));
                    recipientAddress.Country = "CN";
                    requestShipment.RecipientAddress = recipientAddress;
                    requestShipment.TotalNumberOfParcels = comm.Weight.Length.ToString();

                    ShipService.Enhancement enhancement = new ShipService.Enhancement();

                    //增加的保险额度
                    //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                    enhancement.EnhancedCompensation = "0";
                    //周末是否取件
                    enhancement.SaturdayDeliveryRequired = false;
                    requestShipment.Enhancement = enhancement;

                    ShipService.InternationalInfo internationalInfo = new ShipService.InternationalInfo();
                    internationalInfo.DocumentsOnly = false;
                    requestShipment.InternationalInfo = internationalInfo;


                    ShipService.Parcel[] parcelInfo = new ShipService.Parcel[comm.Weight.Length];
                    for (int ij = 0; ij < comm.Weight.Length; ij++)
                    {
                        ShipService.Parcel parcel = new ShipService.Parcel();
                        parcel.WeightSpecified = true;
                        parcel.Weight = (decimal)comm.Weight[ij];
                        parcel.Width = comm.Width[ij].ToString().Substring(0, ((comm.Width[ij].ToString().Length > 8) ? 8 : comm.Width[ij].ToString().Length));
                        parcel.Height = comm.Height[ij].ToString().Substring(0, ((comm.Height[ij].ToString().Length > 8) ? 8 : comm.Height[ij].ToString().Length));
                        parcel.Length = comm.Length[ij].ToString().Substring(0, ((comm.Length[ij].ToString().Length > 8) ? 8 : comm.Length[ij].ToString().Length)); ;
                        parcel.PurposeOfShipment = comm.PurposeOfShipment[ij];



                        ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                        ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                        contentDetail.CountryOfManufacture = "GB";
                        string sss = PinYinHelpers.ToPinYin(comm.Description[ij]);
                        if (sss.Length > 30)
                        {
                            sss = sss.Substring(0, 30);
                        }
                        contentDetail.Description = sss;
                        contentDetail.UnitWeight = (decimal)comm.Weight[ij];
                        contentDetail.UnitQuantity = "1";
                        contentDetail.UnitValue = (decimal)comm.Value[ij];
                        contentDetail.Currency = "gbp";
                        contentDetails[0] = contentDetail;
                        parcel.ContentDetails = contentDetails;
                        parcelInfo[ij] = parcel;
                    }
                    requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                    requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                    requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                    requestShipment.InternationalInfo.Parcels = parcelInfo;
                    ShipService.ShipPortTypeClient client = new ShipService.ShipPortTypeClient();

                    ShipService.CreateShipmentRequest shipRequest = new ShipService.CreateShipmentRequest();
                    shipRequest.Authentication = auth;
                    shipRequest.RequestedShipment = requestShipment;
                    ShipService.CreateShipmentReply shipReply = client.createShipment(shipRequest);
                     if (shipReply.Alerts != null)
                    {
                        alertMsg += comm.Ordernumber + ":";
                        //string alertMsg = null;
                        for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                        {
                            alertMsg += shipReply.Alerts[ij].Message;
                        }
                        alertMsg += "\r\n";
                        //alert("订单号" + order_number_array[shun-1 ] + alertMsg);
                    }
                    else
                    {
                        string shipNumber=null;
                        for (int ij = 0; ij < shipReply.CompletedShipmentInfo.CompletedShipments.Length; ij++)
                        {
                            if (ij == shipReply.CompletedShipmentInfo.CompletedShipments.Length - 1)
                                shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber;
                            else
                                shipNumber += shipReply.CompletedShipmentInfo.CompletedShipments[ij].ShipmentNumber + ",";
                        }
                        if (shipNumber == null)
                        {
                            unsuccess = comm.Ordernumber.ToString();
                        }

                        else
                        {

                            successOrder = 1;


                            if (comm.Ordernumber.Contains("WM"))
                            {
                                // 界面下单
                                ArrayList array_package = new PackageDAO().getPackage(comm.Ordernumber);
                                string[] track_array = shipNumber.Split(',');

                                for (int i = 0; i < track_array.Length; i++)
                                {
                                    Package temp_package = (Package)array_package[i];
                                    new PackageDAO().updateTrackNo(temp_package.Wp_track_no, "", track_array[i], "");
                                }

                                new OrderDAO().updateTrackNo(comm.Ordernumber, shipNumber);


                            }
                            else if (comm.Ordernumber.Contains("WA"))
                            {
                                // Excel 下单 跟新 包裹的追踪号
                                new AutoOrderListDAO().updateAutoOrderListTrackNo(comm.Ordernumber, "", "", shipNumber);

                            }


                            string collectionAddress = comm.CollectionAddress;
                            string AddressLine2 = null;
                            string AddressLine3 = null;
                            string AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //comm.CollectionAddressLine;
                            if (collectionAddress.Length >= 24)
                                AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 43) ? 19 : (collectionAddress.Length - 24)));
                            if (collectionAddress.Length >= 43)
                                AddressLine3 = collectionAddress.Substring(43, ((collectionAddress.Length > 67) ? 24 : (collectionAddress.Length - 43)));
                            string Postcode = comm.CollectionPostCode.Substring(0, ((comm.CollectionPostCode.Length > 16) ? 16 : comm.CollectionPostCode.Length));
                            string Town = comm.CollectionTown.Substring(0, ((comm.CollectionTown.Length > 24) ? 24 : comm.CollectionTown.Length));
                            string BusinessName = comm.CollectionCompanyName.Substring(0, ((comm.CollectionCompanyName.Length > 24) ? 24 : comm.CollectionCompanyName.Length));
                            string ContactName = comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length));
                            string Telephone = comm.CollectionPhone.Substring(0, ((comm.CollectionPhone.Length > 15) ? 15 : comm.CollectionPhone.Length));


                            for(int sn=0;sn<shipNumber.Split(',').Length;sn++)
                            {
                                ThreadPool.QueueUserWorkItem(new WaitCallback(RequestLabel), (shipNumber.Split(','))[sn]);
                            }

                            PFLabel pflabel = new PFLabel(comm.Ordernumber, shipNumber, comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length)), Town, "China", AddressLine1, Postcode, contact.ContactName, comm.Weight,Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, "IPECOLLECTION", comm.Description);
                            PFCN21 pfcn21 = new PFCN21(comm.Ordernumber, shipNumber, BusinessName, comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length)), Town, contact.BusinessName, "China", AddressLine1, AddressLine2, AddressLine3, Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);
                            PFCommercial pfcommercial = new PFCommercial(comm.Ordernumber, shipNumber, ContactName, Telephone, Town, "China", AddressLine1, AddressLine2, AddressLine3, Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);
                            string[] track = shipNumber.Split(',');
                            for (int trac = 0; trac < track.Length; trac++)
                            {
                                string[] pdflist = new string[3];
                                for (int jj = 0; jj < 3; jj++)
                                {
                                    if (jj == 2)
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + "3.pdf";
                                    else
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + jj.ToString() + ".pdf";
                                }

                                mergePDFFiles(pdflist, AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + ".pdf", true);
                            }
                        }
                    }
                }
            }
            else if (comm.Servicecode.ToUpper().Contains("PF-GPR"))
            {
                if (comm.Servicecode.ToUpper().Contains( "COLLECTION"))
                {
                    //ParcelForce用户名密码认证
                    //ParcelForce用户名密码认证
                    ShipService.Authentication auth = new ShipService.Authentication();
                    auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                    auth.Password = "kvhkwr22";//"129v2iz5";
                    //订单请求
                    ShipService.RequestedShipment requestShipment = new ShipService.RequestedShipment();
                    //收件联络人
                    ShipService.Contact contact = new ShipService.Contact();
                    //收件人公司名称
                    string recipientCompanyName = PinYinHelpers.ToPinYin(comm.RecipientCompanyName);
                    string recipientContactName = PinYinHelpers.ToPinYin(comm.RecipientContactName);
                    //收件人公司名称
                    contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//comm.RecipientCompanyName;
                    //收件联络人姓名
                    contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// comm.RecipientContactName;
                    //收件联络人电话
                    contact.Telephone = comm.RecipientPhone;
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

                    requestShipment.ShippingDate = DateTime.Parse(comm.ShippingDate);
                    //收件人地址
                    ShipService.Address recipientAddress = new ShipService.Address();
                    string address = PinYinHelpers.ToPinYin(comm.RecipientAddress);
                    recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// comm.RecipientAddressLine;
                    if (address.Length > 24)
                        recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                    if (address.Length > 43)
                        recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));


                    string recipientTown = PinYinHelpers.ToPinYin(comm.RecipientTown);
                    recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //comm.RecipientTown;
                    //comm.RecipientTown;
                    recipientAddress.Postcode = comm.RecipeintPostCode.Substring(0, ((comm.RecipeintPostCode.Length > 16) ? 16 : comm.RecipeintPostCode.Length));

                    //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                    recipientAddress.Country = "CN";
                    requestShipment.RecipientAddress = recipientAddress;

                    //寄件信息
                    ShipService.CollectionInfo importerCollectionInfo = new ShipService.CollectionInfo();
                    //寄件联络人信息
                    ShipService.Contact importerContact = new ShipService.Contact();
                    importerContact.BusinessName = comm.CollectionCompanyName.Substring(0, ((comm.CollectionCompanyName.Length > 24) ? 24 : comm.CollectionCompanyName.Length));
                    importerContact.ContactName = comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length));

                    importerContact.Telephone = comm.CollectionPhone.Substring(0, ((comm.CollectionPhone.Length > 15) ? 15 : comm.CollectionPhone.Length));

                    //importerContact.EmailAddress = "1005780548@qq.com";
                    requestShipment.ImporterContact = importerContact;
                    //寄件联络人地址信息
                    ShipService.Address importerAddress = new ShipService.Address();
                    string collectionAddress = comm.CollectionAddress;
                    importerAddress.AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //comm.CollectionAddressLine;
                    if (collectionAddress.Length >= 19)
                        importerAddress.AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 43) ? 19 : (collectionAddress.Length - 24)));
                    if (collectionAddress.Length >= 43)
                        importerAddress.AddressLine3 = collectionAddress.Substring(43, ((collectionAddress.Length > 67) ? 24 : (collectionAddress.Length - 43)));
                    importerAddress.Postcode = comm.CollectionPostCode.Substring(0, ((comm.CollectionPostCode.Length > 16) ? 16 : comm.CollectionPostCode.Length));
                    importerAddress.Town = comm.CollectionTown.Substring(0, ((comm.CollectionTown.Length > 24) ? 24 : comm.CollectionTown.Length));


                    //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                    importerAddress.Country = "GB";
                    requestShipment.ImporterAddress = importerAddress;

                    ////取件时间，From为起始取件时间，To为结束取件时间
                    ShipService.DateTimeRange collectionTime = new ShipService.DateTimeRange();


                    collectionTime.From = DateTime.Parse(comm.ShippingDate + "T00:00:00");
                    collectionTime.To = DateTime.Parse(comm.ShippingDate + "T00:00:00");

                    //寄件包裹的地址联络人以及取件时间的设置
                    importerCollectionInfo.CollectionAddress = importerAddress;
                    importerCollectionInfo.CollectionContact = importerContact;
                    importerCollectionInfo.CollectionTime = collectionTime;


                    //
                    requestShipment.CollectionInfo = importerCollectionInfo;
                    //设置包裹的总数量
                    //数据库中暂无此字段，这是个问题，期待解决
                    requestShipment.TotalNumberOfParcels = comm.Weight.Length.ToString();

                    ShipService.Enhancement enhancement = new ShipService.Enhancement();

                    //增加的保险额度
                    //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                    enhancement.EnhancedCompensation = "0";
                    //周末是否取件
                    enhancement.SaturdayDeliveryRequired = false;
                    requestShipment.Enhancement = enhancement;

                    ShipService.InternationalInfo internationalInfo = new ShipService.InternationalInfo();
                    internationalInfo.DocumentsOnly = false;
                    requestShipment.InternationalInfo = internationalInfo;

                    ShipService.Parcel[] parcelInfo = new ShipService.Parcel[comm.Weight.Length];
                    for (int ij = 0; ij < comm.Weight.Length; ij++)
                    {
                        ShipService.Parcel parcel = new ShipService.Parcel();
                        parcel.WeightSpecified = true;
                        parcel.Weight = (decimal)comm.Weight[ij];
                        parcel.Width = comm.Width[ij].ToString().Substring(0, ((comm.Width[ij].ToString().Length > 8) ? 8 : comm.Width[ij].ToString().Length));
                        parcel.Height = comm.Height[ij].ToString().Substring(0, ((comm.Height[ij].ToString().Length > 8) ? 8 : comm.Height[ij].ToString().Length));
                        parcel.Length = comm.Length[ij].ToString().Substring(0, ((comm.Length[ij].ToString().Length > 8) ? 8 : comm.Length[ij].ToString().Length)); ;
                        parcel.PurposeOfShipment = comm.PurposeOfShipment[ij];



                        ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                        ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                        contentDetail.CountryOfManufacture = "GB";
                        string sss = PinYinHelpers.ToPinYin(comm.Description[ij]);
                        if (sss.Length > 30)
                        {
                            sss = sss.Substring(0, 30);
                        }
                        contentDetail.Description = sss;
                        contentDetail.UnitWeight = (decimal)comm.Weight[ij];
                        contentDetail.UnitQuantity = "1";
                        contentDetail.UnitValue = (decimal)comm.Value[ij];
                        contentDetail.Currency = "gbp";
                        contentDetails[0] = contentDetail;
                        parcel.ContentDetails = contentDetails;
                        parcelInfo[ij] = parcel;
                    }
                    requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                    requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                    requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                    requestShipment.InternationalInfo.Parcels = parcelInfo;

                    ShipService.ShipPortTypeClient client = new ShipService.ShipPortTypeClient();

                    ShipService.CreateShipmentRequest shipRequest = new ShipService.CreateShipmentRequest();
                    shipRequest.Authentication = auth;
                    shipRequest.RequestedShipment = requestShipment;
                    ShipService.CreateShipmentReply shipReply = client.createShipment(shipRequest);

                    if (shipReply.Alerts != null)
                    {
                        alertMsg += comm.Ordernumber + ":";
                        //string alertMsg = null;
                        for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                        {
                            alertMsg += shipReply.Alerts[ij].Message;
                        }
                        alertMsg += "\r\n";
                        //alert("订单号" + order_number_array[shun-1 ] + alertMsg);
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
                            unsuccess = comm.Ordernumber.ToString();
                        }
                        else
                        {
                            if (comm.Ordernumber.Contains("WM"))
                            {
                                // 界面下单
                                ArrayList array_package = new PackageDAO().getPackage(comm.Ordernumber);
                                string[] track_array = shipNumber.Split(',');

                                for (int i = 0; i < track_array.Length; i++)
                                {
                                    Package temp_package = (Package)array_package[i];
                                    new PackageDAO().updateTrackNo(temp_package.Wp_track_no, "", track_array[i], "");
                                }

                                new OrderDAO().updateTrackNo(comm.Ordernumber, shipNumber);


                            }
                            else if (comm.Ordernumber.Contains("WA"))
                            {
                                // Excel 下单 跟新 包裹的追踪号
                                new AutoOrderListDAO().updateAutoOrderListTrackNo(comm.Ordernumber, "", "", shipNumber);

                            }

                            successOrder = 1;
                            //comm.Ea_track_no = shipNumber;

                            // new AutoOrdercomm().updateAutoOrderListTrackNo(comm.Order_no, comm.S_track_no, comm.Cd_track_no, comm.Ea_track_no);

                            PFLabel pflabel = new PFLabel(comm.Ordernumber, shipNumber, importerContact.ContactName, recipientAddress.Town, "China", importerAddress.AddressLine1, importerAddress.Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, "GPRCOLLECTION", comm.Description);
                            PFCN21 pfcn21 = new PFCN21(comm.Ordernumber, shipNumber, importerContact.BusinessName, importerContact.ContactName, importerAddress.Town, contact.BusinessName, "China", importerAddress.AddressLine1, importerAddress.AddressLine2, importerAddress.AddressLine3, importerAddress.Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);
                            PFCommercial pfcommercial = new PFCommercial(comm.Ordernumber, shipNumber, importerContact.ContactName, importerContact.Telephone, importerAddress.Town, "China", importerAddress.AddressLine1, importerAddress.AddressLine2, importerAddress.AddressLine3, importerAddress.Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);
                            string[] track = shipNumber.Split(',');
                            for (int trac = 0; trac < track.Length; trac++)
                            {
                                string[] pdflist = new string[3];
                                for (int jj = 0; jj < 3; jj++)
                                {
                                    if (jj == 2)
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + "3.pdf";
                                    else
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + jj.ToString() + ".pdf";
                                }

                                mergePDFFiles(pdflist, AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + ".pdf", true);
                            }
                        }
                    }
                }

                else
                {
                    //ParcelForce用户名密码认证
                    //ParcelForce用户名密码认证
                    ShipService.Authentication auth = new ShipService.Authentication();
                    auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                    auth.Password = "kvhkwr22";//"129v2iz5";
                    //订单请求
                    ShipService.RequestedShipment requestShipment = new ShipService.RequestedShipment();
                    //收件联络人
                    ShipService.Contact contact = new ShipService.Contact();
                    //收件人公司名称
                    string recipientCompanyName = PinYinHelpers.ToPinYin(comm.RecipientCompanyName);
                    string recipientContactName = PinYinHelpers.ToPinYin(comm.RecipientContactName);
                    //收件人公司名称
                    contact.BusinessName = recipientCompanyName.Substring(0, ((recipientCompanyName.Length > 24) ? 24 : recipientCompanyName.Length));//comm.RecipientCompanyName;
                    //收件联络人姓名
                    contact.ContactName = recipientContactName.Substring(0, ((recipientContactName.Length > 24) ? 24 : recipientContactName.Length));// comm.RecipientContactName;
                    //收件联络人电话
                    contact.Telephone = comm.RecipientPhone;
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
                    requestShipment.ShippingDate = DateTime.Parse(comm.ShippingDate);
                    //收件人地址
                    ShipService.Address recipientAddress = new ShipService.Address();
                    string address = PinYinHelpers.ToPinYin(comm.RecipientAddress);
                    recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// comm.RecipientAddressLine;
                    if (address.Length > 24)
                        recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 43) ? 19 : (address.Length - 24)));
                    if (address.Length > 43)
                        recipientAddress.AddressLine3 = address.Substring(43, ((address.Length > 67) ? 24 : (address.Length - 43)));
                    string recipientTown = PinYinHelpers.ToPinYin(comm.RecipientTown);
                    recipientAddress.Town = recipientTown.Substring(0, ((recipientTown.Length > 24) ? 24 : recipientTown.Length)); //comm.RecipientTown;
                    //comm.RecipientTown;
                    recipientAddress.Postcode = comm.RecipeintPostCode.Substring(0, ((comm.RecipeintPostCode.Length > 16) ? 16 : comm.RecipeintPostCode.Length));

                    //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                    recipientAddress.Country = "CN";
                    requestShipment.RecipientAddress = recipientAddress;
                    //设置包裹的总数量
                    //数据库中暂无此字段，这是个问题，期待解决
                    requestShipment.TotalNumberOfParcels = comm.Weight.Length.ToString();

                    ShipService.Enhancement enhancement = new ShipService.Enhancement();

                    //增加的保险额度
                    //我没有用到数据库此字段，因为不知道是哪个字段，期待修改解决
                    enhancement.EnhancedCompensation = "0";
                    //周末是否取件
                    enhancement.SaturdayDeliveryRequired = false;
                    requestShipment.Enhancement = enhancement;

                    ShipService.InternationalInfo internationalInfo = new ShipService.InternationalInfo();
                    internationalInfo.DocumentsOnly = false;
                    requestShipment.InternationalInfo = internationalInfo;


                    ShipService.Parcel[] parcelInfo = new ShipService.Parcel[comm.Weight.Length];
                    for (int ij = 0; ij < comm.Weight.Length; ij++)
                    {
                        ShipService.Parcel parcel = new ShipService.Parcel();
                        parcel.WeightSpecified = true;
                        parcel.Weight = (decimal)comm.Weight[ij];
                        parcel.Width = comm.Width[ij].ToString().Substring(0, ((comm.Width[ij].ToString().Length > 8) ? 8 : comm.Width[ij].ToString().Length));
                        parcel.Height = comm.Height[ij].ToString().Substring(0, ((comm.Height[ij].ToString().Length > 8) ? 8 : comm.Height[ij].ToString().Length));
                        parcel.Length = comm.Length[ij].ToString().Substring(0, ((comm.Length[ij].ToString().Length > 8) ? 8 : comm.Length[ij].ToString().Length)); ;
                        parcel.PurposeOfShipment = comm.PurposeOfShipment[ij];



                        ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                        ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                        contentDetail.CountryOfManufacture = "GB";
                        string sss = PinYinHelpers.ToPinYin(comm.Description[ij]);
                        if (sss.Length > 30)
                        {
                            sss = sss.Substring(0, 30);
                        }
                        contentDetail.Description = sss;
                        contentDetail.UnitWeight = (decimal)comm.Weight[ij];
                        contentDetail.UnitQuantity = "1";
                        contentDetail.UnitValue = (decimal)comm.Value[ij];
                        contentDetail.Currency = "gbp";
                        contentDetails[0] = contentDetail;
                        parcel.ContentDetails = contentDetails;
                        parcelInfo[ij] = parcel;
                    }

                    requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                    requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                    requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                    requestShipment.InternationalInfo.Parcels = parcelInfo;

                    ShipService.ShipPortTypeClient client = new ShipService.ShipPortTypeClient();

                    ShipService.CreateShipmentRequest shipRequest = new ShipService.CreateShipmentRequest();
                    shipRequest.Authentication = auth;
                    shipRequest.RequestedShipment = requestShipment;
                    ShipService.CreateShipmentReply shipReply = client.createShipment(shipRequest);
                    if (shipReply.Alerts != null)
                    {
                        alertMsg += comm.Ordernumber + ":";
                        //string alertMsg = null;
                        for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                        {
                            alertMsg += shipReply.Alerts[ij].Message;
                        }
                        alertMsg += "\r\n";
                        //alert("订单号" + order_number_array[shun-1 ] + alertMsg);
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
                            unsuccess = comm.Ordernumber.ToString();
                        }
                        else
                        {
                            successOrder = 1;


                            if (comm.Ordernumber.Contains("WM"))
                            {
                                // 界面下单
                                ArrayList array_package = new PackageDAO().getPackage(comm.Ordernumber);
                                string[] track_array = shipNumber.Split(',');

                                for (int i = 0; i < track_array.Length; i++)
                                {
                                    Package temp_package = (Package)array_package[i];
                                    new PackageDAO().updateTrackNo(temp_package.Wp_track_no, "", track_array[i], "");
                                }

                                new OrderDAO().updateTrackNo(comm.Ordernumber, shipNumber);


                            }
                            else if (comm.Ordernumber.Contains("WA"))
                            {
                                // Excel 下单 跟新 包裹的追踪号
                                new AutoOrderListDAO().updateAutoOrderListTrackNo(comm.Ordernumber, "", "", shipNumber);

                            }




                            string collectionAddress = comm.CollectionAddress;
                            string AddressLine2 = null;
                            string AddressLine3 = null;
                            string AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //comm.CollectionAddressLine;
                            if (collectionAddress.Length >= 24)
                                AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 43) ? 19 : (collectionAddress.Length - 24)));
                            if (collectionAddress.Length >= 43)
                                AddressLine3 = collectionAddress.Substring(43, ((collectionAddress.Length > 67) ? 24 : (collectionAddress.Length - 43)));
                            string Postcode = comm.CollectionPostCode.Substring(0, ((comm.CollectionPostCode.Length > 16) ? 16 : comm.CollectionPostCode.Length));
                            string Town = comm.CollectionTown.Substring(0, ((comm.CollectionTown.Length > 24) ? 24 : comm.CollectionTown.Length));
                            string BusinessName = comm.CollectionCompanyName.Substring(0, ((comm.CollectionCompanyName.Length > 24) ? 24 : comm.CollectionCompanyName.Length));
                            string ContactName = comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length));
                            string Telephone = comm.CollectionPhone.Substring(0, ((comm.CollectionPhone.Length > 15) ? 15 : comm.CollectionPhone.Length));



                            for (int sn = 0; sn < shipNumber.Split(',').Length; sn++)
                            {
                                ThreadPool.QueueUserWorkItem(new WaitCallback(RequestLabel), (shipNumber.Split(','))[sn]);
                            }
                          
                            PFLabel pflabel = new PFLabel(comm.Ordernumber, shipNumber, comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length)), recipientAddress.Town, "China", AddressLine1, Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, "GPRCOLLECTION", comm.Description);
                            PFCN21 pfcn21 = new PFCN21(comm.Ordernumber, shipNumber, BusinessName, comm.CollectionContactName.Substring(0, ((comm.CollectionContactName.Length > 24) ? 24 : comm.CollectionContactName.Length)), Town, contact.BusinessName, "China", AddressLine1, AddressLine2, AddressLine3, Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);
                            PFCommercial pfcommercial = new PFCommercial(comm.Ordernumber, shipNumber, ContactName, Telephone, Town, "China", AddressLine1, AddressLine2, AddressLine3, Postcode, contact.ContactName, comm.Weight, recipientAddress.Town, recipientAddress.AddressLine1, recipientAddress.AddressLine2, recipientAddress.AddressLine3, recipientAddress.Postcode, comm.ShippingDate, contact.Telephone, comm.Description, comm.Value);

                            string[] track = shipNumber.Split(',');
                            for (int trac = 0; trac < track.Length; trac++)
                            {
                                string[] pdflist = new string[3];
                                for (int jj = 0; jj < 3; jj++)
                                {
                                    if (jj == 2)
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + "3.pdf";
                                    else
                                        pdflist[jj] = AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] +jj.ToString()+ ".pdf";
                                }

                                mergePDFFiles(pdflist, AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + track[trac] + ".pdf", true);
                            }
                        }

                    }
                }
            }
            if (context.Session["unsuccess"] == null && unsuccess != null)
            {
                unsuccesses.Add(unsuccess);
                context.Session["unsuccess"] = unsuccesses;
            }

            else if (unsuccess != null)
            {
                unsuccesses = (ArrayList)(context.Session["unsuccess"]);
                unsuccesses.Add(unsuccess);
                context.Session["unsuccess"] = unsuccesses;
            }
            if (shun == order_number_array.Count)
            {
                if (context.Session["unsuccess"] != null)
                {
                    unsuccesses = (ArrayList)(context.Session["unsuccess"]);
                    for (shun = 1; shun <= unsuccesses.Count; shun++)
                    {


                    }
                }
                context.Session["alertMsg"] = alertMsg;
                context.Session["pay_orders"] = order_number_array;
                context.Response.Redirect("order-label.aspx");
            }
            if (successOrder == 1)
                context.Response.Write("success");
            else if (successOrder == 0)
                context.Response.Write("failed");
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private void mergePDFFiles(string[] fileList, string outMergeFile, bool bol)
        {

            PdfReader reader;

            Document document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));

            document.Open();

            PdfContentByte cb = writer.DirectContent;

            reader = new PdfReader(fileList[0]);

            PdfImportedPage newPage;
            document.SetPageSize(reader.GetPageSize(1));
            // document.SetPageSize(new Rectangle(595, 421));
            for (int i = 0; i < fileList.Length; i++)
            {

                reader = new PdfReader(fileList[i]);

                int iPageNum = reader.NumberOfPages;

                for (int j = 1; j <= iPageNum; j++)
                {
                    if (i == 1 && bol)
                    {
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 2, 0, 0, 2, 0, 0);
                    }
                    else
                    {
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 0, 0);
                    }
                }

            }

            document.Close();
        }


        private float getTotalWeight(float[] weight)
        {
            float total_weight = 0;

            for (int i = 0; i < weight.Length; i++)
            {
                total_weight += weight[i];
            }

                return total_weight;
        }
        public void RequestLabel(Object shipnumber)
        {
            try
            {
           
                string shipNumber = (string)shipnumber;
                ShipService.Authentication auth = new ShipService.Authentication();
                auth.UserName = "EL_WDMABYR";//"EL_WDMAAYZ";
                auth.Password = "kvhkwr22";//"129v2iz5";
                ShipService.ShipPortTypeClient client = new ShipService.ShipPortTypeClient();
                ShipService.PrintLabelRequest labelRequest = new ShipService.PrintLabelRequest();
                labelRequest.Authentication = auth;
                labelRequest.ShipmentNumber = shipNumber;
                ShipService.PrintLabelReply labelReply = client.printLabel(labelRequest);
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "\\views\\pdf\\" + shipNumber + "11.pdf", labelReply.Label.Data);
            }
            catch (Exception ee)
            {

            }
        }


    }
}