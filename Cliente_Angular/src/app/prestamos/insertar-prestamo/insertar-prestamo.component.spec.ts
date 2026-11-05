import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertarPrestamoComponent } from './insertar-prestamo.component';

describe('InsertarPrestamoComponent', () => {
  let component: InsertarPrestamoComponent;
  let fixture: ComponentFixture<InsertarPrestamoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsertarPrestamoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsertarPrestamoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
