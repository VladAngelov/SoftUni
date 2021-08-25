import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import {
    FormsModule,
    ReactiveFormsModule
} from "@angular/forms";

import { SharedModule } from "src/app/shared/shared.module";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { FirefliesRoutingModule } from "./fireflies-routing.model";
import { FirefliesComponent } from "./list/fireflies.component";

@NgModule({
    declarations: [
        FirefliesComponent,
        CreateComponent,
        EditComponent
    ],
    imports: [
        CommonModule,
        FirefliesRoutingModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [
        EditComponent,
        CreateComponent,
        FirefliesComponent
    ]
})

export class FirefliesModule { }
