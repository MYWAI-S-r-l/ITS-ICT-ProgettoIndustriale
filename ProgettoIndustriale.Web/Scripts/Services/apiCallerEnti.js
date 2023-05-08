export default class ApiCallerEnti {

    constructor(helper) {
        this.apiCallerHelper = helper;
    }

    getAllEnti() {
        const url = `${commonModule.webApiBaseUrl}/enti/getAll`;
        // return this.apiCallerHelper.callGetWithBearer(url);
        return this.apiCallerHelper.callGetWithoutBearerForTest(url);
        
    }
    
    insertEnte(enteToInsert) {
        const url = `${commonModule.webApiBaseUrl}/enti/upsertEnte`;
        // return this.apiCallerHelper.callPostWithBearer(url, enteToInsert, false);
        console.log("calling: ", url, " with: ", enteToInsert);
        return this.apiCallerHelper.callPostWithoutBearerForTest(url, enteToInsert);
        
    }

    deleteEnte(id) {
        const url = `${commonModule.webApiBaseUrl}/enti/delete/${id}`;
        // return this.apiCallerHelper.callPostWithBearer(url, null, false);
        return this.apiCallerHelper.callGetWithoutBearerForTest(url);
        
    }
}
