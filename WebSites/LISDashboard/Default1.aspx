<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="ShellDefault"
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

    <div id="content" style="padding: 0px 0px !important;">
        <%--<div class="row">
			<div class="col-sm-12 col-md-12 col-lg-12">
				<div class="well" style="padding: 0px;">					
					<div class="jumbotron">
                        <h2>National Laboratory Dashboard</h2>                        
					</div>
                </div>
            </div>
        </div>--%>
        <div class="row">
            <div class="col-sm-24 col-md-12 col-lg-12">
                <%--<div class="well">--%>
					<div id="myCarousel" class="carousel fade">
						<ol class="carousel-indicators">
							<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
							<li data-target="#myCarousel" data-slide-to="1" class=""></li>
							<li data-target="#myCarousel" data-slide-to="2" class=""></li>
                            <li data-target="#myCarousel" data-slide-to="3" class=""></li>
                            <li data-target="#myCarousel" data-slide-to="4" class=""></li>                            
						</ol>
						<div class="carousel-inner">
							<!-- Slide 1 -->
							<div class="item active">
								<img src="img/demo/t1.jpg" alt="">
								<div class="carousel-caption caption-right">
									<%--<h4>Title 1</h4>--%>
									<p>
                                        Welcome to LabAcceX . . .
									</p>
									<%--<br>
									<a href="javascript:void(0);" class="btn btn-info btn-sm">Read more</a>--%>
								</div>
							</div>
							<!-- Slide 2 -->
							<div class="item">
								<img src="img/demo/t2.jpg" alt="">
								<div class="carousel-caption caption-left">
									<%--<h4>Title 2</h4>--%>
									<p>
                                        Refresher Training on Laboratory Information Management System
                                        <br />for HIV Viral Load and EID
									</p>
									<%--<br>
									<a href="javascript:void(0);" class="btn btn-danger btn-sm">Read more</a>--%>
								</div>
							</div>
							<!-- Slide 3 -->
							<div class="item">
								<img src="img/demo/t3.jpg" alt="">
								<div class="carousel-caption caption-left">
									<%--<h4>Title 3</h4>--%>
									<p>
                                        Refresher Training on Laboratory Information Management System
                                        <br />for HIV Viral Load and EID
									</p>
								</div>
							</div>
                            <!-- Slide 4 -->
                            <div class="item">
								<img src="img/demo/t4.jpg" alt="">
								<div class="carousel-caption caption-left">
									<%--<h4>Title 4</h4>--%>
									<p>
                                        Refresher Training on Laboratory Information Management System
                                        <br />for HIV Viral Load and EID
									</p>
								</div>
							</div>
                            <!-- Slide 5 -->
							<div class="item">
								<img src="img/demo/t5.jpg" alt="">
								<div class="carousel-caption caption-left">
									<%--<h4>Title 5</h4>--%>
									<p>
										Refresher Training on Laboratory Information Management System
                                        <br />for HIV Viral Load and EID
									</p>
									<%--<br>
									<a href="javascript:void(0);" class="btn btn-danger btn-sm">Read more</a>--%>
								</div>
							</div>
						</div>
						<a class="left carousel-control" href="#myCarousel" data-slide="prev"> <span class="glyphicon glyphicon-chevron-left"></span> </a>
						<a class="right carousel-control" href="#myCarousel" data-slide="next"> <span class="glyphicon glyphicon-chevron-right"></span> </a>
					</div>				
				<%--</div>--%>
            </div>
        </div>

        
    </div>        

</asp:Content>
