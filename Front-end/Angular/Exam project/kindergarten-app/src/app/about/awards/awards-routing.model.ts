import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { AwardsComponent } from "./list/awards.component";

const routes: Routes = [
    {
        path: 'awards',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'awards',
                pathMatch: 'full',
                component: AwardsComponent
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

export const AwardsRoutingModule = RouterModule.forChild(routes);
