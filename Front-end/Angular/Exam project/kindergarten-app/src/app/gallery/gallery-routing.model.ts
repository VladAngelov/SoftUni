import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "../core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { GalleryComponent } from "./list/gallery.component";

const routes: Routes = [
    {
        path: 'gallery',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: GalleryComponent
            },
            // {
            //     path: 'edit/:id',
            //     component: EditComponent,
            //     data: {
            //         isLogged: true
            //     }
            // },
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

export const GalleryRoutingModule = RouterModule.forChild(routes);
