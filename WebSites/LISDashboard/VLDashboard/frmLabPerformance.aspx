<%@ Page Title="Lab Performance" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="frmLabPerformance.aspx.cs" Inherits="CHAI.LISDashboard.Modules.VLDashboard.Views.frmLabPerformance" %>


<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
     <script src="../js/libs/jquery-2.0.2.min.js"></script>
      <!-- HIGHCHART:  -->
    <script src="../js/plugin/HighCharts/highcharts.js"></script>
    <script src="../js/plugin/HighCharts/exporting.js"></script>
    <script src="../js/plugin/HighCharts/export-data.js"></script>
    
    

    <script type="text/javascript">
   
</script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'MM/DD/YYYY'
            });
            $('#datetimepicker2').datetimepicker({
                format: 'MM/DD/YYYY'
            });
            // Testing Trends by Valid Test 
            
            $(function GetVLValidTestTrends() {
                var subject = JSON.parse('<%=JstringVLTestingTrends%>');
                var series = [],categories=[],data=[],name=[];
                                
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                
                BindVLValidTestTrends(categories, series);
                function BindVLValidTestTrends(categories, series) {
                    window.chart = new Highcharts.chart('ValidTestTrends', {
                        chart: {
                            type: 'spline',
                            height: 300,
                            marginRight: 120
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Total Tests'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            floating: false,
                            y: 0,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
            // labs Rejection Trends
            
            $(function GetVLLabRejectionTrends() {
                var subject = JSON.parse('<%=JstringVLRejectionTrends%>');
                var series = [],categories=[],data=[],name=[];
                                
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                
                    BindVLLabRejectionTrends(categories, series);
                    function BindVLLabRejectionTrends(categories, series) {
                        window.chart = new Highcharts.chart('LabRejectionTrend', {
                        chart: {
                            type: 'spline',
                            height: 300,
                            marginRight: 120
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Total Rejected Samples'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 0,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
            // Testing By Sample Type  
            $(function GetTestingSampleTypedata() {
                var subject = JSON.parse('<%=JstringVLLAbSampleTypeTrends%>');
                var series = [],categories = [],DBS = [],WholeBlood = [],Plasma = [];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    DBS.push(subject[i][0] );
                    WholeBlood.push(subject[i][1] );
                    Plasma.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'DBS' ,
                    data: DBS
                    
                },
                {
                    name: 'Whole Blood ',
                    data: WholeBlood
                },

                {
                    name: 'Plasma' ,
                    data: Plasma
                }
                );

                BindTestingSampleType(categories, series);
                function BindTestingSampleType(categories, series) {
                    window.chart = new Highcharts.chart('testSampleType', {
                        chart: {
                            type: 'column',
                            marginBottom: 120
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            },
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        },
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            x: 0,
                            verticalAlign: 'bottom',
                            y: 0,
                            floating: false,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series
                    });
                }
            });
            // Testing By Gender 
            $(function GetLABTestingGenderdata() {
                var subject = JSON.parse('<%=JstringVLLAbGenderTrends%>');
                var series = [], categories = [], Male = [], Female = [], Not_Indicated_on_Form = [];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    Male.push(subject[i][1]);
                    Female.push(subject[i][0]);
                    Not_Indicated_on_Form.push(subject[i][3]);
                    
                }
                series.push({
                    name: 'Male' ,
                    data: Male
                    
                },
                {
                    name: 'Female',
                    data: Female
                },

                {                
                    name: 'Not Indicated on Form ',
                    data: Not_Indicated_on_Form
                }
                );

                BindTestingGender(categories, series);
                function BindTestingGender(categories, series) {
                    window.chart = new Highcharts.chart('testGender', {
                        chart: {
                            type: 'column',
                            marginBottom: 120
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            },
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        },
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            x: 0,
                            verticalAlign: 'bottom',
                            y: 0,
                            floating: false,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series
                    });
                }
            });
            // Testing By Age 
            $(function GetLABTestingAgedata() {
                var subject = JSON.parse('<%=JstringVLLAbAgeTrends%>');
                var series = [], categories = [], Childern = [], Adult = [], Not_Indicated_on_Form = [];
                
                for (var i in subject) {
                    categories.push(subject[i][4]);
                    Childern.push(subject[i][0]);
                    Adult.push(subject[i][1]);
                    
                    
                }
                series.push({
                    name: 'Childern',
                    data: Childern
                    
                },
                {
                    name: 'Adult',
                    data: Adult
                }
               
                );

                BindTestingAge(categories, series);
                function BindTestingAge(categories, series) {
                    window.chart = new Highcharts.chart('testAge', {
                        chart: {
                            type: 'column',
                            marginBottom: 120
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            },
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        },
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            x: 0,
                            verticalAlign: 'bottom',
                            y: 0,
                            floating: false,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series
                    });
                }
            });
            // Lab Outcome
            $(function GetLABOutcomedata() {
                var subject = JSON.parse('<%=JstringVLLAbOutcome%>');
                var series = [], categories = [], Suppressed = [], Not_Suppressed = [];
                
                for (var i in subject) {
                    categories.push(subject[i][4]);
                    Suppressed.push(subject[i][0]);
                    Not_Suppressed.push(subject[i][1]);
                   
                    
                }
                series.push({
                    name: 'Suppressed',
                    data: Suppressed
                    
                },
                {
                    name: 'Not Suppressed',
                    data: Not_Suppressed
                }

                
                );

                BindTestingGender(categories, series);
                function BindTestingGender(categories, series) {
                    window.chart = new Highcharts.chart('Laboutcome', {
                        chart: {
                            type: 'column',
                            marginRight: 150
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            },
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        },
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 0,
                            floating: false,                            
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series
                    });
                }
            });
             // Lab Rejection reason  
            
            $(function GetLAbNationalRejectiondata() {
                var subject = JSON.parse('<%=JstringVLLAbNationalRejectionRes%>');
                var series = [], categories = [], NoofRejectedreason = [], NoofRejectedreasonRate=[];
               
                for (var i in subject) {
                    NoofRejectedreason.push(subject[i][0]);
                    NoofRejectedreasonRate.push(subject[i][1]);
                    categories.push(subject[i][2]);
                    
                }
               
                series.push({
                    type: 'column',
                    name: 'Rejected Sample',
                    data: NoofRejectedreason
                },
               
                {
                    type: 'spline',
                    name: 'Rejection Rate',
                    data: NoofRejectedreasonRate,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'white'
                    }
                }
              
                );

                BindLAbNationalRejection(categories, series);
                function BindLAbNationalRejection(categories, series) {
                    window.chart = new Highcharts.chart('NationalRejection', {
                        chart: {
                            type: 'column',
                            height: 250
                        },
                        title: {
                            text: 'National Rejections'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: [{
                            title: {
                                text: 'Rejected Samples'
                            }
                        }, {
                            title: {
                                text: 'Percentage',
                              
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
                                             
                       
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
            // Lab Outcome Trends  
            
            $(function GetLAbOutcomebyLabdata() {
                var subject = JSON.parse('<%=JstringVLLAbOutcomebyLab%>');
                var series = [],categories=[], Suppressed = [], Not_Suppressed = [],SuppressionRate=[];
                
                for (var i in subject) {
                    Suppressed.push(subject[i][0]);
                    Not_Suppressed.push(subject[i][1]);
                    SuppressionRate.push(subject[i][2]);
                    categories.push(subject[i][3] + " " + subject[i][4]);
                 
                    
                }
                series.push({
                    type: 'column',
                    name: 'Suppressed',
                    data: Suppressed
                },
                {
                    type: 'column',
                    name: 'Not Suppressed',
                    data: Not_Suppressed
                },

                {
                    type: 'spline',
                    name: 'Supperssion Rate',
                    data: SuppressionRate,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'white'
                    }
                }
              
                );

                BindGetLAbOutcomebyLab(categories, series);
                function BindGetLAbOutcomebyLab(categories, series) {
                    window.chart = new Highcharts.chart('LAbOutcomebyLab', {
                        chart: {
                            type: 'column',
                            height: 250
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: [{
                            title: {
                                text: 'Total Tests'
                            }
                        }, {
                            title: {
                                text: 'Percentage',
                              
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
                                             
                       
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
            // Testing Trends by Supperssion 
            
            $(function GetVLSuppressionTrends() {
                var subject = JSON.parse('<%=JstringVLLAbSuppressionTrendbyLab%>');
                var series = [],categories=[],data=[],name=[];
                               
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                 
                BindVLSuppressionTrends(categories, series);
                function BindVLSuppressionTrends(categories, series) {
                    window.chart = new Highcharts.chart('SuppressionTrends', {
                        chart: {
                            type: 'spline',
                            height: 250
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Suppression Rate %'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
             // Testing Trends by Valid Test 
            
            $(function GetVLValidTestTrends() {
                var subject = JSON.parse('<%=JstringVLLAbValidTestingTrendsbyLab%>');
                var series = [],categories=[],data=[],name=[];
                              
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
               
               

                BindVLValidTestTrends(categories, series);
                function BindVLValidTestTrends(categories, series) {
                    window.chart = new Highcharts.chart('LAbValidTestTrendbyLab', {
                        chart: {
                            type: 'spline',
                            height: 250
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Number of valid Tests'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
           // Testing Trends by Rejection 
            
            $(function GetVLRejectedTrends() {
                var subject = JSON.parse('<%=JstringVLLAbRejectedTrendbyLab%>');
                var series = [],categories=[],data=[],name=[];
                
                
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
               

                BindVLRejectedTrends(categories, series);
                function BindVLRejectedTrends(categories, series) {
                    window.chart = new Highcharts.chart('LabRejectionTrends', {
                        chart: {
                            type: 'spline',
                            height: 250
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Rejection %'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
            // Rejection reason  by selected lab
            
            $(function GetLAbRejectionBylabdata() {
                var subject = JSON.parse('<%=JstringVLLabRejectionReasonbyLab%>');
                var series = [], categories = [], NoofRejectedreason = [], NoofRejectedreasonRate=[];
               
                for (var i in subject) {
                    NoofRejectedreason.push(subject[i][0]);
                    NoofRejectedreasonRate.push(subject[i][1]);
                    categories.push(subject[i][2]);
                    
                }
               
                series.push({
                    type: 'column',
                    name: 'Rejected Sample',
                    data: NoofRejectedreason
                },
               
                {
                    type: 'spline',
                    name: 'Rejection Rate',
                    data: NoofRejectedreasonRate,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'white'
                    }
                }
              
                );

                BindLAbRejectionBylab(categories, series);
                function BindLAbRejectionBylab(categories, series) {
                    window.chart = new Highcharts.chart('ByLabRejection', {
                        chart: {
                            type: 'column',
                            height: 250
                        },
                        title: {
                            text: 'Rejections'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: [{
                            title: {
                                text: 'Rejected Samples'
                            }
                        }, {
                            title: {
                                text: 'Percentage',
                              
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
                                             
                       
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
        });
        </script>

     <div class="row">
 <div class="well">
        <div class="row">
				<div class="col-sm-3 pull-left">                      
                      <asp:DropDownList ID="ddlLab" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="LaboratoryName" DataValueField="LabCode" AutoPostBack="True" OnSelectedIndexChanged="ddlLab_SelectedIndexChanged">
                                        <asp:ListItem Value="0">All Laboratories</asp:ListItem>
                      </asp:DropDownList><i></i>					
				</div>
            <div class="col-sm-3 pull-left"> 
            <h6> <span class="txt-color-blue">
                <asp:Label ID="lblLab" runat="server" Text="ALL Labs"></asp:Label></span></h6>
                </div>
             <div class="col-sm-2 pull-right">	
                 <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click" />								
			 </div>				
			 <div class="col-sm-2 pull-right">
                     <div class="input-group date"  id='datetimepicker2'>
					        <asp:TextBox ID="txtdateto" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="Date To"></asp:TextBox>
                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                     </div>
			 </div>
             <div class="col-sm-2 pull-right">
                    <div class="input-group date"  id='datetimepicker1'>
                         <asp:TextBox ID="txtdatefrom" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="Date From"></asp:TextBox>
					         <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                   </div>
			</div>
               
		</div>
					
	</div>
    <section id="widget-grid" class="">
        <div id="first" runat="server" style="display:block;">
		    <div class="row">
		     <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>LAB PERFORMANCE STATS (<asp:Label ID="lblDatefromyear" runat="server"></asp:Label>-<asp:Label ID="lblDatetoyear" runat="server" ></asp:Label>)</h2>
                        </header>
                  
										    <!-- add: non-hidden - to disable auto hide -->
                            	
                    			    <div role="content">
                                    
									    <div class="widget-body no-padding">
                                            <div class="dt-toolbar"><div class="col-xs-12 col-sm-6"><div id="dt_basic_filter" class="dataTables_filter"><label><span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span><asp:TextBox ID="txtLabName" CssClass="form-control" aria-controls="dt_basic" placeholder="Lab Name" runat="server" OnTextChanged="txtLabName_TextChanged" ></asp:TextBox></label></div></div><div class="col-sm-6 col-xs-12 hidden-xs"><div class="dataTables_length" id="dt_basic_length"></div></div></div>
                                           <div class="table-responsive">                      		
                                                <asp:GridView ID="gvLabStats" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" Width="100%" ShowFooter="True" AllowPaging="True" OnPageIndexChanging="gvLabStats_PageIndexChanging">
                                                 <Columns>
                                                    <asp:BoundField HeaderText="LaboratoryName" DataField="LaboratoryName" />
                                                    <asp:BoundField HeaderText="Facilities Sending Samples" DataField="Facilities_Sending_Samples" />
                                                     <asp:BoundField HeaderText="Recieved Samples Lab" DataField="Recieved_Samples_at_lab" />
                                                     <asp:BoundField HeaderText="Rejected Samples %" DataField="RejectedSamples" />
                                                     <asp:BoundField HeaderText="Tot Detected < 1000" DataField="Tot_Detected_LE_1000" />
                                                     <asp:BoundField HeaderText="Tot_Detected > 1000" DataField="Tot_Detected_G_1000" />
                                                     <asp:BoundField HeaderText="Total Suppressed %" DataField="Total_Suppressed" />
                                                     <asp:BoundField HeaderText="Invalid/Error/Noresult" DataField="Invalid_Error_Noresult" />
                                                     
                                                </Columns>
                                                    <PagerSettings
                                                     Mode="NextPreviousFirstLast" PageButtonCount="5" />
                                            </asp:GridView>
                                        
                                      </div>
									    </div>
								    </div>
			     </div>
             
		     </article>
		    </div>
            <div class="row">
			    <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-2" data-widget-editbutton="false" role="widget" style="">
					    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>Labs Testing Trends (<%=datefrom%> - <%=dateto%>)</h2>
                        </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">
                                          <div id="ValidTestTrends" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
       		    </article>
			    <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-25" data-widget-editbutton="false" role="widget" style="">
								    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						                <h2>Labs Rejection Trends (<%=datefrom%> - <%=dateto%>)</h2>
                                    </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">                                        
                                           <div id="LabRejectionTrend" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
			    </article>
		    </div>
            <div class="row">
			    <article class="col-xs-12 col-sm-4 col-md-4 col-lg-4 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-4" data-widget-editbutton="false" role="widget" style="">
					    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>VLs Tested by Sample Type (<%=datefrom%> - <%=dateto%>)</h2>
                        </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">
                                          <div id="testSampleType" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
       		    </article>
			    <article class="col-xs-12 col-sm-4 col-md-4 col-lg-4 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-3" data-widget-editbutton="false" role="widget" style="">
								    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						                <h2>VLs Gender Breakdown (<%=datefrom%> - <%=dateto%>)</h2>
                                    </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">                                        
                                           <div id="testGender" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
			    </article>
                <article class="col-xs-12 col-sm-4 col-md-4 col-lg-4 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-5" data-widget-editbutton="false" role="widget" style="">
								    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						                <h2>VLs Age Breakdown (<%=datefrom%> - <%=dateto%>)</h2>
                                    </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">                                        
                                           <div id="testAge" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
			    </article>
		    </div>
            <div class="row">
		     <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                  <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-16" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>Routine VLs Result Outcomes (<%=datefrom%> - <%=dateto%>)</h2>
                       
                        </header>
                  
										    <!-- add: non-hidden - to disable auto hide -->
                            
                    			    <div role="content">
                                    
									    <div class="widget-body no-padding">
                                         <i></i>
									
                                            <div id="Laboutcome" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                       
									    </div>
								    </div>
			     </div>
             
		     </article>
		    </div>
            <div class="row">
		     <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                  <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-6" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>Sample Rejections (<%=datefrom%> - <%=dateto%>)</h2>
                       
                        </header>
                  
										    <!-- add: non-hidden - to disable auto hide -->
                            
                    			    <div role="content">
                                    
									    <div class="widget-body no-padding">
                                         <i></i>
									
                                            <div id="NationalRejection" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                       
									    </div>
								    </div>
			     </div>
             
		     </article>
		    </div>
        </div>
        <div id="second" runat="server" style="display: none;">
            <div class="row">
		 <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-7" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>Outcomes  (<%=datefrom%> - <%=dateto%>)</h2>
                       
                    </header>
                  
										<!-- add: non-hidden - to disable auto hide -->
                            
                    			<div role="content">
                                    
									<div class="widget-body no-padding">
                      
									
                                        <div id="LAbOutcomebyLab" style="min-width: 1024px; height: 300px; margin: 0 auto"></div>
                                       
									</div>
								</div>
			 </div>
             
		 </article>
		</div>
            <div class="row">
			    <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-8" data-widget-editbutton="false" role="widget" style="">
					    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>Supperssion Trends</h2>
                        </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">
                                          <div id="SuppressionTrends" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
       		    </article>
			    <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-9" data-widget-editbutton="false" role="widget" style="">
								    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						                <h2>Testing Trends</h2>
                                    </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">                                        
                                           <div id="LAbValidTestTrendbyLab" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
			    </article>
		    </div>
            <div class="row">
			    <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-10" data-widget-editbutton="false" role="widget" style="">
					    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>Rejection Rate Trends</h2>
                        </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">
                                          <div id="LabRejectionTrends" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
       		    </article>
			    <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                    <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-11" data-widget-editbutton="false" role="widget" style="">
								    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						                <h2>Turn Around Time (Collection - Dispatch)</h2>
                                    </header>
                 				    <div role="content">
                                        <div class="widget-body no-padding">                                        
                                           <div id="testbygender" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                        </div>
								    </div>
				    </div>
			    </article>
		    </div>
            <div class="row">
		     <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                  <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-12" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						    <h2>Lab Rejections (<%=datefrom%> - <%=dateto%>)</h2>
                       
                        </header>
                  
										    <!-- add: non-hidden - to disable auto hide -->
                            
                    			    <div role="content">
                                    
									    <div class="widget-body no-padding">
                                         <i></i>
									
                                            <div id="ByLabRejection" style="min-width: 1024px; height: 300px; margin: 0 auto"></div>
                                       
									    </div>
								    </div>
			     </div>
             
		     </article>
		    </div>
        </div>
    </section>


</div>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>

