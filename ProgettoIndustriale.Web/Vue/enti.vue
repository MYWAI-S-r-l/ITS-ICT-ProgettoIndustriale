<template>
    <v-container fluid>
        <v-card outlined>
            <enti-insert v-if="addEnteDialog"
                            :enteToEdit="enteToEdit"
                            :possibleParents="enteToEdit == null ? enti : enti.filter(e => e.id !== enteToEdit.id)"
                            :possiblePersone="possiblePersone"
                            @inserted-ente="addEnteToList"
                            @close-dialog-ente="addEntiDialogOpenClose(false)">
            </enti-insert>
            <v-card-title class="pa-4 mywaiTheme">
                Visualizzazione Enti
            </v-card-title>
            <v-row class="pa-5">
                <v-skeleton-loader v-if="loading" type="article"></v-skeleton-loader>
                <mywai-kendo-grid v-else 
                                  :dataItems="enti"
                                  file-name="entiExcel.xlsx"
                                  :addDeleteEnabled="true"
                                  :headers="entiHeaders"
                                  @edit-row="editCalled"
                                  @delete-row="deleteCalled">
                </mywai-kendo-grid>
            </v-row>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn outlined rounded text
                       @click="addEntiDialogOpenClose(true)">
                    <v-icon color="mywai">mdi-plus</v-icon>
                    Aggiungi un ente
                </v-btn>&nbsp;
            </v-card-actions>
        </v-card>
        <v-dialog v-if="showConfirm"
                  v-model="showConfirm"
                  style="margin: 0"
                  scrollable>
            <dialog-delete
                v-if="showConfirm"
                name="Ente"
                @remove-canceled="deleteCancelled"
                @remove-confirmed="deleteConfirmed">
            </dialog-delete>
        </v-dialog>
    </v-container>
</template>

<script>
    import { services} from "../Scripts/Services/serviceBuilder";
    export default {
        name: 'enti',
        data: function () {
            return {
                enti: [],
                entiHeaders: [
                    { field: 'sigla', title: 'Sigla', filterable: true },
                    { field: 'nome', title: 'Nome esteso', filterable: true },
                    { field: 'parent.sigla', title: 'Sigla Ente Padre', filterable: true },
                    { title: 'Actions', cell: 'myTemplate', filterable: false, width: '125px' }
                ],
                loading: false,
                addEnteDialog: false,
                enteToEdit: null,
                possiblePersone: [],
                showConfirm: false,
                selectedForDelete: null
            };
        },
        methods: {
            getAllEnti: function () {
                let that = this;
                that.loading = true;
                services.apiCallerEnti.getAllEnti()
                    .then(res => {
                        that.enti = res.data;
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                    that.loading = false;
                });
            },
            getAllPossiblePersone: function () {
                let that = this;
                that.loading = true;
                services.apiCallerPersone.getAllPersone()
                    .then(res => {
                        that.possiblePersone = res.data;
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                        that.loading = false;
                    });
            },
            addEntiDialogOpenClose: function (openClose) {
                this.addEnteDialog = openClose;
                if(openClose)
                    this.enteToEdit = null;
            },
            addEnteToList: function (enteToAdd) {
                this.enti = this.enti.filter(el => el.id !== enteToAdd.id);
                this.enti.push(enteToAdd);
                this.addEntiDialogOpenClose(false);
            },
            editCalled: function (datum) {
                console.log("editCalled with datum: ", datum);
                this.enteToEdit = datum;
                this.addEnteDialog = true;
            },
            deleteCancelled: function () {
              this.showConfirm = false;  
              this.selectedForDelete = null;
            },
            deleteCalled: function (datum) {
                this.showConfirm = true;
                this.selectedForDelete = datum;
                
            },
            deleteConfirmed: function () {
                let that = this;
                services.apiCallerEnti.deleteEnte(that.selectedForDelete.id)
                    .then(res => {
                        that.enti = that.enti.filter(el => el.id !== that.selectedForDelete.id);
                    })
                    .catch(err => {
                        console.log("got an error: ", err);
                    })
                    .finally(_ => {
                        that.loading = false;
                        that.selectedForDelete = null;
                        that.showConfirm = false;
                    });
            }
        },
        created: function() {
            this.getAllEnti();
            this.getAllPossiblePersone();
        }
    }

</script>
