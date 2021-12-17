import axios from "axios";
import React from 'react';
import { BASE_URL_API } from "./Store/Constants";
//import {}

const baseUrl = BASE_URL_API;

export const getData =(endPoint, callBackFunction, token)=>{
    const config = {
        headers: { Authorization: `Bearer ${token}` }
    };
    axios.get(baseUrl+endPoint, config).then((respose)=>{
        callBackFunction(respose.data);
    });
}

// with pagination
export const getPaginatedData =(endPoint, callBackFunction, page)=>{

    axios.get(baseUrl+endPoint, { params: { 'page': page }} ).then((respose)=>{
        callBackFunction(respose.data);
    });
}


export const postData =(endPoint, payload, token)=>{
    const config = {
        headers: { Authorization: `Bearer ${token}` }
    };
    return axios.post(baseUrl+endPoint, payload, config);
}
