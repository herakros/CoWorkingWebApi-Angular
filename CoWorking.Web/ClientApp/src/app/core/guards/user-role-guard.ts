import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthenticationService } from "../services/Authentication.service";

@Injectable({
    providedIn: 'root'
  })
export class UserRoleGuard implements CanActivate{

    constructor(private authenticationService: AuthenticationService,
        private router: Router) { }

    canActivate(): boolean {
        if(this.authenticationService.currentUser.role == "Manager" || "Developer")
        {
            return true;
        }

        this.router.navigate(['login']);
        return false;
    }
}
