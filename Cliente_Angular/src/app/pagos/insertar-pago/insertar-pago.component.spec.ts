import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertarPagoComponent } from './insertar-pago.component';

describe('InsertarPagoComponent', () => {
  let component: InsertarPagoComponent;
  let fixture: ComponentFixture<InsertarPagoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsertarPagoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsertarPagoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
