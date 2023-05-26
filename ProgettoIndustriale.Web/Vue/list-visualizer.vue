<template>
    <v-container fluid>
        <v-simple-table>
            <template v-slot:default>
                <thead>
                <tr>
                    <th v-for="column in columnNames" :key="column">{{ column }}</th>
                    <th>Actions</th> <!-- Empty header for the button column -->
                </tr>
                </thead>
                <tbody>
                <tr v-for="item in listToVisualize" :key="item.id">
                    <td v-for="column in columnNames" :key="column">{{ item[column] }}</td>
                    <td>
                        <v-btn @click="passToFather(item)"> Get Meteo</v-btn>
                    </td>
                </tr>
                </tbody>
            </template>
        </v-simple-table>
    </v-container>
</template>

<script>
    export default {
        name: 'list-visualizer',
        data() {
            return {
                
            }
        },
        props: {
            listToVisualize: [],
            columnNames: []
        },
        methods: {
            passToFather: function (value) {
                this.$emit('pass-to-father', value);
            }
        }
    }
</script>

<style>

</style>
