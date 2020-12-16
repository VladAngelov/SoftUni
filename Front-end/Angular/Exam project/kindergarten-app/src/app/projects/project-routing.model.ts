import { RouterModule, Routes } from '@angular/router';
import { AccessGuard } from '../core/guards/access.guard';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ProjectsComponent } from './list/projects.component';

const routes: Routes = [
    {
        path: 'projects',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: ProjectsComponent
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

export const ProjectRoutingModule = RouterModule.forChild(routes);
