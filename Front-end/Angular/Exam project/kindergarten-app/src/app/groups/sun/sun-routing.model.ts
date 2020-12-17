import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { SunComponent } from "./list/sun.component";

const routes: Routes = [
    {
        path: 'sun',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'sun',
                pathMatch: 'full',
                component: SunComponent
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

export const SunRoutingModule = RouterModule.forChild(routes);
