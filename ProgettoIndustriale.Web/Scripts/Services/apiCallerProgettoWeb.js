export default class ApiCallerProgettoWeb
{

    constructor(helper) {
        this.apiCallerHelper = helper;
    }

    
    getLastCommodities() {
        
        const url = `${commonModule.webApiBaseUrl}/Utils/getLastCommodities`;
        // return this.apiCallerHelper.callGetWithBearer(url);
        return this.apiCallerHelper.callGetWithoutBearerForTest(url);
    }
    
}