import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AtendimentoCreateComponent } from './atendimento-create.component';

describe('AtendimentoCreateComponent', () => {
  let component: AtendimentoCreateComponent;
  let fixture: ComponentFixture<AtendimentoCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AtendimentoCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AtendimentoCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
