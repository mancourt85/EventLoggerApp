import { Component, OnInit } from '@angular/core';
import { LogService, EventLog } from '../../services/log.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-query-log',
  templateUrl: './logs-table-view.component.html',
  styleUrls: ['./logs-table-view.component.css'],
  imports: [CommonModule]
})
export class LogsTableViewComponent implements OnInit {
  logs: EventLog[] = [];
  filteredLogs: EventLog[] = [];
  logTypeFilter: string = ''; // Log type filter
  startDate: string = ''; // Start date for filter
  endDate: string = ''; // End date for filter

  constructor(private logService: LogService) {}

  ngOnInit(): void {
    this.logService.getLogs().subscribe({
      next: (data: EventLog[]) => {
        this.logs = data;
        this.filteredLogs = data; // Initially show all logs
      },
      error: (err: any) => console.error('Error loading logs', err),
    });
  }

  // Function to apply the filters
  applyFilters(): void {
    this.filteredLogs = this.logs.filter((log) => {
      const logDate = new Date(log.dateEvent);

      // Filter by log type if selected
      const typeMatch = this.logTypeFilter ? log.logType === this.logTypeFilter : true;

      // Filter by date range if both dates are selected
      const startDateMatch = this.startDate ? logDate >= new Date(this.startDate) : true;
      const endDateMatch = this.endDate ? logDate <= new Date(this.endDate) : true;

      return typeMatch && startDateMatch && endDateMatch;
    });
  }
}
