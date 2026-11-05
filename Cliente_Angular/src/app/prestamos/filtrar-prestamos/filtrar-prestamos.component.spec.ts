import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltrarPrestamosComponent } from './filtrar-prestamos.component';

describe('FiltrarPrestamosComponent', () => {
  let component: FiltrarPrestamosComponent;
  let fixture: ComponentFixture<FiltrarPrestamosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FiltrarPrestamosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FiltrarPrestamosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
