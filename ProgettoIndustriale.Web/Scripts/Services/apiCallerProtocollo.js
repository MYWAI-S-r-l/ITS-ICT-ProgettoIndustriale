export default class ApiCallerProtocollo {

    constructor(helper) {
        this.apiCallerHelper = helper;
    }

    //Protocollo Section
    getProtocolloById(id) {
        const url = `${commonModule.webApiBaseUrl}/protocollo/get/${id}`;
        return this.apiCallerHelper.callGetWithBearer(url);
    }

    getAllAttiGiudiziari() {
        console.log("called getAllProtocollo");
        const url = `${commonModule.webApiBaseUrl}/AttiGiudiziari/getAll`;
        console.log("url: ", url);
        return this.apiCallerHelper.callGetWithBearer(url);
        
    }
    
    downloadAttoGiudiziario(attoId) {
        console.log("called downloadAttoGiudiziario with id: ", attoId);
        const url = `${commonModule.webApiBaseUrl}/AttiGiudiziari/DownloadAttoGiudiziario/${attoId}`;
        return this.apiCallerHelper.callGetFileWithBearer(url);
    
    }
    
    uploadAttoGiudiziario(data) {
        console.log("called uploadAttiGiudiziari with ", data);
        const url = `${commonModule.webApiBaseUrl}/AttiGiudiziari/uploadAttoGiudiziario`;
        //TODO: put bearer again
        return this.apiCallerHelper.callPostWithBearer(url, data, true);
    }

    getAllPostaEntrata() {
        console.log("called getAllPostaEntrata");
        console.log("commonModule: ", commonModule);
        const url = `${commonModule.webApiBaseUrl}/PostaEntrata/getAll`;
        console.log("url: ", url);
        return this.apiCallerHelper.callGetWithBearer(url);
        // return this.apiCallerHelper.callGetWithoutBearerForTest(url);
    }

    uploadPostaEntrata(data) {
        console.log("called uploadPostaEntrata with ", data);
        console.log("commonModule: ", commonModule);
        const url = `${commonModule.webApiBaseUrl}/PostaEntrata/uploadPostaEntrata`;
        console.log("url: ", url);
        //TODO: put bearer again
        return this.apiCallerHelper.callPostWithBearer(url, data, true);
        // return this.apiCallerHelper.callPostWithoutBearerForTest(url, data, true);
    }

    getAllPostaUscita() {
        console.log("called getAllPostaUscita");
        console.log("commonModule: ", commonModule);
        const url = `${commonModule.webApiBaseUrl}/PostaUscita/getAll`;
        console.log("url: ", url);
        return this.apiCallerHelper.callGetWithBearer(url);
        // return this.apiCallerHelper.callGetWithoutBearerForTest(url);
    }

    uploadPostaUscita(data) {
        console.log("called uploadPostaEntrata with ", data);
        console.log("commonModule: ", commonModule);
        const url = `${commonModule.webApiBaseUrl}/PostaUscita/uploadPostaUscita`;
        console.log("url: ", url);
        //TODO: put bearer again
        return this.apiCallerHelper.callPostWithBearer(url, data, true);
        // return this.apiCallerHelper.callPostWithoutBearerForTest(url, data, true);
    }
}
