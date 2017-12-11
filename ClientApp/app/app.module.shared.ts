import { UserService } from './services/user.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { Create } from './components/create/create.component';
import { Users } from './components/list/users.component';
import { Update } from './components/update/update.component';
import { RoleService } from './services/role.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        Create,
        Update,
        Users
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'users/list', pathMatch: 'full' },
            { path: 'users/list', component: Users },
            { path: 'users/create', component: Create },
            { path: 'users/update/:id', component: Update },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [UserService, RoleService]
})
export class AppModuleShared {
}
