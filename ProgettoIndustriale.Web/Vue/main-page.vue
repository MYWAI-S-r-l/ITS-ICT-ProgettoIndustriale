<template>
    <v-container fluid>
        <v-card outlined>
            <v-card-title class="pa-4 mywaiTheme">
                This is a main page
            </v-card-title>
            
            <v-card-actions>
                <v-spacer></v-spacer>
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script>
    // import { services} from "../Scripts/Services/serviceBuilder";
    export default {
        name: 'main-page',
        data: function () {
            return {
                loading: false,
            };
        },
        methods: {
        },
        created: function() {
            console.log("created main page");
        }
    }

</script>
