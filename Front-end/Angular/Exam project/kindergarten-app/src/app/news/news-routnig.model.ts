import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "../core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { NewsComponent } from "./list/news.component";

const routes: Routes = [
    {
        path: 'news',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'news',
                pathMatch: 'full',
                component: NewsComponent
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

export const NewsRoutingModule = RouterModule.forChild(routes);
