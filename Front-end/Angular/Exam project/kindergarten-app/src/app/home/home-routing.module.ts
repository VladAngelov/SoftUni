import { RouterModule, Routes } from '@angular/router';
import { AccessGuard } from '../core/guards/access.guard';
import { CreateComponent } from './post/create/create.component';
import { PostComponent } from './post/post.component';

const routes: Routes = [
    {
        path: 'home',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                // path: 'post/:id',
                // component: PostComponent,
                // data: {
                //     isLogged: true
                // }
            },
            {
                path: 'post/create',
                component: CreateComponent,
                data: {
                    isLogged: true
                }
            }
        ]
    }
];

export const HomeRoutingModule = RouterModule.forChild(routes);
