export default class ApiCallerProvince {

    constructor(helper) {
        this.apiCallerHelper = helper;
    }
    getAllProvince() {
        const url = `${commonModule.webApiBaseUrl}/province/getAll`;
        // return this.apiCallerHelper.callGetWithBearer(url);
        return this.apiCallerHelper.callGetWithoutBearerForTest(url);
    }

    getMeteoForProvincia(provinciaForMeteo) {
        const url = `${commonModule.webApiBaseUrl}/province/getMeteoForProvincia`;
        return this.apiCallerHelper.callPostWithoutBearerForTest(url, provinciaForMeteo);

    }
}
