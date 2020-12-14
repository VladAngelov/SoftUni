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
                component: HomeComponent,
                data: {
                    title: 'Начало'
                }
            },
            {
                path: 'edit/:id',
                component: EditComponent,
                data: {
                    isLogged: true,
                    title: 'Редакция на пост'
                }
            },
            {
                path: 'create',
                component: CreateComponent,
                data: {
                    isLogged: true,
                    title: 'Добави пост'
                }
            }
        ]
    }
];

export const HomeRoutingModule = RouterModule.forChild(routes);
