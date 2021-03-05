import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnAssignUserComponent } from './un-assign-user.component';

describe('UnAssignUserComponent', () => {
  let component: UnAssignUserComponent;
  let fixture: ComponentFixture<UnAssignUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnAssignUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UnAssignUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
