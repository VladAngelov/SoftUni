import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { LionsComponent } from "./list/lions.component";

const routes: Routes = [
    {
        path: 'lions',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'lions',
                pathMatch: 'full',
                component: LionsComponent
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

export const LionsRoutingModule = RouterModule.forChild(routes);
