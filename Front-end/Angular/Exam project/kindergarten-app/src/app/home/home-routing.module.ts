import { RouterModule, Routes } from '@angular/router';
import { AccessGuard } from '../core/guards/access.guard';
import { PostComponent } from './post/post.component';

const routes: Routes = [
    {
        path: 'home',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'home/psot/:id',
                component: PostComponent,
                data: {
                    isLogged: true
                }
            }
        ]
    }
];

export const HomeRoutingModule = RouterModule.forChild(routes);
