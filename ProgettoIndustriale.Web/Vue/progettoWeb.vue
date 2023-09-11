<template>
    <v-container >
        <div class="container mt-7 mb-7">
            <div class="row justify-center mb-6">
                <div class="card col-12 col-sm-3" v-for="item in data":key="item.id">
                    <div class="card-body ">
                        <div class=" row ">
                            <div class="col-3">
                                <i><img class="mt-2" height="60" width="60" v-bind:src="require('./../wwwroot/assets/Icone/ImmaginiCategoria/' + item.image)" /></i>
                            </div>
                            <div class="col-9 text-end" >
                                <h2 class="card-title text--black mb-0" >{{item.price}}</h2>
                                <h6  class="card-text  text-muted">{{item.unit}}</h6>

                            </div>
                        </div>
                        <div class="row">
                            <h6 id="title" class="text-center">
                                {{item.name}}
                                
                            </h6>
                        </div>
                    </div>
                </div>
              
            </div>
        </div>
        
            <grafico></grafico>
       
        <!-- Inserimento del grafico nella homepage -->
    </v-container>
</template>

<script>
import { count } from "../node_modules/@progress/kendo-data-query/dist/npm/array.operators";
import { services } from '../Scripts/Services/serviceBuilder';
   

    export default {
        name: 'progetto',
        data: function () {
            return {
                data: [
                    {
                        id: 1,
                        image: "Ico_Petrolio.png",
                        price: "No data",
                        unit: "No data",
                        name: "No data",
                    },
                    {
                        id: 2,
                        image: "Ico_Solare.png",
                        price: "No data",
                        unit: "No data",
                        name: "No data",
                    },
                    {
                        id: 3,
                        image: "Ico_Nucleare.png",
                        price: "No data",
                        unit: "No data",
                        name: "No data",
                    },
                    
                ],
                immagine: require("./../wwwroot/assets/Icone/ImmaginiCategoria/Ico_Nucleare.png") ,
                loading: false
            };
        },
        
        methods: {
          
            getPriceOil: function () {
               
                //var price = document.getElementById("priceBrent");
                //var title = document.getElementById("nameBrent")
                //var unit = document.getElementById("unitBrent")
                let that = this;
                that.loading = true;
                services.apiCallerProgettoWeb.getLastCommodities()
                    .then(res => {
                        that.datioil = res.data;
                        let datipetrolio = res.data;                     
                        console.log(datipetrolio[0]["valueUsd"]);                      
                        //price.textContent = datipetrolio[0]["valueUsd"] + " €"; 
                        //title.textContent = datipetrolio[0]["name"];
                        //unit.textContent = datipetrolio[0]["unit"]
                        for (var i = 0; i < 3; i++) {
                            this.data[i]["price"] = datipetrolio[i]["valueUsd"] + " $"; 
                            this.data[i]["unit"] = datipetrolio[i]["unit"];
                            this.data[i]["name"] = datipetrolio[i]["name"];

                           
                        }

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
        
    }
</style>
<style>


    @media (max-width: 500px) {
        .card {
            
        }
    }
    
    main {
        background: rgb(1,208,114);
        background: linear-gradient(90deg, rgba(1,208,114,1) 0%, rgba(3,222,206,1) 100%);
    }
   
    .container {
      
    }
    
    .card {
        margin-right:0.9em;
        
        padding: 0.2em 0.2em 0.2em;
        border-radius: 0.9em;
        
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
        width: 100%;
        -ms-word-wrap: inherit;
        word-wrap: inherit;
    }

    .col {
        padding: 0.5em 0.5em 0.5em 0.4em;
        border-radius: 0.8em;
       
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
        background-color: white;
        border: solid 2px;
    }

    .col-3 {
        padding: 0.1em 0.1em 0.1em 0.9em;
        border-radius: 0.8em;
        text-align: center;

        border-color: darkgreen;
        max-height: 60px;
        max-width:60px;
        background-color: white;
    }
    .col-7{
        text-align:justify;
    }
    .card-text, .card-title{
       
    }
    #title {
        padding: 0.1em 0.1em 0.1em;
        border-radius: 0.2em;
        text-align: left !important;
        box-shadow:1px 1px 4px rgb(1,208,114);
        border-color: darkgreen;
        width: 100%;
        background-color: white;
    }
</style>