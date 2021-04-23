import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {
    path: 'dashboard',
    component: HomeComponent
  }
  // ,{
  //   path: '',
  //   pathMatch: 'full',
  //   redirectTo: 'dashboard'
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
