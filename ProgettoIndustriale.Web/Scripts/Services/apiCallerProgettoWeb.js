export default class ApiCallerProgettoWeb
{

    constructor(helper) {
        this.apiCallerHelper = helper;
    }

    
    getCommoditiesByDate(currentdate) {
        
        const url = `${commonModule.webApiBaseUrl}/Commodity/getCommoditybyDates?startDate=2023-1-1&endDate=${currentdate}`;
        // return this.apiCallerHelper.callGetWithBearer(url);
        return this.apiCallerHelper.callGetWithoutBearerForTest(url);
    }
    
}