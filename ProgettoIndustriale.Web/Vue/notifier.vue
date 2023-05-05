<template>
    <div id="notifierDiv">
        <v-snackbar v-if="!isError"
                    :timeout="timeout" v-model="visible" :absolute="true" :color="color"
                    :top="true" :right="true">
            <v-row class="pa-0 d-flex justify-space-between">
                <v-icon size="28" color="mywai">
                    mdi-check-bold
                </v-icon>
                <div class="d-flex justify-space-between align-center">
                    <v-label> {{messageInfo}}</v-label>
                    <v-btn icon @click="visible = false">
                        <v-icon size="28" color="mywai">mdi-close-circle</v-icon>
                    </v-btn>
                </div>
            </v-row>
        </v-snackbar>
        <v-dialog v-else v-model="visible" width="400">
            <v-card color="error">
                <v-alert type="error">
                    {{messageInfo}}
                </v-alert>
                <v-divider></v-divider>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="white" text @click="visible = false">
                        Close
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
    export default {
        name: 'notifier',
        data() {
            return {
                visible: this.value
            }
        },
        props: {
            value: { type: Boolean, default: false },
            timeout: { type: Number, default: 5000 },
            messageInfo: { type: String, default: "" },
            isError: { type: Boolean, default: false },
            color: { type: String, default: "mywaiTheme" }
        },
        watch: {
            visible: function (val) {
                this.$emit('input', val)
            },
            value: function (newValue) {
                this.visible = newValue;
            }
        }
    }
</script>

<style>
    #notifierDiv {
        position: fixed !important;
        width: 500px;
        right: 0;
        z-index:99;
    }
</style>
