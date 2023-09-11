<template>

    <v-container>
        <div class="row mb-0">
            <div class="col-12">
                <div class="card mt-7 mb-0">
                    <h3 class="col-12" style="text-align:center">MEDIA CONSUMI</h3>
                    <h6 class="display-5" style="text-align:center">Mostra in base ai filtri di data e zona, la media dei consumi. Passando sopra le colonne, si possono visualizzare i dati che influenzano questi consumi in MWh.</h6>
                </div>
            </div>
            <div class="row mt-7">
                <div class="col-12">
                    <div class="card customContainer mt-0">
                        <div class="embed-responsive embed-responsive-16by9">
                            
                            <iframe class="embed-responsive-item" title="stat_load" width="1024" height="804" src="https://app.powerbi.com/view?r=eyJrIjoiZDc5ZmZjYTItNDU2ZC00OWViLTliNGItMTNhNmMzMDc5NjljIiwidCI6ImM2YmRkMmE4LTNkNWItNGM1NC1hYzVmLTFiNTRhNWIxOTI5YSIsImMiOjh9" frameborder="0" allowFullScreen="true"></iframe>
                        </div>
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
    .embed-responsive-16by9 {
        padding: 0 0 0 0;
        height: 100%;
    }

    .customContainer {
        height: 550px;
        width: 100%;
    }

    .embed-responsive-item {
        border-radius: 1em;
        padding: 0.0em 0.0em 0.0em;
    }


    @media (min-height: 1060px) {
        * {
        }

        .card {
            width: 70% !important;
            font-size: 50px;
            border-radius: 0.8em;
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
        padding: 0.2em 0.1em 0 0.1em;
        width: 100%;
        border-radius: 0.8em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
    }
</style>