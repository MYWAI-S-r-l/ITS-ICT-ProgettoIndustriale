<template>
    <v-container fluid>
        <li v-for="value in listToVisualize">
            {{ value }}
        </li>
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
            listToVisualize: []
        },
    }
</script>

<style>

</style>
