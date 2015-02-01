<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/reception-stage/batch.Master" AutoEventWireup="true" CodeBehind="local-order-pick-up.aspx.cs" Inherits="WM_Project.views.inter_express.local_order_pick_up" %>

<asp:Content ID="Content2" ContentPlaceHolderID="center" runat="server">

    <div class="panel panel-primary" style="width:60%;margin:0 auto;" id="before_login" runat="Server" visible="false">
            <div class="panel-heading">
                <h3 class="panel-title">
                    User Login</h3>
            </div>
            <div class="panel-body">
                <div class="form-group" style="height:30px;margin-top:10px">
                    <label for="username" class="col-md-3 control-label" style="padding-top:5px;text-align:right">
                        User&nbsp;&nbsp;Name:</label>
                    <div class="col-md-7" style="padding-left:0px">
                        <input type="text" class="form-control" id="txt_username" name="txt_username" placeholder="please input user name" />
                    </div>
                    <div class="col-md-2" style="color: #FF0000;padding-top:10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height:30px">
                    <label for="password" class="col-md-3 control-label" style="padding-top:5px;text-align:right">
                        Password:</label>
                    <div class="col-md-7" style="padding-left:0px">
                        <input type="password" class="form-control" name="txt_password" id="txt_password"/>
                    </div>
                    <div class="col-md-2" style="color: #FF0000;padding-top:10px">
                        *
                    </div>
                </div>
                <div class="form-group" style="height:30px">
                    <label for="code" class="col-md-3 control-label" style="padding-top:5px;text-align:right">
                        Code:</label>
                    <div class="col-md-5" style="padding-left:0px">
                        <input type="text" class="form-control" name="txt_code" id="txt_code" />
                    </div>
                    <div class="col-md-2 " style="text-align:right"><img src="../code.aspx" alt="" height="30px" onclick="this.src=this.src+'?'"/></div>
                    <div class="col-md-2" style="color: #FF0000;padding-top:10px">
                        *
                    </div>
                </div>
                
                <div class="form-group" style="height:30px;padding-top:20px">
                    <div style="text-align:center"><asp:Button ID="btn_login" runat="Server" Text="登陆" OnClientClick="return isNull();" 
                            CssClass="btn btn-info" onclick="btn_login_Click"/></div>
                </div>
            </div>
        </div>



   <div class="panel panel-primary" style="width: 100%; font-size: 16px" id="after_login" runat="Server">
        <div class=" panel-heading">
            <h5 class="panel-title">
                可能需要使用本地取件服务的国际订单</h5>
        </div>
        <div class=" panel-body" style="padding-left: 0px; padding-right: 0px">
            <div class="form-group" style="height: 40px">
                <div style="width: 160px; float: left;padding-left:30px">
                    <label class="control-label" style="text-align: right; padding-top: 6px;padding-left:10px">
                        按订单号查找</label>
                </div>
                <div style="width: 360px; float: left">
                    <input type="text" name="order_number" class="form-control" /></div>
                <div style="padding-top: 5px; color: #FF0000; width: 240px; float: left; padding-left: 10px">
                    输入EMS、PostNL 追踪号</div>
                <div style="text-align: right; width: 180px; float: left">
                    <asp:Button ID="btn_check_by_order" runat="Server" Text="查询" Width="120px" CssClass="btn btn-info"
                        OnClick="btn_check_by_order_Click" OnClientClick="return isOrderNull()" /></div>
            </div>
            <div class="form-group" style="clear: both; margin-top: 10px; margin-bottom: 10px;
                height: 2px; background: #DADADA">
            </div>
            <div class="form-group" style="height: 40px">
                <div class="control-label" style="width: 160px; float: left;padding-left:30px">
                    <label style="text-align: left; padding-top: 6px; width: 130px;padding-left:10px">
                        按时间段查找</label>
                </div>
                <div style="width: 40px; float: left">
                    <label class="control-label" style="padding-top: 6px">
                        From</label>
                </div>
                <div style="float: left;width:250px;padding-left:10px">
                    <asp:TextBox ID="txt_from" runat="Server" CssClass="form-control txt_from" onclick="new Calendar().show(this);" /></div>
                <div style="width: 60px; float: left; text-align: right">
                    <label class="control-label" style="text-align: right; padding-top: 6px; padding-right: 10px">
                        To</label>
                </div>
                <div style="width: 250px; float: left">
                    <asp:TextBox ID="txt_to" runat="Server" CssClass="form-control txt_to" onclick="new Calendar().show(this);"></asp:TextBox></div>
                <div style="text-align: right;width: 180px; float: left">
                    <asp:Button ID="btn_check_by_time" runat="Server" Text="查询" Width="120px" CssClass="btn btn-info check_by_time"
                        OnClick="btn_check_by_time_Click" OnClientClick="return isTimeNull()" /></div>
            </div>
            <div class="form-group" style="height: 36px; padding-top: 5px; padding-left: 20px;
                background: #3B84C3; color: #FFFFFF; font-size: 20px; margin-top: 16px">
                订单信息显示如下
            </div>
            <div id="has_local_order" runat="Server">
                <div class="form-group">
                    <asp:DataList ID="local_datalist" runat="Server">
                        <HeaderTemplate>
                            <div style="padding-top: 5px; padding-bottom: 5px;width:978px;height: 30px">
                                <div style="width: 5%; float: left; font-weight: 600; text-align: center">
                                    选择
                                </div>
                                <div style="width: 22%; float: left; font-weight: 600; text-align: center">
                                    订单号
                                </div>
                                <div style="width: 7%; float: left; font-weight: 600; text-align: center">
                                    包裹数
                                </div>
                                <div style="width: 9%; float: left; font-weight: 600; text-align: center">
                                    包裹重量
                                </div>
                                <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                    发件人
                                </div>
                                <div style="width: 12%; float: left; font-weight: 600; text-align: center">
                                    收件人
                                </div>
                                <div style="width: 10%; float: left; font-weight: 600; text-align: center">
                                    服务方式
                                </div>
                                <div style="width: 9%; float: left; font-weight: 600; text-align: center">
                                    付款金额
                                </div>
                                <div style="width: 14%; float: left; font-weight: 600; text-align: center">
                                    付款时间
                                </div>
                            </div>
                            <div style="background: #E4E4E4; height: 5px">
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="clear: both; padding-top: 5px; padding-bottom: 5px; height: 30px;width:978px">
                                <div style="width: 5%; float: left; text-align: center">
                                    <input type="checkbox" name="check" value='<%#DataBinder.Eval(Container.DataItem,"order_number") %>'>
                                </div>
                                <div style="width: 22%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"order_number") %>
                                </div>
                                <div style="width: 7%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"order_count") %>
                                </div>
                                <div style="width: 9%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"order_weight") %>
                                </div>
                                <div style="width: 12%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"collection_name") %>
                                </div>
                                <div style="width: 12%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"delivery_name") %>
                                </div>
                                <div style="width: 10%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"service_way") %>
                                </div>
                                <div style="width: 9%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"money_pay") %>
                                </div>
                                <div style="width: 14%; float: left; text-align: center">
                                    <%#DataBinder.Eval(Container.DataItem,"pay_time") %>
                                </div>
                            </div>
                            <div style="background: #E4E4E4; height: 5px">
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="form-group">
                    <div style="width: 400px; padding-left: 20px;float:left">
                        <input type="checkbox" name="select_all" onclick="selectAll(this)" />&nbsp;全选</div>
                    <div style="text-align: right; width: 560px;float:left">
                        <asp:Button ID="btn_local_order" runat="Server" Text="对选中进行本地下单" CssClass="btn btn-info"
                            Width="160px" OnClick="btn_local_order_Click" OnClientClick="return isChecked()" /></div>
                </div>
            </div>
            <div id="no_local_order" runat="server" visible="false" class="form-group" style="height: 200px;
                padding-top: 80px; text-align: center">
                <p style="color: #FF0000; font-size: 24px; font-weight: 600">
                    <%=message %></p>
            </div>
        </div>
        <div class="panel-footer">
            <p style="color: #3C85C4; font-size: 12px; font-weight: 500">
                *&nbsp;对选中进行本地下单时，所有选中的包裹的取件地址必须是一样的
            </p>
        </div>
    </div>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../javascripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../../script/Calendar3.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        ///登陆前的验证

        function isNull() {
            var name = document.getElementById("txt_username").value;
            var password = document.getElementById("txt_password").value;
            var code = document.getElementById("txt_code").value;

            if (name == "" || password == ""|| code=="") {
                alert("带*号的不能为空！");
                return false;
            }

            return true;
        }

        //订单号不能为空
        function isOrderNull() {
            var order = document.getElementsByName("order_number");
            if (order[0].value.trim() == "") {
                alert("订单号不能为空！！");
                return false;
            }
            return true;
        }
        //时间不能为空
        function isTimeNull() {
            var st = document.getElementById('<%=txt_from.ClientID %>').value;
            var ed = document.getElementById('<%=txt_to.ClientID %>').value;

            if (st.trim() == "") {
                alert("起始时间不能为空！！");
                return false;
            } else if (ed.trim() == "") {
                alert("终止时间不能为空！！");
                return false;
            }
            return true;
        }

        //    全选
        function selectAll(obj) {
            var checks = document.getElementsByName("check");
            for (i = 0; i < checks.length; i++) {
                checks[i].checked = obj.checked;
            }
        }


        function isChecked() {
            var checks = document.getElementsByName("check");

            k = 0;
            for (i = 0; i < checks.length; i++) {
                if (checks[i].checked == true)
                    k++;
            }
            if (k == 0) {
                alert("请选择要下单的订单!!");
                return false;
            }

        }
    </script>
</asp:Content>

