import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VeterinarioDetailsComponent } from './veterinario-details.component';

describe('VeterinarioDetailsComponent', () => {
  let component: VeterinarioDetailsComponent;
  let fixture: ComponentFixture<VeterinarioDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VeterinarioDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VeterinarioDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
