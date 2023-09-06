<template>
    
    <v-container>
        <div class="row mb-0">
            <div class="card mb-0">
                <h4 class="col-12" style="text-align:center">CONTATTACI</h4>
            </div>
        </div>
        <div class="row mt-2">
            <div class="card mt-0">
                <form class="font-italic" id="myForm"  method="post" @submit="postData">
                    <div class="form-group">

                        <label class="mt-2" for="email">Email</label>
                        <input  type="email" class="form-control" id="email"   placeholder="name@example.com" required>
                        <label class="mt-5" for="exampleFormControlInput1">Name</label>
                        <input type="text" class="form-control" id="nametxt"  placeholder="Nome" required>
                        <label class="mt-5" for="exampleFormControlInput1">Cognome </label>
                        <input type="text" class="form-control" id="cognometxt" placeholder="Cognome" required>
                        <label class="mt-5" for="exampleFormControlInput1">Cellulare</label>
                        <input type="tel" class="form-control" id="celltxt" placeholder="Cellulare">


                        <label for="exampleFormControlTextarea1">Inserire messaggio</label>
                        <textarea class="form-control" id="Textarea" rows="5"></textarea>
                        <input id="btn-form" class="btn btn-primary mt-2" style="width:150px" type="submit" value="Invia" />
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
                
            },
            postData: async function (e) {
               
                

                let jsonObject = {
                    name: document.querySelector("#nametxt").value,
                    cognome: document.querySelector("#cognometxt").value,
                    mail: document.querySelector("#email").value,
                    cell: document.querySelector("#celltxt").value,
                    testo: document.querySelector("#Textarea").value,
                };

                const dataresponse = await axios.post('https://localhost:7235/api/Contact/SendContactData', jsonObject, {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                
                if (dataresponse.data.ris) {
                    window.alert("Messaggio inviato correttamente")
                    
                }
                else {
                    window.alert(dataresponse.data.messagge)

                }
                
                console.log(data);
                console.log("data return");
                
                
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
        margin-top: 20px;
        margin-bottom: 20px;
        margin-left: 20%;
        width: 60%;
        padding: 0.3em .3em .3em;
        border-radius: 2em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
    }

</style>