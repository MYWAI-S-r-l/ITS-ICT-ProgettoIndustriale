<template>
    
    <v-container>
      
        <div class="row mb-0">
            <div class="card mb-0">
                <h4 class="col-12" style="text-align:center">CONTATTACI</h4>
            </div>
        </div>
        <div class="row mt-2">

            <div class="card mt-0">
                <form class="font-italic" id="myForm" v-on:submit="postData" method="post">


                    <div class="form-group">


                        <label class="mt-2" for="email">Email</label>
                        <input type="email" class="form-control" id="email" placeholder="name@example.com" required>
                        <label class="mt-5" for="exampleFormControlInput1">Name</label>
                        <input type="text" class="form-control" id="nametxt" placeholder="Nome" required>
                        <label class="mt-5" for="exampleFormControlInput1">Cognome </label>
                        <input type="text" class="form-control" id="cognometxt" placeholder="Cognome" required>
                        <label class="mt-5" for="exampleFormControlInput1">Cellulare</label>
                        <input type="tel" class="form-control" id="celltxt" placeholder="Cellulare">


                        <label for="exampleFormControlTextarea1">Inserire messaggio</label>
                        <textarea class="form-control" id="Textarea" rows="5"></textarea>



                        <button id="btn-form" class="btn btn-primary mt-2" style="width:150px" type="submit" value="Invia"> <i>Invia</i><div id="spinner" class=" loader-container spinner-border spinner-border-sm" role="status" aria-hidden="true"></div></button>
                    </div>
                    <div id="popMessagge">
                        ciao
                    </div>

                </form>

            </div>
        </div>
    </v-container>
   
</template>

<script>

    function popupmessagge(data) {
        var errorDiv = document.getElementById("popMessagge");
        
        // Imposta lo stile del div (colore rosso, bordo, posizione, ecc.)
        errorDiv.style.display = "block";
  
        // Aggiungi il testo del messaggio di errore al div
        errorDiv.innerHTML = data.messagge;

        // Aggiungi il div al documento

        // Imposta una funzione per rimuovere il div dopo 10 secondi
        if (data.ris) {
            setTimeout(function () {
                errorDiv.style.display = "none";
                location.reload();
            }, 4000);
        }
        else {
            setTimeout(function () {
                errorDiv.style.display = "none";                
            }, 4000);

        }
       
        
        
        
    }
    export default {
        name: 'contact',
        data: function () {
            return {
                loading: false,
            };
        },
        methods: {

            controlData: function () {
                this.postData();
            },
            hideButton: function () {
                
            },
               
            postData: function  (e) {
                
                var button = document.getElementById("spinner");
                button.style.display = "initial";
                
                // Altrimenti, impostare il suo stile display a "inline-block"
               

                console.log("provaHidden")


                let jsonObject = {
                    name: document.querySelector("#nametxt").value,
                    cognome: document.querySelector("#cognometxt").value,
                    mail: document.querySelector("#email").value,
                    cell: document.querySelector("#celltxt").value,
                    testo: document.querySelector("#Textarea").value,
                };
                
                let ris = "fatto";
                const { dataresponse } = axios.post('https://localhost:7235/api/Contact/SendContactData', jsonObject, {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(function (response) {
                        console.log(response)
                        
                        button.style.display = "none";
                        
                        if (response.data.ris) {
                            
                           popupmessagge(response.data);
                            

                        }
                        else {
                            popupmessagge("falso");
                            popupmessagge(response.data);
                            
                        }
                        
                        

                    })
                    .catch(function (error) {
                        popupmessagge(error);
                    });
                    
                
                  
                
                    
                
                e.preventDefault()
                
                console.log("buonfine");
                console.log("data return");
                
                
            }


        },
        mounted:  function () {
            //document.getElementById("myForm").addEventListener("submit"), function (event) {
            //    event.preventdefault(); controlData();
            //}

        },


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
        background: linear-gradient(90deg, rgba(1,208,114,1) 0%, rgba(3,222,206,1) 100%);
      
            
        
    }
    main {
        background: rgb(1,208,114);
        background: linear-gradient(90deg, rgba(1,208,114,1) 0%, rgba(3,222,206,1) 100%);
        
    }
    /* Selezionare il bottone con l'id "btn-form" */

    #popMessagge {
        
       
        display:none;
        padding-top: 1.5em;
        margin-top: 10px;
        width: 100%;
        text-align: center;
        height: 100px;
        background: rgb(2,0,36);
        background: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(237,246,246,1) 0%);
        border-radius: 0.4em;
        box-shadow: 1px 1px 4px rgb(1,208,114);
        border-color: white;
       
        z-index: 3;
        transform: translate(0, -180px)
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
        border-radius: 0.9em;
        text-align: left;
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
        border-color: darkgreen;
    }
    
    .loader-container {
        width: 20px;
        height: 20px;
        position: absolute;
        margin-top: 4px;
        margin-left:10px;
        z-index: 1;
        display:none;
       
    }
    

</style>