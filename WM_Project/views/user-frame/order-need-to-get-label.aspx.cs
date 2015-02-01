using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using WM_Project.logical.common;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data.SqlClient;
using WM_Project.control;


namespace WM_Project.views.user_frame
{
    public partial class order_need_to_get_label : System.Web.UI.Page
    {
        public int requestOver = 0;
        public string alertMsg = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["name"] = "yangwang";

                if (Session["name"] == null)
                {
                    Response.Redirect("../user-login.aspx");
                }
                else
                {
                    ArrayList need_label = new ArrayList();
                    need_label = new AutoOrderListDAO().getAutoOrderListArrayNeedLabel(Session["name"].ToString(), "paied", "");
                    if (need_label.Count > 0)
                    {
                        bar_code.DataSource = createBarCodeTable(need_label);
                        bar_code.DataBind();
                    }
                    else
                    {
                        has_order.Visible = false;
                        has_not_order.Visible = true;
                    }

                }
            }

        }



        protected void bar_code_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName.ToString().Equals("PrintByDownload"))
            {

                requestOver = 0;
                string Ordernum = e.CommandArgument.ToString();

                AutoOrderList listdao = new AutoOrderListDAO().getAutoOrderList(Ordernum);

                if (listdao.Ea_track_no.Contains("EA") || listdao.Ea_track_no.Contains("EE") || listdao.Ea_track_no.Contains("EG") || listdao.Ea_track_no.Contains("EM"))
                {
                    string filename = Server.MapPath("~") + "views\\pdf\\" + Ordernum + "2.pdf";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + Ordernum + ".pdf");

                    HttpContext.Current.Response.WriteFile(filename);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.Close();
                }
                else
                {
                    if (listdao.ServiceCode == "WM_Project")
                    {
                        int contentLength = 1;
                        string[] Content = { "Content" };
                        string[] CostCenter = { "CostCenter" };
                        string[] CustomerOrderNumber = { "number" };
                        string[] CountryOfOrigin = { "GB" };
                        string[] Description = { listdao.PackageDescription };
                        string[] HSTariffNr = { "10306759" };
                        string[] contentQuantity = { "1" };
                        string[] contentValue = { listdao.PackageValue.ToString() };
                        string[] contentWeight = { listdao.Weight.ToString() };

                        CIF_SB cif = new CIF_SB();
                        string barcode = cif.GenerateBarcode("3T@o!", "238dcbeece103ec91c86f07d778565a338ef917e", "ABCD", "22446688", "ABCD", "0000000-9999999", "3S", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                        //获取CD运单号
                        string DownPartnerBarcode = cif.GenerateBarcode("3T@o!", "238dcbeece103ec91c86f07d778565a338ef917e", "1234", "22446688", "1234", "0000-9999", "CD", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                        listdao.S_track_no = barcode;

                        // string DownPartnerBarcode = cif.GenerateBarcode("Et@0!!", "23621feac2e556e9beffbd7a4f8885ba93aef578", "6836", "10423404", "6836", "0000-9999", "CD", "1", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                        listdao.Cd_track_no = DownPartnerBarcode;

                        WM_Project.LabelTest1.LabellingWebServiceClient client = new WM_Project.LabelTest1.LabellingWebServiceClient();
                        client.ClientCredentials.UserName.UserName = "3T@o!";
                        client.ClientCredentials.UserName.Password = "238dcbeece103ec91c86f07d778565a338ef917e";
                        WM_Project.LabelTest1.GenerateLabelRequest request = new WM_Project.LabelTest1.GenerateLabelRequest();
                        WM_Project.LabelTest1.Customer customer = new WM_Project.LabelTest1.Customer();
                        WM_Project.LabelTest1.Address address = new WM_Project.LabelTest1.Address();
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
                        customer.ContactPerson = listdao.RecipientContactName;

                        customer.CustomerCode = "1234";
                        customer.CustomerNumber = "22446688";
                        customer.Email = "";
                        customer.Name = listdao.CollectionContactName;

                        WM_Project.LabelTest1.Customs custome = new WM_Project.LabelTest1.Customs();
                        custome.ShipmentType = "Gift";

                        WM_Project.LabelTest1.Message message = new WM_Project.LabelTest1.Message();
                        message.MessageID = "1";
                        message.MessageTimeStamp = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                        message.Printertype = "GraphicFile|PDF";

                        WM_Project.LabelTest1.Shipment shipment = new WM_Project.LabelTest1.Shipment();
                        WM_Project.LabelTest1.Address shipmentaddress = new WM_Project.LabelTest1.Address();
                        shipmentaddress.AddressType = "01";
                        shipmentaddress.City = listdao.RecipientTown;
                        shipmentaddress.CompanyName = listdao.RecipientContactName + "\r\n" + listdao.RecipientCompanyName;
                        shipmentaddress.Countrycode = "CN";
                        shipmentaddress.HouseNr = listdao.RecipientPhone;
                        shipmentaddress.Street = listdao.RecipientAddressLine;
                        shipmentaddress.Zipcode = listdao.RecipeintPostCode;
                        WM_Project.LabelTest1.Address[] shipmentaddresses = new WM_Project.LabelTest1.Address[1];
                        shipmentaddresses[0] = shipmentaddress;
                        shipment.Addresses = shipmentaddresses;
                        shipment.Barcode = barcode;
                        WM_Project.LabelTest1.Contact contact = new WM_Project.LabelTest1.Contact();
                        contact.ContactType = "01";
                        contact.Email = "";
                        contact.SMSNr = listdao.RecipientPhone;
                        WM_Project.LabelTest1.Contact[] contacts = new WM_Project.LabelTest1.Contact[1];
                        contacts[0] = contact;
                        shipment.Contacts = contacts;

                        WM_Project.LabelTest1.Content[] contents = new WM_Project.LabelTest1.Content[contentLength];
                        for (int j = 0; j < contentLength; j++)
                        {
                            WM_Project.LabelTest1.Content content = new WM_Project.LabelTest1.Content();
                            shipment.Content = Content[j];
                            shipment.CostCenter = CostCenter[j];
                            shipment.CustomerOrderNumber = CustomerOrderNumber[j];
                            content.CountryOfOrigin = CountryOfOrigin[j];
                            content.Description = Description[j];
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
                        WM_Project.LabelTest1.Dimension dimenshin = new WM_Project.LabelTest1.Dimension();
                        dimenshin.Height = (Math.Ceiling(listdao.Height * 100)).ToString();
                        dimenshin.Length = Math.Ceiling(listdao.Length * 100).ToString();
                        dimenshin.Volume = Math.Ceiling(listdao.Volumetric * 100).ToString();
                        dimenshin.Weight = Math.Ceiling(listdao.Weight * 1000).ToString();
                        dimenshin.Width = Math.Ceiling(listdao.Width * 100).ToString();
                        shipment.Dimension = dimenshin;
                        shipment.DownPartnerBarcode = DownPartnerBarcode;
                        WM_Project.LabelTest1.Group group = new WM_Project.LabelTest1.Group();
                        group.GroupCount = "2";
                        group.GroupSequence = "2";
                        group.GroupType = "03";
                        // group.MainBarcode = MainBarcode;
                        WM_Project.LabelTest1.Group[] groups = new WM_Project.LabelTest1.Group[1];
                        groups[0] = group;
                        shipment.Groups = groups;
                        shipment.Customs = custome;
                        shipment.ProductCodeDelivery = "4947"; //"3987";
                        shipment.Reference = "Gift";//"MYREF01";

                        request.Shipment = shipment;
                        request.Customer = customer;
                        request.Message = message;
                        try
                        {
                            WM_Project.LabelTest1.ResponseShipment request2 = client.GenerateLabel(request);

                            string PartnerID = request2.DownPartnerID;
                            string PartnerBarcode = request2.DownPartnerBarcode;

                            listdao.Ea_track_no = PartnerBarcode;

                            new AutoOrderListDAO().updateAutoOrderListTrackNo(listdao.Order_no, listdao.S_track_no, listdao.Cd_track_no, listdao.Ea_track_no);

                            int m = request2.Labels.Length;
                            byte[][] byt = new byte[m][];
                            for (int ii = 0; ii < m; ii++)
                            {
                                byt[ii] = request2.Labels[ii].Content;
                                File.WriteAllBytes(Server.MapPath("~") + "views\\pdf\\" + listdao.Order_no + ii.ToString() + ".pdf", byt[ii]);
                            }
                            string[] pdflist = new string[m];
                            for (int jj = 0; jj < m; jj++)
                            {
                                pdflist[jj] = Server.MapPath("~") + "views\\pdf\\" + listdao.Order_no + jj.ToString() + ".pdf";
                            }
                            mergePDFFiles(pdflist, Server.MapPath("~") + "views\\pdf\\" + listdao.Order_no + m.ToString() + ".pdf");
                        }
                        catch (Exception ee)
                        {
                            alertMsg += "订单号" + listdao.Order_no + "的WM_Project出错了,请查看网络以及请求的数据，重新下此单\r\n";
                        }

                    }

                    else if (listdao.ServiceCode == "EMS")
                    {
                        try
                        {
                            SqlConnection conn = DBConn.getConn();
                            conn.Open();


                            SqlCommand cmd = new SqlCommand("select top 1 EMSNumber from tb_EMS with (UPDLOCK) where EMSStatus=0", conn);
                            SqlDataReader dataReader = cmd.ExecuteReader();
                            if (dataReader.Read())
                            {

                                listdao.Ea_track_no = dataReader["EMSNumber"].ToString();
                            }
                            conn.Close();
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("update tb_EMS set EMSStatus=1 where EMSNumber='" + listdao.Ea_track_no + "'", conn);
                            cmd1.ExecuteNonQuery();
                            if (listdao.Ea_track_no != null)
                            {
                                new AutoOrderListDAO().updateAutoOrderListTrackNo(listdao.Order_no, listdao.S_track_no, listdao.Cd_track_no, listdao.Ea_track_no);
                              //  PdfPrint EMSLabel = new PdfPrint(listdao.Order_no, listdao.Ea_track_no, listdao.RecipientContactName, listdao.RecipientPhone, listdao.RecipientAddressLine, listdao.RecipeintPostCode, listdao.RecipientTown, listdao.CollectionContactName, listdao.CollectionPhone, listdao.CollectionAddressLine, "", listdao.Weight, listdao.PackageValue, "", listdao.PackageDescription, 1);

                            }

                            conn.Close();
                        }
                        catch (Exception ee)
                        {
                            alertMsg += "订单号" + listdao.Order_no + "的EMS订单出错了,请查看网络以及请求的数据，重新下此单\r\n";
                        }
                    }




                    else if (listdao.ServiceCode.Contains("PF-IPE"))
                    {
                        if (listdao.Shippingtype == "COLLECTION")
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
                            contact.BusinessName = PinyinHelper.GetPinyin(listdao.RecipientCompanyName);//listdao.RecipientCompanyName;
                            //收件联络人姓名
                            contact.ContactName = PinyinHelper.GetPinyin(listdao.RecipientContactName); ;// listdao.RecipientContactName;
                            //收件联络人电话
                            contact.Telephone = listdao.RecipientPhone;
                            //contact.EmailAddress = "1005780548@qq.com";

                            requestShipment.RecipientContact = contact;
                            //DepartmentId
                            requestShipment.DepartmentId = "3";
                            //Set to COLLECTION    DELIVERY   TRAILER
                            requestShipment.ShipmentType = "COLLECTION";
                            requestShipment.ContractNumber = "P831255";
                            requestShipment.ServiceCode = "IPE";
                            requestShipment.ShippingDateSpecified = true;
                            //寄件日期设置

                            requestShipment.ShippingDate = DateTime.Parse(listdao.Shippingdate);


                            //收件人地址
                            ShipService.Address recipientAddress = new ShipService.Address();
                            string address = PinyinHelper.GetPinyin(listdao.RecipientAddressLine);
                            recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// listdao.RecipientAddressLine;
                            if (address.Length > 24)
                                recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 48) ? 24 : (address.Length - 24)));
                            if (address.Length > 48)
                                recipientAddress.AddressLine3 = address.Substring(48, ((address.Length > 72) ? 24 : (address.Length - 48)));
                            recipientAddress.Town = PinyinHelper.GetPinyin(listdao.RecipientTown);//listdao.RecipientTown;
                            recipientAddress.Postcode = listdao.RecipeintPostCode;
                            //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                            recipientAddress.Country = "CN";
                            requestShipment.RecipientAddress = recipientAddress;

                            //寄件信息
                            ShipService.CollectionInfo importerCollectionInfo = new ShipService.CollectionInfo();
                            //寄件联络人信息
                            ShipService.Contact importerContact = new ShipService.Contact();
                            importerContact.BusinessName = listdao.CollectionCompanyName;
                            importerContact.ContactName = listdao.CollectionContactName;
                            importerContact.Telephone = listdao.CollectionPhone;
                            //importerContact.EmailAddress = "1005780548@qq.com";
                            requestShipment.ImporterContact = importerContact;
                            //寄件联络人地址信息
                            ShipService.Address importerAddress = new ShipService.Address();
                            string collectionAddress = listdao.CollectionAddressLine;
                            importerAddress.AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //listdao.CollectionAddressLine;
                            if (collectionAddress.Length >= 24)
                                importerAddress.AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 48) ? 24 : (collectionAddress.Length - 24)));
                            if (collectionAddress.Length >= 48)
                                importerAddress.AddressLine3 = collectionAddress.Substring(48, ((collectionAddress.Length > 72) ? 24 : (collectionAddress.Length - 48)));
                            importerAddress.Postcode = listdao.CollectionPostCode;
                            importerAddress.Town = listdao.CollectionTown;

                            //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                            importerAddress.Country = "GB";
                            requestShipment.ImporterAddress = importerAddress;

                            ////取件时间，From为起始取件时间，To为结束取件时间
                            ShipService.DateTimeRange collectionTime = new ShipService.DateTimeRange();


                            collectionTime.From = DateTime.Parse(listdao.Shippingdate + "T00:00:00");
                            collectionTime.To = DateTime.Parse(listdao.Shippingdate + "T00:00:00");

                            //寄件包裹的地址联络人以及取件时间的设置
                            importerCollectionInfo.CollectionAddress = importerAddress;
                            importerCollectionInfo.CollectionContact = importerContact;
                            importerCollectionInfo.CollectionTime = collectionTime;


                            //
                            requestShipment.CollectionInfo = importerCollectionInfo;
                            //设置包裹的总数量
                            //数据库中暂无此字段，这是个问题，期待解决
                            requestShipment.TotalNumberOfParcels = "1";

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

                            ShipService.Parcel parcel = new ShipService.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)listdao.Weight;
                            parcel.Width = listdao.Width.ToString();
                            parcel.Height = listdao.Height.ToString();
                            parcel.Length = listdao.Length.ToString();
                            parcel.PurposeOfShipment = "Gift";// listdao.Shippingpurpose;

                            ShipService.Parcel[] parcelInfo = new ShipService.Parcel[1];

                            ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                            ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinyinHelper.GetPinyin(listdao.PackageDescription);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)listdao.Weight;
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)listdao.PackageValue;
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[0] = parcel;

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
                                alertMsg += listdao.Order_no + ":";
                                for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                                {
                                    alertMsg += shipReply.Alerts[ij].Message;
                                }
                                alertMsg += "\r\n";
                            }
                            else
                            {
                                string shipNumber = shipReply.CompletedShipmentInfo.LeadShipmentNumber;

                                listdao.Ea_track_no = shipNumber;

                                new AutoOrderListDAO().updateAutoOrderListTrackNo(listdao.Order_no, listdao.S_track_no, listdao.Cd_track_no, listdao.Ea_track_no);

                                ShipService.PrintDocumentRequest documentRequest = new ShipService.PrintDocumentRequest();
                                documentRequest.Authentication = auth;
                                documentRequest.ShipmentNumber = shipNumber;
                                documentRequest.DocumentType = "1";
                                ShipService.PrintDocumentReply documentReply = client.printDocument(documentRequest);

                                byte[] documentbyt = documentReply.Label.Data;
                                File.WriteAllBytes(Server.MapPath("~\\views\\pdf\\" + listdao.Order_no + "2.pdf"), documentbyt);
                                File.WriteAllBytes(Server.MapPath("~\\views\\pdf\\" + listdao.Order_no + "1.pdf"), documentbyt);
                               
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
                            contact.BusinessName = PinyinHelper.GetPinyin(listdao.RecipientCompanyName);//listdao.RecipientCompanyName;
                            //收件联络人姓名
                            contact.ContactName = PinyinHelper.GetPinyin(listdao.RecipientContactName); ;// listdao.RecipientContactName;
                            //收件联络人电话
                            contact.Telephone = listdao.RecipientPhone;
                            //contact.EmailAddress = "1005780548@qq.com";

                            requestShipment.RecipientContact = contact;
                            //DepartmentId

                            //Set to COLLECTION    DELIVERY   TRAILER
                            requestShipment.ShipmentType = "DELIVERY";
                            if (listdao.Shippingtype.Contains("Depot"))
                            {
                                requestShipment.DepartmentId = "4";
                                requestShipment.ContractNumber = "P831263";
                            }
                            if (listdao.Shippingtype.Contains("Trailer"))
                            {
                                requestShipment.DepartmentId = "5";
                                requestShipment.ContractNumber = "P831271";
                            }
                            if (listdao.Shippingtype.Contains("POL"))
                            {
                                requestShipment.DepartmentId = "6";
                                requestShipment.ContractNumber = "P888907";
                            }
                            requestShipment.ServiceCode = "IPE";
                            requestShipment.ShippingDateSpecified = true;
                            //寄件日期设置

                            requestShipment.ShippingDate = DateTime.Parse(listdao.Shippingdate);


                            //收件人地址
                            ShipService.Address recipientAddress = new ShipService.Address();
                            string address = PinyinHelper.GetPinyin(listdao.RecipientAddressLine);
                            recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// listdao.RecipientAddressLine;
                            if (address.Length > 24)
                                recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 48) ? 24 : (address.Length - 24)));
                            if (address.Length > 48)
                                recipientAddress.AddressLine3 = address.Substring(48, ((address.Length > 72) ? 24 : (address.Length - 48)));
                            recipientAddress.Town = PinyinHelper.GetPinyin(listdao.RecipientTown);//listdao.RecipientTown;
                            recipientAddress.Postcode = listdao.RecipeintPostCode;
                            //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                            recipientAddress.Country = "CN";
                            requestShipment.RecipientAddress = recipientAddress;

                            ////
                            //requestShipment.CollectionInfo = importerCollectionInfo;
                            //设置包裹的总数量
                            //数据库中暂无此字段，这是个问题，期待解决
                            requestShipment.TotalNumberOfParcels = "1";

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


                            ShipService.Parcel parcel = new ShipService.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)listdao.Weight;
                            parcel.Width = listdao.Width.ToString();
                            parcel.Height = listdao.Height.ToString();
                            parcel.Length = listdao.Length.ToString();
                            parcel.PurposeOfShipment = "Gift";// listdao.Shippingpurpose;

                            ShipService.Parcel[] parcelInfo = new ShipService.Parcel[1];

                            ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                            ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinyinHelper.GetPinyin(listdao.PackageDescription);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)listdao.Weight;
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)listdao.PackageValue;
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[0] = parcel;

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
                                alertMsg += listdao.Order_no + ":";
                                //string alertMsg = null;
                                for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                                {
                                    alertMsg += shipReply.Alerts[ij].Message;
                                }
                                alertMsg += "\r\n";
                                //alert("订单号" + listdao.Order_no + alertMsg);
                            }
                            else
                            {

                                string shipNumber = shipReply.CompletedShipmentInfo.LeadShipmentNumber;

                                listdao.Ea_track_no = shipNumber;

                                new AutoOrderListDAO().updateAutoOrderListTrackNo(listdao.Order_no, listdao.S_track_no, listdao.Cd_track_no, listdao.Ea_track_no);



                                ShipService.PrintLabelRequest labelRequest = new ShipService.PrintLabelRequest();
                                labelRequest.Authentication = auth;
                                labelRequest.ShipmentNumber = shipNumber;
                                labelRequest.PrintTypeSpecified = true;
                                labelRequest.PrintType = ShipService.PrintType.ALL_PARCELS;
                                ShipService.PrintLabelReply shipLabel = client.printLabel(labelRequest);

                                byte[] byt = shipLabel.Label.Data;
                                File.WriteAllBytes(Server.MapPath("~\\views\\pdf\\" + listdao.Order_no + "1.pdf"), byt);
                                //string PartnerCode = shipLabel.PartnerCode;
                                ShipService.PrintDocumentRequest documentRequest = new ShipService.PrintDocumentRequest();
                                documentRequest.Authentication = auth;
                                documentRequest.ShipmentNumber = shipNumber;
                                documentRequest.DocumentType = "1";
                                ShipService.PrintDocumentReply documentReply = client.printDocument(documentRequest);

                                byte[] documentbyt = documentReply.Label.Data;

                                File.WriteAllBytes(Server.MapPath("~\\views\\pdf\\" + listdao.Order_no + "0.pdf"), documentbyt);
                                string[] pdflist = new string[2];
                                for (int jj = 0; jj < 2; jj++)
                                {
                                    pdflist[jj] = Server.MapPath("~") + "\\pdf\\" + listdao.Order_no + jj.ToString() + ".pdf";
                                }
                                mergePDFFiles(pdflist, Server.MapPath("~") + "\\pdf\\" + listdao.Order_no + "2.pdf");


                            }
                        }
                    }






                    else if (listdao.ServiceCode.Contains("PF-GPR"))
                    {
                        if (listdao.Shippingtype == "COLLECTION")
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
                            contact.BusinessName = PinyinHelper.GetPinyin(listdao.RecipientCompanyName);//listdao.RecipientCompanyName;
                            //收件联络人姓名
                            contact.ContactName = PinyinHelper.GetPinyin(listdao.RecipientContactName); ;// listdao.RecipientContactName;
                            //收件联络人电话
                            contact.Telephone = listdao.RecipientPhone;
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

                            requestShipment.ShippingDate = DateTime.Parse(listdao.Shippingdate);


                            //收件人地址
                            ShipService.Address recipientAddress = new ShipService.Address();
                            string address = PinyinHelper.GetPinyin(listdao.RecipientAddressLine);
                            recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// listdao.RecipientAddressLine;
                            if (address.Length > 24)
                                recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 48) ? 24 : (address.Length - 24)));
                            if (address.Length > 48)
                                recipientAddress.AddressLine3 = address.Substring(48, ((address.Length > 72) ? 24 : (address.Length - 48)));
                            recipientAddress.Town = PinyinHelper.GetPinyin(listdao.RecipientTown);//listdao.RecipientTown;
                            recipientAddress.Postcode = listdao.RecipeintPostCode;
                            //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                            recipientAddress.Country = "CN";
                            requestShipment.RecipientAddress = recipientAddress;

                            //寄件信息
                            ShipService.CollectionInfo importerCollectionInfo = new ShipService.CollectionInfo();
                            //寄件联络人信息
                            ShipService.Contact importerContact = new ShipService.Contact();
                            importerContact.BusinessName = listdao.CollectionCompanyName;
                            importerContact.ContactName = listdao.CollectionContactName;
                            importerContact.Telephone = listdao.CollectionPhone;
                            //importerContact.EmailAddress = "1005780548@qq.com";
                            requestShipment.ImporterContact = importerContact;
                            //寄件联络人地址信息
                            ShipService.Address importerAddress = new ShipService.Address();
                            string collectionAddress = listdao.CollectionAddressLine;
                            importerAddress.AddressLine1 = collectionAddress.Substring(0, ((collectionAddress.Length < 24) ? (collectionAddress.Length) : 24)); //listdao.CollectionAddressLine;
                            if (collectionAddress.Length >= 24)
                                importerAddress.AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 48) ? 24 : (collectionAddress.Length - 24)));
                            if (collectionAddress.Length >= 48)
                                importerAddress.AddressLine3 = collectionAddress.Substring(48, ((collectionAddress.Length > 72) ? 24 : (collectionAddress.Length - 48)));
                            importerAddress.Postcode = listdao.CollectionPostCode;
                            importerAddress.Town = listdao.CollectionTown;

                            //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                            importerAddress.Country = "GB";
                            requestShipment.ImporterAddress = importerAddress;

                            ////取件时间，From为起始取件时间，To为结束取件时间
                            ShipService.DateTimeRange collectionTime = new ShipService.DateTimeRange();


                            collectionTime.From = DateTime.Parse(listdao.Shippingdate + "T00:00:00");
                            collectionTime.To = DateTime.Parse(listdao.Shippingdate + "T00:00:00");


                            // collectionTime.From = DateTime.Parse("2014-12-18");
                            //   collectionTime.To = DateTime.Parse("2014-12-18");

                            //寄件包裹的地址联络人以及取件时间的设置
                            importerCollectionInfo.CollectionAddress = importerAddress;
                            importerCollectionInfo.CollectionContact = importerContact;
                            importerCollectionInfo.CollectionTime = collectionTime;


                            //
                            requestShipment.CollectionInfo = importerCollectionInfo;
                            //设置包裹的总数量
                            //数据库中暂无此字段，这是个问题，期待解决
                            requestShipment.TotalNumberOfParcels = "1";

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


                            ShipService.Parcel parcel = new ShipService.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)listdao.Weight;
                            parcel.Width = listdao.Width.ToString();
                            parcel.Height = listdao.Height.ToString();
                            parcel.Length = listdao.Length.ToString();
                            parcel.PurposeOfShipment = "Gift";// listdao.Shippingpurpose;

                            ShipService.Parcel[] parcelInfo = new ShipService.Parcel[1];

                            ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                            ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinyinHelper.GetPinyin(listdao.PackageDescription);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)listdao.Weight;
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)listdao.PackageValue;
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[0] = parcel;

                            requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                            requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                            requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                            requestShipment.InternationalInfo.Parcels = parcelInfo;

                            //ShipService.Returns ret = new ShipService.Returns();
                            //ret.ReturnsEmail = "1005780548@qq.com";
                            //ret.EmailLabel = true;
                            //ret.EmailMessage = "";
                            //requestShipment.Returns = ret;

                            ShipService.ShipPortTypeClient client = new ShipService.ShipPortTypeClient();

                            ShipService.CreateShipmentRequest shipRequest = new ShipService.CreateShipmentRequest();
                            shipRequest.Authentication = auth;
                            shipRequest.RequestedShipment = requestShipment;
                            ShipService.CreateShipmentReply shipReply = client.createShipment(shipRequest);
                            if (shipReply.Alerts != null)
                            {
                                alertMsg += listdao.Order_no + ":";
                                //string alertMsg = null;
                                for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                                {
                                    alertMsg += shipReply.Alerts[ij].Message;
                                }
                                alertMsg += "\r\n";
                                //alert("订单号" + listdao.Order_no + alertMsg);
                            }
                            else
                            {

                                string shipNumber = shipReply.CompletedShipmentInfo.LeadShipmentNumber;


                                listdao.Ea_track_no = shipNumber;

                                new AutoOrderListDAO().updateAutoOrderListTrackNo(listdao.Order_no, listdao.S_track_no, listdao.Cd_track_no, listdao.Ea_track_no);


                                //ShipService.PrintLabelRequest labelRequest = new ShipService.PrintLabelRequest();
                                //labelRequest.Authentication = auth;
                                //labelRequest.ShipmentNumber = shipNumber;
                                //labelRequest.PrintTypeSpecified = true;
                                //labelRequest.PrintType = ShipService.PrintType.ALL_PARCELS;
                                //ShipService.PrintLabelReply shipLabel = client.printLabel(labelRequest);

                                //byte[] byt = shipLabel.Label.Data;
                                //File.WriteAllBytes(Server.MapPath("\\pdf\\" + shipNumber + "0.pdf"), byt);
                                //string PartnerCode = shipLabel.PartnerCode;
                                ShipService.PrintDocumentRequest documentRequest = new ShipService.PrintDocumentRequest();
                                documentRequest.Authentication = auth;
                                documentRequest.ShipmentNumber = shipNumber;
                                documentRequest.DocumentType = "1";
                                ShipService.PrintDocumentReply documentReply = client.printDocument(documentRequest);

                                byte[] documentbyt = documentReply.Label.Data;
                                File.WriteAllBytes(Server.MapPath("\\views\\pdf\\" + listdao.Order_no + "2.pdf"), documentbyt);
                                File.WriteAllBytes(Server.MapPath("\\views\\pdf\\" + listdao.Order_no + "1.pdf"), documentbyt);
                                //string[] pdflist = new string[2];
                                //for (int jj = 0; jj < 2; jj++)
                                //{
                                //    pdflist[jj] = Server.MapPath("") + "\\pdf\\" + listdao.Order_no + jj.ToString() + ".pdf";
                                //}
                                //mergePDFFiles(pdflist, Server.MapPath("") + "\\pdf\\" + listdao.Order_no + "2.pdf");

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
                            contact.BusinessName = PinyinHelper.GetPinyin(listdao.RecipientCompanyName);//listdao.RecipientCompanyName;
                            //收件联络人姓名
                            contact.ContactName = PinyinHelper.GetPinyin(listdao.RecipientContactName); ;// listdao.RecipientContactName;
                            //收件联络人电话
                            contact.Telephone = listdao.RecipientPhone;
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

                            requestShipment.ShippingDate = DateTime.Parse(listdao.Shippingdate);


                            //收件人地址
                            ShipService.Address recipientAddress = new ShipService.Address();
                            string address = PinyinHelper.GetPinyin(listdao.RecipientAddressLine);
                            recipientAddress.AddressLine1 = address.Substring(0, ((address.Length < 24) ? (address.Length) : 24));// listdao.RecipientAddressLine;
                            if (address.Length > 24)
                                recipientAddress.AddressLine2 = address.Substring(24, ((address.Length > 48) ? 24 : (address.Length - 24)));
                            if (address.Length > 48)
                                recipientAddress.AddressLine3 = address.Substring(48, ((address.Length > 72) ? 24 : (address.Length - 48)));
                            recipientAddress.Town = PinyinHelper.GetPinyin(listdao.RecipientTown);//listdao.RecipientTown;
                            recipientAddress.Postcode = listdao.RecipeintPostCode;
                            //这里要更改为国家对应的代码，此处暂未更改，以后要更改
                            recipientAddress.Country = "CN";
                            requestShipment.RecipientAddress = recipientAddress;

                            ////寄件信息
                            //ShipService.CollectionInfo importerCollectionInfo = new ShipService.CollectionInfo();
                            ////寄件联络人信息
                            //ShipService.Contact importerContact = new ShipService.Contact();
                            //importerContact.BusinessName = listdao.CollectionCompanyName;
                            //importerContact.ContactName = listdao.CollectionContactName;
                            //importerContact.Telephone = listdao.CollectionPhone;
                            ////importerContact.EmailAddress = "1005780548@qq.com";
                            //requestShipment.ImporterContact = importerContact;
                            ////寄件联络人地址信息
                            //ShipService.Address importerAddress = new ShipService.Address();
                            //string collectionAddress = listdao.CollectionAddressLine;
                            //importerAddress.AddressLine1 = collectionAddress.Substring(0, 24); //listdao.CollectionAddressLine;
                            //if (collectionAddress.Length >= 24)
                            //    importerAddress.AddressLine2 = collectionAddress.Substring(24, ((collectionAddress.Length > 48) ? 24 : (collectionAddress.Length - 24)));
                            //if (collectionAddress.Length >= 48)
                            //    importerAddress.AddressLine3 = collectionAddress.Substring(48, ((collectionAddress.Length > 72) ? 24 : (collectionAddress.Length - 48)));
                            //importerAddress.Postcode = listdao.CollectionPostCode;
                            //importerAddress.Town = listdao.CollectionTown;

                            ////这里要更改为国家对应的代码，此处暂未更改，以后要更改
                            //importerAddress.Country = "GB";
                            //requestShipment.ImporterAddress = importerAddress;

                            //////取件时间，From为起始取件时间，To为结束取件时间
                            //ShipService.DateTimeRange collectionTime = new ShipService.DateTimeRange();


                            //collectionTime.From = DateTime.Parse(listdao.Shippingdate + "T00:00:00");
                            //collectionTime.To = DateTime.Parse(listdao.Shippingdate + "T00:00:00");


                            //// collectionTime.From = DateTime.Parse("2014-12-18");
                            ////   collectionTime.To = DateTime.Parse("2014-12-18");

                            ////寄件包裹的地址联络人以及取件时间的设置
                            //importerCollectionInfo.CollectionAddress = importerAddress;
                            //importerCollectionInfo.CollectionContact = importerContact;
                            //importerCollectionInfo.CollectionTime = collectionTime;


                            ////
                            //requestShipment.CollectionInfo = importerCollectionInfo;
                            //设置包裹的总数量
                            //数据库中暂无此字段，这是个问题，期待解决
                            requestShipment.TotalNumberOfParcels = "1";

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


                            ShipService.Parcel parcel = new ShipService.Parcel();
                            parcel.WeightSpecified = true;
                            parcel.Weight = (decimal)listdao.Weight;
                            parcel.Width = listdao.Width.ToString();
                            parcel.Height = listdao.Height.ToString();
                            parcel.Length = listdao.Length.ToString();
                            parcel.PurposeOfShipment = "Gift";// listdao.Shippingpurpose;

                            ShipService.Parcel[] parcelInfo = new ShipService.Parcel[1];

                            ShipService.ContentDetail[] contentDetails = new ShipService.ContentDetail[1];
                            ShipService.ContentDetail contentDetail = new ShipService.ContentDetail();
                            contentDetail.CountryOfManufacture = "GB";
                            string sss = PinyinHelper.GetPinyin(listdao.PackageDescription);
                            if (sss.Length > 30)
                            {
                                sss = sss.Substring(0, 30);
                            }
                            contentDetail.Description = sss;
                            contentDetail.UnitWeight = (decimal)listdao.Weight;
                            contentDetail.UnitQuantity = "1";
                            contentDetail.UnitValue = (decimal)listdao.PackageValue;
                            contentDetail.Currency = "gbp";
                            contentDetails[0] = contentDetail;
                            parcel.ContentDetails = contentDetails;
                            parcelInfo[0] = parcel;

                            requestShipment.InternationalInfo.ShipperExporterVatNo = "GB125897969";
                            requestShipment.InternationalInfo.InvoiceDate = DateTime.Now;
                            requestShipment.InternationalInfo.TermsOfDelivery = "DDU/Incoterm 20";
                            requestShipment.InternationalInfo.Parcels = parcelInfo;

                            //ShipService.Returns ret = new ShipService.Returns();
                            //ret.ReturnsEmail = "1005780548@qq.com";
                            //ret.EmailLabel = true;
                            //ret.EmailMessage = "";
                            //requestShipment.Returns = ret;

                            ShipService.ShipPortTypeClient client = new ShipService.ShipPortTypeClient();

                            ShipService.CreateShipmentRequest shipRequest = new ShipService.CreateShipmentRequest();
                            shipRequest.Authentication = auth;
                            shipRequest.RequestedShipment = requestShipment;
                            ShipService.CreateShipmentReply shipReply = client.createShipment(shipRequest);
                            if (shipReply.Alerts != null)
                            {
                                //string alertMsg = null;
                                alertMsg += listdao.Order_no + ":";
                                //string alertMsg = null;
                                for (int ij = 0; ij < shipReply.Alerts.Length; ij++)
                                {
                                    alertMsg += shipReply.Alerts[ij].Message;
                                }
                                alertMsg += "\r\n";
                                //alert("订单号" + listdao.Order_no + alertMsg);
                            }
                            else
                            {
                                string shipNumber = shipReply.CompletedShipmentInfo.LeadShipmentNumber;

                                listdao.Ea_track_no = shipNumber;

                                new AutoOrderListDAO().updateAutoOrderListTrackNo(listdao.Order_no, listdao.S_track_no, listdao.Cd_track_no, listdao.Ea_track_no);




                                ShipService.PrintLabelRequest labelRequest = new ShipService.PrintLabelRequest();
                                labelRequest.Authentication = auth;
                                labelRequest.ShipmentNumber = shipNumber;
                                labelRequest.PrintTypeSpecified = true;
                                labelRequest.PrintType = ShipService.PrintType.ALL_PARCELS;
                                ShipService.PrintLabelReply shipLabel = client.printLabel(labelRequest);

                                byte[] byt = shipLabel.Label.Data;
                                File.WriteAllBytes(Server.MapPath("\\views\\pdf\\" + listdao.Order_no + "1.pdf"), byt);
                                //string PartnerCode = shipLabel.PartnerCode;
                                ShipService.PrintDocumentRequest documentRequest = new ShipService.PrintDocumentRequest();
                                documentRequest.Authentication = auth;
                                documentRequest.ShipmentNumber = shipNumber;
                                documentRequest.DocumentType = "1";
                                ShipService.PrintDocumentReply documentReply = client.printDocument(documentRequest);

                                byte[] documentbyt = documentReply.Label.Data;

                                File.WriteAllBytes(Server.MapPath("\\views\\pdf\\" + listdao.Order_no + "0.pdf"), documentbyt);

                                string[] pdflist = new string[2];
                                for (int jj = 0; jj < 2; jj++)
                                {
                                    pdflist[jj] = Server.MapPath("") + "\\pdf\\" + listdao.Order_no + jj.ToString() + ".pdf";
                                }
                                mergePDFFiles(pdflist, Server.MapPath("") + "\\pdf\\" + listdao.Order_no + "2.pdf");
                            }
                        }
                    }
                    if (alertMsg != null)
                    {
                        alert(alertMsg);
                    }
                    else
                    {
                        string filename = Server.MapPath("") + "\\pdf\\" + Ordernum + "2.pdf";
                        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + Ordernum + "3.pdf");

                        HttpContext.Current.Response.WriteFile(filename);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.Close();

                        //跟新显示没有下载Label的订单信息
                        ArrayList need_label = new ArrayList();
                        need_label = new AutoOrderListDAO().getAutoOrderListArrayNeedLabel(Session["name"].ToString(), "paied", "");
                        if (need_label.Count > 0)
                        {
                            bar_code.DataSource = createBarCodeTable(need_label);
                            bar_code.DataBind();
                        }
                        else
                        {
                            has_order.Visible = false;
                            has_not_order.Visible = true;
                        }
                    }

                }


            }
        }

        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
        private void mergePDFFiles(string[] fileList, string outMergeFile)
        {

            PdfReader reader;

            Document document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));

            document.Open();

            PdfContentByte cb = writer.DirectContent;

            reader = new PdfReader(fileList[0]);

            PdfImportedPage newPage;
            document.SetPageSize(reader.GetPageSize(1));
            //document.SetPageSize(new Rectangle(595, 421));
            for (int i = 0; i < fileList.Length; i++)
            {

                reader = new PdfReader(fileList[i]);

                int iPageNum = reader.NumberOfPages;

                for (int j = 1; j <= iPageNum; j++)
                {

                    document.NewPage();
                    newPage = writer.GetImportedPage(reader, j);
                    cb.AddTemplate(newPage, 0, 0);

                }

            }

            document.Close();
        }



        private DataTable createBarCodeTable(ArrayList orders_needLabel)
        {
            DataTable table = new DataTable();

            //订单号
            DataColumn dc = new DataColumn("order_number", typeof(string));
            table.Columns.Add(dc);

            //包裹个数
            dc = new DataColumn("weight", typeof(float));
            table.Columns.Add(dc);

            //发件人
            dc = new DataColumn("sender", typeof(string));
            table.Columns.Add(dc);

            //收件人
            dc = new DataColumn("receiver", typeof(string));
            table.Columns.Add(dc);

            //服务方式
            dc = new DataColumn("postway", typeof(string));
            table.Columns.Add(dc);

            //付款金额
            dc = new DataColumn("pay", typeof(string));
            table.Columns.Add(dc);

            //下单时间
            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);


            for (int i = 0; i < orders_needLabel.Count; i++)
            {


                AutoOrderList order = (AutoOrderList)orders_needLabel[i];

                DataRow dr = table.NewRow();

                dr["order_number"] = order.Order_no;
                dr["weight"] = order.Weight;
                dr["sender"] = order.CollectionContactName;
                dr["receiver"] = order.RecipientContactName;
                dr["postway"] = order.ServiceCode;
                dr["pay"] = order.Pay_after_discount;
                dr["time"] = order.Pay_time;

                table.Rows.Add(dr);

            }

            return table;
        }
    }
}