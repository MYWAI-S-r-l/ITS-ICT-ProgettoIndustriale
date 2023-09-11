
<template>
    <v-container>
        <div class="row">
            <div class="col-12">
                <div class="card customContainer mt-0">
                    <div class="embed-responsive embed-responsive-16by9 ">

                        <!--<iframe class="embed-responsive-item" title="home-page" src="https://app.powerbi.com/reportEmbed?reportId=0c5f7b57-5120-41de-bb16-b318c94eb80c&autoAuth=true&ctid=c6bdd2a8-3d5b-4c54-ac5f-1b54a5b1929a" frameborder="0"></iframe>-->
                        <iframe class="embed-responsive-item" title="Report Section" src="https://app.powerbi.com/view?r=eyJrIjoiNzBjMTk4N2YtOGIzMS00NzFhLWFiNTgtYzdjMTgxNjQ4MGU5IiwidCI6ImM2YmRkMmE4LTNkNWItNGM1NC1hYzVmLTFiNTRhNWIxOTI5YSIsImMiOjh9&pageName=ReportSection9dccfc3a4dd0f01e3f92" frameborder="0" allowFullScreen="true"></iframe>
                    </div>
                </div>

            </div>
        </div>
    </v-container>

</template>

<!--<iframe class="embed-responsive-item" title="GetAllProvince" src="https://app.powerbi.com/reportEmbed?reportId=b8248c3a-ee42-4ad5-a775-f77bea259e1e&autoAuth=true&ctid=c6bdd2a8-3d5b-4c54-ac5f-1b54a5b1929a" frameborder="0" allowFullScreen="true"></iframe>-->

<script>
   

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
        }


    }


</script>
<style>
    .embed-responsive-16by9 {
       padding: 0 0 0 0;
       height:100%;
    }
    .customContainer{
        height:550px;
        width:100%;
    }
    
    .embed-responsive-item {
       
        border-radius: 1em;
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
        padding:0.2em 0.1em 0 0.1em ;
        
        width: 100%;
        border-radius: 0.8em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
        
    }
    
</style>