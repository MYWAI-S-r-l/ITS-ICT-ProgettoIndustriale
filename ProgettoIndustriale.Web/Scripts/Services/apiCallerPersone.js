export default class ApiCallerPersone {

    constructor(helper) {
        this.apiCallerHelper = helper;
    }

    getAllPersone() {
        const url = `${commonModule.webApiBaseUrl}/persone/getAll`;
        return this.apiCallerHelper.callGetWithBearer(url);
        // return this.apiCallerHelper.callGetWithoutBearerForTest(url);
        
    }
    
    insertPersona(personaToInsert) {
        const url = `${commonModule.webApiBaseUrl}/persone/upsertPersona`;
        return this.apiCallerHelper.callPostWithBearer(url, personaToInsert, false);
    }
    
    deletePersona(id) {
        const url = `${commonModule.webApiBaseUrl}/persone/delete/${id}`;
        return this.apiCallerHelper.callPostWithBearer(url, null, false);
    }
    
}
