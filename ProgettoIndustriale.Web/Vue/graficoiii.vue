<template>

    <v-container>
        <div class="row mb-0">
            <div class="col-12">
                <div class="card mb-0">
                    <h3 class="col-12" style="text-align:center">GRAFICO 3</h3>
                    <h6 class="display-5" style="text-align:center">Descrizione grafico</h6>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-12">
                    <div class="card mt-0">
                        <div class="embed-responsive embed-responsive-16by9">

                            <iframe class="embed-responsive-item" title="generazione_energia" src="https://app.powerbi.com/reportEmbed?reportId=d1cfbabf-7213-4eb5-949e-8cf79d4d96ad&autoAuth=true&ctid=c6bdd2a8-3d5b-4c54-ac5f-1b54a5b1929a" frameborder="0" allowFullScreen="true"></iframe>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </v-container>

</template>

<script>
    export default {
        name: 'graficoiii',
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
        width: 100%;
        height: 550px;
    }

    .embed-responsive-item {
        border-radius: 0.8em;
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
        margin-top: 0.9em;
        border-radius: 0.8em;
        padding: 0.5em .5em .5em;
        border-radius: 0.8em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
    }
</style>