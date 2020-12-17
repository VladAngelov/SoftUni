import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "../core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { ParentsComponent } from "./list/parents.component";

const routes: Routes = [
    {
        path: 'parents',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'parents',
                pathMatch: 'full',
                component: ParentsComponent
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

export const ParentsRoutingModule = RouterModule.forChild(routes);
