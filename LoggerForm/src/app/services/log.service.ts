import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface EventLog {
  content: string;
  logType: string;
  dateEvent: Date;
}

@Injectable({
  providedIn: 'root'
})
export class LogService {
  private apiUrl = 'https://localhost:7030/api/EventLogger';

  constructor(private http: HttpClient) { }

  createLog(log: EventLog): Observable<EventLog> {
    return this.http.post<EventLog>(this.apiUrl, log);
  }

  getLogs(): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(this.apiUrl);
  }

}
