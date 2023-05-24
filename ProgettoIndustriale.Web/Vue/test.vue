<template>
    <v-container fluid>
        <v-card outlined>
            <v-card-title class="pa-4 mywaiTheme">
                Test
            </v-card-title>
            <v-row v-if="apiResult !== ''"
                   class="pa-5"
            >
                Ciao {{ apiResult }}
            </v-row>
            <v-row>
                <list-visualizer
                    :list-to-visualize="pippo"
                >
                    
                </list-visualizer>
            </v-row>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn outlined rounded text
                       @click="helloWorld">
                    <v-icon color="mywai">mdi-plus</v-icon>
                    Chiama api di test: {{ apiResult }}
                </v-btn>&nbsp;

                <v-btn outlined rounded text
                       @click="getMyName(0)">
                    <v-icon color="mywai">mdi-plus</v-icon>
                    Chiama getMyName con 0
                </v-btn>&nbsp;

                <v-btn outlined rounded text
                       @click="getMyName(1)">
                    <v-icon color="mywai">mdi-plus</v-icon>
                    Chiama getMyName con 1
                </v-btn>&nbsp;
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script>
    import { services} from "../Scripts/Services/serviceBuilder";
    export default {
        name: 'test',
        data: function () {
            return {
                loading: false,
                apiResult: "",
                pippo: []
            };
        },
        methods: {
            helloWorld: function () {
                let that = this;
                that.loading = true;
                
                services.apiCallerEnti.getTestApi()
                    .then(res => {
                        console.log("got res ", res);
                        that.apiResult = res.data;
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                        that.loading = false;
                    });
            },
            getMyName: function (number) {
                let that = this;
                that.loading = true;

                services.apiCallerEnti.getMyName(number)
                    .then(res => {
                        console.log("got res ", res);
                        that.apiResult = res.data;
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                        that.loading = false;
                    });
            },
            created: function () {
                console.log("created");
            }
        }
    }

</script>
