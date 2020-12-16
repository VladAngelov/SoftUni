import { Routes, RouterModule } from '@angular/router';
import { AwardsComponent } from './about/awards/awards.component';
import { HistoryComponent } from './about/history/history.component';
import { MissionComponent } from './about/mission/mission.component';
import { PlaceComponent } from './about/place/place.component';
import { SchoolsComponent } from './about/schools/schools.component';
import { ContactsComponent } from './contacts/contacts.component';
import { GalleryComponent } from './gallery/gallery.component';
import { FirefliesComponent } from './groups/fireflies/list/fireflies.component';
import { LadybugsComponent } from './groups/ladybugs/list/ladybugs.component';
import { LionsComponent } from './groups/lions/list/lions.component';
import { MargaritasComponent } from './groups/margaritas/margaritas.component';
import { PuhComponent } from './groups/puh/puh.component';
import { StarsComponent } from './groups/stars/stars.component';
import { SunComponent } from './groups/sun/sun.component';
import { HomeComponent } from './home/home.component';
import { NewsComponent } from './news/news.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ParentsComponent } from './parents/parents.component';
import { ProjectsComponent } from './projects/list/projects.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'about/history',
    component: HistoryComponent
  },
  {
    path: 'about/list/awards',
    component: AwardsComponent
  },
  {
    path: 'about/list/mission',
    component: MissionComponent
  },
  {
    path: 'about/list/place',
    component: PlaceComponent
  },
  {
    path: 'about/list/schools',
    component: SchoolsComponent
  },
  {
    path: 'groups/list/fireflies',
    component: FirefliesComponent
  },
  {
    path: 'groups/list/ladybugs',
    component: LadybugsComponent
  },
  {
    path: 'groups/list/lions',
    component: LionsComponent
  },
  {
    path: 'groups/list/margaritas',
    component: MargaritasComponent
  },
  {
    path: 'groups/list/puh',
    component: PuhComponent
  },
  {
    path: 'groups/list/sun',
    component: SunComponent
  },
  {
    path: 'groups/list/stars',
    component: StarsComponent
  },
  {
    path: 'list/parents',
    component: ParentsComponent
  },
  {
    path: 'list/gallery',
    component: GalleryComponent
  },
  {
    path: 'list/news',
    component: NewsComponent
  },
  {
    path: 'list/projects',
    component: ProjectsComponent
  },
  {
    path: 'list/contacts',
    component: ContactsComponent
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
