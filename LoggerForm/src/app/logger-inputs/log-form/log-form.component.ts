import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EventLog, LogService } from '../../services/log.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-log-form',
  templateUrl: './log-form.component.html',
  styleUrls: ['./log-form.component.css'],
  imports: [ReactiveFormsModule, CommonModule]
})
export class LogFormComponent {
  logForm: FormGroup;
  submitted = false;
  success = false;
  logs: EventLog[] = [];
  date: string; // Hold the manual date input value

  constructor(private fb: FormBuilder, private logService: LogService) {
    this.logForm = this.fb.group({
      message: ['', Validators.required], // Message input
      level: ['Info', Validators.required], // Level selection
      dateEvent: ['', [Validators.required, Validators.pattern(/^(\d{4})-(\d{2})-(\d{2})$/)]] // Date input with regex pattern
    });

    this.date = ''; // Initially empty, to hold manual input
  }

  // Getter for easy access to form controls
  get f() {
    return this.logForm.controls;
  }

  // Submit handler
  onSubmit() {
    this.submitted = true;

    // If the form is invalid, return
    if (this.logForm.invalid) return;

    const log: EventLog = {
      content: this.logForm.value.message,
      logType: this.logForm.value.level,
      dateEvent: new Date(this.logForm.value.dateEvent), // Convert string to Date
    };

    console.log(log);

    // Call the service to save the log
    this.logService.createLog(log).subscribe({
      next: () => {
        this.success = true;
        this.logs.unshift(log); // Add new log to the list
        this.logForm.reset({ level: 'Info' }); // Reset form with default values
      },
      error: (err: any) => console.error('Error submitting log', err),
    });
  }
}
