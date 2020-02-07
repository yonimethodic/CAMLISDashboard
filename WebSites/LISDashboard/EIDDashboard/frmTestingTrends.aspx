<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="frmTestingTrends.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EIDDashboard.Views.frmTestingTrends" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
    
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
    <!-- HIGHCHART:  -->
    <script src="../js/plugin/HighCharts/highcharts.js"></script>
    <script src="../js/plugin/HighCharts/exporting.js"></script>
    <script src="../js/plugin/HighCharts/export-data.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'MM/DD/YYYY'
            });
            $('#datetimepicker2').datetimepicker({
                format: 'MM/DD/YYYY'
            });
                        
            // DNA PCR Test Yearly
            $(function GetEIDIntialPCRdbyYeardata() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRbyYear%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                },
                {
                type: 'spline',
                name: 'Positivity',
                data: Positivity,
                yAxis: 1,
                marker: {
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[3],
                    fillColor: 'black'
                }
            }
              
                );

                BindIntialPCRbyYear(categories, series);
                function BindIntialPCRbyYear(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRbyYear', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }},{
                                title: {
                                    text: 'Positivity',
                              
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
           
            // EID All Test Outcome by Year
            //DNA PCR Test Quarterly
            $(function GetEIDAllTestbyYeardata() {
                var subject = JSON.parse('<%=JstringEIDAllTestbyYear%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                },
                {
                type: 'spline',
                name: 'Positivity',
                data: Positivity,
                yAxis: 1,
                marker: {
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[3],
                    fillColor: 'black'
                }
            }
              
                );

                BindAllTesbyYear(categories, series);
                function BindAllTesbyYear(categories, series) {
                    window.chart = new Highcharts.chart('testAllTestbyYear', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }},{
                                title: {
                                    text: 'Positivity',
                              
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

            //Added by ZaySoe on 09_Jan_2019
            //DNA PCR Test Monthly
            $(function GetEIDIntialPCRdbyMonthdata() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRbyMonth%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                },
                {
                type: 'spline',
                name: 'Positivity',
                data: Positivity,
                yAxis: 1,
                marker: {
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[3],
                    fillColor: 'black'
                }
            }
              
                );

                BindIntialPCRbyMonth(categories, series);
                function BindIntialPCRbyMonth(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRbyMonth', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }},{
                                title: {
                                    text: 'Positivity',
                              
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

            // EID All Test Infant Outcome
            $(function GetEIDAllTestInfantbyYeardata() {
                var subject = JSON.parse('<%=JstringEIDAllTestInfantbyYear%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                },
                {
                type: 'spline',
                name: 'Positivity',
                data: Positivity,
                yAxis: 1,
                marker: {
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[3],
                    fillColor: 'black'
                }
            }
              
                );

                BindallTestInfantbyYear(categories, series);
                function BindallTestInfantbyYear(categories, series) {
                    window.chart = new Highcharts.chart('testAllTestInfantbyYear', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }},{
                                title: {
                                    text: 'Positivity',
                              
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
            
            // EID Test  rejection by Year

               $(function GetEIDRejectinByYeardata() {
                var subject = JSON.parse('<%=JstringEIDRejectionByYear%>');
                var series = [],categories=[],data=[],name=[];
                
               if(<%=ddlDate.SelectedValue%> == 0)
                {
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                }
                else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]

                   
                        }
                    );
                    }
                    
                }
               

                    BindEIDRejectinByYear(categories, series);
                    function BindEIDRejectinByYear(categories, series) {
                        window.chart = new Highcharts.chart('rejectionbyYear', {
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
                                text: 'Rejection Rate'
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

           
             // EID Turnaround by Year

               <%--$(function GetEIDTuraroundByYeardata() {
                var subject = JSON.parse('<%=JstringEIDTurnaroundbyYear%>');
                var series = [],categories=[],data=[],name=[];
                
               if(<%=ddlDate.SelectedValue%> == 0)
                {
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                }
                else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]

                   
                        }
                    );
                    }
                    
                }
               

                    BindEIDturnaroundByYear(categories, series);
                    function BindEIDturnaroundByYear(categories, series) {
                        window.chart = new Highcharts.chart('turnaroundbyYear', {
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
                                text: 'TAT(Days) '
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
            });--%>

            // EID AllTestInfant2mm by Year

            $(function GetEIDAllTestInfant2MByYeardata() {
                var subject = JSON.parse('<%=JstringEIDAllTestInfant2MbyYear%>');
                var series = [],categories=[],data=[],name=[];
                
               if(<%=ddlDate.SelectedValue%> == 0)
                {
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                }
                else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]

                   
                        }
                    );
                    }
                    
                }
               

                BindEIDAllTestInfant2MByYear(categories, series);
                function BindEIDAllTestInfant2MByYear(categories, series) {
                        window.chart = new Highcharts.chart('infant2mtestbyYear', {
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
                                text: 'No of Infant Tests '
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

           

            

            // EID Poitivity Trend by Year

            $(function GetEIDPoitivityTrendbyYearData() {
                var subject = JSON.parse('<%=JstringEIDPoitivityTrendbyYear%>');
                var series = [],categories=[],data=[],name=[];
                
               if(<%=ddlDate.SelectedValue%> == 0)
                {
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                }
                else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]

                   
                        }
                    );
                    }
                    
                }
               

                BindEIDPositivityTrendbyYear(categories, series);
                function BindEIDPositivityTrendbyYear(categories, series) {
                    window.chart = new Highcharts.chart('positivityTrendbyYear', {
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
                                text: 'Positivity '
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

            //Added by ZaySoe on 09_Jan_2019
            // EID Initial PCR Age by Yearly       
            $(function GetEIDIntialPCRdAgeByYearly() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByYearly%>');
                var series = [], categories = [], less2month = [], between2and6month = [], between6and9month = [], between9and18month = [], greaterthan18month = [], NoData = [], lessthan_2months_rate=[];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    less2month.push(subject[i][0]);
                    between2and6month.push(subject[i][1]);
                    between6and9month.push(subject[i][2]);
                    between9and18month.push(subject[i][3]);
                    greaterthan18month.push(subject[i][4]);
                    //NoData.push(subject[i][5]);
                    lessthan_2months_rate.push(subject[i][5]);                    
                }
                series.push({
                        name: '< 2 Month',
                        data: less2month
                    },
                    {
                        name: '2-6 Month',
                        data: between2and6month
                    },
                    {
                        name: '6-9 Month',
                        data: between6and9month
                    },
                    {
                        name: '9-18 Month',
                        data: between9and18month
                    },
                    {
                        name: '> 18 Month',
                        data: greaterthan18month
                    },
                   //{
                   //     name: 'No Data',
                   //     data: NoData
                   //},
                    {
                       type: 'spline',
                       name: '< 2 months Testing Rate',
                       data: lessthan_2months_rate,
                       yAxis: 1,
                       marker: {
                           lineWidth: 2,
                           lineColor: Highcharts.getOptions().colors[3],
                           fillColor: 'black'
                       }
                   }
                );

                BindIntialPCRAgeByYearly(categories, series);
                function BindIntialPCRAgeByYearly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRAgeByYearly', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }
                            }, {
                            title: {
                                text: '< 2 months Testing Rate',
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

            // EID Initial PCR Age by Quarterly       
            $(function GetEIDIntialPCRdAgeByQuarterly() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByQuarterly%>');
                var series = [], categories = [], less2month = [], between2and6month = [], between6and9month = [], between9and18month = [], greaterthan18month = [], NoData = [], lessthan_2months_rate=[];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    less2month.push(subject[i][0]);
                    between2and6month.push(subject[i][1]);
                    between6and9month.push(subject[i][2]);
                    between9and18month.push(subject[i][3]);
                    greaterthan18month.push(subject[i][4]);
                    //NoData.push(subject[i][5]);
                    lessthan_2months_rate.push(subject[i][5]);                    
                }
                series.push({
                        name: '< 2 Month',
                        data: less2month
                    },
                    {
                        name: '2-6 Month',
                        data: between2and6month
                    },
                    {
                        name: '6-9 Month',
                        data: between6and9month
                    },
                    {
                        name: '9-18 Month',
                        data: between9and18month
                    },
                    {
                        name: '> 18 Month',
                        data: greaterthan18month
                    },
                   //{
                   //     name: 'No Data',
                   //     data: NoData
                   //},
                    {
                       type: 'spline',
                       name: '< 2 months Testing Rate',
                       data: lessthan_2months_rate,
                       yAxis: 1,
                       marker: {
                           lineWidth: 2,
                           lineColor: Highcharts.getOptions().colors[3],
                           fillColor: 'black'
                       }
                   }
                );

                BindIntialPCRAgeByQuarterly(categories, series);
                function BindIntialPCRAgeByQuarterly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRAgeByQuarterly', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }
                            }, {
                            title: {
                                text: '< 2 months Testing Rate',
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

            // EID Initial PCR Age by Monthly
            $(function GetEIDIntialPCRdAgeByMonthly() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByMonthly%>');
                var series = [], categories = [], less2month = [], between2and6month = [], between6and9month = [], between9and18month = [], greaterthan18month = [], NoData = [], lessthan_2months_rate=[];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    less2month.push(subject[i][0]);
                    between2and6month.push(subject[i][1]);
                    between6and9month.push(subject[i][2]);
                    between9and18month.push(subject[i][3]);
                    greaterthan18month.push(subject[i][4]);
                    //NoData.push(subject[i][5]);
                    lessthan_2months_rate.push(subject[i][5]);                    
                }
                series.push({
                        name: '< 2 Month',
                        data: less2month
                    },
                    {
                        name: '2-6 Month',
                        data: between2and6month
                    },
                    {
                        name: '6-9 Month',
                        data: between6and9month
                    },
                    {
                        name: '9-18 Month',
                        data: between9and18month
                    },
                    {
                        name: '> 18 Month',
                        data: greaterthan18month
                    },
                   //{
                   //     name: 'No Data',
                   //     data: NoData
                   //},
                    {
                       type: 'spline',
                       name: '< 2 months Testing Rate',
                       data: lessthan_2months_rate,
                       yAxis: 1,
                       marker: {
                           lineWidth: 2,
                           lineColor: Highcharts.getOptions().colors[3],
                           fillColor: 'black'
                       }
                   }
                );

                BindIntialPCRAgeByMonthly(categories, series);
                function BindIntialPCRAgeByMonthly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRAgeByMonthly', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }
                            }, {
                            title: {
                                text: '< 2 months Testing Rate',
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
            
            });
    </script>
  
   
     <div class="well">
        <div class="row">
			<div class="col-sm-3 pull-left">                      
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="ProvinceName" DataValueField="Id">
                    <asp:ListItem Value="0">National</asp:ListItem>
                </asp:DropDownList><i></i>					
			</div>
            <div class="col-sm-3 pull-left"> 
                <h6> <span class="txt-color-blue">
                <asp:Label ID="lbllocation" runat="server" Text="National"></asp:Label></span></h6>
            </div>
            <div class="col-sm-2 pull-right">
                <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click"  />								
			</div>				
			<%-- <div class="col-sm-2 pull-right">
                     <div class="input-group date"  id='datetimepicker2'>
					        <asp:TextBox ID="txtdateto" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="Date To"></asp:TextBox>
                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                     </div>
			 </div>
            --%><%-- <div class="col-sm-2 pull-right">
                    <div class="input-group date"  id='datetimepicker1'>
                         <asp:TextBox ID="txtdatefrom" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="Date From"></asp:TextBox>
					         <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                   </div>
			</div>--%>
                <div class="col-sm-2 pull-left" style="display: none">
                      <asp:DropDownList ID="ddlDate" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">Yearly</asp:ListItem>
                                        <asp:ListItem Value="1">Quarterly</asp:ListItem>
                      </asp:DropDownList><i></i>
                </div>
                <div class="col-sm-1 pull-left">
                    <asp:Label ID="lblFrom" runat="server" Text="From:"></asp:Label>
                </div>
                <div class="col-sm-2 pull-left">
                    <asp:DropDownList ID="ddlYearFrom" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>					
				</div>
                <div class="col-sm-1 pull-left">
                    <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
                </div>
                <div class="col-sm-2 pull-left">
                    <asp:DropDownList ID="ddlYearTo" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>					
				</div>           
		</div>
					
	</div>
    <section id="widget-grid" class="">

        <!-- Tab Initial PCR Test -->
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable" id="c439e80cae8e4d94e4027ca799d50cbf" data-widget-editbutton="false" data-widget-colorbutton="false" role="widget">
	                <header role="heading">
		                <div class="jarviswidget-ctrls" role="menu">
			                <a href="#" class="button-icon jarviswidget-toggle-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Collapse"><i class="fa fa-minus "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-delete-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete"><i class="fa fa-times"></i></a>
		                </div>

                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-darken"></i></span>
                        <h2>DNA PCR Testing</h2>

		                <ul class="nav nav-tabs pull-right">
			                <li class="active">
				                <a href="#0" data-toggle="tab">Yearly</a>
			                </li>
			                <li class="">
				                <a href="#1" data-toggle="tab">Quarterly</a>
			                </li>
                            <li class="">
				                <a href="#2" data-toggle="tab">Monthly</a>
			                </li>
		                </ul>

		                <span class="jarviswidget-loader">
			                <i class="fa fa-refresh fa-spin"></i>
		                </span>
	                </header>

	                <div role="content">
		                <div class="jarviswidget-editbox">
		                </div>
		                <div class="widget-body ">
			                <div class="tab-content padding-10">
				                <div class="tab-pane active" id="0">

                                    <%--<div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
                                        <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
                                            <h2>Initial PCR  by Year(<asp:Label ID="lblDatefromyear" runat="server" Text=""></asp:Label>-<asp:Label ID="lblDatetoyear" runat="server" Text=""></asp:Label>)</h2>   
                                        </header>--%>
                                        <!-- add: non-hidden - to disable auto hide -->
                                        <div role="content">
                                            <div class="widget-body no-padding">
                                                <div id="testIntialPCRbyYear" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                            </div>
                                        </div>
			                         <%--</div>--%>

				                </div>
				                <div class="tab-pane" id="1">

                                    <%--<div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-2" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					                    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						                    <h2>All Test Outcome</h2>
                                        </header>--%>
                 	                    <div role="content">
                                            <div class="widget-body no-padding">
                                                <div id="testAllTestbyYear" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                            </div>
					                    </div>
				                    <%--</div>--%>

				                </div>
                                <div class="tab-pane" id="2">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRbyMonth" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
			                </div>
		                </div>
	                </div>
                </div>
            </article>
        </div>
        <!-- End Tab -->

        <!-- Tab Initial PCR By Age -->
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable" id="tabInitialPCRAge" data-widget-editbutton="false" data-widget-colorbutton="false" role="widget">
	                <header role="heading">
		                <div class="jarviswidget-ctrls" role="menu">
			                <a href="#" class="button-icon jarviswidget-toggle-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Collapse"><i class="fa fa-minus "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-delete-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete"><i class="fa fa-times"></i></a>
		                </div>

                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-darken"></i></span>
                        <h2>DNA PCR By Age</h2>

		                <ul class="nav nav-tabs pull-right">
			                <li class="active">
				                <a href="#3" data-toggle="tab">Yearly</a>
			                </li>
			                <li class="">
				                <a href="#4" data-toggle="tab">Quarterly</a>
			                </li>
                            <li class="">
				                <a href="#5" data-toggle="tab">Monthly</a>
			                </li>
		                </ul>

		                <span class="jarviswidget-loader">
			                <i class="fa fa-refresh fa-spin"></i>
		                </span>
	                </header>

	                <div role="content">
		                <div class="jarviswidget-editbox">
		                </div>
		                <div class="widget-body ">
			                <div class="tab-content padding-10">
				                <div class="tab-pane active" id="3">                                    
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByYearly" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                                        </div>
                                    </div>
				                </div>
				                <div class="tab-pane" id="4">
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByQuarterly" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
                                <div class="tab-pane" id="5">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByMonthly" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
			                </div>
		                </div>
	                </div>
                </div>
            </article>
        </div>        
        <!-- End Tab -->

        <div class="row">
			<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-3" data-widget-editbutton="false" role="widget" style="">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2> All Test Outcome Infant(<2M)</h2>
                    </header>
                 	<div role="content">
                        <div class="widget-body no-padding">                                        
                            <div id="testAllTestInfantbyYear" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                        </div>
					</div>
				</div>
			</article>
		</div>
        	    
        <div class="row">
			<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-6" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Rejection Rate Trend </h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                       <div id="rejectionbyYear" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        
					<!-- row -->
		<%--<div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-7" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>
                                        <asp:Label ID="lbloutcomeProFac" runat="server" Text="Turn Around Time"></asp:Label></h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                        
                                      <div id="turnaroundbyYear" style="min-width: 1024px; height: 300px;  margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>--%>
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-7" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>
                                        <asp:Label ID="Label1" runat="server" Text="Infant Test(less 2m )"></asp:Label></h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                        
                                      <div id="infant2mtestbyYear" style="min-width: 1024px; height: 300px;  margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-7" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>
                                        <asp:Label ID="Label2" runat="server" Text="Positivity Trends"></asp:Label></h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                        
                                      <div id="positivityTrendbyYear" style="min-width: 1024px; height: 300px;  margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        
        		<!-- end row -->
     </section>
   </asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>