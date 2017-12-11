import { User } from './../components/list/users.component';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map"

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

    updateUser(user:any) {
        console.log(user.id);
        return this.http.put('http://localhost:5000/users/' + user.id, user)
                .map(response => response.json());
    }

    findUserById(id: number) {

        return this.http.get('http://localhost:5000/users/'+id)
                .map(response => response.json())
    }
}