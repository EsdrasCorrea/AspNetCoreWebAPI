import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessorAlunosComponent } from './professor-alunos.component';

describe('ProfessorAlunosComponent', () => {
  let component: ProfessorAlunosComponent;
  let fixture: ComponentFixture<ProfessorAlunosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfessorAlunosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessorAlunosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
