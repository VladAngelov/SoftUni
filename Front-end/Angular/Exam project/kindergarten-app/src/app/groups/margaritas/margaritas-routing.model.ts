import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { MargaritasComponent } from "./list/margaritas.component";

const routes: Routes = [
    {
        path: 'margaritas',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'margaritas',
                pathMatch: 'full',
                component: MargaritasComponent
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

export const MargaritasRoutingModule = RouterModule.forChild(routes);
