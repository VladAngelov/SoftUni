import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from "src/app/shared/shared.module";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { SunComponent } from "./list/sun.component";
import { SunRoutingModule } from "./sun-routing.model";
import { SunService } from "./sun.service";

@NgModule({
    declarations: [
        SunComponent,
        CreateComponent,
        EditComponent
    ],
    imports: [
        CommonModule,
        SunRoutingModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [
        SunService
    ],
    exports: [
        EditComponent,
        CreateComponent,
        SunComponent
    ]
})

export class SunModule { }
