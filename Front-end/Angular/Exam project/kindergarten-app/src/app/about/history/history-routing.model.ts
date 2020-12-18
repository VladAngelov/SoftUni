import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { HistoryComponent } from "./list/history.component";

const routes: Routes = [
    {
        path: 'history',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'history',
                pathMatch: 'full',
                component: HistoryComponent
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

export const HistoryRoutingModule = RouterModule.forChild(routes);
