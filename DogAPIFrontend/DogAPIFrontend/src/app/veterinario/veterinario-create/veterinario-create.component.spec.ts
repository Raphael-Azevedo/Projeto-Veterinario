import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VeterinarioCreateComponent } from './veterinario-create.component';

describe('VeterinarioCreateComponent', () => {
  let component: VeterinarioCreateComponent;
  let fixture: ComponentFixture<VeterinarioCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VeterinarioCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VeterinarioCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
