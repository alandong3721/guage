<script type="text/javascript">
		 	  $(function(){
		 	  	    var temp='<div style="width:420px; height:260px; padding:20px; border:1px solid #ccc; background-color:#eee;"><p>我从左边来，我自定了风格。</p><button id="pagebtn" class="btns" onclick="">关闭</button></div>';
		 	  	    var temp='<div id="login">'+
							            '<table border="0" cellspacing="0" cellpadding="0" width="500">'+
							                '<tr>'+
							                    '<td style="height:40px;background:#83C75D;padding-left:20px" valign="middle" colspan="3" class="font">Member Login</td>'+
							                '</tr>'+
							                '<tr style="height:40px">'+
							                    '<td class="td_text">user name:</td>'+
							                    '<td style="width:200px"><input name="ctl00$left_part$txt_name" type="text" id="left_part_txt_name" style="height:20px;width:200px;" /></td>'+
							                    '<td class="red_color">*</td>'+
							                '</tr>'+
							                '<tr style="height:40px">'+
							                    '<td class="td_text">password:</td>'+
							                    '<td><input name="ctl00$left_part$txt_pwd" type="password" id="left_part_txt_pwd" style="height:20px;width:200px;" /></td>'+
							                    '<td class="red_color">*</td>'+
							                '</tr>'+
							                '<tr style="height:40px">'+
							                    '<td class="td_text">code:</td>'+
							                    '<td valign="middle">'+
							                        '<div style="width:200px;height:22px">'+
							                            '<div style="width:80px;height:22px;float:left;margin-left:2px;padding-top:3px"><input name="ctl00$left_part$txt_code" type="text" id="left_part_txt_code" style="height:20px;width:80px;" />'+
							                            '</div>'+
							                            '<div style="width:60px;height:22px;float:left;margin-left:8px;padding-top:4px">'+
							                            '<img id="codeImg" alt="" src="../views/code.aspx" width="60px" height="20px" onclick="this.src=this.src+ &apos;? &apos;" />'+
							                            '</div>'+
							                        '</div>'+
							                    '</td>'+
							                    '<td class="red_color">*</td>'+
							                '</tr>'+
							                '<tr style="height:40px">'+
							                    '<td colspan="3" align="center">'+
							                        '<input type="image" name="ctl00$left_part$img_login" id="left_part_img_login" src="../images/login.jpg" />'+
							                    '</td>'+
							                '</tr>'+
							                '<tr style="height:40px">'+
							                    '<td colspan="3" align="center"></td>'+
							                '</tr>'+
							        '</table>'+'</div>';
				  	$("#login").click(function(){
				  	    var pageii = $.layer({
					    type: 1,
					    title: false,
					    area: ['auto', 'auto'],
					    border: [0], //去掉默认边框
					    shade: [0.8, '#000'], 
					    closeBtn: [1, true], //去掉默认关闭按钮
					    shift: 'left', //从左动画弹出
					    page: {
					             html: temp
					    }
						});
						$("#pagebtn").click(function(){
							layer.close(pageii);
						});
				  	});
				  });
		</script>