import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailComponent } from './detail/detail.component';
import { AccessGuard } from 'src/app/core/guards/access.guard';
import { EditComponent } from './edit/edit.component';
import { CreateComponent } from './create/create.component';

const routes: Routes = [
  {
    path: 'teachers',
    canActivateChild: [
      AccessGuard
    ],
    children: [
      {
        path: 'teachers',
        pathMatch: 'full',
        component: ListComponent
      },
      {
        path: 'detail/:id',
        component: DetailComponent
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

export const TeachersRoutingModule = RouterModule.forChild(routes);
