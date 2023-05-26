<template>
    <v-container fluid>
        <v-card outlined>
            <v-card-title class="pa-4 mywaiTheme">
                Meteo Province Getter
            </v-card-title>
            <v-row class="pa-5" v-if="meteoData != null">
                <simple-meteo-plot :meteoResponse="meteoData"></simple-meteo-plot>
            </v-row>
            <v-row>
                <list-visualizer
                    :list-to-visualize="pippo"
                    :column-names="['codice', 'nome', 'sigla', 'regione']"
                    @pass-to-father="selectElement"
                >
                    
                </list-visualizer>
            </v-row>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn outlined rounded text
                       @click="riempiLista(10)">
                    Get Province List
                    <v-icon color="mywai">mdi-plus</v-icon>
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
                pippo: [],
                meteoData: null
            };
        },
        methods: {
            riempiLista: function () {
                let that = this;
                this.pippo = [];
                services.apiCallerProvince.getAllProvince()
                    .then(res => {
                        that.pippo = res.data;
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                        that.loading = false;
                    });
            },
            selectElement: function (value) {
                let that = this;
                that.meteoData = null;
                services.apiCallerProvince.getMeteoForProvincia(value)
                    .then(res => {
                        console.log("got res ", res);
                        that.meteoData = res.data;
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                        that.loading = false;
                    });
            },
        }
    }

</script>
