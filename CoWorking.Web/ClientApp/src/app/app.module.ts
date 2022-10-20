import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpHeaders} from '@angular/common/http';
import { LoginComponent } from './presentation/user-components/login/login.component';
import { RegisterComponent } from './presentation/user-components/register/register.component';
import { HomeComponent } from './presentation/home-components/home/home.component';
import { FooterComponent } from './presentation/home-components/footer/footer.component';
import { HeaderComponent } from './presentation/home-components/header/header.component';
import { AuthInterceptorProvider } from './core/interceptors/auth.interceptor';
import { ErrorInterceptorProvider } from './core/interceptors/error.interceptor';
import { AuthenticationService } from './core/services/Authentication.service';
import { AddBookingComponent } from './presentation/admin-components/add-booking/add-booking.component';
import { UserListComponent } from './presentation/admin-components/user-list/user-list.component';
import { UserEditComponent } from './presentation/admin-components/user-edit/user-edit.component';
import { AdminService } from './core/services/Admin.service';
import { AdminRoleGuard } from './core/guards/admin-role-guard';
import { AuthGuard } from './core/guards/auth-guard.service';
import { AdminBookingListComponent } from './presentation/admin-components/admin-booking-list/admin-booking-list.component';
import { EditBookingComponent } from './presentation/admin-components/edit-booking/edit-booking.component';
import { BookingListComponent } from './presentation/booking-components/booking-list/booking-list.component';
import { UserRoleGuard } from './core/guards/user-role-guard';
import { BookingViewComponent } from './presentation/booking-components/booking-view/booking-view.component';
import { CommentService } from './core/services/Comment.service';
import { SubscribeUserModalComponent } from './presentation/booking-components/SubscribeUserModal/SubscribeUserModal.component';
import { HomeService } from './core/services/Home.service';
import { ManagerService } from './core/services/Manager.service';
import { DeveloperService } from './core/services/Developer.service';
import { ChangeBookingModalComponent } from './presentation/booking-components/ChangeBookingModal/ChangeBookingModal.component';
import { EventEmitterService } from './core/services/EventEmitter.service';
import { JwtModule } from '@auth0/angular-jwt';
import { UserProfileComponent } from './presentation/user-profile-components/user-profile/user-profile.component';
import { UserService } from './core/services/User.service';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    FooterComponent,
    HeaderComponent,
    AddBookingComponent,
    UserListComponent,
    UserEditComponent,
    AdminBookingListComponent,
    EditBookingComponent,
    BookingListComponent,
    BookingViewComponent,
    SubscribeUserModalComponent,
    ChangeBookingModalComponent,
    UserProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,

    JwtModule.forRoot({
      config: {
        tokenGetter
      }
    })
  ],
  providers: [
    AuthInterceptorProvider,
    ErrorInterceptorProvider,
    AuthenticationService,
    AdminService,
    CommentService,
    HomeService,
    ManagerService,
    DeveloperService,
    UserService,
    EventEmitterService,
    AdminRoleGuard,
    UserRoleGuard,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
