<template>
    <v-container fluid>
        <v-card outlined>
            <v-card-title class="pa-4 mywaiTheme">
                {{ enteToEdit == null ? 'Aggiungi un nuovo ente' : 'Modifica ente selezionato'}}
            </v-card-title>
            <v-card-text>
                <v-form class="pa-3">
                    <v-row>
                        <v-text-field label="Nome"
                                      prepend-icon="mdi-domain"
                                      v-model="enteToInsert.nome">
                        </v-text-field>
                        <v-text-field label="Sigla"
                                      prepend-icon="mdi-domain"
                                      v-model="enteToInsert.sigla">
                        </v-text-field>
                        <v-select
                            label="Ente Padre"
                            v-model="enteToInsert.parent"
                            :items="possibleParents"
                            item-text="sigla"
                            return-object
                            prepend-icon="mdi-account-edit">
                        </v-select>
                        <v-select
                            v-model="enteToInsert.persone"
                            :items="possiblePersone"
                            item-text="matricola"
                            label="Persone"
                            multiple
                            return-object
                            chips
                            hint="Scegli persone appartenenti"
                            persistent-hint
                        ></v-select>
                    </v-row>
                </v-form>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn outlined rounded text
                       @click="insertEnte()">
                    <v-icon color="mywai">mdi-plus</v-icon>
                    Salva
                </v-btn>&nbsp;
                <v-btn outlined rounded text
                       @click="closeDialog()">
                    <v-icon color="mywai">mdi-minus</v-icon>
                    Cancella
                </v-btn>&nbsp;
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script>
import { services} from "../Scripts/Services/serviceBuilder";
export default {
    name: 'enti-insert',
    data: function () {
        return {
            enteToInsert: {
                nome:"",
                sigla:"",
                parent: null,
                persone: [],
                children: []
            },
            selectedPersone: [],
            selectedParent: null,
            loading: false,
        };
    },
    props: {
        enteToEdit: null,
        possibleParents: null,
        possiblePersone: null,
    },
    watch: {
        enteToEdit: {
            immediate: true,
            handler(val, oldVal) {
                if (val != null) {
                    this.enteToInsert = val;
                }
            }
        }
    }, 
    methods: {
        insertEnte: function () {
            let that = this;
            that.loading = true;
            that.enteToInsert.idParent = that.enteToInsert?.parent?.id ?? null;
            console.log("calling insert ente with: ", that.enteToInsert);
            services.apiCallerEnti.insertEnte(that.enteToInsert)
                .then(res => {
                    that.$emit('inserted-ente', res.data);
                })
                .catch(err => {
                    console.log("got an error: ", err);
                })
                .finally(_ => {
                    that.loading = false;
                });
        },
        closeDialog: function () {
            this.enteToInsert =  {
                nome:"",
                sigla:"",
                parent: null,
                persone: [],
                children: []
            };
            this.$emit('close-dialog-ente');
        }

    },
    created: function() {
        console.log("created enti insert page");
    }
}

</script>
