<template>
    <v-container >
        <div class="container mt-2" >
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <div class="card">
                        <div class="card-body">
                            <div class=" row">
                                <div class="col-6">
                                    <i><img height="50" width="50" src="../wwwroot/assets/Icone/ImmaginiCategoria/Ico_Lampadina.png" /></i>
                                </div>
                                <div class="col-6 ">
                                    <div class="row">
                                        <h5 class="card-title mt-5">83,04$</h5>
                                    </div>

                                </div>

                            </div>
                            <div class="card-title">
                                <h5>
                                    Prezzo barile
                                </h5>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="card">
                        <div class="card-body">
                            <div class=" row">
                                <div class="col-6">
                                    <i><img height="50" width="50" src="../wwwroot/assets/Icone/ImmaginiCategoria/Ico_Petrolio.png" /></i>
                                </div>
                                <div class="col-6 ">
                                    <div class="row">
                                        <h5 class="card-title mt-5">83,04$</h5>
                                    </div>

                                </div>

                            </div>
                            <div class="card-title">
                                <h5>
                                    Prezzo barile
                                </h5>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="card">
                        <div class="card-body">
                            <div class=" row">
                                <div class="col-6">
                                    <i><img height="50" width="50" src="../wwwroot/assets/Icone/ImmaginiCategoria/Ico_Solare.png" /></i>
                                </div>
                                <div class="col-6 ">
                                    <div class="row">
                                        <h5 class="card-title mt-5">83,04$</h5>
                                    </div>

                                </div>

                            </div>
                            <div class="card-title">
                                <h5>
                                    Prezzo barile
                                </h5>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="card">
                        <div class="card-body">
                            <div class=" row">
                                <div class="col-6">
                                    <i><img height="50" width="50" src="../wwwroot/assets/Icone/ImmaginiCategoria/Ico_Nucleare.png" /></i>
                                </div>
                                <div class="col-6 ">
                                    <div class="row">
                                        <h5 class="card-title mt-5">83,04$</h5>
                                    </div>

                                </div>

                            </div>
                            <div class="card-title">
                                <h5>
                                    Prezzo barile
                                </h5>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="row container ">
                <div class="col mt-0">
                    <p class="mb-0 font-italic">
                        <div class="hello" ref="chartdiv">
                            <h3>Prezzo Medio</h3>
                        </div>
                    </p>
                </div>

                

            </div>




        </div>
    </v-container>
</template>

<script>
    import * as am5 from '@amcharts/amcharts5';
    import * as am5xy from '@amcharts/amcharts5/xy';
    import am5themes_Animated from '@amcharts/amcharts5/themes/Animated';
    import * as am5percent from "@amcharts/amcharts5/percent";

    export default {
        name: 'progetto',
        data: function () {
            return {
                loading: false,
            };
        },
        methods: {
        },
        created: function () {
            console.log("created main page");
        },
        mounted() {
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
                categoryField: "country",
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
                categoryXField: "country",
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
                country: "Gennaio",
                value: 100
            }, {
                country: "Febbraio",
                value: 50
            }, {
                country: "Marzo",
                value: 40
            }, {
                country: "Aprile",
                value: 55
            }, {
                country: "Maggio",
                value: 30
            }, {
                country: "Giugno",
                value: 20
            }, {
                country: "Luglio",
                value: 19
            }, {
                country: "Agosto",
                value: 81
            }, {
                country: "Settembre",
                value: 50
            }, {
                country: "Ottobre",
                value: 70
            }, {
                country: "Novembre",
                value: 77
            }, {
                country: "Dicembre",
                value: 50
            }];

            xAxis.data.setAll(data);
            series.data.setAll(data);


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
<style scoped>
    .hello {
        width: 100%;
        height: 500px;
    }
</style>
<style>
   

       
    
    main {
        background: rgb(1,208,114);
        background: linear-gradient(90deg, rgba(1,208,114,1) 0%, rgba(3,222,206,1) 100%);
    }

    .container {
        padding-top: 0px;
    }

    .card {
        
        border-radius: 2em;
        text-align: center;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
        height: 100px;
        width:100%;
        -ms-word-wrap: inherit;
        word-wrap: inherit;
    }

    .col {
        padding: 1.5em .5em .5em;
        border-radius: 2em;
        text-align: center;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
        background-color: white;
        border: solid 2px;
    }

    .col-4 {
        padding: 1.5em .5em .5em;
        border-radius: 2em;
        text-align: center;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
        border: solid 2px;
        background-color: white;
        height: 600px;
    }
</style>