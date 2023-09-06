<template>
    <v-container >
        <div class="container mt-3 " >
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <div class="card ml-0">
                        <div class="card-body">
                            <div class=" row">
                                <div class="col-6">
                                    <i><img height="50" width="50" src="../wwwroot/assets/Icone/ImmaginiCategoria/Ico_Lampadina.png" /></i>
                                </div>
                                <div class="col-6 ">
                                    <div class="row">
                                        <h3 id="priceOil" class="card-title mt-5">83,04$</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="card-title">
                                <h6>
                                    Prezzo barile
                                </h6>
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
                                        <h3 class="card-title mt-5">83,04$</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="card-title">
                                <h6>
                                    Prezzo barile
                                </h6>
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
                                        <h3 class="card-title mt-5">83,04$</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="card-title">
                                <h6>
                                    Prezzo barile
                                </h6>
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
                                        <h3 class="card-title mt-5">83,04$</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="card-title">
                                <h6>
                                    Prezzo barile
                                </h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="width:100%">
                <div class="col mt-1">
                    <p class="mb-0 justify-center font-italic">
                        <grafico></grafico>
                    </p>
                </div>
            </div>
        </div>
    </v-container>
</template>

<script>
import { count } from "../node_modules/@progress/kendo-data-query/dist/npm/array.operators";
import { services } from '../Scripts/Services/serviceBuilder';
   

    export default {
        name: 'progetto',
        data: function () {
            return {
                datioil: [],
                loading: false
            };
        },
        
        methods: {
          
            getPriceOil: function () {
               
                var price = document.getElementById("priceOil");
               
                let that = this;
                that.loading = true;
                services.apiCallerProvince.getAllProvince()
                    .then(res => {
                        that.datioil = res.data;
                        let datipetrolio = res.data;                     
                        console.log(datipetrolio[0]["valueUsd"]);                      
                        price.textContent = datipetrolio[0]["valueUsd"] + "$"; 
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
  
        },
        mounted() {
            console.log("created main page1");   
            this.getPriceOil();       
        }
    }


</script>
<style scoped>
    .hello {
        width: 100%;
        height: 450px;
        
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
        width:95%;
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
        height: 500px;
    }
</style>