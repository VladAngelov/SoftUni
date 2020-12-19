import { RouterModule, Routes } from "@angular/router";
import { AccessGuard } from "../core/guards/access.guard";
import { CreateComponent } from "./create/create.component";
import { EditComponent } from "./edit/edit.component";
import { ContactsComponent } from "./list/contacts.component";

const routes: Routes = [
    {
        path: 'contacts',
        canActivateChild: [
            AccessGuard
        ],
        children: [
            {
                path: 'contacts',
                pathMatch: 'full',
                component: ContactsComponent
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

export const ContactsRoutingModule = RouterModule.forChild(routes);
