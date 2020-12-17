import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { SharedModule } from "../shared/shared.module";
import { ParentsComponent } from "./list/parents.component";
import { ParentsRoutingModule } from "./parents-routing.model";
import { ParentsService } from "./parents.service";

@NgModule({
    declarations: [
        ParentsComponent,
        CreateComponent,
        EditComponent
    ],
    imports: [
        CommonModule,
        ParentsRoutingModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [
        ParentsService
    ],
    exports: [
        EditComponent,
        CreateComponent,
        ParentsComponent
    ]
})

export class ParentsModule { }
