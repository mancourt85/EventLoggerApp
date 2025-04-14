import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogsTableViewComponent } from './logs-table-view/logs-table-view.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LogsTableViewComponent,
    RouterModule
  ]
})
export class LoggerOutputsModule { }
