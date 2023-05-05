
<template>
    <v-container fluid style="margin-top:45px" d-flex>
        <v-row align="center" justify="center">
            <v-card color="transparent" flat>
                <br />
                <v-card-text class="pt-4 pb-0" align="center">

                    <div id="errorContainer">
                        <div class="pnf">
                            <h1>An error occurred</h1>
                            <br /><br />
                            <v-row justify="center">
                                <v-img v-if="code==404" src="./assets/images/404.png"
                                       max-height="256" max-width="256"></v-img>
                                <v-img v-else src="./assets/images/error.png"
                                       max-height="256" max-width="256"></v-img>
                            </v-row>
                        </div>
                    </div>

                    <div class="title text-h4">
                        {{message}}
                    </div><br />
                    <div class="text-xl-subtitle-1">
                        Try going back to home page and repeating your action.
                        Or contact helpdesk for support.
                    </div>

                </v-card-text>

            </v-card>
        </v-row>

    </v-container>
</template>


<script>

    export default {
        name: 'error',
        data() {
            return {

            }
        },
        computed: {

        },
        created: function () {
        },
        methods: {
            homePage: function () {
                window.location.href = "/";
            }

        },
        props: {
            path: null,
            message: null,
            code: 0
        }
    }
</script>

<style scoped>
    .v-card-title text {
        font-size: 5em;
    }
    /*    * {
        transition: all 0.6s;
    }

    html {
        height: 100%;
    }

    body {
        font-family: 'Lato', sans-serif;
        color: #888;
        margin: 0;
    }*/

    #errorContainer {
        display: table;
        width: 100%;
        /*height: 100%;*/
        text-align: center;
    }

    .pnf {
        display: table-cell;
        vertical-align: middle;
    }

        .pnf h1 {
            font-size: 50px;
            display: inline-block;
            padding-right: 12px;
            animation: type .5s alternate infinite;
        }

        .pnf h2 {
            font-size: 25px;
            display: inline-block;
            padding-right: 12px;
            animation: type .5s alternate infinite;
            line-height: 1.5em;
        }

            .pnf h2 a:link, .pnf h2 a:visited {
                color: #444;
            }

            .pnf h2 a:link, .pnf h2 a:visited {
                color: #444;
            }
</style>
