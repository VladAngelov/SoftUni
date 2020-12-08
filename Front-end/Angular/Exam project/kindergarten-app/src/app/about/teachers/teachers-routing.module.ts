import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailComponent } from './detail/detail.component';

const routes: Routes = [
  {
    path: 'about/teachers',
    component: ListComponent
  },
  {
    path: 'about/teachers/detail/:id',
    component: DetailComponent
  }
];

export const TeachersRoutingModule = RouterModule.forChild(routes);
