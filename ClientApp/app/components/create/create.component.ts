import { User, Role } from './../list/users.component';
import { UserService } from './../../services/user.service';
import { RoleService } from './../../services/role.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'create',
    templateUrl: './create.component.html'
})
export class Create {
    
    roles:Role[] = []

    name:string;
    email:string;
    password:string;
    roleId: any;

    constructor(private roleService: RoleService, private userService:UserService, private router: Router){}

    ngOnInit() {
        this.roleService.getRoles()
            .subscribe(roles => this.roles = roles);
    
    }

    save() {

        let roleId = parseInt(this.roleId)
        let user: User = {
            id: 0,
            name: this.name,
            email: this.email,
            password: this.password,
            roleId: roleId,
            role: {
                id: roleId,
                name: ''
            }
        };
        
        this.userService.createUser(user)
            .subscribe(user => {
                console.log(user);

                this.router.navigateByUrl('/users/list');
            }, error => console.log(error));
        
    }
}
