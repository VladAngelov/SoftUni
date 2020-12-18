import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { MissionComponent } from "./list/mission.component";

const routes: Routes = [
    {
        path: 'mission',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'mission',
                pathMatch: 'full',
                component: MissionComponent
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

export const MissionRoutingModule = RouterModule.forChild(routes);
