import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { StarsComponent } from "./list/stars.component";

const routes: Routes = [
    {
        path: 'stars',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'stars',
                pathMatch: 'full',
                component: StarsComponent
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

export const StarsRoutingModule = RouterModule.forChild(routes);
