import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map"
import { User } from "../components/list/users.component";

@Injectable()
export class UserService
{
    constructor(private http: Http){}

    getUsers() {
        
        return this.http.get("http://localhost:5000/users/all")
                .map(response => response.json());
    }

    createUser(user:User) {

        return this.http.post('http://localhost:5000/users/create', user)
            .map(response => response.json());
    } 
}