import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserstructComponent } from './userstruct.component';

describe('UserstructComponent', () => {
  let component: UserstructComponent;
  let fixture: ComponentFixture<UserstructComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserstructComponent]
    });
    fixture = TestBed.createComponent(UserstructComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
