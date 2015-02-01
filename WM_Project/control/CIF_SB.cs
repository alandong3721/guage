using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace WM_Project.control
{
    public class CIF_SB
    {
        public string GenerateBarcode(string UserName, string Password, string CustomerCode, string CustomerNumber, string Range, string Serie, string Type, string MessageID, string MessageTimeStamp)
        {
            BarcodeService.GenerateBarcodeRequestContract contract = new BarcodeService.GenerateBarcodeRequestContract();


            BasicHttpBinding basichttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            basichttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            BarcodeService.BarcodeWebServiceClient barcodeservice = new BarcodeService.BarcodeWebServiceClient();



            barcodeservice.ClientCredentials.UserName.UserName = UserName;
            barcodeservice.ClientCredentials.UserName.Password = Password;


            BarcodeService.GenerateBarcodeMessage barcodeMessage = new BarcodeService.GenerateBarcodeMessage();
            BarcodeService.GenerateBarcodeCustomer generatoeCustomer = new BarcodeService.GenerateBarcodeCustomer();
            generatoeCustomer.CustomerCode = CustomerCode;
            generatoeCustomer.CustomerNumber = CustomerNumber;


            BarcodeService.GenerateBarcodeResponse barcodeResponse = new BarcodeService.GenerateBarcodeResponse();


            BarcodeService.Barcode barcode = new BarcodeService.Barcode();
            barcode.Range = Range;
            barcode.Serie = Serie;
            barcode.Type = Type;
            BarcodeService.Message message = new BarcodeService.Message();
            message.MessageID = MessageID;
            message.MessageTimeStamp = MessageTimeStamp;
            barcodeMessage.Message = message;
            barcodeMessage.Customer = generatoeCustomer;
            barcodeMessage.Barcode = barcode;




            // barcodeMessage.ExtensionData = null;
            BarcodeService.GenerateBarcodeRequestContract requestcontract = new BarcodeService.GenerateBarcodeRequestContract();
            requestcontract.GenerateBarcode = barcodeMessage;

            BarcodeService.GenerateBarcodeResponse reponse = barcodeservice.GenerateBarcode(barcodeMessage);
            return reponse.Barcode;

        }


        public byte[][] GenerateLabel(string UserName, string Password, string shipFromAddressType, string shipFromCity,
            string shipFromCompanyName, string shipFromCountrycode, string shipFromHouseNr, string shipFromName, string shipFromRemark,
            string shipFromStreet, string shipFromZipcode, string CollectionLocation, string ContactPerson, string CustomerCode,
            string CustomerNumber, string CustomerEmail, string CustomerName, string ShipmentType, string MessageID, string MessageTimeStamp,
           string Printertype, string shipToAddressType, string shipToCity, string shipToCompanyName, string shipToCountrycode,
            string shipToHouseNr, string shipToStreet, string shipToZipcode, string Barcode, string ContactType, string ContactEmail,
            string ContactSMSNr, int contentLength, string[] Content, string[] CostCenter, string[] CustomerOrderNumber, string[] CountryOfOrigin, string[] Description,
            string[] HSTariffNr, string[] contentQuantity, string[] contentValue, string[] contentWeight, string Currency, string HandleAsNonDeliverable, string Invoice,
            string InvoiceNr, string License, string LicenseNr, string Certificate, string CertificateNr, string Height, string Length,
            string Volume, string Weight, string Width, string GroupCount, string GroupSequence, string GroupType, string DownPartnerBarcode,
            string ProductCodeDelivery, string Reference)
        {
            LabelTest1.LabellingWebServiceClient client = new LabelTest1.LabellingWebServiceClient();
            client.ClientCredentials.UserName.UserName = UserName;
            client.ClientCredentials.UserName.Password = Password;
            LabelTest1.GenerateLabelRequest request = new LabelTest1.GenerateLabelRequest();
            LabelTest1.Customer customer = new LabelTest1.Customer();
            LabelTest1.Address address = new LabelTest1.Address();
            address.AddressType = shipFromAddressType;
            address.City = shipFromCity;
            address.CompanyName = shipFromCompanyName;
            address.Countrycode = shipFromCountrycode;
            address.HouseNr = shipFromHouseNr;
            address.Name = shipFromName;
            address.Remark = shipFromRemark;
            address.Street = shipFromStreet;
            address.Zipcode = shipFromZipcode;
            customer.Address = address;
            customer.CollectionLocation = CollectionLocation;
            customer.ContactPerson = ContactPerson;

            customer.CustomerCode = CustomerCode;

            customer.CustomerNumber = CustomerNumber;

            customer.Email = CustomerEmail;
            customer.Name = CustomerName;


            LabelTest1.Customs custome = new LabelTest1.Customs();
            custome.ShipmentType = ShipmentType;//"Commercial Goods";

            LabelTest1.Message message = new LabelTest1.Message();
            message.MessageID = MessageID;
            message.MessageTimeStamp = MessageTimeStamp;
            message.Printertype = Printertype;



            LabelTest1.Shipment shipment = new LabelTest1.Shipment();
            LabelTest1.Address shipmentaddress = new LabelTest1.Address();
            shipmentaddress.AddressType = shipToAddressType;
            shipmentaddress.City = shipToCity;
            shipmentaddress.CompanyName = shipToCompanyName;
            shipmentaddress.Countrycode = shipToCountrycode;
            shipmentaddress.HouseNr = shipToHouseNr;
            shipmentaddress.Street = shipToStreet;
            shipmentaddress.Zipcode = shipToZipcode;
            LabelTest1.Address[] shipmentaddresses = new LabelTest1.Address[1];
            shipmentaddresses[0] = shipmentaddress;
            shipment.Addresses = shipmentaddresses;
            shipment.Barcode = Barcode;
            LabelTest1.Contact contact = new LabelTest1.Contact();
            contact.ContactType = ContactType;
            contact.Email = ContactEmail;
            contact.SMSNr = ContactSMSNr;
            LabelTest1.Contact[] contacts = new LabelTest1.Contact[1];
            contacts[0] = contact;
            shipment.Contacts = contacts;

            LabelTest1.Content[] contents = new LabelTest1.Content[contentLength];
            for (int i = 0; i < contentLength; i++)
            {
                LabelTest1.Content content = new LabelTest1.Content();
                shipment.Content = Content[i];
                shipment.CostCenter = CostCenter[i];
                shipment.CustomerOrderNumber = CustomerOrderNumber[i];
                content.CountryOfOrigin = CountryOfOrigin[i];
                content.Description = Description[i];
                content.HSTariffNr = HSTariffNr[i];
                content.Quantity = contentQuantity[i];
                content.Value = contentValue[i];
                content.Weight = contentWeight[i];
                contents[i] = content;
            }
            custome.Content = contents;
            custome.Currency = Currency;
            custome.HandleAsNonDeliverable = HandleAsNonDeliverable;
            custome.Invoice = Invoice;
            custome.InvoiceNr = InvoiceNr;
            custome.License = License;
            custome.LicenseNr = LicenseNr;
            custome.Certificate = Certificate;
            custome.CertificateNr = CertificateNr;
            LabelTest1.Dimension dimenshin = new LabelTest1.Dimension();
            dimenshin.Height = Height;
            dimenshin.Length = Length;
            dimenshin.Volume = Volume;
            dimenshin.Weight = Weight;
            dimenshin.Width = Width;
            shipment.Dimension = dimenshin;
            shipment.DownPartnerBarcode = DownPartnerBarcode;
            LabelTest1.Group group = new LabelTest1.Group();
            group.GroupCount = GroupCount;
            group.GroupSequence = GroupSequence;
            group.GroupType = GroupType;
           // group.MainBarcode = MainBarcode;
            LabelTest1.Group[] groups = new LabelTest1.Group[1];
            groups[0] = group;
            shipment.Groups = groups;
            shipment.Customs = custome;
            shipment.ProductCodeDelivery = ProductCodeDelivery; //"3987";
            shipment.Reference = Reference;//"MYREF01";

            request.Shipment = shipment;
            request.Customer = customer;
            request.Message = message;
            LabelTest1.ResponseShipment request2 = client.GenerateLabel(request);
            // LabelTest1.ResponseShipment response = client.GenerateLabelWithoutConfirm(request);

            //  LabelTest1.Label[] labels = response.Labels;
            // File.WriteAllBytes("D:\\aaaa1.pdf", labels[0].Content);
            //string partercode = request2.DownPartnerBarcode;
            //string barcode = request2.Barcode;
            //string partnerid = request2.DownPartnerID;
            //string productdelivery = request2.ProductCodeDelivery;
            //string contenttype = request2.Labels[0].Contenttype;
            //string labeltype = request2.Labels[0].Labeltype;
            int m = request2.Labels.Length;
            byte[][] byt = new byte[m][];
            for (int i = 0; i < m; i++)
            {
                byt[i] = request2.Labels[i].Content;
                //File.WriteAllBytes("D:aaaaa" + i.ToString() + ".pdf", request2.Labels[i].Content);
            }
            return byt;
        }
    }
}