import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { SchoolsComponent } from "./list/schools.component";

const routes: Routes = [
    {
        path: 'schools',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'schools',
                pathMatch: 'full',
                component: SchoolsComponent
            },
            {
                path: 'edit/:id',
                component: EditComponent,
                data: {
                    isLogged: true
                }
            },
            {
                path: 'create',
                component: CreateComponent,
                data: {
                    isLogged: true
                }
            }
        ]
    }
];

export const SchoolsRoutingModule = RouterModule.forChild(routes);
