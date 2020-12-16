import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "src/app/core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { LadybugsComponent } from "./list/ladybugs.component";

const routes: Routes = [
    {
        path: 'ladybugs',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'ladybugs',
                pathMatch: 'full',
                component: LadybugsComponent
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

export const LadybugsRoutingModule = RouterModule.forChild(routes);
