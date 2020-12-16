import { RouterModule, Routes } from '@angular/router';
import { AccessGuard } from '../../core/guards/access.guard';

import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { FirefliesComponent } from './list/fireflies.component';

const routes: Routes = [
    {
        path: 'fireflies',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'fireflies',
                pathMatch: 'full',
                component: FirefliesComponent
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

export const FirefliesRoutingModule = RouterModule.forChild(routes);
