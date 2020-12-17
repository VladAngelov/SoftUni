import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { PuhComponent } from "./list/puh.component";

const routes: Routes = [
    {
        path: 'puh',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'puh',
                pathMatch: 'full',
                component: PuhComponent
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

export const PuhRoutingModule = RouterModule.forChild(routes);
