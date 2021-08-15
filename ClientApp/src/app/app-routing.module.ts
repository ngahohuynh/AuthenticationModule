import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { LoginPageComponent } from './modules/auth/pages/login-page/login-page.component';
import { RegisterPageComponent } from './modules/auth/pages/register-page/register-page.component';
import { HomePageComponent } from './modules/home/home-page/home-page.component';

const routes: Routes = [
  {
    path: 'home',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    component: HomePageComponent,
  },
  {
    path: 'login',
    component: LoginPageComponent,
  },
  {
    path: 'register',
    component: RegisterPageComponent,
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
