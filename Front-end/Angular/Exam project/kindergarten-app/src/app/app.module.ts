import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AngularFireModule } from '@angular/fire';
import { AngularFirestoreModule } from '@angular/fire/firestore';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HistoryComponent } from './about/history/history.component';
import { AwardsComponent } from './about/awards/awards.component';
import { MissionComponent } from './about/mission/mission.component';
import { PlaceComponent } from './about/place/place.component';
import { SchoolsComponent } from './about/schools/schools.component';
import { FirefliesComponent } from './groups/fireflies/fireflies.component';
import { LadybugsComponent } from './groups/ladybugs/ladybugs.component';
import { LionsComponent } from './groups/lions/lions.component';
import { MargaritasComponent } from './groups/margaritas/margaritas.component';
import { PuhComponent } from './groups/puh/puh.component';
import { SunComponent } from './groups/sun/sun.component';
import { StarsComponent } from './groups/stars/stars.component';
import { ParentsComponent } from './parents/parents.component';
import { GalleryComponent } from './gallery/gallery.component';
import { NewsComponent } from './news/news.component';
import { ProjectsComponent } from './projects/projects.component';
import { ContactsComponent } from './contacts/contacts.component';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { TeachersModule } from './about/teachers/teachers.module';
import { UserService } from './user/user.service';
import { HomeService } from './home/home.service';
import { UserModule } from './user/user.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { AccessGuard } from './core/guards/access.guard';
import { PostComponent } from './home/post/post.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HistoryComponent,
    AwardsComponent,
    MissionComponent,
    PlaceComponent,
    SchoolsComponent,
    FirefliesComponent,
    LadybugsComponent,
    LionsComponent,
    MargaritasComponent,
    PuhComponent,
    SunComponent,
    StarsComponent,
    ParentsComponent,
    GalleryComponent,
    NewsComponent,
    ProjectsComponent,
    ContactsComponent,
    NotFoundComponent,
    PostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    TeachersModule,
    HttpClientModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFirestoreModule,
    UserModule
  ],
  providers: [
    AccessGuard,
    UserService,
    HomeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
