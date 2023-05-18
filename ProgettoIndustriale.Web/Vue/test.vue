<template>
    <v-container fluid>
        <v-card outlined>
            <v-card-title class="pa-4 mywaiTheme">
                Test
            </v-card-title>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn outlined rounded text
                       @click="helloWorld">
                    <v-icon color="mywai">mdi-plus</v-icon>
                    Chiama api di test
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
                addEnteDialog: false,
                enteToEdit: null,
                showConfirm: false,
                selectedForDelete: null
            };
        },
        methods: {
            helloWorld: function () {
                // pluto
                // paperino
                let that = this;
                that.loading = true;
                services.apiCallerEnti.getTestApi()
                    .then(res => {
                        console.log("got res ", res);
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
