<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/home.Master" AutoEventWireup="true"
    CodeBehind="frequent-ask-question.aspx.cs" Inherits="WM_Project.views.frequent_ask_question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center_right" runat="server">
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h5 class="panel-title">Frequent Asked Question</h5>
            </div>
            <div class="panel-body" style="padding-left: 1cm; padding-right: 1cm">
                <h2>
                    <strong>FAQ</strong></h2>
                <hr style="border: 2px solid #c8c3c3; width: 100%" />
                <ol>
                    <li><strong>What is my colleciton date?</strong>
                        <p>
                            The collection date is the date you want your parcel to be collected for forwarding.
                            It should be between Monday to Friday (Except Bank Holidays) and on the second day
                            after you place your order. Same day collection services may be arranged if you
                            are able to complete your online order, payment process and has facility to print
                            out the required documents by 12.00am. Please call customer service for further
                            details.
                        </p>
                    </li>
                    <li><strong>How did you caculate my shipping fee?</strong>
                        <p>
                            shipping fee is based on the greater value of actural weight and volume weight of
                            your parcel. Parcel’s volume weight =（Parcel lengthxParcel WidthxParcel Height）/5000。
                            For example，if you would like to send a 3kg parcel with a size of 34cmx30.5cmx30.5cm。Its
                            volume weight =（34×30.5×30.5）/5000 = 6.3kg > 3kg. Therefore, our shipping fee will
                            be caculated as if you are sending a 6.3kg parcel rather than its actural weight
                            3kg.
                        </p>
                    </li>
                    <li><strong>What will happen if the weight I provided is not accurate?</strong>
                        <p>
                            We understand the weight our customer provided is not always as accuate as it should
                            be. Please make all your effort to ensure you provide the actural weight and size
                            as accurate as possible. Parcel Force has special equipments to accurately measure
                            the actural weight and size of all the parcels you sent and issue bills correctly.
                            We trust our customer’s personality and good will, so we will collect your shipping
                            fee and arrange parcel collection based on the information you provided. When we
                            receive the final bill from Parcel Force , we will compare it with the information
                            you provided and ask for the outstanding balance. If we find the informaton you
                            provided is far off how it should i.e. 1kg or 5cm inaccuracy , we will charge an
                            administration fee on top of your outstanding balance.
                        </p>
                    </li>
                    <li><strong>Where can I get my Parcel Force tracking No.?</strong>
                        <p>
                            Once we booked a parcel collection for you, a confirmation email will be sent to
                            you with completed custom declaration form and parcel label. You can find your parcel
                            force tracking No. on them or simply input your WM Express tracking No. (same as
                            Transaction ID in your invoice) into our website to obtain your Parcel Force tracking
                            No. i.e. EK123456789GB.
                        </p>
                    </li>
                    <li><strong>What will happen if the collection driver didn’t come on the confirmed collection
                        date?</strong>
                        <p>
                            If this situation does happen, please contact us immediately. If this happend because
                            of your own reason i.e. you didn’t wait for the collection driver as confirmed,
                            the driver came but no one answered the door and driver left a miss collection card,
                            your parcel was not ready when the driver came,we will charge you a fee to rearrange
                            your parcel collection. If it is not your fault, we will rearrange your parcel collection
                            for free.
                        </p>
                    </li>
                    <li><strong>What’s the difference between Parcel Force express and UK-China/HongKong
                        air freight?</strong>
                        <p>
                            Both of them are using air freight shipping method, fully trackable with compensation
                            included. Parcel Force express is like you taking direct flight to your destanation
                            while UK-China/Hongkong air freight is like indirect flight. Parcel Force express
                            is straightforward and faster but with higher shipping fee excluding custom tax.
                            It normally takes 3-8 days to get your parcel delivered. UK-China/Hongkong air freight
                            is safe and more economy with custom tax paid. It normally takes 2-3 weeks to get
                            your parcel delivered.For airfreight service,the compensation for goods lost is
                            up to 100RMB per kg.
                        </p>
                    </li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
