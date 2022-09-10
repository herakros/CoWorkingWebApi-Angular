import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRoleGuard } from './core/guards/admin-role-guard';
import { AuthGuard } from './core/guards/auth-guard.service';
import { AddBookingComponent } from './presentation/admin-components/add-booking/add-booking.component';
import { UserEditComponent } from './presentation/admin-components/user-edit/user-edit.component';
import { UserListComponent } from './presentation/admin-components/user-list/user-list.component';
import { HomeComponent } from './presentation/home-components/home/home.component';
import { LoginComponent } from './presentation/user-components/login/login.component';
import { RegisterComponent } from './presentation/user-components/register/register.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: "admin/users", component: UserListComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: "admin/users:id", component: UserEditComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: "admin/booking", component: AddBookingComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
