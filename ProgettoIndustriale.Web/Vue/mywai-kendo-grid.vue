<template>
    <div>
        <Grid
            ref="grid"
            :style="{ height: '500px' }"
            :data-items="result"
            :columns="headers"
            :column-menu="columnMenu"
            :resizable="true"
            :reorderable="true"
            :sortable="true"
            :pageable="gridPageable"
            :sort="sort"
            :filter="filter"
            :take="take"
            :skip="skip"
            :expand-field="expandField"
            :selectable="true"
            :selected-field="selectedField"
            @sortchange="sortChangeHandler"
            @selectionchange="onSelectionChange"
            @headerselectionchange="onHeaderSelectionChange"
            @datastatechange="dataStateChange"
            @expandchange="expandChange"
            >
            <template v-slot:myTemplate="{props}">
                <custom
                        @edit-row="fireEvent(true, $event)"
                        @delete-row="fireEvent(false, $event)"
                        @download-data="fireDownloadEvent($event)"
                        :download-button="downloadButton"
                        :data-item="props.dataItem" 
                        :edit-delete-buttons="editDeleteButton"/>
            </template>
            <toolbar>
                <span class="k-textbox k-grid-search k-display-flex">
                    <k-input :style="{ width: '230px' }"
                             :placeholder="gridSearchMessage"
                             :value="searchWord"
                             @input="onFilter">
                    </k-input>
                </span>
                <span class="export-buttons">
                    <k-button
                        title="Export to Excel"
                        :theme-color="'primary'"
                        @click="exportExcel">
                      {{ exportExcelMessage }}
                    </k-button>
                      &nbsp;
<!--                        <kbutton :theme-color="'primary'" @click="exportPDF">-->
<!--                          {{ exportPdfMessage }}-->
<!--                        </kbutton>-->
                </span>
            </toolbar>
        </Grid>
    </div>
</template>

<script>
import {saveExcel} from "@progress/kendo-vue-excel-export";
import {orderBy} from '@progress/kendo-data-query';
import { process } from "@progress/kendo-data-query";
export default {
    name: "mywai-kendo-grid",
    data: function () {
        return {
            searchWord: "",
            columnMenu: true,
            selectedField: "selected",
            expandField: "expanded",
            gridPageable: {
                buttonCount: 5,
                info: true,
                type: "numeric",
                pageSizes: true,
                previousNext: true,
            },
            gridData: [],
            skip: 0,
            take: 10,
            group: [],
            sort: [],
            filter: null,
            expandedItems: [],
        };
    },
    props: {
        dataItems: null,
        headers: null,
        fileName: null,
        editDeleteButton: true,
        downloadButton: false
    },
    created: function () {
        this.gridData = this.dataItems;
    },
    mounted: function () {
    },
    computed: {
        areAllSelected() {
            return this.dataItems.findIndex((item) => item.selected === false) === -1;
        },
        // exportPdfMessage() {
        //     return provideLocalizationService(this).toLanguageString(
        //         "exportPdf",
        //         "Export to PDF"
        //     );
        // },
        exportExcelMessage() {
            return "Export to Excel";
        },
        gridSearchMessage() {
            return "Search in all columns...";
        },
        result: {
            get: function () {
                if (this.searchWord === "")
                    this.gridData = this.dataItems;
                return orderBy(this.gridData, this.sort);
            },
        },
    },
    methods: {
        fireEvent: function (eventToFire, eventFired) {
            if (eventToFire){
                this.$emit('edit-row', eventFired);
            }
            else {
                this.$emit('delete-row', eventFired);
            }
        },
        fireDownloadEvent: function(eventData) {
          this.$emit('download-file', eventData);  
        },
        onFilter(e) {
            console.log("called filter with: ",e);
            let that = this;
            this.searchWord =  e.value;
            this.gridData = process(that.dataItems, {
                filter: {
                    logic: 'or',
                    filters: that.headers.filter(x => x.filterable).map(h => {
                        return {
                            field: h.field,
                            operator: 'contains',
                            value: e.value
                        }
                    }),
                },

            });
            console.log("grid data after process: ", this.gridData);
            console.log("dataItems after process: ", this.dataItems);
        },
        sortChangeHandler: function(event) {
            this.sort = event.sort;
        },
        onHeaderSelectionChange(event) {
            let checked = event.event.target.checked;
            this.gridData.data = this.gridData.data.map((item) => {
                return { ...item, selected: checked };
            });
        },
        createAppState: function (dataState) {
            this.group = dataState.group;
            this.take = dataState.take;
            this.skip = dataState.skip;
            this.sort = dataState.sort;
            this.filter = dataState.filter;
        },
        dataStateChange: function (event) {
            this.createAppState(event.data);
        },
        expandChange: function (event) {
            if (event.dataItem) {
                //event.dataItem[event.target.$props.expandField] = event.value;
                //
                // In Vue 2 context, instead of the above line, inside the expandChange method we should have the following:
                
                  Vue.set(
                    event.dataItem,
                    event.target.$props.expandField,
                    event.dataItem.expanded === undefined ? false : !event.dataItem.expanded
                  );
                
            }
        },
        exportExcel() {
            const columnsToExport = [...this.headers];
            saveExcel({
                data: this.gridData,
                fileName: this.fileName != null ? this.fileName : "excel_export",
                columns: columnsToExport,
            });
        },
        // exportPDF() {
        //     const tempSort = this.sort;
        //     this.sort = null;
        //     this.$nextTick(() => {
        //         this.columnMenu = false;
        //         this.$refs.gridPdfExport.save(
        //             process(this.gridData.data, { skip: this.skip, take: this.take })
        //         );
        //         this.columnMenu = true;
        //         this.sort = tempSort;
        //     });
        // },
        onSelectionChange(event) {
            event.dataItem[this.selectedField] = !event.dataItem[this.selectedField];
        }
    },
};
</script>

<style>
td.text-center {
    text-align: center;
}

.red {
    color: #d9534f;
}

.text-bold {
    font-weight: 600;
}
.export-buttons {
    margin-left: auto;
    margin-right: 0;
}
</style>