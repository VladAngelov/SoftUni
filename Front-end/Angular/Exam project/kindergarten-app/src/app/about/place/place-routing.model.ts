import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { PlaceComponent } from "./list/place.component";

const routes: Routes = [
    {
        path: 'place',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'place',
                pathMatch: 'full',
                component: PlaceComponent
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

export const PlaceRoutingModule = RouterModule.forChild(routes);
