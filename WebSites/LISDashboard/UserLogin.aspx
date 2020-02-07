<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="CHAI.LISDashboard.Modules.Shell.Views.UserLogin"
    Title="UserLogin" MasterPageFile="~/Shared/LogInMaster.master" %>

<asp:Content ID="content1" ContentPlaceHolderID="DefaultContent" runat="Server">
        
    <div class="container">
        <section>
            <div class="tabs tabs-style-bar">
                <nav>
                    <ul>
                        <li><a href="#section-bar-1" class="fa fa-home"><span>Login</span></a></li>
                        <li><a href="#section-bar-2" class="fa fa-download"><span>Download</span></a></li>
                        <li><a href="#section-bar-3" class="fa fa-info-circle"><span>Contact Us</span></a></li>
                        <%--<li><a href="#section-bar-3" class="icon icon-display"><span>Analytics</span></a></li>
                        <li><a href="#section-bar-4" class="icon icon-upload"><span>Upload</span></a></li>
                        <li><a href="#section-bar-5" class="icon icon-tools"><span>Settings</span></a></li>--%>
                    </ul>
                </nav>
                <div class="content-wrap">
					<section id="section-bar-1">

                        <%--<div class="col-sm-12 col-md-12 col-lg-1"></div>--%>
                        <div class="col-sm-12 col-md-12 col-lg-9">
                            <%--<div class="well">--%>
                                <div class="jumbotron">
									<h1>National Laboratory Dashboard</h1>
                                    <h2>HIV Viral Load and Early Infant Diagnosis</h2>
                                    <%--<h2>Dashboard</h2>--%>
                                    <p>
                                    </p>
									<%--<p>
										Early Infant Diagnosis<br />HIV Viral Load
                                        <a class="btn btn-primary btn-lg" role="button">Learn more</a>
									</p>--%>
								</div>
                            <%--</div>--%>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <div class="well no-padding">
                                <header>Sign In
                                    <asp:UpdateProgress ID="updatePro1" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                            <ProgressTemplate>
                                                <asp:Image ImageUrl="~/img/ajax-loader2.gif" runat="server" ID="waitsymbol1" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                </header>
                                <fieldset>
                                    <asp:Label ID="lblLoginError" runat="server" CssClass="txt-color-red" EnableViewState="False"></asp:Label>
                                    <section>
                                        <label class="label">User Name</label>
                                        <label class="input">
                                            <i class="icon-append fa fa-user"></i>
                                            <asp:TextBox class="inputText" ID="txtUsername" runat="server"  ValidationGroup="Group1"></asp:TextBox>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter username</b></label>                                            
                                    </section>
                                    <section>
                                        <label class="label">Password</label>
                                        <label class="input">
                                            <i class="icon-append fa fa-lock"></i>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  ValidationGroup="Group1"></asp:TextBox>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-lock txt-color-teal"></i> Enter your password</b>
                                        </label>
                                    </section>
                                    <section>
                                        <asp:CheckBox ID="chkPersistLogin" runat="server" Text="" Font-Size="Small" Style="font-size: x-small" />
                                        Stay signed in
                                        &nbsp;&nbsp;&nbsp;                                                                                                                        
                                        <a id="lnkForgetPwd" href="#" onclick="funcForgetPassword()">Forget Password</a>
                                        <%--<button id="lnkForgetPwd" onclick="funcForgetPassword()">Forget Password</button>--%>
                                    </section>
                                </fieldset>
                                <footer>
                                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Sign in" ValidationGroup="Group1" class="btn btn-primary"></asp:Button>
                                </footer>
                            </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <%--<div class="col-sm-12 col-md-12 col-lg-1"></div>--%>

					</section>
					<section id="section-bar-2">
                        <div class="col-sm-12 col-md-12 col-lg-3"></div>
                        <div class="col-sm-12 col-md-12 col-lg-6">                            
                            <div class="well">
                                <h3 class="txt-color-green">Download EID Forms</h3>
                                <ul class="media-list">                                    
                                    <li class="media">
                                        <div class="media-body">
                                            <i class="fa fa-download" aria-hidden="true"></i>&nbsp; 
							                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/UploadFiles/DNA_PAR_RequestForm.pdf">DNA PAR Requisition Form</asp:HyperLink>
                                        </div>
                                    </li>
                                    <li class="media">
                                        <div class="media-body">
                                            <i class="fa fa-download" aria-hidden="true"></i>&nbsp; 
							                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/UploadFiles/DNA_PCR_ReqFormDef.pdf">Guidelines for DNA PCR Requisition Form Definition</asp:HyperLink>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="well">                            
                                <h3 class="txt-color-green">Download Viral Load Forms</h3>
                                <ul class="media-list">
                                    <li class="media">
                                        <div class="media-body">
                                            <i class="fa fa-download" aria-hidden="true"></i>&nbsp; 
							                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/UploadFiles/ViralLoadRequestForm.pdf">HIV Viral Load Requisition Form</asp:HyperLink>
                                        </div>
                                    </li>
                                    <li class="media">
                                        <div class="media-body">
                                            <i class="fa fa-download" aria-hidden="true"></i>&nbsp; 
							                    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/UploadFiles/HIVViralLoad_ReqFormDef.pdf">HIV Viral Load Requisition Form Definition</asp:HyperLink>
                                        </div>
                                    </li>
                                    <li class="media">
                                        <div class="media-body">
                                            <i class="fa fa-download" aria-hidden="true"></i>&nbsp; 
						                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UploadFiles/HIVViralLoad_LabRegister.pdf">Health Facility Laboratory Register (HIV Viral Load)</asp:HyperLink>
                                        </div>
                                    </li>
                                    <li class="media">
                                        <div class="media-body">
                                            <i class="fa fa-download" aria-hidden="true"></i>&nbsp; 
						                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/UploadFiles/HIVViralLoad_LabDef.pdf">Health Facility Laboratory Register Definition (HIV Viral Load)</asp:HyperLink>
                                        </div>
                                    </li>
                                </ul>                            
                            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-3"></div>
                    </section>
                    <section id="section-bar-3">
                        <!-- Contact Form -->
                        <%--<div class="well">--%>
                            <div class="col-sm-12 col-md-12 col-lg-3"></div>
                            <article class="col-sm-12 col-md-12 col-lg-6 sortable-grid ui-sortable">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <div class="well no-padding">
                                    <header>Contact Us
                                        <asp:UpdateProgress ID="updatePro2" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                            <ProgressTemplate>
                                                <asp:Image ImageUrl="~/img/ajax-loader2.gif" runat="server" ID="waitsymbol2" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </header>
                                    <fieldset>
                                        <div class="row">
                                            <section class="col col-12">
                                                <asp:Label ID="lblContactUsError" runat="server" CssClass="txt-color-red" EnableViewState="False"></asp:Label>
                                            </section>
                                        </div>
                                        <div class="row">
									        <section class="col col-6">
										        <label class="label">Name</label>
                                                <asp:Label class="input" id="lblGroupName" runat="server">
                                                    <i class="icon-append fa fa-user"></i>
                                                    <asp:TextBox class="inputText" ID="txtName" runat="server" ValidationGroup="Group2"></asp:TextBox>
                                                    <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter name</b>                                                    
                                                </asp:Label>										    
									        </section>
									        <section class="col col-6">										       
                                                <label class="label">Facility / Organization</label>
									            <asp:Label class="input" id="lblGroupFacility"  runat="server">
										            <i class="icon-append fa fa-hospital-o"></i>										
                                                    <asp:TextBox class="inputText" ID="txtFacility" runat="server" ValidationGroup="Group2"></asp:TextBox>
                                                    <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter facility</b>
									            </asp:Label>
									        </section>
								        </div>								
                                        <div class="row">
                                            <section class="col col-6">
									            <label class="label">Phone</label>
									            <asp:Label class="input" id="lblGroupPhone" runat="server">
										            <i class="icon-append fa fa-phone"></i>										
                                                    <asp:TextBox class="inputText" ID="txtPhone" runat="server" ValidationGroup="Group2"></asp:TextBox>
                                                    <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter phone</b>
									            </asp:Label>
								            </section>
								            <section class="col col-6">
                                                <label class="label">E-mail</label>
										        <asp:Label class="input" id="lblGroupEmail" runat="server">
											        <i class="icon-append fa fa-envelope-o"></i>											    
                                                    <asp:TextBox class="inputText" ID="txtEmail" runat="server"  ValidationGroup="Group2"></asp:TextBox>
                                                    <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter email</b>                                                    
										        </asp:Label>									            
								            </section>
                                        </div>
                                        <section>
									        <label class="label">Subject</label>
									        <asp:Label class="input" id="lblSubject" runat="server">
										        <i class="icon-append fa fa-tag"></i>										
                                                <asp:TextBox class="inputText" ID="txtSubject" runat="server" ValidationGroup="Group2"></asp:TextBox>
                                                <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter subject</b>
									        </asp:Label>
								        </section>
								        <section>
									        <label class="label">Message</label>
									        <asp:Label class="textarea" id="lblGroupMessage" runat="server">
										        <i class="icon-append fa fa-comment"></i>
                                                <asp:TextBox class="inputText" ID="txtMessage" runat="server" TextMode="MultiLine" ValidationGroup="Group2"></asp:TextBox>
										        <%--<textarea rows="4" name="message" id="message"></textarea>--%>
									        </asp:Label>
								        </section>                                        

								        <%--<section>
									        <label class="checkbox"><input type="checkbox" name="copy" id="copy"><i></i>Send a copy to my e-mail address</label>
								        </section>--%>
                                    </fieldset>
                                    <footer>
                                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" class="btn btn-primary" ValidationGroup="Group2"></asp:Button>
                                    </footer>
                                </div>
				                </ContentTemplate>
                            </asp:UpdatePanel>
                            </article>
			            
                            <div class="col-sm-12 col-md-12 col-lg-3"></div>
                        <%--</div>--%>
                        <!-- End of Contact Form -->

					</section>					
				</div>
            </div>
            <!-- /tabs -->
        </section>        
    </div>
    <!-- /container -->




    

    <%--<div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 hidden-xs hidden-sm" style="margin-top: 20px">        
    </div>
    <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 hidden-xs hidden-sm" style="margin-top: 20px; text-align: left">
    </div>
    <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 hidden-xs hidden-sm" style="margin-top: 20px; text-align: left">        
        <ul>                                      
            <li>
                <i class="fa fa-download" aria-hidden="true"></i>&nbsp;
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/UploadFiles/ViralLoadRequestForm.pdf">HIV Viral Load Requisition Form</asp:HyperLink>
			</li>
            <li>
                <i class="fa fa-download" aria-hidden="true"></i>&nbsp;
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/UploadFiles/DNA_PAR_RequestForm.pdf">DNA PAR Requisition Form</asp:HyperLink>
			</li>
            <li>
                <i class="fa fa-download" aria-hidden="true"></i>&nbsp;
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/UploadFiles/DNA_PCR_ReqFormDef.pdf">Guidelines for DNA PCR Requisition form_Final</asp:HyperLink>
			</li>			
		</ul>
        <br />
        <ul style="list-style-type: none; line-height: 25px">
			<li>
                <i class="fa fa-download" aria-hidden="true"></i>&nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UploadFiles/HIVViralLoad_LabDef.pdf">Health Facility Laboratory Register Definition (HIV Viral Load)</asp:HyperLink>                                        
			</li>
			<li>
                <i class="fa fa-download" aria-hidden="true"></i>&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UploadFiles/HIVViralLoad_LabRegister.pdf">Health Facility Laboratory Register (HIV Viral Load)</asp:HyperLink>
			</li>
            <li>
                <i class="fa fa-download" aria-hidden="true"></i>&nbsp;
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/UploadFiles/HIVViralLoad_ReqFormDef.pdf">HIV Viral Load Requisition Form Definition</asp:HyperLink>
			</li>
        </ul>
        
    </div>--%>    
</asp:Content>

