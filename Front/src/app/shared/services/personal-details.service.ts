import { Injectable } from "@angular/core";

@Injectable()
export class PersonalDetailsService {

    constructor() { }

    public set companyName(companyName : string) {
        localStorage.setItem("companyName", companyName);
    }
    
    public set companyNumber(companyNumber : string) {
        localStorage.setItem("companyNumber", companyNumber);
    }
    
    public get userId() : string {
        return localStorage.getItem("id");
    }

    public get companyName() : string {
        return localStorage.getItem("companyName");
    }
    
    public get companyNumber() : string {
        return localStorage.getItem("companyNumber");
    }
}