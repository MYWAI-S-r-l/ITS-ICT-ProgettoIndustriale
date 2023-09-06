<template>
    
    <v-container>
        <div class="row mb-0">
            <div class="col-12">
            <div class="card mb-0">
                <h3 class="col-12" style="text-align:center">GRAFICO 1</h3>
                <h6 class="display-5" style="text-align:center">Descrizione grafico</h6>
            </div>
        </div>
            <div class="row mt-3">
                <div class="col-12">
                    <div class="card mt-0">
                        <form class="form font-italic" id="myForm" method="post">
                            <div class="form-group">

                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </v-container>
   
</template>

<script>
    export default {
        name: 'graficoi',
        data: function () {
            return {
                loading: false,
            };
        },
        methods: {

            created: function () {
            }
        }

    }
            


   

</script>

<style>

    @media (min-height: 1060px) {
        * {
            
        }

        .card {
            
            width:70% !important;
            font-size:50px;
           
        }

        form {
            
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

    form {
        width: 90%;
        margin-left: 5%;
    }

    .card {
        margin-top: 25px;
        margin-bottom: 50px;
        padding: 0.5em .5em .5em;
        border-radius: 2em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
    }

</style>