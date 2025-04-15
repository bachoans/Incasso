import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClosedFilesComponent } from './closed-files.component';

describe('ClosedFilesComponent', () => {
  let component: ClosedFilesComponent;
  let fixture: ComponentFixture<ClosedFilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClosedFilesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClosedFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
