import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarClientesConPrestamoComponent } from './listar-clientes-con-prestamo.component';

describe('ListarClientesConPrestamoComponent', () => {
  let component: ListarClientesConPrestamoComponent;
  let fixture: ComponentFixture<ListarClientesConPrestamoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListarClientesConPrestamoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarClientesConPrestamoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
