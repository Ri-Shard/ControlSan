import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InformateComponent } from './informate.component';

describe('InformateComponent', () => {
  let component: InformateComponent;
  let fixture: ComponentFixture<InformateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InformateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InformateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
