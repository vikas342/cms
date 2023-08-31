import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminstructComponent } from './adminstruct.component';

describe('AdminstructComponent', () => {
  let component: AdminstructComponent;
  let fixture: ComponentFixture<AdminstructComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminstructComponent]
    });
    fixture = TestBed.createComponent(AdminstructComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
