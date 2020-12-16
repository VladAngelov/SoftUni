import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { SharedModule } from "src/app/shared/shared.module";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { FirefliesRoutingModule } from "./fireflies-routing.model";
import { FirefliesService } from "./fireflies.service";
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
    providers: [
        FirefliesService
    ],
    exports: [
        EditComponent,
        CreateComponent,
        FirefliesComponent
    ]
})

export class FirefliesModule { }
