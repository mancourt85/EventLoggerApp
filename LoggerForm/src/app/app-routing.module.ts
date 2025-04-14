import { LoggerInputsModule } from './logger-inputs/logger-inputs.module';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './home/homepage/homepage.component';
import { LogFormComponent } from './logger-inputs/log-form/log-form.component';
import { HomeModule } from './home/home.module';
import { LoggerOutputsModule } from './logger-outputs/logger-outputs.module';
import { LogsTableViewComponent } from './logger-outputs/logs-table-view/logs-table-view.component';

const routes: Routes = [
  { path: '', component: HomepageComponent },  // Home page
  { path: 'add-log', component: LogFormComponent },  // Add log form
  { path: 'view-logs', component: LogsTableViewComponent },  // View logs page
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
    HomeModule,
    LoggerOutputsModule,
    LogsTableViewComponent
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
