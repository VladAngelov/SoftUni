import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from "src/app/shared/shared.module";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { LadybugsRoutingModule } from "./ladybugs-routing.model";
import { LadybugsService } from "./ladybugs.service";
import { LadybugsComponent } from "./list/ladybugs.component";


@NgModule({
    declarations: [
        LadybugsComponent,
        CreateComponent,
        EditComponent
    ],
    imports: [
        CommonModule,
        LadybugsRoutingModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [
        LadybugsService
    ],
    exports: [
        EditComponent,
        CreateComponent,
        LadybugsComponent
    ]
})

export class LadybugsModule { }
