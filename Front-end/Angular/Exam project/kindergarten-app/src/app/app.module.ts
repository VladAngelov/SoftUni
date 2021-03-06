import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AngularFireModule } from '@angular/fire';
import { AngularFirestoreModule } from '@angular/fire/firestore';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GalleryComponent } from './gallery/list/gallery.component';
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
import { ParentsService } from './parents/parents.service';
import { ParentsModule } from './parents/parents.module';
import { NewsModule } from './news/news.module';
import { NewsService } from './news/news.service';
import { TeachersService } from './about/teachers/teachers.service';
import { AwardsModule } from './about/awards/awards.module';
import { HistoryModule } from './about/history/history.module';
import { MissionModule } from './about/mission/mission.module';
import { SchoolsModule } from './about/schools/schools.module';
import { PlaceModule } from './about/place/place.module';
import { ContactsModule } from './contacts/contacts.module';
import { GalleryModule } from './gallery/gallery.module';

@NgModule({
  declarations: [
    AppComponent,
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
    SunModule,
    ParentsModule,
    NewsModule,
    TeachersModule,
    AwardsModule,
    HistoryModule,
    MissionModule,
    SchoolsModule,
    PlaceModule,
    ContactsModule,
    GalleryModule
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
    SunService,
    ParentsService,
    NewsService,
    TeachersService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
