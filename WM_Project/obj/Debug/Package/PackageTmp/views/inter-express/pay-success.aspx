<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true"
    CodeBehind="pay-success.aspx.cs" Inherits="WM_Project.views.inter_express.pay_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="../../script/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../../javascripts/bootstrap.js" type="text/javascript"></script>
    
    <script src="../../script/layer.min.js" type="text/javascript"></script>
    <script src="../../javascripts/jquery-1.6.1.min.js" type="text/javascript"></script>
      <script src="../../script/jquery_ui/jquery-ui-1.11.1.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../script/jquery_ui/jquery-ui-1.11.1.custom/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function ($) {

            var successOrder = 1;
            var ii = 1;
            var i = 1;
            var total_count = $("#total_count").val();
            var progressTimer,
      progressbar = $("#progressbar"),
      progressLabel = $(".progress-label"),
      dialogButtons = [{
          text: "请等待",
          click: closeDownload
      }],
      dialog = $("#dialog").dialog({
          width: 500,
          height: 200,
          autoOpen: false,
          closeOnEscape: false,
          resizable: false,
          Modal: true,
          //buttons: dialogButtons,

          open: function () {
              $("#img").fadeOut("slow");
              $(".ui-dialog-titlebar-close").hide();
              progressTimer = setTimeout(progress, 50);
          }
      });

            if (total_count != 0) {
                $(".progress-label").text("您总共需要请求  " + total_count + " 个订单,现在正在请求第 " + ii + " 个订单");
                dialog.dialog("open");
            }
            progressbar.progressbar({
                //                value: ii / total_count,
                change: function () {
                    if (ii + 1 == total_count) {
                        progressLabel.text("您总共需要请求  " + total_count + " 个订单,现在正在请求第 " + (ii + 1) + " 个订单,已经成功请求" + (successOrder) + "个订单，失败了" + (ii - successOrder) + "个订单并且为您检查不成功的订单，并将不成功的订单进行第二次请求.....");
                    }
                    else {
                        progressLabel.text("您总共需要请求  " + total_count + " 个订单,现在正在请求第 " + (ii + 1) + " 个订单,已经成功请求" + (successOrder) + "个订单，失败了" + (ii - successOrder) + "个订单");
                    }
                },
                complete: function () {
                    progressLabel.text("完成!");
                    location.href = "order-label.aspx";

                }
            });
            function progress() {
                var val;
                progressbar.progressbar("value", (i / total_count) * 100);

                val = progressbar.progressbar("value");
                if (i <= total_count) {
                    $.ajax
                    ({
                        type: "POST",
                        url: "../views/Handler1.ashx",
                        data: { shunxu: i },
                        async: false,
                        success: function (data) {
                           
                            if (data == "success") {
                                successOrder++;
                            }
                            ii++;
                            i++;
                        }
                    });
                }
                if (val <= 99.999999) {
                    progressTimer = setTimeout(progress, 10);
                }
            }


            function OrderRequest() {
                if (total_count != 0) {
                    $(".progress-label").text("您总共需要请求  " + total_count + " 个订单,现在正在请求第 " + ii + " 个订单");
                    $(this).button("option", {
                        disabled: true,
                        label: "请求中..."
                    });
                    dialog.dialog("open");
                }
            }
            function closeDownload() {
                alert("订单正在请求中，请稍等");

            }


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">
    <div class="panel panel-primary" style="border-color: #E4E4E4; width: 100%">
        <div class="panel-heading">
            <h3 class="panel-title">
                付款成功</h3>
        </div>
    
           <div id="dialog" title="订单请求中......" >
               
  <div class="progress-label"></div>
  <div id="progressbar"></div>
     
</div>
    
    </div>


 <input id="total_count" type="hidden" value="<%=total_count%>"/>

</asp:Content>

