import { RouterModule, Routes } from '@angular/router';
import { AccessGuard } from '../core/guards/access.guard';

import { HomeComponent } from './home.component';
import { CreateComponent } from './post/create/create.component';
import { EditComponent } from './post/edit/edit.component';

const routes: Routes = [
    {
        path: 'home',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: HomeComponent
            },
            {
                path: 'edit/:id',
                component: EditComponent,
                data: {
                    isLogged: true
                }
            },
            {
                path: 'create',
                component: CreateComponent,
                data: {
                    isLogged: true
                }
            }
        ]
    }
];

export const HomeRoutingModule = RouterModule.forChild(routes);
