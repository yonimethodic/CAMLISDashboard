<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="ShellDefault"
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

    <div id="content">
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
            <div class="col-sm-12 col-md-12 col-lg-12">
                <div class="well">								
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
				</div>                
            </div>
        </div>

        <div class="row">
						<%--<h2 class="row-seperator-header"><i class="fa fa-square-o"></i> Containers, Media and Pagination</h2>--%>
						<div class="col-sm-12 col-md-12 col-lg-6">                                                                                   				
							<div class="well">				
                                <h3 class="text-primary">Address</h3>
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
                                </address>

								<%--<h3>Jumbotron <small>Gets your user attention!</small></h3>--%>				
								<div class="jumbotron">
									<h1>National Laboratory</h1>
                                    <h2>Dashboard</h2>
									<p>
										This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.
									</p>
									<%--<p>
										<a class="btn btn-primary btn-lg" role="button">Learn more</a>
									</p>--%>
								</div>
				
								<%--<h3>Wells <small>Notice the well sizes</small></h3>
				
								<div class="well well-lg">
									Large well
									<br>
									<code>
										.well .well-lg</code>
								</div>
				
								<div class="well ">
									Default well
									<br>
									<code>
										.well</code>
								</div>
				
								<div class="well well-sm well-light">
									Small well with light background
									<br>
									<code>
										.well .well-sm .well-light</code>
								</div>--%>
				
								<div class="row">
				
									<div class="col-sm-6">
				
										<div class="well well-sm bg-color-red txt-color-white text-center">
											<h5><i class="fa fa-child"></i> Early Infant Diagnosis</h5>
											<%--<code>.bg-color-darken</code>--%>
										</div>
				
									</div>
				
									<div class="col-sm-6">
				
										<div class="well well-sm bg-color-green txt-color-white text-center">
											<h5><i class="fa fa-bar-chart-o"></i> HIV Viral Load</h5>
											<%--<code>.bg-color-teal</code>--%>
										</div>
				
									</div>
                                
                                </div>
				                <div class="row">
								
                                    <div class="col-sm-6">
				
										<div class="well well-sm bg-color-magenta txt-color-white text-center">
											<h5><i class="fa fa-flask"></i> Laboratory</h5>
											<%--<code>.bg-color-pinkDark</code>--%>
										</div>
				
									</div>

                                    <div class="col-sm-6">
				
										<div class="well well-sm bg-color-orange txt-color-white text-center">
											<h5><i class="fa fa-pencil-square-o"></i> Reports</h5>
											<%--<code>.bg-color-pinkDark</code>--%>
										</div>
				
									</div>
				
								</div>
								<%--<p>
									Learn more about other colors that you can use for .well by going to <a href="typography.html"> typography page</a>
								</p>--%>				
							</div>
				
						</div>
				
						<div class="col-sm-12 col-md-12 col-lg-6">				
                            <div class="well">
								<%--<h3><code></code></h3>
								<p><code></code></p>--%>
								<div id="myCarousel2" class="carousel fade">
									<ol class="carousel-indicators">
										<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
										<li data-target="#myCarousel" data-slide-to="1" class=""></li>
										<li data-target="#myCarousel" data-slide-to="2" class=""></li>
									</ol>
									<div class="carousel-inner">
										<!-- Slide 1 -->
										<div class="item active">
											<img src="img/demo/m1.jpg" alt="">
											<div class="carousel-caption caption-right">
												<h4>Title 1</h4>
												<p>
													Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
												</p>
												<br>
												<a href="javascript:void(0);" class="btn btn-info btn-sm">Read more</a>
											</div>
										</div>
										<!-- Slide 2 -->
										<div class="item">
											<img src="img/demo/m2.jpg" alt="">
											<div class="carousel-caption caption-left">
												<h4>Title 2</h4>
												<p>
													Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
												</p>
												<br>
												<a href="javascript:void(0);" class="btn btn-danger btn-sm">Read more</a>
											</div>
										</div>
										<!-- Slide 3 -->
										<div class="item">
											<img src="img/demo/m3.jpg" alt="">
											<div class="carousel-caption">
												<h4>A very long thumbnail title here to fill the space</h4>
												<br>
											</div>
										</div>
									</div>
									<a class="left carousel-control" href="#myCarousel" data-slide="prev"> <span class="glyphicon glyphicon-chevron-left"></span> </a>
									<a class="right carousel-control" href="#myCarousel" data-slide="next"> <span class="glyphicon glyphicon-chevron-right"></span> </a>
								</div>				
							</div>

							<%--<div class="well">
                                <div id="bigBox13" class="bigBox animated fadeIn fast" style="background-color: rgb(50, 118, 177);">
                                    <div id="bigBoxColor13">
                                        <i class="botClose fa fa-times" id="botClose13"></i>
                                        <span>Big Information box</span><p>Lorem ipsum dolor sit amet, test consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam</p>
                                        <div class="bigboxicon"><i class="fa fa-bell swing animated"></i></div>
                                        <div class="bigboxnumber">2</div>
                                    </div>
                                </div>

                                <div class="text-center">
                                    <img src="img/demo/demo-smartbig-alert.png" alt="demo" class="img-responsive">
                                </div>
				
								<h3>Media</h3>
				
								<ul class="media-list">
									<li class="media">
										<a class="pull-left" href="javascript:void(0);"> <img class="media-object" alt="64x64" src="img/demo/64x64.png"> </a>
										<div class="media-body">
											<h4 class="media-heading">Media heading</h4>
											<p>
												Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
											</p>
											<!-- Nested media object -->
											<div class="media">
												<a class="pull-left" href="javascript:void(0);"> <img class="media-object" alt="64x64" src="img/demo/64x64.png"> </a>
												<div class="media-body">
													<h4 class="media-heading">Nested media heading</h4>
													Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
													<!-- Nested media object -->
													<div class="media">
														<a class="pull-left" href="javascript:void(0);"> <img class="media-object" alt="64x64" src="img/demo/64x64.png"> </a>
														<div class="media-body">
															<h4 class="media-heading">Nested media heading</h4>
															Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
														</div>
													</div>
												</div>
											</div>
											<!-- Nested media object -->
											<div class="media">
												<a class="pull-left" href="javascript:void(0);"> <img class="media-object" alt="64x64" src="img/demo/64x64.png"> </a>
												<div class="media-body">
													<h4 class="media-heading">Nested media heading</h4>
													Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
												</div>
											</div>
										</div>
									</li>
									<li class="media">
										<a class="pull-left" href="javascript:void(0);"> <img class="media-object" alt="64x64" src="img/demo/64x64.png"> </a>
										<div class="media-body">
											<h4 class="media-heading">Media heading</h4>
											Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
										</div>
									</li>
								</ul>
				
							</div>--%>				                            

							<%--<div class="well well-light">
								<h3>Pagination <small>two different styles</small></h3>
								<div class="text-center">
									<ul class="pagination pagination-lg">
										<li>
											<a href="javascript:void(0);"><i class="fa fa-chevron-left"></i></a>
										</li>
										<li class="active">
											<a href="javascript:void(0);">1</a>
										</li>
										<li>
											<a href="javascript:void(0);">2</a>
										</li>
										<li>
											<a href="javascript:void(0);">3</a>
										</li>
										<li>
											<a href="javascript:void(0);">4</a>
										</li>
										<li>
											<a href="javascript:void(0);">5</a>
										</li>
										<li>
											<a href="javascript:void(0);"><i class="fa fa-chevron-right"></i></a>
										</li>
									</ul>
									&nbsp; &nbsp;
									<ul class="pagination pagination-alt pagination-lg">
										<li>
											<a href="javascript:void(0);"><i class="fa fa-angle-left"></i></a>
										</li>
										<li>
											<a href="javascript:void(0);">1</a>
										</li>
										<li>
											<a href="javascript:void(0);">2</a>
										</li>
										<li>
											<a href="javascript:void(0);">3</a>
										</li>
										<li class="active">
											<a href="javascript:void(0);">4</a>
										</li>
										<li>
											<a href="javascript:void(0);">5</a>
										</li>
										<li>
											<a href="javascript:void(0);"><i class="fa fa-angle-right"></i></a>
										</li>
									</ul>
								</div>
								<div class="text-center">
									<ul class="pagination">
										<li>
											<a href="javascript:void(0);"><i class="fa fa-arrow-left"></i></a>
										</li>
										<li>
											<a href="javascript:void(0);">1</a>
										</li>
										<li class="active">
											<a href="javascript:void(0);">2</a>
										</li>
										<li>
											<a href="javascript:void(0);">3</a>
										</li>
										<li>
											<a href="javascript:void(0);">4</a>
										</li>
										<li>
											<a href="javascript:void(0);">5</a>
										</li>
										<li>
											<a href="javascript:void(0);"><i class="fa fa-arrow-right"></i></a>
										</li>
									</ul>
									&nbsp; &nbsp;
									<ul class="pagination pagination-alt">
										<li>
											<a href="javascript:void(0);"><i class="fa fa-angle-left"></i></a>
										</li>
										<li>
											<a href="javascript:void(0);">1</a>
										</li>
										<li>
											<a href="javascript:void(0);">2</a>
										</li>
										<li>
											<a href="javascript:void(0);">3</a>
										</li>
										<li class="active">
											<a href="javascript:void(0);">4</a>
										</li>
										<li>
											<a href="javascript:void(0);">5</a>
										</li>
										<li>
											<a href="javascript:void(0);"><i class="fa fa-angle-right"></i></a>
										</li>
									</ul>
								</div>
								<div class="text-center">
									<ul class="pagination pagination-sm">
										<li>
											<a href="javascript:void(0);"><i class="fa fa-angle-left"></i></a>
										</li>
										<li>
											<a href="javascript:void(0);">1</a>
										</li>
										<li>
											<a href="javascript:void(0);">2</a>
										</li>
										<li class="active">
											<a href="javascript:void(0);">3</a>
										</li>
										<li>
											<a href="javascript:void(0);">4</a>
										</li>
										<li>
											<a href="javascript:void(0);">5</a>
										</li>
										<li>
											<a href="javascript:void(0);"><i class="fa fa-angle-right"></i></a>
										</li>
									</ul>
									&nbsp; &nbsp;
									<ul class="pagination pagination-sm pagination-alt">
										<li>
											<a href="javascript:void(0);">«</a>
										</li>
										<li>
											<a href="javascript:void(0);">1</a>
										</li>
										<li>
											<a href="javascript:void(0);">2</a>
										</li>
										<li class="active">
											<a href="javascript:void(0);">3</a>
										</li>
										<li>
											<a href="javascript:void(0);">4</a>
										</li>
										<li>
											<a href="javascript:void(0);">5</a>
										</li>
										<li>
											<a href="javascript:void(0);">»</a>
										</li>
									</ul>
								</div>
								<div style="width:200px; margin:0 auto">
									<ul class="pager">
										<li class="previous disabled">
											<a href="javascript:void(0);">← Older</a>
										</li>
										<li class="next">
											<a href="javascript:void(0);">Newer →</a>
										</li>
									</ul>
								</div>
				
							</div>--%>
				
						</div>
				
					</div>
    </div>        

</asp:Content>
