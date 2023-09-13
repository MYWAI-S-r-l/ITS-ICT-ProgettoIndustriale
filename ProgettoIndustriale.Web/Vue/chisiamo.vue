<template>
    
    <v-container>
        <div class="row mb-0">
            <div class="card mb-0">
                <h3 class="col-12" style="text-align:center">CHI SIAMO</h3>
            </div>
        </div>
        <div class="row mt-5">
            <div class="card mt-0">
                <form class="form font-italic" id="myForm" method="post">
                    <div class="form-group">
                        <label class="mt-5" for="exampleFormControlInput1">Benvenuti nella sezione dedicata alla descrizione del Progetto Industriale 11.2, un percorso che ha incarnato il culmine dell'esperienza formativa e professionale degli studenti del corso Ciclo 11.2 (Data Specialist) presso l'ITS-ICT Accademia Digitale Liguria. Questa pagina riflette l'accurata realizzazione di un ambizioso progetto di sviluppo software, svolto con la massima precisione e impegno.</label>

                        <label class="mt-5" for="exampleFormControlInput1">SUDDIVISIONE DEL LAVORO</label>
                        <label for="exampleFormControlInput1">
                            Il Progetto Industriale 11.2 è stato condotto da una squadra di 12 studenti. Questa divisione ha permesso la massima concentrazione su ogni aspetto del progetto, garantendo la realizzazione di un sistema completo e funzionale:
                        </label>

                        <label for="exampleFormControlInput1">- Database: Alessandro Romano, Gabriele Piccardo</label>
                        <label for="exampleFormControlInput1">- Data Acquisition: Serena Schincaglia, Federico Zunino, Simone Schiano</label>
                        <label for="exampleFormControlInput1">- Front-end: Dana Luta, Carlo Tommaso, Lorenzo Motto</label>
                        <label for="exampleFormControlInput1">- Back-end: Sara Urdangaray, Jandry Vicente, Matteo Bonino, Giacomo Cattozzo</label>

                        <label class="mt-5" for="exampleFormControlInput1">DAL CONCETTO ALLA REALTÀ: L'APPLICAZIONE WEB COMPLETA</label>
                        <label for="exampleFormControlInput1">L'obiettivo principale del progetto era sviluppare un'applicazione web sofisticata che potesse raccogliere dati tramite API e file CSV da sorgenti online. Questi dati sono stati poi presentati in forma di grafici e informazioni dettagliate riguardanti domanda e consumo di energia elettrica. Il progetto ha incluso un'analisi dettagliata di variabili influenzanti come il costo delle materie prime e le condizioni meteorologiche.</label>

                        <label class="mt-5" for="exampleFormControlInput1">APPROCCIO DA PROFESSIONISTI</label>
                        <label for="exampleFormControlInput1">
                            Le specifiche dettagliate fornite dai docenti Fabrizio Marchesano e Enrico Barelli hanno guidato ogni passo del nostro processo. La scelta di tecnologie quali MariaDb, C# e Vue.js è stata una decisione consapevole per garantire un'architettura solida e scalabile. La progettazione delle API esterne, l'architettura del database, l'identità grafica e la navigabilità sono state sviluppate seguendo standard di eccellenza.
                        </label>

                        <label class="mt-5" for="exampleFormControlInput1">RINGRAZIAMENTI E FUTURO PROMETTENTE</label>
                        <label for="exampleFormControlInput1">
                            Desideriamo ringraziare sinceramente i docenti Fabrizio Marchesano e Enrico Barelli per averci guidato con saggezza attraverso questa sfida. Il Progetto Industriale 11.2 è stato un banco di prova che ha temprato le nostre abilità e la nostra attitudine professionale.
                        </label>
                        <label class="mt-1" for="exampleFormControlInput1">
                            In un contesto in cui la professionalità è fondamentale, il Progetto Industriale 11.2 ci ha fornito non solo una piattaforma per dimostrare il nostro talento, ma anche un'esperienza che ci accompagnerà nell'affrontare le sfide del mondo professionale.
                        </label>

                    </div>

                    <!--<div class="form-group">
                    <label for="exampleFormControlSelect2">Example multiple select</label>
                    <select multiple class="form-control" id="exampleFormControlSelect2">
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                    </select>
                </div>-->

                </form>

            </div>
        </div>
    </v-container>
   
</template>

<script>
    export default {
        name: 'chisiamo',
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
        margin-left: 20%;
        width: 60%;
        padding: 0.5em .5em .5em;
        border-radius: 0.9em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
    }

</style>