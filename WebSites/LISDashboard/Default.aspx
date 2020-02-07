<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ShellDefault"
    MasterPageFile="~/Shared/DefaultMaster.master" %>

<%@ MasterType TypeName="CHAI.LISDashboard.Modules.Shell.BaseMaster" %>
<asp:Content ID="content1" ContentPlaceHolderID="DefaultContent" runat="Server">

    <%--<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCv-JsUDEbcS6fa4XwF5FkSllHBM7oAKNo"
  type="text/javascript"></script>
	<script>
		function InitializeMap() 
		{				
			var latlng = new google.maps.LatLng(16.919701, 97.367798);
			var myOptions = {
			    zoom: 8,
			    center: latlng,
			    mapTypeId: google.maps.MapTypeId.ROADMAP
			};
			var map = new google.maps.Map(document.getElementById("googleMap"), myOptions);

		}
		window.onload = InitializeMap;
	</script>
    <div id="googleMap" style="width:100%;height:400px;"></div>--%>

    <div id="content" style="background-color: #fafafa;">
        <%--<div class="row">			
			<div class="col-sm-12 col-md-12 col-lg-12">				
				<div class="well" style="height: 115px;">
					<h3>Jumbotron <small>Gets your user attention!</small></h3>
					<div class="jumbotron">
                        <h2>National Laboratory Dashboard</h2>
                        <h2>Dashboard</h2>
						<p>
							This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.
				        </p>
					</div>
                </div>
            </div>
        </div>--%>
              
        <div class="row">
						<%--<h2 class="row-seperator-header"><i class="fa fa-square-o"></i> Containers, Media and Pagination</h2>--%>
						<div class="col-sm-18 col-md-18 col-lg-8">                                                                                   				
							<div class="well">				
                                <%--<h3 class="text-primary">Address</h3>
                                <address>
                                    <strong>Clinton Health Access Initiative (CHAI)</strong><br />
                                    No. 46 Pan Tra St<br />
                                    Room 1-A, First Floor, New Excellent Condo<br />
                                    Dagon Township, Yangon, Myanmar<br />
                                    <abbr title="Phone"><span class="fa fa-phone"></span></abbr> (+95) 456-7890
                                </address>
                                <address>
                                    <strong>Dr. Than Htike Oo</strong><br>
                                    <a href="mailto:#">chai.lims.mm@gmail.com</a>
                                </address>--%>
								<div class="jumbotron">
									<h1>National Laboratory Dashboard</h1>
                                    <h2>HIV Viral Load and Early Infant Diagnosis</h2>                                                                                                      
									<p>                                        
                                        This dashboard displays all the information on HIV Viral Load and Early Infant Diagnosis testing captured by Lab Information Management System called “LIMSLite”. LIMSLite system was currently being deploying in  public labs in Cameroon.
									</p>									
								</div>
							</div>

				
					</div>
    </div>        

</asp:Content>
