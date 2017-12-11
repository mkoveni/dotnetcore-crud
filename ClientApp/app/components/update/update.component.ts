import { RoleService } from './../../services/role.service';
import { User, Role } from './../list/users.component';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { ActivatedRoute, Router, Params } from '@angular/router/';

@Component({
    selector: 'update',
    templateUrl: './update.component.html'
})
export class Update {

    user: User;
    roles: Role[] =[];
    constructor(private userService: UserService, private route:ActivatedRoute, private roleService: RoleService, private router: Router) {}

    ngOnInit() {

        this.roleService.getRoles().subscribe(roles => this.roles = roles);

        this.route.params.subscribe((params: Params) => {
            
            this.userService.findUserById(params['id'])
                .subscribe(user => this.user = user);
        });

    
    }

    update() {

        
        this.userService.updateUser(this.user)
            .subscribe(user => {
                
                this.router.navigateByUrl('/users/list')
            })
    }

}
