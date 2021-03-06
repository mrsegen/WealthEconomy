﻿import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";

// Components
import { AccountEditComponent } from "./account-edit.component";
import { AccountOverviewComponent } from "./account-overview.component";
import { AddPasswordComponent } from "./add-password.component";
import { ChangeEmailComponent } from "./change-email.component";
import { ChangePasswordComponent } from "./change-password.component";
import { ChangeUserNameComponent } from "./change-username.component";
import { ConfirmEmailComponent } from "./confirm-email.component";
import { LoginComponent } from "./login.component";
import { RegisterComponent } from "./register.component";
import { ResetPasswordComponent } from "./reset-password.component";
import { SocialLoginsComponent } from "./social-logins.component";

// Services
import { AuthGuard } from "../core/core.module";
import { CanDeactivateGuard } from "../core/core.module";

// Routes
export const accountRoutes: Routes = [
    { path: "app/account", component: AccountOverviewComponent, canActivate: [AuthGuard], data: { title: "Account Overview" } },
    { path: "app/account/account-edit", component: AccountEditComponent, canActivate: [AuthGuard], canDeactivate: [CanDeactivateGuard], data: { title: "Account Edit" } },
    { path: "app/account/add-password", component: AddPasswordComponent, canActivate: [AuthGuard], canDeactivate: [CanDeactivateGuard], data: { title: "Add Password" } },
    { path: "app/account/change-email", component: ChangeEmailComponent, canActivate: [AuthGuard], canDeactivate: [CanDeactivateGuard], data: { title: "Change Email" } },
    { path: "app/account/change-password", component: ChangePasswordComponent, canActivate: [AuthGuard], canDeactivate: [CanDeactivateGuard], data: { title: "Change Password" } },
    { path: "app/account/change-username", component: ChangeUserNameComponent, canActivate: [AuthGuard], canDeactivate: [CanDeactivateGuard], data: { title: "Change Username" } },
    { path: "app/account/confirm-email", component: ConfirmEmailComponent, canActivate: [AuthGuard], data: { title: "Confirm Email" } },
    { path: "app/account/login", component: LoginComponent, data: { title: "Login" } },
    { path: "app/account/register", component: RegisterComponent, data: { title: "Register" } },
    { path: "app/account/reset-password", component: ResetPasswordComponent, canDeactivate: [CanDeactivateGuard], data: { title: "Reset Password" } },
];

@NgModule({
    declarations: [
        AccountEditComponent,
        AccountOverviewComponent,
        AddPasswordComponent,
        ChangeEmailComponent,
        ChangePasswordComponent,
        ChangeUserNameComponent,
        ConfirmEmailComponent,
        LoginComponent,
        RegisterComponent,
        ResetPasswordComponent,
        SocialLoginsComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule
    ]
})
export class AccountModule { }
