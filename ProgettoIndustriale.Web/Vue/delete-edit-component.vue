<template>
    <td class="customButtons">
            <div class="d-flex justify-space-around align-center flex-column flex-sm-row">
                <v-btn small class="primary customSmallButton" @click="fireEvent(true)">
                    <v-icon>mdi-pencil</v-icon>
            </v-btn>
            <v-btn small class="red lighten-1 customSmallButton" @click="fireEvent(false)">
                <v-icon>mdi-trash-can-outline</v-icon>
            </v-btn>
            <v-btn v-if="downloadButton" small class="customSmallButton"  @click="fireEventDownload">
                <v-icon>mdi-file-download-outline</v-icon>
            </v-btn>
        </div>
    </td>
</template>
<script>

export default {
    props: {
        dataItem: Object,
        editDeleteButtons: false,
        downloadButton: false
    },
    methods: {
        fireEvent: function (eventToFire) {
            if (eventToFire){
                this.$emit('edit-row', this.dataItem);
            }
            else {
                this.$emit('delete-row', this.dataItem);                
            }
        },
        fireEventDownload: function() {
            this.$emit('download-data', this.dataItem);
        }
    },
    created: function() {
    },
    mounted: function() {
    },
}
</script>
<style>
.customSmallButton{
    max-width: 15px !important;
    width: 15px !important;
    min-width: 0 !important;
}
.customSmallButton{
  max-width: 20px !important;
  width: 20px !important;
  min-width: 0 !important;
}
</style>