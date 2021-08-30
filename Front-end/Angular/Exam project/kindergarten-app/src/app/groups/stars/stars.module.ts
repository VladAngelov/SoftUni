import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import {
    FormsModule,
    ReactiveFormsModule
} from "@angular/forms";
import { SharedModule } from "src/app/shared/shared.module";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { StarsComponent } from "./list/stars.component";
import { StarsRoutingModule } from "./stars-routing.model";

@NgModule({
    declarations: [
        StarsComponent,
        CreateComponent,
        EditComponent
    ],
    imports: [
        CommonModule,
        StarsRoutingModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [
        EditComponent,
        CreateComponent,
        StarsComponent
    ]
})

export class StarsModule { }
