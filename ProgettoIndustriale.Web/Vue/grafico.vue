
<template>

    <div class="row">
        
            <div class="card customContainer mt-0">
                <div class="embed-responsive embed-responsive-16by9 customContainer">

                    <iframe class="embed-responsive-item" title="home-page" src="https://app.powerbi.com/reportEmbed?reportId=0c5f7b57-5120-41de-bb16-b318c94eb80c&autoAuth=true&ctid=c6bdd2a8-3d5b-4c54-ac5f-1b54a5b1929a" frameborder="0"></iframe>

                </div>
            </div>
        
    </div>

</template>

<!--<iframe class="embed-responsive-item" title="GetAllProvince" src="https://app.powerbi.com/reportEmbed?reportId=b8248c3a-ee42-4ad5-a775-f77bea259e1e&autoAuth=true&ctid=c6bdd2a8-3d5b-4c54-ac5f-1b54a5b1929a" frameborder="0" allowFullScreen="true"></iframe>-->

<script>
    import * as am5 from '@amcharts/amcharts5';
    import * as am5xy from '@amcharts/amcharts5/xy';
    import am5themes_Animated from '@amcharts/amcharts5/themes/Animated';
    import * as am5percent from "@amcharts/amcharts5/percent";

    import { services } from '../Scripts/Services/serviceBuilder';
    let datigrafico = [{}];

    export default {
        name: 'grafico',
        data: function () {
            return {
                loading: false,
                dataprova1: []
            };
        },
        methods: {
            getMonthName: function (monthNumber) {
                const date = new Date();
                date.setMonth(monthNumber - 1);
                return date.toLocaleString([], { month: 'long' });
            },
            async getDataGrafico() {
                let that = this;
                that.loading = true;
                const dateS = new Date();
                let currentDate = `${dateS.getFullYear()}-${dateS.getMonth() + 1}-${dateS.getDate()}`


                await services.apiCallerProgettoWeb.getCommoditiesByDate(currentDate)
                    .then(res => {
                        let count = [];
                        count = res.data;

                        for (var i = 0; i < count.length; i++) {
                            var schema = {
                                Month: this.getMonthName(count[i]["date"]["month"]).toUpperCase(),
                                value: count[i]["valueUsd"]
                            }
                            datigrafico[i] = schema;

                        }

                        console.log("Dati grafico aggiunti");
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                        that.loading = false;
                    });
            }
        },
        created: function () {
            console.log("created main page");
        },

        async mounted() {
            await this.getDataGrafico();
            var root = am5.Root.new(this.$refs.chartdiv);


            // Set themes
            // https://www.amcharts.com/docs/v5/concepts/themes/
            root.setThemes([
                am5themes_Animated.new(root)
            ]);


            // Create chart
            // https://www.amcharts.com/docs/v5/charts/xy-chart/
            var chart = root.container.children.push(am5xy.XYChart.new(root, {
                panX: true,
                panY: true,
                wheelX: "panX",
                wheelY: "zoomX",
                pinchZoomX: true
            }));

            // Add cursor
            // https://www.amcharts.com/docs/v5/charts/xy-chart/cursor/
            var cursor = chart.set("cursor", am5xy.XYCursor.new(root, {}));
            cursor.lineY.set("visible", false);


            // Create axes
            // https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
            var xRenderer = am5xy.AxisRendererX.new(root, { minGridDistance: 30 });
            xRenderer.labels.template.setAll({
                rotation: -90,
                centerY: am5.p50,
                centerX: am5.p100,
                paddingRight: 15
            });

            xRenderer.grid.template.setAll({
                location: 1
            })

            var xAxis = chart.xAxes.push(am5xy.CategoryAxis.new(root, {
                maxDeviation: 0.3,
                categoryField: "Month",

                renderer: xRenderer,
                tooltip: am5.Tooltip.new(root, {})
            }));

            var yAxis = chart.yAxes.push(am5xy.ValueAxis.new(root, {
                maxDeviation: 0.3,
                renderer: am5xy.AxisRendererY.new(root, {
                    strokeOpacity: 0.1
                })
            }));


            // Create series
            // https://www.amcharts.com/docs/v5/charts/xy-chart/series/
            var series = chart.series.push(am5xy.ColumnSeries.new(root, {
                name: "Series 1",
                xAxis: xAxis,
                yAxis: yAxis,
                valueYField: "value",
                sequencedInterpolation: true,
                categoryXField: "Month",
                tooltip: am5.Tooltip.new(root, {
                    labelText: "{valueY}"
                })
            }));

            series.columns.template.setAll({ cornerRadiusTL: 5, cornerRadiusTR: 5, strokeOpacity: 0 });
            series.columns.template.adapters.add("fill", function (fill, target) {
                return chart.get("colors").getIndex(series.columns.indexOf(target));
            });

            series.columns.template.adapters.add("stroke", function (stroke, target) {
                return chart.get("colors").getIndex(series.columns.indexOf(target));
            });


            // Set data
            var data = [{
                Month: "GENNAIO",

            }, {
                Month: "FEBBRAIO"
            }, {
                Month: "MARZO"
            }, {
                Month: "APRILE"
            }, {
                Month: "MAGGIO"
            }, {
                Month: "GIUGNO"
            }, {
                Month: "LUGLIO"
            }, {
                Month: "AGOSTO"
            }, {
                Month: "SETTEMBRE"
            }, {
                Month: "OTTOBRE"
            }, {
                Month: "NOVEMBRE"
            }, {
                Month: "DICEMBRE"
            }];

            xAxis.data.setAll(data);
            series.data.setAll(datigrafico);

            // Make stuff animate on load
            // https://www.amcharts.com/docs/v5/concepts/animations/
            series.appear(1000);
            chart.appear(1000, 100);

        },

        beforeDestroy() {
            if (this.root) {
                this.root.dispose();
            }
        }


    }


</script>
<style>
    .embed-responsive-16by9 {
       padding: 0 0 0 0;
       height:100%;
    }
    .customContainer{
        height:569px;
    }
    
    .embed-responsive-item {
        
        border-radius: 2em;
        padding: 0.0em 0.0em 0.0em;
    }

    @media (min-height: 1060px) {
        * {
        }

        .card {
           
            font-size: 50px;
        }
    }

    #btn-form {
        background: rgb(1,208,114);
        background: linear-gradient(90deg, rgba(1,208,114,1) 0%, rgba(3,222,206,1) 100%)
    }

    main {
        background: rgb(1,208,114);
        background: linear-gradient(90deg, rgba(1,208,114,1) 0%, rgba(3,222,206,1) 100%);
    }


    .container {
        padding: 0px;
    }



    .card {
        
       
        border-radius: 0.8em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
        
    }
    
</style>