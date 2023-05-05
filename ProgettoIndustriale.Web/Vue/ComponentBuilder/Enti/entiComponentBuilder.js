import leftMenu from "../../left-menu.vue";
import notifier from "../../notifier.vue";
import mywaiKendoGrid from "../../mywai-kendo-grid.vue";
import enti from "../../enti.vue";
import entiInsert from "../../enti-insert.vue";
import deleteEditActions from "../../delete-edit-component.vue";
import dialogDelete from "../../dialog-delete.vue";

Vue.component("custom", deleteEditActions);
Vue.component("left-menu", leftMenu);
Vue.component("mywai-kendo-grid", mywaiKendoGrid);
Vue.component("notifier", notifier);
Vue.component("enti", enti);
Vue.component("enti-insert", entiInsert);
Vue.component("dialog-delete", dialogDelete);

//Kendo UI
import { Button } from '@progress/kendo-vue-buttons';
import { ComboBox } from '@progress/kendo-vue-dropdowns';
import { Dialog, DialogActionsBar } from '@progress/kendo-vue-dialogs';
import { Grid, GridNoRecords, GridToolbar } from '@progress/kendo-vue-grid';
import { Input, MaskedTextBox  } from "@progress/kendo-vue-inputs";
import { TabStrip, TabStripTab } from '@progress/kendo-vue-layout';
import { Fade } from '@progress/kendo-vue-animation';
import { Upload } from '@progress/kendo-vue-upload';


Vue.component("k-button", Button);
Vue.component("combobox", ComboBox);
Vue.component("k-dialog", Dialog);
Vue.component("dialog-actions-bar", DialogActionsBar);
Vue.component("Grid", Grid);
Vue.component('grid-norecords', GridNoRecords);
Vue.component("k-input", Input);
Vue.component("maskedtextbox", MaskedTextBox);
Vue.component("tabstrip", TabStrip);
Vue.component("tabstripTab", TabStripTab);
Vue.component("toolbar", GridToolbar);
Vue.component("Fade", Fade);
Vue.component("kendo-upload", Upload);

Vue.config.devtools = true;