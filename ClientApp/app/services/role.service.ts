import { Http } from '@angular/http';
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map"


@Injectable()
export class RoleService
{
    constructor(private http: Http) {}

    getRoles() {
        return this.http.get("http://localhost:5000/roles/all")
                .map(response =>response.json());
    }
}