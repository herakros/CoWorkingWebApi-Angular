import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
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
    UserEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthInterceptorProvider,
    ErrorInterceptorProvider,
    AuthenticationService,
    AdminService,
    AdminRoleGuard,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
