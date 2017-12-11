import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { UserService } from '../../services/user.service';

@Component({
    selector: 'users',
    templateUrl: './users.component.html'
})
export class Users {
    users:User[] = [];
    constructor(private userService:UserService) {
        
        this.userService.getUsers()
                        .subscribe(users => {
                            this.users = users
        });
    }


}

export interface User
{
    Id: number;
    Name:string;
    Email: string;
    Password: string;
    RoleId: number;
    Role: Role;
}

export interface Role
{
    Id:number;
    Name: string;
}

