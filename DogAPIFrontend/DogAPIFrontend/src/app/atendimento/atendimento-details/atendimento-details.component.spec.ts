import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AtendimentoDetailsComponent } from './atendimento-details.component';

describe('AtendimentoDetailsComponent', () => {
  let component: AtendimentoDetailsComponent;
  let fixture: ComponentFixture<AtendimentoDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AtendimentoDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AtendimentoDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
