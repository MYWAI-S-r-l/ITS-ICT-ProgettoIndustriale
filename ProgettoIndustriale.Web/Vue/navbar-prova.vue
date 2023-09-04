<template>
    
    <div class="">

        <v-navigation-drawer style="width:250px; height:100%" app v-model="drawer">
            <div align="center" style="padding-top:40px">
                <img src="../wwwroot/assets/Icone/logo.jpg" height="150" class="d-line-block  align-top" alt="">

            </div>
            <nav style="padding-top:20%;">
                <div class="container--fluid">


                    <div>
                        <ul role="menu" aria-labelledby="buttonProva__BV_toggle_" style=" padding-left: 0px; position: relative; transform: translate3d(0px, 0px, 0px); top: 0px; will-change: transform;" x-placement="bottom-start">
                            <li @click="changePage('index')" class="list-group-item list-group-item-action mb-8" style="list-style:none"><i style="padding-right:20px; padding-left:20%"><img src="../wwwroot/assets/Icone/Icona_Home.png" width="30" height="30" /></i>Home</li>
                            <li class="nav-item dropdown list-group-item list-group-item-action mb-8">
                                <i style="padding-right:20px; padding-left:20%"><img src="../wwwroot/assets/Icone/Icona_Grafici.png" width="30" height="30" /></i>Grafici

                                <b-dropdown aria-expanded="true" id="buttonProva" text="">
                                    <b-dropdown-item><i style="padding-right:12px"><img src="../wwwroot/assets/Icone/Ico_Grafico.png" width="25" height="25" /></i>I Grafico</b-dropdown-item>
                                    <b-dropdown-item><i style="padding-right:12px"><img src="../wwwroot/assets/Icone/Ico_Italy.png" width="25" height="25" /></i>II Grafico</b-dropdown-item>
                                </b-dropdown>

                            </li>
                            <li @click="changePage('contact')" class="list-group-item list-group-item-action mb-8" style="list-style:none"><i style="padding-right:20px; padding-left:20%"><img src="../wwwroot/assets/Icone/Icona_Contatti.png" width="30" height="30" /></i>Contatti</li>
                            <li @click="changePage('chisiamo')" class="list-group-item list-group-item-action  mb-8" style="list-style:none"><i style="padding-right:20px; padding-left:20%"><img src="../wwwroot/assets/Icone/Ico_ChiSiamo.png" width="30" height="30" /></i>Chi siamo</li>
                           



                        </ul>
                    </div>
                </div>

            </nav>
        </v-navigation-drawer>
        <!--<footer id="footer">
            <div style="font-size: 19px">copyright Data Specialist 11-2 2023 </div>
        </footer>-->
    </div>

</template>

<style>
    * {
        font-size: 18px;
    }
    #footer {
        position: absolute;
        bottom: 0;
        background-color:white;
        width:100%;
        text-align:center;
        
    }

    .navbar {
        top: 0;
        right: 0;
        width: 100%;
        height: 50vh;
        background-color: white;
    }

    .p4{

    }

   
   

    .list-group-item:hover {
        background: rgb(1,208,114);
        cursor: pointer;
        background: linear-gradient(90deg, rgba(1,208,114,1) 0%, rgba(3,222,206,1) 100%);
    }

   

    #buttonProva__BV_toggle_ {
        background-color: transparent;
        color:black;
        border: none;
    }
    #buttonProva__BV_toggle_ {
        background-color: transparent;
        color: black;
        border: none;
    }
    #dropdown #b-dropdown #show #btn-group{
        background-color:yellow;
    }

    .dropdown-item {
        display: block;
        background-color: transparent;
        border: none;
        text-align: center;
        font-size: 15px;
    }

   

  .dropdown-menu {
        position: relative;
        margin-top: 12px;
        left: 0px;
        font-size: 10px !important;
        width: 290px;
       
    }
  .dropdown-menu li{
      width:100%;
  }

    .v-application a {
        color: #000 !important;
    }
    .dropdown-menu.show {
        position: relative !important;
        transform: translate3d(-80px, 0px, 0px) !important;
        background-color: transparent !important;
        
        border: none;
    }
    .dropdown-item.active, .dropdown-item:active {
        color: #fff;
        text-decoration: none;
        background-color:aquamarine;
        
     
    }
   
   
</style>

<script>
    export default {
        name: 'progetto-nav',
        props: {
            userobject: null,
            currentpage: null
        },
        
        methods: {
            
            changePage: function (page) {
                if (!page)
                    return;
                
                window.location.href = "progettoweb/" + page
            }
            
        }   
    }
</script>


