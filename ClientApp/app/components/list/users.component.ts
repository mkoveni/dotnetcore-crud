import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { UserService } from '../../services/user.service';
import {Router} from '@angular/router'

@Component({
    selector: 'users',
    templateUrl: './users.component.html'
})
export class Users {
    users:User[] = [];
    constructor(private userService:UserService,  private router: Router) {
        
        this.userService.getUsers()
                        .subscribe(users => {
                            this.users = users
        });
    }

    delete(user: any) {

        if(confirm('Are you sure about deleting '+ user.name+'?'))
        {
            console.log('deleted')
            this.userService.deleteUser(user.id)
                .subscribe(id => {
                    console.log(id)
                
                
                    this.users = this.users.filter(u => u.id !== id);
                })

        }
    }

}

export interface User
{
    id: number;
    name:string;
    email: string;
    password: string;
    roleId: number;
    role: Role;
}

export interface Role
{
    id:number;
    name: string;
}

