import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManipuladorComponent } from './manipulador.component';

describe('ManipuladorComponent', () => {
  let component: ManipuladorComponent;
  let fixture: ComponentFixture<ManipuladorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManipuladorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManipuladorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
