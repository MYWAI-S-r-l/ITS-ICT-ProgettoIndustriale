<template>
    
    <v-container>
        <div class="row mb-0">
            <div class="card mb-0">
                <h1 class="col-12" style="text-align:center">CONTATTACI</h1>
            </div>
        </div>
        <div class="row mt-5">
            <div class="card mt-0">
                <form class="form font-italic" id="myForm" method="post">
                    <div class="form-group">
                        <label class="mt-5" for="exampleFormControlInput1">Email</label>
                        <input type="email" class="form-control" id="emailtxt" placeholder="name@example.com">
                        <label class="mt-5" for="exampleFormControlInput1">Name</label>
                        <input type="text" class="form-control" id="nametxt" placeholder="Nome">
                        <label class="mt-5" for="exampleFormControlInput1">Cognome </label>
                        <input type="text" class="form-control" id="cognometxt" placeholder="Cognome">
                        <label class="mt-5" for="exampleFormControlInput1">Cellulare</label>
                        <input type="tel" class="form-control" id="celltxt" placeholder="Cellulare">
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
                    <div class="form-group">
                        <label for="exampleFormControlTextarea1">Inserire messaggio</label>
                        <textarea class="form-control" id="Textarea" rows="7"></textarea>
                        <input id="btn-form" class="btn btn-primary mt-2" style="width:160px" type="button" value="INVIA" @click="created()" />
                    </div>

                </form>

            </div>
        </div>
    </v-container>
   
</template>

<script>
    export default {
        name: 'contact',
        data: function () {
            return {
                loading: false,
            };
        },
        methods: {

            created: function () {


                let jsonObject = {
                    name: document.querySelector("#nametxt").value,
                    cognome: document.querySelector("#cognometxt").value,
                    mail: document.querySelector("#emailtxt").value,
                    cell: document.querySelector("#celltxt").value,
                    testo: document.querySelector("Textarea").value,
                };


                this.postData(jsonObject);
                
                console.log(jsonObject);
            },
            postData: async function (json) {
                const data = await axios.post('https://localhost:7235/api/Contact/SendContactData', json, {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                console.log(data.cognome);
                
                
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
        width: 60%;
        margin-left: 20%;
    }

    .card {
        margin-top: 25px;
        margin-bottom: 50px;
        margin-left: 20%;
        width: 60%;
        padding: 0.5em .5em .5em;
        border-radius: 2em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
    }

</style>