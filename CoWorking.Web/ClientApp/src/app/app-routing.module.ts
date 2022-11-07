import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRoleGuard } from './core/guards/admin-role-guard';
import { AuthGuard } from './core/guards/auth-guard.service';
import { UserRoleGuard } from './core/guards/user-role-guard';
import { AddBookingComponent } from './presentation/admin-components/add-booking/add-booking.component';
import { AdminBookingListComponent } from './presentation/admin-components/admin-booking-list/admin-booking-list.component';
import { EditBookingComponent } from './presentation/admin-components/edit-booking/edit-booking.component';
import { UserEditComponent } from './presentation/admin-components/user-edit/user-edit.component';
import { UserListComponent } from './presentation/admin-components/user-list/user-list.component';
import { BookingListComponent } from './presentation/booking-components/booking-list/booking-list.component';
import { BookingViewComponent } from './presentation/booking-components/booking-view/booking-view.component';
import { HomeComponent } from './presentation/home-components/home/home.component';
import { LoginComponent } from './presentation/user-components/login/login.component';
import { RegisterComponent } from './presentation/user-components/register/register.component';
import { ChangePasswordComponent } from './presentation/user-profile-components/change-password/change-password.component';
import { UserProfileComponent } from './presentation/user-profile-components/user-profile/user-profile.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: "admin/users", component: UserListComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: "admin/users/:id", component: UserEditComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: "admin/bookings", component: AdminBookingListComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: "admin/bookings/:id", component: EditBookingComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: "admin/booking", component: AddBookingComponent, canActivate: [AdminRoleGuard, AuthGuard]},
  {path: "home/bookings", component: BookingListComponent, canActivate: [UserRoleGuard, AuthGuard]},
  {path: "home/bookings/:id", component: BookingViewComponent, canActivate: [UserRoleGuard, AuthGuard]},
  {path: "user-profile", component: UserProfileComponent, canActivate: [UserRoleGuard, AuthGuard]},
  {path: "user-profile/password", component: ChangePasswordComponent, canActivate: [UserRoleGuard, AuthGuard]},
  {path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
