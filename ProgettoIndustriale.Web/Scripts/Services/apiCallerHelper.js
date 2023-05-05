export default class ApiCallerHelper {
    
    getBearerToken() {
        // console.log("called getBearerToken");
        // console.log("commonModule.webApiBaseUrl: ", commonModule.webApiBaseUrl);
        // console.log("commonModule.webBaseUrl: ", commonModule.webBaseUrl);
        //
        const tokenUrl = commonModule.webBaseUrl + "AuthHelper/GetAccessToken";
        return window.axios.get(tokenUrl);
    }

    callGetWithBearer(urlToCall) {
        let that = this;

        return new Promise((resolve, reject) => {
            that.getBearerToken().then((res) => {
                if (res.data !== "") {
                    window.axios({
                        method: "get",
                        headers: {
                            'Authorization': 'Bearer ' + res.data
                        },
                        url: urlToCall
                    }).then(result => {
                        return resolve(result);
                    }).catch((err) => {
                        return reject(err);
                    });
                }
                else {
                    window.location.href = "/Home/Logout";
                }
            });
        });
    }

    callGetWithoutBearerForTest(urlToCall) {
        return new Promise((resolve, reject) => {
            window.axios({
                method: "get",
                headers: {
                },
                url: urlToCall
            }).then(result => {
                return resolve(result);
            }).catch((err) => {
                return reject(err);
            });
        });
    }
    
    callGetFileWithBearer(urlToCall) {
        let that = this;

        return new Promise((resolve, reject) => {
            that.getBearerToken().then((res) => {
                if (res.data !== "") {
                    window.axios({
                        method: "get",
                        headers: {
                            'Authorization': 'Bearer ' + res.data
                        },
                        responseType: 'arraybuffer',
                        url: urlToCall
                    }).then(result => {
                        return resolve(result);
                    }).catch((err) => {
                        return reject(err);
                    });
                }
                else {
                    window.location.href = "/Home/Logout";
                }
            });
        });
    }

    callPutWithBearer(urlToCall) {
        var that = this;

        return new Promise((resolve, reject) => {
            that.getBearerToken().then((res) => {
                if (res.data !== "") {
                    window.axios({
                        method: "put",
                        headers: {
                            'Authorization': 'Bearer ' + res.data
                        },
                        url: urlToCall
                    }).then(result => {
                        return resolve(result);
                    }).catch((err) => {
                        return reject(err);
                    });
                }
                else {
                    window.location.href = "/Home/Logout";
                }

            });
        });
    }
    
    callPostWithoutBearerForTest(urlToCall, data, isJson=true) {
        return new Promise((resolve, reject) => {
            let headersToUse = isJson ? {
                'Content-Type': 'application/json',
            } : {
                'Accept': 'application/json',
                "Content-Type": "multipart/form-data"
            };
            window.axios({
                method: "post",
                headers: headersToUse,
                url: urlToCall,
                data: data
            }).then(result => {
                return resolve(result);
            }).catch((err) => {
                return reject(err);
            });
        });
    }
    
    callPostWithBearer(urlToCall, data, isJson=true) {
        var that = this;

        return new Promise((resolve, reject) => {
            that.getBearerToken().then((res) => {
                if (res.data !== "") {
                    let headersToUse = isJson ? {
                        'Authorization': 'Bearer ' + res.data,
                        'Content-Type' : 'application/json'
                    } : {
                        'Authorization': 'Bearer ' + res.data,
                    };
                    window.axios({
                        method: "post",
                        headers: headersToUse,
                        url: urlToCall,
                        data: data
                    }).then(result => {
                        return resolve(result);
                    }).catch((err) => {
                        return reject(err);
                    });
                }
                else {
                    window.location.href = "/Home/Logout";
                }
            });
        });
    }

    callPostFilesWithBearer(urlToCall, data) {
        var that = this;

        return new Promise((resolve, reject) => {
            that.getBearerToken().then((res) => {
                if (res.data !== "") {
                    window.axios({
                        method: "post",
                        headers: {
                            'Authorization': 'Bearer ' + res.data
                        },
                        url: urlToCall,
                        data: data
                    }).then(result => {
                        return resolve(result);
                    }).catch((err) => {
                        return reject(err);
                    });
                }
                else {
                    window.location.href = "/Home/Logout";
                }
            });
        });
    }
}