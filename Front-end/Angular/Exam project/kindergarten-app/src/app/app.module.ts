import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AngularFireModule } from '@angular/fire';
import { AngularFirestoreModule } from '@angular/fire/firestore';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HistoryComponent } from './about/history/history.component';
import { AwardsComponent } from './about/awards/awards.component';
import { MissionComponent } from './about/mission/mission.component';
import { PlaceComponent } from './about/place/place.component';
import { SchoolsComponent } from './about/schools/schools.component';
import { ParentsComponent } from './parents/parents.component';
import { GalleryComponent } from './gallery/gallery.component';
import { NewsComponent } from './news/news.component';
import { ContactsComponent } from './contacts/contacts.component';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { TeachersModule } from './about/teachers/teachers.module';
import { UserService } from './user/user.service';
import { HomeService } from './home/home.service';
import { UserModule } from './user/user.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { AccessGuard } from './core/guards/access.guard';
import { HomeModule } from './home/home.module';
import { ProjectService } from './projects/project.service';
import { ProjectModule } from './projects/project.module';
import { FirefliesModule } from './groups/fireflies/fireflies.module';
import { FirefliesService } from './groups/fireflies/fireflies.service';
import { LadybugsService } from './groups/ladybugs/ladybugs.service';
import { LadybugsModule } from './groups/ladybugs/ladybugs.module';
import { LionsModule } from './groups/lions/lions.module';
import { LionsService } from './groups/lions/lions.service';
import { MargaritasModule } from './groups/margaritas/margaritas.module';
import { MargaritasService } from './groups/margaritas/margaritas.service';
import { PuhModule } from './groups/puh/puh.module';
import { PuhService } from './groups/puh/puh.service';
import { StarsModule } from './groups/stars/stars.module';
import { StarsService } from './groups/stars/stars.service';
import { SunModule } from './groups/sun/sun.module';
import { SunService } from './groups/sun/sun.service';

@NgModule({
  declarations: [
    AppComponent,
    HistoryComponent,
    AwardsComponent,
    MissionComponent,
    PlaceComponent,
    SchoolsComponent,
    ParentsComponent,
    GalleryComponent,
    NewsComponent,
    ContactsComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    TeachersModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFirestoreModule,
    HttpClientModule,
    UserModule,
    HomeModule,
    ProjectModule,
    FirefliesModule,
    LadybugsModule,
    LionsModule,
    MargaritasModule,
    PuhModule,
    StarsModule,
    SunModule
  ],
  providers: [
    AccessGuard,
    UserService,
    HomeService,
    ProjectService,
    FirefliesService,
    LadybugsService,
    LionsService,
    MargaritasService,
    PuhService,
    StarsService,
    SunService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
