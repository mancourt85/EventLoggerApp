import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogsTableViewComponent } from './logs-table-view.component';

describe('LogsTableViewComponent', () => {
  let component: LogsTableViewComponent;
  let fixture: ComponentFixture<LogsTableViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LogsTableViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LogsTableViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
